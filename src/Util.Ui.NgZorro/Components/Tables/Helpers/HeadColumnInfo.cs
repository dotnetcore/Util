namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 表头列配置信息
/// </summary>
public class HeadColumnInfo {
    /// <summary>
    /// 索引
    /// </summary>
    public int Index { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 宽度
    /// </summary>
    public string Width { get; set; }
    /// <summary>
    /// 自定义列标识
    /// </summary>
    public string CellControl { get; set; }
    /// <summary>
    /// 对齐方式
    /// </summary>
    public string Align { get; set; }
    /// <summary>
    /// 标题对齐方式
    /// </summary>
    public string TitleAlign { get; set; }
    /// <summary>
    /// 是否自动省略
    /// </summary>
    public bool? Ellipsis { get; set; }
    /// <summary>
    /// 左侧固定
    /// </summary>
    public string IsLeft { get; set; }
    /// <summary>
    /// 右侧固定
    /// </summary>
    public string IsRight { get; set; }
    /// <summary>
    /// 是否启用拖动调整列宽
    /// </summary>
    public bool? IsEnableResizable { get; set; }
}