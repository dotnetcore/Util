using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Components.Inputs.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Inputs {
    /// <summary>
    /// 输入框,生成的标签为&lt;input nz-input /&gt;
    /// </summary>
    [HtmlTargetElement( "util-input",TagStructure = TagStructure.WithoutEndTag)]
    public class InputTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// name,名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [name],名称
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// [required],是否必填项
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// 扩展属性 requiredMessage,必填项验证消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// 扩展属性 [requiredMessage],必填项验证消息
        /// </summary>
        public string BindRequiredMessage { get; set; }
        /// <summary>
        /// [minlength],最小长度验证
        /// </summary>
        public string MinLength { get; set; }
        /// <summary>
        /// 扩展属性 minLengthMessage,最小长度验证消息
        /// </summary>
        public string MinLengthMessage { get; set; }
        /// <summary>
        /// 扩展属性 [minLengthMessage],最小长度验证消息
        /// </summary>
        public string BindMinLengthMessage { get; set; }
        /// <summary>
        /// [maxlength],最大长度验证
        /// </summary>
        public string MaxLength { get; set; }
        /// <summary>
        /// 扩展属性 emailMessage,电子邮件验证消息
        /// </summary>
        public string EmailMessage { get; set; }
        /// <summary>
        /// 扩展属性 [emailMessage],电子邮件验证消息
        /// </summary>
        public string BindEmailMessage { get; set; }
        /// <summary>
        /// pattern,正则表达式验证
        /// </summary>
        public string Pattern { get; set; }
        /// <summary>
        /// [pattern],正则表达式验证
        /// </summary>
        public string BindPattern { get; set; }
        /// <summary>
        /// 扩展属性 patternMessage,正则表达式错误消息
        /// </summary>
        public string PatternMessage { get; set; }
        /// <summary>
        /// 扩展属性 [patternMessage],正则表达式错误消息
        /// </summary>
        public string BindPatternMessage { get; set; }
        /// <summary>
        /// placeholder,占位符提示信息
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [placeholder],占位符提示信息
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// [disabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [disabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [readOnly],只读
        /// </summary>
        public bool Readonly { get; set; }
        /// <summary>
        /// [readOnly],只读
        /// </summary>
        public string BindReadonly { get; set; }
        /// <summary>
        /// nzSize,输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public InputSize Size { get; set; }
        /// <summary>
        /// [nzSize],输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// type,输入框类型, 可选值: 'text' | 'password' |  'number' |  'email'
        /// </summary>
        public InputType Type { get; set; }
        /// <summary>
        /// [type],输入框类型, 可选值: 'text' | 'password' |  'number' |  'email'
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// nzAddOnBefore,设置前置标签,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string AddOnBefore { get; set; }
        /// <summary>
        /// [nzAddOnBefore],设置前置标签,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindAddOnBefore { get; set; }
        /// <summary>
        /// nzAddOnAfter,设置后置标签,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string AddOnAfter { get; set; }
        /// <summary>
        /// [nzAddOnAfter],设置后置标签,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindAddOnAfter { get; set; }
        /// <summary>
        /// nzAddOnBeforeIcon,设置前置图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public AntDesignIcon AddOnBeforeIcon { get; set; }
        /// <summary>
        /// [nzAddOnBeforeIcon],设置前置图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindAddOnBeforeIcon { get; set; }
        /// <summary>
        /// nzAddOnAfterIcon,设置后置图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public AntDesignIcon AddOnAfterIcon { get; set; }
        /// <summary>
        /// [nzAddOnAfterIcon],设置后置图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindAddOnAfterIcon { get; set; }
        /// <summary>
        /// nzPrefix,设置前缀,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// [nzPrefix],设置前缀,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindPrefix { get; set; }
        /// <summary>
        /// nzSuffix,设置后缀,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// [nzSuffix],设置后缀,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindSuffix { get; set; }
        /// <summary>
        /// nzPrefixIcon,设置前缀图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public AntDesignIcon PrefixIcon { get; set; }
        /// <summary>
        /// [nzPrefixIcon],设置前缀图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindPrefixIcon { get; set; }
        /// <summary>
        /// nzSuffixIcon,设置后缀图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public AntDesignIcon SuffixIcon { get; set; }
        /// <summary>
        /// [nzSuffixIcon],设置后缀图标,自动创建&lt;nz-input-group&gt;&lt;/nz-input-group&gt;
        /// </summary>
        public string BindSuffixIcon { get; set; }
        /// <summary>
        /// 是否允许清除内容,设置为 true 将显示清除图标,注意:必须设置ngModel
        /// </summary>
        public bool AllowClear { get; set; }
        /// <summary>
        /// [nzAutocomplete],设置自动完成组件的引用
        /// </summary>
        public string Autocomplete { get; set; }
        /// <summary>
        /// 扩展属性,自动完成是否启用服务端搜索关键字,在搜索框输入时,设置查询参数的Keyword属性并发送请求,默认值：false
        /// </summary>
        public bool AutocompleteSearchKeyword { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (input),输入事件
        /// </summary>
        public string OnInput { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new InputService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new InputRender( _config );
        }
    }
}