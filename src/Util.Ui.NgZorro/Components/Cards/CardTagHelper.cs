using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Cards {
    /// <summary>
    /// 卡片,生成的标签为&lt;nz-card>&lt;/nz-card>
    /// </summary>
    [HtmlTargetElement( "util-card")]
    public class CardTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题,支持i18n
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题,类型: string|TemplateRef&lt;void>
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// [nzActions],卡片操作组，位置在卡片底部,类型: Array&lt;TemplateRef&lt;void>>
        /// </summary>
        public string Actions { get; set; }
        /// <summary>
        /// [nzBodyStyle],内容区域自定义样式,类型: { [key: string]: string }
        /// </summary>
        public string BodyStyle { get; set; }
        /// <summary>
        /// [nzBorderless],是否移除边框,默认值: false
        /// </summary>
        public bool Borderless { get; set; }
        /// <summary>
        /// [nzBorderless],是否移除边框,默认值: false
        /// </summary>
        public string BindBorderless { get; set; }
        /// <summary>
        /// [nzCover],卡片封面,类型: TemplateRef&lt;void>
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// [nzExtra],卡片右上角操作区域,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Extra { get; set; }
        /// <summary>
        /// [nzHoverable],鼠标滑过时是否可浮起,默认值: false
        /// </summary>
        public bool Hoverable { get; set; }
        /// <summary>
        /// [nzHoverable],鼠标滑过时是否可浮起,默认值: false
        /// </summary>
        public string BindHoverable { get; set; }
        /// <summary>
        /// [nzLoading],是否加载状态,默认值: false
        /// </summary>
        public bool Loading { get; set; }
        /// <summary>
        /// [nzLoading],是否加载状态,默认值: false
        /// </summary>
        public string BindLoading { get; set; }
        /// <summary>
        /// nzType,卡片类型，可设置为 inner 或 不设置
        /// </summary>
        public CardType Type { get; set; }
        /// <summary>
        /// [nzType],卡片类型，可设置为 inner 或 不设置
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// nzSize,卡片大小，可选值: 'default'|'small',默认值: 'default'
        /// </summary>
        public CardSize Size { get; set; }
        /// <summary>
        /// [nzSize],卡片大小，可选值: 'default'|'small',默认值: 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// (click),单击事件
        /// </summary>
        public string OnClick { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CardRender( config );
        }
    }
}