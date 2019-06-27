using Util.Ui.Builders;

namespace Util.Ui.Zorro.Menus.Builders {
    /// <summary>
    /// NgZorro菜单项生成器
    /// </summary>
    public class MenuItemBuilder : TagBuilder {
        /// <summary>
        /// 初始化菜单项生成器
        /// </summary>
        public MenuItemBuilder() : base( "li" ) {
            base.AddAttribute( "nz-menu-item" );
        }
    }
}