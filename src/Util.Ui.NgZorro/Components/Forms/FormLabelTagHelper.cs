using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms; 

/// <summary>
/// 表单标签,生成的标签为&lt;nz-form-label&gt;&lt;/nz-form-label&gt;
/// </summary>
[HtmlTargetElement( "util-form-label" )]
public class FormLabelTagHelper : ColumnTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 扩展属性,内容文本,支持多语言
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// 扩展属性,属性表达式
    /// </summary>
    public ModelExpression For { get; set; }
    /// <summary>
    /// [nzRequired],是否必填项，显示红色星号, 类型: boolean, 默认值: false
    /// </summary>
    public string Required { get; set; }
    /// <summary>
    /// [nzNoColon],是否不显示冒号, 类型: boolean, 默认值: false
    /// </summary>
    public string NoColon { get; set; }
    /// <summary>
    /// [nzLabelWrap],标签文本是否换行, 类型: boolean, 默认值: false
    /// </summary>
    public string LabelWrap { get; set; }
    /// <summary>
    /// nzLabelAlign,标签文本对齐方式, 类型: 'left' | 'right', 默认值: 'right'
    /// </summary>
    public LabelAlign LabelAlign { get; set; }
    /// <summary>
    /// [nzLabelAlign],标签文本对齐方式, 类型: 'left' | 'right', 默认值: 'right'
    /// </summary>
    public string BindLabelAlign { get; set; }
    /// <summary>
    /// nzFor,设置标签指向的组件Id,注意：应设置组件的 raw-id 或 nz-id,即原始Id属性
    /// </summary>
    public string NzFor { get; set; }
    /// <summary>
    /// [nzFor],设置标签指向的组件Id,注意：应设置组件的 raw-id 或 nz-id,即原始Id属性
    /// </summary>
    public string BindNzFor { get; set; }
    /// <summary>
    /// nzTooltipTitle,提示信息,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string TooltipTitle { get; set; }
    /// <summary>
    /// [nzTooltipTitle],提示信息,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindTooltipTitle { get; set; }
    /// <summary>
    /// nzTooltipIcon,提示图标
    /// </summary>
    public AntDesignIcon TooltipIcon { get; set; }
    /// <summary>
    /// [nzTooltipIcon],提示图标, 类型: string | NzFormTooltipIcon
    /// </summary>
    public string BindTooltipIcon { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new FormItemShareService( _config );
        service.Init();
        service.AutoCreateFormLabel( false );
        LoadExpression();
    }

    /// <summary>
    /// 加载表达式
    /// </summary>
    private void LoadExpression() {
        var loader = new ExpressionLoader();
        loader.Load( _config );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new FormLabelRender( _config );
    }
}