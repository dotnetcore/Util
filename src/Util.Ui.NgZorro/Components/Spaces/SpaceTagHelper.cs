using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spaces.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Spaces {
    /// <summary>
    /// 间距,生成的标签为&lt;nz-space&gt;&lt;/nz-space&gt;
    /// </summary>
    [HtmlTargetElement( "util-space")]
    public class SpaceTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzSize,间距大小,可选值: 'small' | 'middle' | 'large'
        /// </summary>
        public SpaceSize Size { get; set; }
        /// <summary>
        /// [nzSize],间距大小,可选值: 'small' | 'middle' | 'large'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzDirection,间距方向,水平方向或垂直方向,默认水平方向,可选值: 'horizontal' | 'vertical'
        /// </summary>
        public SpaceDirection Direction { get; set; }
        /// <summary>
        /// [nzDirection],间距方向,水平方向或垂直方向,默认水平方向,可选值: 'horizontal' | 'vertical'
        /// </summary>
        public string BindDirection { get; set; }
        /// <summary>
        /// nzAlign,对齐方式,可选值: 'start' | 'end' | 'center' |  'baseline'
        /// </summary>
        public SpaceAlign Align { get; set; }
        /// <summary>
        /// [nzAlign],对齐方式,可选值: 'start' | 'end' | 'center' |  'baseline'
        /// </summary>
        public string BindAlign { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new SpaceRender( config );
        }
    }
}