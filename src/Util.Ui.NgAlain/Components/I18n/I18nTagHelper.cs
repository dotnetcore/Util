using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.I18n.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.I18n {
    /// <summary>
    /// i18n多语言显示组件,支持显示html标签,生成的标签为&lt;span&gt;&lt;/span&gt;
    /// </summary>
    [HtmlTargetElement( "util-i18n", TagStructure = TagStructure.WithoutEndTag )]
    public class I18nTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 多语言配置键,范例: util.ok
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 传递给i18n管道的参数,范例: a:2,b:'c'
        /// </summary>
        public string Param { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new I18nRender( config );
        }
    }
}