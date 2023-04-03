using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Radios.Helpers;
using Util.Ui.NgZorro.Components.Radios.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Radios {
    /// <summary>
    /// 单选框组合,生成的标签为&lt;nz-radio-group&gt;&lt;/nz-radio-group&gt;
    /// </summary>
    [HtmlTargetElement( "util-radio-group" )]
    public class RadioGroupTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// nzName,单选框组合中的所有单选按钮的 name 属性
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [nzName],单选框组合中的所有单选按钮的 name 属性
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// nzSize,尺寸,可选值: 'large' | 'small' | 'default'
        /// </summary>
        public ButtonSize Size { get; set; }
        /// <summary>
        /// [nzSize],尺寸,可选值: 'large' | 'small' | 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzButtonStyle,风格样式,可选值: 'outline' | 'solid',默认值: 'outline'
        /// </summary>
        public RadioStyle ButtonStyle { get; set; }
        /// <summary>
        /// [nzButtonStyle],风格样式,可选值: 'outline' | 'solid',默认值: 'outline'
        /// </summary>
        public string BindButtonStyle { get; set; }
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
            base.ProcessBefore( context, output );
            _config = new Config( context, output );
            var service = new RadioGroupService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new RadioGroupRender( _config );
        }
    }
}