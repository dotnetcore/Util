using SixLabors.ImageSharp.Drawing;

namespace Util.Images;

/// <summary>
/// ImageSharp扩展
/// </summary>
public static class ImageSharpExtensions {
    /// <summary>
    /// 转换颜色类型
    /// </summary>
    /// <param name="color">颜色</param>
    public static Color ToImageSharpColor( this System.Drawing.Color color ) {
        return Color.FromRgba( color.R, color.G, color.B, color.A );
    }

    /// <summary>
    /// 图片缩放
    /// </summary>
    /// <param name="image">图片</param>
    /// <param name="scale">缩放比例</param>
    public static Image Zoom( this Image image, double scale ) {
        var width = Util.Helpers.Convert.ToInt( image.Width * scale );
        var height = Util.Helpers.Convert.ToInt( image.Height * scale );
        image.Mutate( t => {
            t.Resize( new Size( width, height ) );
        } );
        return image;
    }

    /// <summary>
    /// 设置圆角
    /// </summary>
    /// <param name="image">图片</param>
    /// <param name="cornerRadius">角度</param>
    public static Image RoundCorners( this Image image, int cornerRadius ) {
        image.Mutate( context => RoundCorners( context, cornerRadius ) );
        return image;
    }

    /// <summary>
    /// 设置圆角
    /// </summary>
    /// <param name="context">图片处理上下文</param>
    /// <param name="cornerRadius">角度</param>
    private static void RoundCorners( IImageProcessingContext context, int cornerRadius ) {
        var size = context.GetCurrentSize();
        var corners = BuildCorners( size.Width, size.Height, cornerRadius );
        context.SetGraphicsOptions( new GraphicsOptions { AlphaCompositionMode = PixelAlphaCompositionMode.DestOut } );
        context.Fill( Color.Red, corners );
    }

    /// <summary>
    /// 构建圆角
    /// </summary>
    /// <param name="imageWidth">图片宽度</param>
    /// <param name="imageHeight">图片高度</param>
    /// <param name="cornerRadius">角度</param>
    private static IPathCollection BuildCorners( int imageWidth, int imageHeight, float cornerRadius ) {
        var rect = new RectangularPolygon( -0.5f, -0.5f, cornerRadius, cornerRadius );
        var cornerTopLeft = rect.Clip( new EllipsePolygon( cornerRadius - 0.5f, cornerRadius - 0.5f, cornerRadius ) );
        var rightPos = imageWidth - cornerTopLeft.Bounds.Width + 1;
        var bottomPos = imageHeight - cornerTopLeft.Bounds.Height + 1;
        var cornerTopRight = cornerTopLeft.RotateDegree( 90 ).Translate( rightPos, 0 );
        var cornerBottomLeft = cornerTopLeft.RotateDegree( -90 ).Translate( 0, bottomPos );
        var cornerBottomRight = cornerTopLeft.RotateDegree( 180 ).Translate( rightPos, bottomPos );
        return new PathCollection( cornerTopLeft, cornerBottomLeft, cornerTopRight, cornerBottomRight );
    }
}