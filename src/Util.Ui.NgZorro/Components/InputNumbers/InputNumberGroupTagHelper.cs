using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.InputNumbers.Renders;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.InputNumbers;

/// <summary>
/// 数字输入框组合,生成的标签为&lt;nz-input-number-group&gt;&lt;/nz-input-number-group&gt;
/// </summary>
[HtmlTargetElement( "util-input-number-group" )]
public class InputNumberGroupTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzAddOnBefore,设置前置标签
    /// </summary>
    public string AddOnBefore { get; set; }
    /// <summary>
    /// [nzAddOnBefore],设置前置标签
    /// </summary>
    public string BindAddOnBefore { get; set; }
    /// <summary>
    /// nzAddOnAfter,设置后置标签
    /// </summary>
    public string AddOnAfter { get; set; }
    /// <summary>
    /// [nzAddOnAfter],设置后置标签
    /// </summary>
    public string BindAddOnAfter { get; set; }
    /// <summary>
    /// nzAddOnBeforeIcon,设置前置图标
    /// </summary>
    public AntDesignIcon AddOnBeforeIcon { get; set; }
    /// <summary>
    /// [nzAddOnBeforeIcon],设置前置图标
    /// </summary>
    public string BindAddOnBeforeIcon { get; set; }
    /// <summary>
    /// nzAddOnAfterIcon,设置后置图标
    /// </summary>
    public AntDesignIcon AddOnAfterIcon { get; set; }
    /// <summary>
    /// [nzAddOnAfterIcon],设置后置图标
    /// </summary>
    public string BindAddOnAfterIcon { get; set; }
    /// <summary>
    /// nzPrefix,设置前缀
    /// </summary>
    public string Prefix { get; set; }
    /// <summary>
    /// [nzPrefix],设置前缀
    /// </summary>
    public string BindPrefix { get; set; }
    /// <summary>
    /// nzSuffix,设置后缀
    /// </summary>
    public string Suffix { get; set; }
    /// <summary>
    /// [nzSuffix],设置后缀
    /// </summary>
    public string BindSuffix { get; set; }
    /// <summary>
    /// nzPrefixIcon,设置前缀图标
    /// </summary>
    public AntDesignIcon PrefixIcon { get; set; }
    /// <summary>
    /// [nzPrefixIcon],设置前缀图标
    /// </summary>
    public string BindPrefixIcon { get; set; }
    /// <summary>
    /// nzSuffixIcon,设置后缀图标
    /// </summary>
    public AntDesignIcon SuffixIcon { get; set; }
    /// <summary>
    /// [nzSuffixIcon],设置后缀图标
    /// </summary>
    public string BindSuffixIcon { get; set; }
    /// <summary>
    /// nzSize,设置输入框大小, 可选值: 'default' | 'small' |  'large'
    /// </summary>
    public InputSize Size { get; set; }
    /// <summary>
    /// [nzSize],设置输入框大小, 可选值: 'default' | 'small' |  'large'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzCompact],是否紧凑模式, 默认值: false
    /// </summary>
    public string Compact { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var formItemShareService = new FormItemShareService( _config );
        formItemShareService.Init();
        formItemShareService.InitId();
        var inputGroupShareService = new InputGroupShareService( _config );
        inputGroupShareService.Init();
        inputGroupShareService.AutoCreateInputGroup( false );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new InputNumberGroupRender( _config );
    }
}