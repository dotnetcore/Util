using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Avatars.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Avatars {
    /// <summary>
    /// 头像组,生成的标签为&lt;nz-avatar-group>&lt;/nz-avatar-group>
    /// </summary>
    [HtmlTargetElement( "util-avatar-group" )]
    public class AvatarGroupTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new AvatarGroupRender( config );
        }
    }
}