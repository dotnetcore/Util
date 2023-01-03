using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Avatars.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Avatars {
    /// <summary>
    /// 头像,生成的标签为&lt;nz-avatar>&lt;/nz-avatar>
    /// </summary>
    [HtmlTargetElement( "util-avatar" )]
    public class AvatarTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzIcon,设置头像图标
        /// </summary>
        public AntDesignIcon Icon { get; set; }
        /// <summary>
        /// [nzIcon],设置头像图标
        /// </summary>
        public string BindIcon { get; set; }
        /// <summary>
        /// nzShape,设置头像形状,可选值: 'circle' | 'square',默认值: 'circle'
        /// </summary>
        public AvatarShape Shape { get; set; }
        /// <summary>
        /// [nzShape],设置头像形状,可选值: 'circle' | 'square',默认值: 'circle'
        /// </summary>
        public string BindShape { get; set; }
        /// <summary>
        /// nzSize,设置头像大小,可选值: 'large' | 'small' | 'default' | number,默认值: 'default'
        /// </summary>
        public AvatarSize Size { get; set; }
        /// <summary>
        /// [nzSize],设置头像大小,可选值: 'large' | 'small' | 'default' | number,默认值: 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzGap,文本距离左右两侧边界,单位:像素,默认值: 4
        /// </summary>
        public double Gap { get; set; }
        /// <summary>
        /// [nzGap],文本距离左右两侧边界,单位:像素,默认值: 4
        /// </summary>
        public string BindGap { get; set; }
        /// <summary>
        /// nzSrc,图片头像地址
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// [nzSrc],图片头像地址
        /// </summary>
        public string BindSrc { get; set; }
        /// <summary>
        /// nzSrcSet,图片头像响应式资源地址
        /// </summary>
        public string SrcSet { get; set; }
        /// <summary>
        /// [nzSrcSet],图片头像响应式资源地址
        /// </summary>
        public string BindSrcSet { get; set; }
        /// <summary>
        /// nzAlt,图片无法显示时的替代文本
        /// </summary>
        public string Alt { get; set; }
        /// <summary>
        /// [nzAlt],图片无法显示时的替代文本
        /// </summary>
        public string BindAlt { get; set; }
        /// <summary>
        /// nzText,文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// [nzText],文本
        /// </summary>
        public string BindText { get; set; }
        /// <summary>
        /// (nzError),图片加载失败事件,调用 preventDefault 方法会阻止组件默认的 fallback 行为,类型: EventEmitter&lt;Event>
        /// </summary>
        public string OnError { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new AvatarRender( config );
        }
    }
}