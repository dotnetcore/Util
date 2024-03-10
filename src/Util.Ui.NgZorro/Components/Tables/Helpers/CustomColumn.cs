namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 自定义列信息
/// </summary>
public class CustomColumn {
    /// <summary>
    /// 初始化自定义列信息
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="width">宽度</param>
    /// <param name="left">固定到左侧</param>
    /// <param name="right">固定到右侧</param>
    /// <param name="titleAlign">标题对齐方式</param>
    /// <param name="align">内容对齐方式</param>
    /// <param name="ellipsis">是否自动省略</param>
    /// <param name="acl">访问控制</param>
    public CustomColumn( string title, string width, bool? left = null, bool? right = null,
        string titleAlign = null,string align = null, bool? ellipsis = null, string acl = null ) {
        Title = title;
        if ( width.IsEmpty() == false )
            Width = width;
        Left = left;
        Right = right;
        if ( titleAlign.IsEmpty() == false )
            TitleAlign = titleAlign;
        if ( align.IsEmpty() == false )
            Align = align;
        Ellipsis = ellipsis;
        if ( acl.IsEmpty() == false )
            Acl = acl;
    }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName( "title" )]
    public string Title { get; }

    /// <summary>
    /// 宽度
    /// </summary>
    [JsonPropertyName( "width" )]
    public string Width { get; }

    /// <summary>
    /// 固定到左侧
    /// </summary>
    [JsonPropertyName( "left" )]
    public bool? Left { get; }

    /// <summary>
    /// 固定到右侧
    /// </summary>
    [JsonPropertyName( "right" )]
    public bool? Right { get; }

    /// <summary>
    /// 标题对齐方式
    /// </summary>
    [JsonPropertyName( "titleAlign" )]
    public string TitleAlign { get; }

    /// <summary>
    /// 内容对齐方式
    /// </summary>
    [JsonPropertyName( "align" )]
    public string Align { get; }

    /// <summary>
    /// 是否自动省略
    /// </summary>
    [JsonPropertyName( "ellipsis" )]
    public bool? Ellipsis { get; }

    /// <summary>
    /// 访问控制
    /// </summary>
    [JsonPropertyName( "acl" )]
    public string Acl { get; }
}