// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Util.Ui.Sources.Spa.StaticFiles;

namespace Util.Ui.Sources.Spa;

internal sealed class SpaDefaultPageMiddleware
{
    public static void Attach(ISpaBuilder spaBuilder)
    {
        ArgumentNullException.ThrowIfNull(spaBuilder);

        var app = spaBuilder.ApplicationBuilder;
        var options = spaBuilder.Options;

        // Rewrite all requests to the default page
        app.Use((context, next) =>
        {
            // If we have an Endpoint, then this is a deferred match - just noop.
            if (context.GetEndpoint() != null)
            {
                return next(context);
            }

            context.Request.Path = options.DefaultPage;
            return next(context);
        });

        // Serve it as a static file
        // Developers who need to host more than one SPA with distinct default pages can
        // override the file provider
        app.UseSpaStaticFilesInternal(
            options.DefaultPageStaticFileOptions ?? new StaticFileOptions(),
            allowFallbackOnServingWebRootFiles: true);
    }
}
