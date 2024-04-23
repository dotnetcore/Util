using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Tags.Helpers;
using Util.Ui.NgZorro.Components.Tags.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;
using TagMode = Util.Ui.NgZorro.Enums.TagMode;

namespace Util.Ui.NgZorro.Components.Tags; 

/// <summary>
/// 标签,生成的标签为&lt;nz-tag>&lt;/nz-tag>
/// </summary>
[HtmlTargetElement( "util-tag" )]
public class TagTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 属性表达式
    /// </summary>
    public ModelExpression For { get; set; }
    /// <summary>
    /// 扩展属性,是否启用扩展指令,当设置Url或Data属性时自动启用,默认为 false
    /// </summary>
    public bool EnableExtend { get; set; }
    /// <summary>
    /// 扩展属性 [autoLoad],初始化时是否自动加载数据，默认为true,设置成false则手工加载
    /// </summary>
    public bool AutoLoad { get; set; }
    /// <summary>
    /// 扩展属性 [(allSelected)],是否选中全部标签
    /// </summary>
    public string AllSelected { get; set; }
    /// <summary>
    /// 扩展属性 [(selectedText)],选中标签文本,多个标签文本使用逗号分隔
    /// </summary>
    public string SelectedText { get; set; }
    /// <summary>
    /// 扩展属性 [(selectedValue)],选中标签值,多个标签值使用逗号分隔
    /// </summary>
    public string SelectedValue { get; set; }
    /// <summary>
    /// 扩展属性 [(queryParam)],查询参数
    /// </summary>
    public string QueryParam { get; set; }
    /// <summary>
    /// 扩展属性 url,Api地址
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 扩展属性 [url],Api地址
    /// </summary>
    public string BindUrl { get; set; }
    /// <summary>
    /// 扩展属性 [data],数据源
    /// </summary>
    public string Data { get; set; }
    /// <summary>
    /// 扩展属性,内容文本,支持i18n
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// 扩展属性,是否显示Enabled文本,默认文本为'Enabled',i18n文本为'util.enabled'
    /// </summary>
    public bool TextEnabled { get; set; }
    /// <summary>
    /// 扩展属性,是否显示Not Enabled文本,默认文本为'Not Enabled',i18n文本为'util.notEnabled'
    /// </summary>
    public bool TextNotEnabled { get; set; }
    /// <summary>
    /// nzMode,模式,可选值: 'closeable' | 'default' | 'checkable',默认值: 'default'
    /// </summary>
    public TagMode Mode { get; set; }
    /// <summary>
    /// [nzMode],模式,可选值: 'closeable' | 'default' | 'checkable',默认值: 'default'
    /// </summary>
    public string BindMode { get; set; }
    /// <summary>
    /// [nzChecked],是否选中,在 nzMode="checkable" 时可用,默认值: false
    /// </summary>
    public string Checked { get; set; }
    /// <summary>
    /// [(nzChecked)],是否选中,在 nzMode="checkable" 时可用,默认值: false
    /// </summary>
    public string BindonChecked { get; set; }
    /// <summary>
    /// nzColor,颜色枚举类型
    /// </summary>
    public AntDesignColor ColorType { get; set; }
    /// <summary>
    /// nzColor,颜色
    /// </summary>
    public string Color { get; set; }
    /// <summary>
    /// [nzColor],颜色
    /// </summary>
    public string BindColor { get; set; }
    /// <summary>
    /// (nzOnClose),关闭事件,在 nzMode="closable" 时可用,类型: EventEmitter&lt;MouseEvent>
    /// </summary>
    public string OnClose { get; set; }
    /// <summary>
    /// (nzCheckedChange),选中状态变化事件,在 nzMode="checkable" 时可用,类型: EventEmitter&lt;void>
    /// </summary>
    public string OnCheckedChange { get; set; }
    /// <summary>
    /// 扩展事件 (onLoad),数据加载完成事件,类型: EventEmitter&lt;any>,参数为服务端返回结果
    /// </summary>
    public string OnLoad { get; set; }
    /// <summary>
    /// 扩展事件 (selectedTextChange),选中文本变更事件,类型: EventEmitter&lt;string>,参数为选中标签的文本,以逗号分隔
    /// </summary>
    public string OnSelectedTextChange { get; set; }
    /// <summary>
    /// 扩展事件 (selectedValueChange),选中值变更事件,类型: EventEmitter&lt;string>,参数为选中标签的值,以逗号分隔
    /// </summary>
    public string OnSelectedValueChange { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var loader = new TagExpressionLoader();
        loader.Load( _config );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new TagRender( _config );
    }
}