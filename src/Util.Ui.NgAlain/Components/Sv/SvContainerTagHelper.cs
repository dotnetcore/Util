using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv.Renders;
using Util.Ui.NgAlain.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sv;

/// <summary>
/// ng-alain 查看容器组件,生成的标签为&lt;sv-container&gt;&lt;/sv-container&gt;
/// </summary>
[HtmlTargetElement( "util-descriptions-x" )]
[HtmlTargetElement( "util-sv-container" )]
public class SvContainerTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [col], 一行显示几列,默认值: 2
    /// </summary>
    public string Column { get; set; }
    /// <summary>
    /// size, 尺寸, 可选项: 'default','small','large'
    /// </summary>
    public SvSize Size { get; set; }
    /// <summary>
    /// [size], 尺寸, 可选项: 'default','small','large'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// layout, 布局, 可选项: 'horizontal','vertical', 默认值: 'horizontal'
    /// </summary>
    public SvLayout Layout { get; set; }
    /// <summary>
    /// [layout], 布局, 可选项: 'horizontal','vertical', 默认值: 'horizontal'
    /// </summary>
    public string BindLayout { get; set; }
    /// <summary>
    /// [gutter], 间距, 默认值: 32
    /// </summary>
    public string Gutter { get; set; }
    /// <summary>
    /// [labelWidth], 标签文本宽度
    /// </summary>
    public string LabelWidth { get; set; }
    /// <summary>
    /// [default], 是否显示默认文本, 默认值: true
    /// </summary>
    public string Default { get; set; }
    /// <summary>
    /// title, 标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [title], 标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// [noColon], 是否不显示标签后面的冒号, 默认值: false
    /// </summary>
    public string NoColon { get; set; }
    /// <summary>
    /// [bordered], 是否显示边框, 默认值: false
    /// </summary>
    public string Bordered { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new SvContainerRender( config );
    }
}