namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 列配置信息
/// </summary>
public class ColumnInfo {
    /// <summary>
    /// 索引
    /// </summary>
    public int Index { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 列名
    /// </summary>
    public string Column { get; set; }
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
    /// 是否排序
    /// </summary>
    public bool IsSort { get; set; }
    /// <summary>
    /// 宽度
    /// </summary>
    public string Width { get; set; }
    /// <summary>
    /// 是否第一列
    /// </summary>
    public bool IsFirst { get; set; }
    /// <summary>
    /// 左侧固定
    /// </summary>
    public string IsLeft { get; set; }
    /// <summary>
    /// 右侧固定
    /// </summary>
    public string IsRight { get; set; }
    /// <summary>
    /// 访问控制列表
    /// </summary>
    public string Acl { get; set; }
    /// <summary>
    /// 访问控制列表模板标识
    /// </summary>
    public string AclElseTemplateId { get; set; }
    /// <summary>
    /// 是否启用拖动调整列宽
    /// </summary>
    public bool IsEnableResizable { get; set; }
    /// <summary>
    /// 是否内部列
    /// </summary>
    public bool IsInner { get; set; }

    /// <summary>
    /// 转换为自定义列
    /// </summary>
    public CustomColumn ToCustomColumn() {
        bool? isLeft = IsLeft.IsEmpty() ? null : true;
        bool? isRight = IsRight.IsEmpty() ? null : true;
        return new CustomColumn( GetCellControl(), Width, isLeft, isRight, TitleAlign, Align, Ellipsis, Acl );
    }

    /// <summary>
    /// 获取自定义列标识
    /// </summary>
    public string GetCellControl() {
        return CellControl.IsEmpty() ? Title : CellControl;
    }
}