namespace Util.Ui.NgZorro.Enums;

/// <summary>
/// 哈希码展示模式
/// </summary>
public enum HashCodeMode {
    /// <summary>
    /// 单行模式
    /// </summary>
    [Description( "single" )]
    Single,
    /// <summary>
    /// 双行模式
    /// </summary>
    [Description( "double" )]
    Double,
    /// <summary>
    /// 长条模式
    /// </summary>
    [Description( "strip" )]
    Strip,
    /// <summary>
    /// 矩形模式
    /// </summary>
    [Description( "rect" )]
    Rect
}