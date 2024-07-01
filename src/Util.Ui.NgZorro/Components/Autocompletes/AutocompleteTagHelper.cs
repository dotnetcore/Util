using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Autocompletes.Helpers;
using Util.Ui.NgZorro.Components.Autocompletes.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Autocompletes; 

/// <summary>
/// 自动完成,生成的标签为&lt;nz-autocomplete&gt;&lt;/nz-autocomplete&gt;
/// </summary>
[HtmlTargetElement( "util-autocomplete" )]
public class AutocompleteTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 属性表达式
    /// </summary>
    public ModelExpression For { get; set; }
    /// <summary>
    /// 扩展属性,是否启用扩展指令,当设置 url 或 data 属性时自动启用
    /// </summary>
    public bool EnableExtend { get; set; }
    /// <summary>
    /// 扩展属性 [autoLoad],初始化时是否自动加载数据，设置成 false 则手工加载,默认值: true
    /// </summary>
    public string AutoLoad { get; set; }
    /// <summary>
    /// 扩展属性 [(queryParam)],查询参数
    /// </summary>
    public string QueryParam { get; set; }
    /// <summary>
    /// 扩展属性 order,排序条件,范例: creationTime desc
    /// </summary>
    public string Sort { get; set; }
    /// <summary>
    /// 扩展属性 [order],排序条件,范例: creationTime desc
    /// </summary>
    public string BindSort { get; set; }
    /// <summary>
    /// 扩展属性 url,Api地址
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 扩展属性 [url],Api地址
    /// </summary>
    public string BindUrl { get; set; }
    /// <summary>
    /// 扩展属性 [data],数据源, 类型: SelectItem[]
    /// </summary>
    public string Data { get; set; }
    /// <summary>
    /// [nzBackfill],使用键盘选择选项时，是否把当前高亮项的值即时回填到输入框中, 默认值: false
    /// </summary>
    public string Backfill { get; set; }
    /// <summary>
    /// [nzDataSource],数据源
    /// </summary>
    public string Datasource { get; set; }
    /// <summary>
    /// [nzDefaultActiveFirstOption],是否默认高亮第一项, 默认值: true
    /// </summary>
    public string DefaultActiveFirstOption { get; set; }
    /// <summary>
    /// [nzWidth],宽度,单位:px 
    /// </summary>
    public string Width { get; set; }
    /// <summary>
    /// nzOverlayClassName,下拉根元素类名
    /// </summary>
    public string OverlayClassName { get; set; }
    /// <summary>
    /// [nzOverlayClassName],下拉根元素类名
    /// </summary>
    public string BindOverlayClassName { get; set; }
    /// <summary>
    /// nzOverlayStyle,下拉根元素样式
    /// </summary>
    public string OverlayStyle { get; set; }
    /// <summary>
    /// [nzOverlayStyle],下拉根元素样式
    /// </summary>
    public string BindOverlayStyle { get; set; }
    /// <summary>
    /// [compareWith],比较算法函数,函数定义:(o1: any, o2: any) => boolean
    /// </summary>
    public string CompareWith { get; set; }
    /// <summary>
    /// 扩展事件 (onLoad),数据加载完成事件,类型: EventEmitter&lt;any>,参数为服务端返回结果
    /// </summary>
    public string OnLoad { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new AutocompleteService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new AutocompleteRender( _config );
    }
}