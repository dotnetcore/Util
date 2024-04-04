namespace Util.Ui.NgZorro.Components.WaterMarks.Helpers;

/// <summary>
/// 字体类型
/// </summary>
internal class FontType {
    /// <summary>
    /// 字体颜色
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; }
    /// <summary>
    /// 字体大小
    /// </summary>
    [JsonPropertyName( "fontSize" )]
    public double? FontSize { get; set; }
    /// <summary>
    /// 字体粗细
    /// </summary>
    [JsonPropertyName( "fontWeight" )]
    public string FontWeight { get; set; }
    /// <summary>
    /// 字体类型
    /// </summary>
    [JsonPropertyName( "fontFamily" )]
    public string FontFamily { get; set; }
    /// <summary>
    /// 字体样式
    /// </summary>
    [JsonPropertyName( "fontStyle" )]
    public string FontStyle { get; set; }
}