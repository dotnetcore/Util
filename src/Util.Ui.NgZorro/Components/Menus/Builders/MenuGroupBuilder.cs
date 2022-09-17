using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单组标签生成器
    /// </summary>
    public class MenuGroupBuilder : TagBuilder {
        /// <summary>
        /// 初始化菜单组标签生成器
        /// </summary>
        public MenuGroupBuilder() : base( "li" ) {
            base.Attribute( "nz-menu-group" );
        }
    }
}