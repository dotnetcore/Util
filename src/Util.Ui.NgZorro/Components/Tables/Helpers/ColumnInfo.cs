namespace Util.Ui.NgZorro.Components.Tables.Helpers; 

/// <summary>
/// 列配置信息
/// </summary>
public class ColumnInfo {
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 列名
    /// </summary>
    public string Column { get; set; }
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
    /// 是否左侧固定
    /// </summary>
    public bool IsLeft { get; set; }
    /// <summary>
    /// 是否右侧固定
    /// </summary>
    public bool IsRight { get; set; }
    /// <summary>
    /// 访问控制列表
    /// </summary>
    public string Acl { get; set; }
    /// <summary>
    /// 访问控制列表模板标识
    /// </summary>
    public string AclElseTemplateId { get; set; }
}