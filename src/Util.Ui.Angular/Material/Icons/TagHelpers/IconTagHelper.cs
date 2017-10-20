using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Icons.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Icons.TagHelpers {
    /// <summary>
    /// 图标TagHelper
    /// </summary>
    public class IconTagHelper : TagHelperBase {
        /// <summary>
        /// Font Awesome图标
        /// </summary>
        public FontAwesomeIcon AspFontAwesomeIcon { get; set; }
        /// <summary>
        /// Material图标
        /// </summary>
        public MaterialIcon AspMaterialIcon { get; set; }
        /// <summary>
        /// 图标大小
        /// </summary>
        public IconSize AspIconSize { get; set; }
        /// <summary>
        /// 旋转
        /// </summary>
        public bool AspSpin { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new IconRender( new Config( context.Attributes, context.OtherAttributes, context.Content ) );
        }
    }
}
