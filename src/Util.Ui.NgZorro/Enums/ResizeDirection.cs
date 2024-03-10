namespace Util.Ui.NgZorro.Enums;

/// <summary>
/// 调整尺寸手柄方向
/// </summary>
public enum ResizeDirection {
    /// <summary>
    /// 上方
    /// </summary>
    [Description( "top" )]
    Top,
    /// <summary>
    /// 右方
    /// </summary>
    [Description( "right" )]
    Right,
    /// <summary>
    /// 下方
    /// </summary>
    [Description( "bottom" )]
    Bottom,
    /// <summary>
    /// 左方
    /// </summary>
    [Description( "left" )]
    Left,
    /// <summary>
    /// 右上方
    /// </summary>
    [Description( "topRight" )]
    TopRight,
    /// <summary>
    /// 右下方
    /// </summary>
    [Description( "bottomRight" )]
    BottomRight,
    /// <summary>
    /// 左下方
    /// </summary>
    [Description( "bottomLeft" )]
    BottomLeft,
    /// <summary>
    /// 左上方
    /// </summary>
    [Description( "topLeft" )]
    TopLeft
}