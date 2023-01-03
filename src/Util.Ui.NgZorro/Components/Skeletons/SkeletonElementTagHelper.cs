using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Skeletons.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Skeletons {
    /// <summary>
    /// 骨架屏元素,生成的标签为&lt;nz-skeleton-element>&lt;/nz-skeleton-element>
    /// </summary>
    [HtmlTargetElement( "util-skeleton-element" )]
    public class SkeletonElementTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzType,骨架屏元素类型,可选值: 'button' | 'avatar' | 'input' | 'image'
        /// </summary>
        public SkeletonElementType Type { get; set; }
        /// <summary>
        /// [nzType],骨架屏元素类型,可选值: 'button' | 'avatar' | 'input' | 'image'
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// [nzActive],是否显示动画效果,类型: boolean,默认值: false
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// [nzActive],是否显示动画效果,类型: boolean,默认值: false
        /// </summary>
        public string BindActive { get; set; }
        /// <summary>
        /// nzSize,大小,可选值: 'large' | 'small' | 'default',默认值: 'default'
        /// </summary>
        public SkeletonElementSize Size { get; set; }
        /// <summary>
        /// [nzSize],大小,可选值: 'large' | 'small' | 'default',当 nzType="avatar" 时,可以设置为数字,默认值: 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzShape,形状,当 nzType="avatar" 时有效,可选值: 'circle' | 'square',默认值: 'square'
        /// </summary>
        public SkeletonElementShape Shape { get; set; }
        /// <summary>
        /// [nzShape],形状,当 nzType="avatar" 时有效,可选值: 'circle' | 'square',默认值: 'square'
        /// </summary>
        public string BindShape { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new SkeletonElementRender( config );
        }
    }
}