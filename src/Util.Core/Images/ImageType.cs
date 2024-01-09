namespace Util.Images; 

/// <summary>
/// 图片类型
/// </summary>
public enum ImageType {
    /// <summary>
    /// .jpg
    /// </summary>
    [Description( ".jpg" )]
    Jpg,
    /// <summary>
    /// .jpeg
    /// </summary>
    [Description( ".jpeg" )]
    Jpeg,
    /// <summary>
    /// .png
    /// </summary>
    [Description( ".png" )]
    Png,
    /// <summary>
    /// .gif
    /// </summary>
    [Description( ".gif" )]
    Gif,
    /// <summary>
    /// .svg
    /// </summary>
    [Description( ".svg" )]
    Svg,
    /// <summary>
    /// .bmp
    /// </summary>
    [Description( ".bmp" )]
    Bmp,
    /// <summary>
    /// .webp
    /// </summary>
    [Description( ".webp" )]
    Webp
}