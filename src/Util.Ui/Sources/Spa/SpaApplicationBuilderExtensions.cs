// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Util.Ui.Sources.Spa;

/// <summary>
/// Provides extension methods used for configuring an application to
/// host a client-side Single Page Application (SPA).
/// </summary>
public static class SpaApplicationBuilderExtensions {
    /// <summary>
    /// Handles all requests from this point in the middleware chain by returning
    /// the default page for the Single Page Application (SPA).
    ///
    /// This middleware should be placed late in the chain, so that other middleware
    /// for serving static files, MVC actions, etc., takes precedence.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
    /// <param name="configuration">
    /// This callback will be invoked so that additional middleware can be registered within
    /// the context of this SPA.
    /// </param>
    public static void UseAngular( this IApplicationBuilder app, Action<ISpaBuilder> configuration ) {
        ArgumentNullException.ThrowIfNull( configuration );
        var optionsProvider = app.ApplicationServices.GetService<IOptions<SpaOptions>>()!;
        var options = new SpaOptions( optionsProvider.Value );
        var spaBuilder = new DefaultSpaBuilder( app, options );
        configuration.Invoke( spaBuilder );
        SpaDefaultPageMiddleware.Attach( spaBuilder );
    }
}
