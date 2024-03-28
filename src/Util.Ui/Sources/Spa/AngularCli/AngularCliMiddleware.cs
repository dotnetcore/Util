// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Util.Ui.Razor;
using Util.Ui.Sources.Spa.Npm;
using Util.Ui.Sources.Spa.Proxying;
using Util.Ui.Sources.Spa.Util;

namespace Util.Ui.Sources.Spa.AngularCli;

internal static class AngularCliMiddleware {
    private const string LogCategoryName = "Microsoft.AspNetCore.SpaServices";
    private static readonly TimeSpan RegexMatchTimeout = TimeSpan.FromSeconds( 5 ); // This is a development-time only feature, so a very long timeout is fine

    public static void Attach(
        ISpaBuilder spaBuilder,
        string scriptName ) {
        var pkgManagerCommand = spaBuilder.Options.PackageManagerCommand;
        var sourcePath = spaBuilder.Options.SourcePath;
        var devServerPort = spaBuilder.Options.DevServerPort;
        if ( string.IsNullOrEmpty( sourcePath ) ) {
            throw new ArgumentException( "Property 'SourcePath' cannot be null or empty", nameof( spaBuilder ) );
        }

        if ( string.IsNullOrEmpty( scriptName ) ) {
            throw new ArgumentException( "Cannot be null or empty", nameof( scriptName ) );
        }

        if ( devServerPort == default ) {
            devServerPort = TcpPortFinder.FindAvailablePort();
        }

        // Start Angular CLI and attach to middleware pipeline
        var appBuilder = spaBuilder.ApplicationBuilder;
        var applicationStoppingToken = appBuilder.ApplicationServices.GetRequiredService<IHostApplicationLifetime>().ApplicationStopping;
        var logger = LoggerFinder.GetOrCreateLogger( appBuilder, LogCategoryName );
        var diagnosticSource = appBuilder.ApplicationServices.GetRequiredService<DiagnosticSource>();
        var angularCliServerInfoTask = GetUrl( devServerPort, applicationStoppingToken );
        spaBuilder.UseProxyToSpaDevelopmentServer( () => {
            var timeout = spaBuilder.Options.StartupTimeout;
            return angularCliServerInfoTask.WithTimeout( timeout,
                $"The Angular CLI process did not start listening for requests " +
                $"within the timeout period of {timeout.TotalSeconds} seconds. " +
                $"Check the log output for error information." );
        } );
        Task.Factory.StartNew( async () => {
            while ( true ) {
                if ( RazorWatchService.IsStartComplete == false ) {
                    await Task.Delay( 500, applicationStoppingToken );
                    continue;
                }
                await StartAngularCliServerAsync( sourcePath, scriptName, pkgManagerCommand, devServerPort, logger, diagnosticSource, applicationStoppingToken );
                return;
            }
        }, applicationStoppingToken );
    }

    private static async Task<Uri> GetUrl( int portNumber, CancellationToken applicationStoppingToken ) {
        var uri = new Uri( $"http://localhost:{portNumber}" );
        await WaitForAngularCliServerToAcceptRequests( uri, applicationStoppingToken );
        return uri;
    }

    private static async Task StartAngularCliServerAsync( string sourcePath, string scriptName, string pkgManagerCommand, int portNumber, ILogger logger, DiagnosticSource diagnosticSource, CancellationToken applicationStoppingToken ) {
        Console.WriteLine($"dbug: 准备启动Angular服务器 http://localhost:{portNumber}");
        if ( logger.IsEnabled( LogLevel.Information ) ) {
            logger.LogInformation( $"Starting @angular/cli on port {portNumber}..." );
        }

        var scriptRunner = new NodeScriptRunner(
            sourcePath, scriptName, $"--port {portNumber}", null, pkgManagerCommand, diagnosticSource, applicationStoppingToken );
        scriptRunner.AttachToLogger( logger );

        bool openBrowserLine;
        using var stdErrReader = new EventedStreamStringReader( scriptRunner.StdErr );
        try {
            openBrowserLine = await scriptRunner.StdOut.WaitForMatch( ["Watch mode enabled", "Angular Live Development"] );
        }
        catch ( EndOfStreamException ex ) {
            throw new InvalidOperationException(
                $"The {pkgManagerCommand} script '{scriptName}' exited without indicating that the " +
                $"Angular CLI was listening for requests. The error output was: " +
                $"{stdErrReader.ReadAsString()}", ex );
        }
    }

    private static async Task WaitForAngularCliServerToAcceptRequests( Uri cliServerUri, CancellationToken applicationStoppingToken ) {
        using var client = new HttpClient();
        var i = 0;
        while ( true ) {
            try {
                i++;
                var response = await client.SendAsync( new HttpRequestMessage( HttpMethod.Get, cliServerUri ), applicationStoppingToken );
                var content = await response.Content.ReadAsStringAsync( applicationStoppingToken );
                if ( content.IsEmpty() == false ) {
                    return;
                }
                await Task.Delay( 300, applicationStoppingToken );
                if ( i > 1000 ) {
                    return;
                }
            }
            catch ( Exception ) {
                // ignored
            }
        }
    }
}
