using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Radios.Helpers;
using Util.Ui.NgZorro.Components.Radios.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Radios {
    /// <summary>
    /// 单选框,生成的标签为&lt;label nz-radio&gt;&lt;/label&gt;
    /// </summary>
    [HtmlTargetElement( "util-radio" )]
    public class RadioTagHelper : FormControlTagHelperBase {
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
        /// [nzAutoFocus],是否自动获取焦点
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动获取焦点
        /// </summary>
        public string BindAutoFocus { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzValue,值,与 nz-radio-group 配合使用
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// [nzValue],值,与 nz-radio-group 配合使用
        /// </summary>
        public string BindValue { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string BindLabel { get; set; }
        /// <summary>
        /// [data],数据源,扩展属性
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// url,Api地址,扩展属性
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// [url],Api地址,扩展属性
        /// </summary>
        public string BindUrl { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new RadioService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new RadioRender( _config );
        }
    }
}
