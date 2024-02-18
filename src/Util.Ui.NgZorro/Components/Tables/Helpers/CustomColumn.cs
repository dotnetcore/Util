using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 自定义列信息
/// </summary>
public class CustomColumn {
    /// <summary>
    /// 初始化自定义列信息
    /// </summary>
    /// <param name="value">值</param>
    /// <param name="width">宽度</param>
    /// <param name="acl">访问控制</param>
    public CustomColumn( string value, string width, string acl ) {
        Value = value;
        Default = true;
        Width = GetWidth( width );
        if ( acl.IsEmpty() == false )
            Acl = acl;
    }

    /// <summary>
    /// 获取宽度
    /// </summary>
    private double GetWidth( string value ) {
        var defaultWidth = NgZorroOptionsService.GetOptions().TableColumnDefaultWidth;
        if ( value.IsEmpty() )
            return defaultWidth;
        if ( Util.Helpers.Validation.IsNumber( value ) )
            return Util.Helpers.Convert.ToDouble( value );
        if ( value.EndsWith( "px" ) )
            return Util.Helpers.Convert.ToDouble( value.RemoveEnd( "px" ) );
        if ( value.EndsWith( "%" ) )
            return 10 * Util.Helpers.Convert.ToDouble( value.RemoveEnd( "%" ) );
        return defaultWidth;
    }

    /// <summary>
    /// 值
    /// </summary>
    [JsonPropertyName( "value" )]
    public string Value { get; }

    /// <summary>
    /// 默认
    /// </summary>
    [JsonPropertyName( "default" )]
    public bool Default { get; }

    /// <summary>
    /// 宽度
    /// </summary>
    [JsonPropertyName( "width" )]
    public double Width { get; }

    /// <summary>
    /// 访问控制
    /// </summary>
    [JsonPropertyName( "acl" )]
    public string Acl { get; }
}