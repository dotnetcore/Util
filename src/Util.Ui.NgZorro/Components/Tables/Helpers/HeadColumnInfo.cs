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
    /// 获取自定义列标识
    /// </summary>
    public string GetCellControl() {
        return CellControl.IsEmpty() ? Title : CellControl;
    }
}