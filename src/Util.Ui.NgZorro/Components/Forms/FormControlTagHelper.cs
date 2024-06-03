using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms; 

/// <summary>
/// 表单域,生成的标签为&lt;nz-form-control&gt;&lt;/nz-form-control&gt;
/// </summary>
[HtmlTargetElement( "util-form-control" )]
public class FormControlTagHelper : ColumnTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// [nzValidateStatus],校验状态，可选值: 'success' | 'warning' | 'error' | 'validating' | FormControl | NgModel
    /// </summary>
    public string ValidateStatus { get; set; }
    /// <summary>
    /// [nzHasFeedback],是否显示校验状态反馈图标,类型: boolean, 默认值: false
    /// </summary>
    public string HasFeedback { get; set; }
    /// <summary>
    /// nzExtra,额外提示信息, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Extra { get; set; }
    /// <summary>
    /// [nzExtra],额外提示信息, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindExtra { get; set; }
    /// <summary>
    /// nzSuccessTip,校验成功提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string SuccessTip { get; set; }
    /// <summary>
    /// [nzSuccessTip],校验成功提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string BindSuccessTip { get; set; }
    /// <summary>
    /// nzWarningTip,校验状态为警告时的提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string WarningTip { get; set; }
    /// <summary>
    /// [nzWarningTip],校验状态为警告时的提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string BindWarningTip { get; set; }
    /// <summary>
    /// nzErrorTip,校验状态为错误时的提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string ErrorTip { get; set; }
    /// <summary>
    /// [nzErrorTip],校验状态为错误时的提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string BindErrorTip { get; set; }
    /// <summary>
    /// nzValidatingTip,正在校验时的提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string ValidatingTip { get; set; }
    /// <summary>
    /// [nzValidatingTip],正在校验时的提示信息, 类型: string \| TemplateRef&lt;{ $implicit: FormControl \| NgModel }>
    /// </summary>
    public string BindValidatingTip { get; set; }
    /// <summary>
    /// [nzAutoTips],自动提示, 类型: Record&lt;string, Record&lt;string, string>>
    /// </summary>
    public string AutoTips { get; set; }
    /// <summary>
    /// [nzDisableAutoTips],是否禁用自动提示, 类型: boolean, 默认值: false
    /// </summary>
    public string DisableAutoTips { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new FormItemShareService( _config );
        service.Init();
        service.AutoCreateFormControl( false );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new FormControlRender( _config );
    }
}