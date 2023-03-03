using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Images.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Images {
    /// <summary>
    /// 图片,生成的标签为&lt;img nz-image />
    /// </summary>
    [HtmlTargetElement( "util-image" )]
    public class ImageTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzSrc,图片地址
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// [nzSrc],图片地址
        /// </summary>
        public string BindSrc { get; set; }
        /// <summary>
        /// nzFallback,加载失败容错地址
        /// </summary>
        public string Fallback { get; set; }
        /// <summary>
        /// [nzFallback],加载失败容错地址
        /// </summary>
        public string BindFallback { get; set; }
        /// <summary>
        /// nzPlaceholder,加载占位地址
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceholder],加载占位地址
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// [nzDisablePreview],是否禁止预览,默认值: false
        /// </summary>
        public bool DisablePreview { get; set; }
        /// <summary>
        /// [nzDisablePreview],是否禁止预览,默认值: false
        /// </summary>
        public string BindDisablePreview { get; set; }
        /// <summary>
        /// [nzCloseOnNavigation],导航时是否关闭预览,默认值: false
        /// </summary>
        public bool CloseOnNavigation { get; set; }
        /// <summary>
        /// [nzCloseOnNavigation],导航时是否关闭预览,默认值: false
        /// </summary>
        public string BindCloseOnNavigation { get; set; }
        /// <summary>
        /// nzDirection,文字方向,可选值: 'ltr' | 'rtl',默认值: 'ltr'
        /// </summary>
        public Direction Direction { get; set; }
        /// <summary>
        /// [nzDirection],文字方向,可选值: 'ltr' | 'rtl',默认值: 'ltr'
        /// </summary>
        public string BindDirection { get; set; }
        /// <summary>
        /// width,宽度
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// [width],宽度
        /// </summary>
        public string BindWidth { get; set; }
        /// <summary>
        /// height,高度
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// [height],高度
        /// </summary>
        public string BindHeight { get; set; }
        /// <summary>
        /// alt,文本描述
        /// </summary>
        public string Alt { get; set; }
        /// <summary>
        /// [alt],文本描述
        /// </summary>
        public string BindAlt { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ImageRender( config );
        }
    }
}