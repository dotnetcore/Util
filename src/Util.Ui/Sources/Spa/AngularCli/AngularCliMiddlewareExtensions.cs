// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Util.Ui.Sources.Spa.AngularCli;

/// <summary>
/// Extension methods for enabling Angular CLI middleware support.
/// </summary>
public static class AngularCliMiddlewareExtensions {
    /// <summary>
    /// 使用Angular开发服务器
    /// </summary>
    public static void UseAngularCliServer(
        this ISpaBuilder spaBuilder,
        string npmScript ) {
        ArgumentNullException.ThrowIfNull( spaBuilder );

        var spaOptions = spaBuilder.Options;

        if ( string.IsNullOrEmpty( spaOptions.SourcePath ) ) {
            throw new InvalidOperationException( $"To use {nameof( UseAngularCliServer )}, you must supply a non-empty value for the {nameof( SpaOptions.SourcePath )} property of {nameof( SpaOptions )} ." );
        }
        AngularCliMiddleware.Attach( spaBuilder, npmScript );
    }
}
