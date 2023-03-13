using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Display.Helpers;
using Util.Ui.NgZorro.Components.Label.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Label {
    /// <summary>
    /// 标签,生成的标签为&lt;span&gt;&lt;/span&gt;
    /// </summary>
    [HtmlTargetElement( "util-label" )]
    public class LabelTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 内容文本,支持i18n
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            LoadExpression();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var loader = new DisplayExpressionLoader();
            loader.Load( _config );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new LabelRender( _config );
        }
    }
}