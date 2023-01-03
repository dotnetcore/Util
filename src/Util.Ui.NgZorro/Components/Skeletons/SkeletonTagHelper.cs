using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Skeletons.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Skeletons {
    /// <summary>
    /// 骨架屏,生成的标签为&lt;nz-skeleton>&lt;/nz-skeleton>
    /// </summary>
    [HtmlTargetElement( "util-skeleton" )]
    public class SkeletonTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzActive],是否显示动画效果,类型: boolean,默认值: false
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// [nzActive],是否显示动画效果,类型: boolean,默认值: false
        /// </summary>
        public string BindActive { get; set; }
        /// <summary>
        /// [nzAvatar],是否显示头像占位图,类型: boolean | NzSkeletonAvatar,默认值: false
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// [nzLoading],是否加载状态, 值为 true 时，显示占位图,false则直接显示子组件,类型: boolean
        /// </summary>
        public string Loading { get; set; }
        /// <summary>
        /// [nzParagraph],是否显示段落占位图,类型: boolean | NzSkeletonParagraph,默认值: true
        /// </summary>
        public string Paragraph { get; set; }
        /// <summary>
        /// [nzTitle],是否显示标题占位图,类型: boolean | NzSkeletonTitle,默认值: true
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzRound],段落和标题是否显示圆角,类型: boolean,默认值: false
        /// </summary>
        public bool Round { get; set; }
        /// <summary>
        /// [nzRound],段落和标题是否显示圆角,类型: boolean,默认值: false
        /// </summary>
        public string BindRound { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new SkeletonRender( config );
        }
    }
}