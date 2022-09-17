using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单项标签生成器
    /// </summary>
    public class MenuItemBuilder : TagBuilder {
        /// <summary>
        /// 初始化菜单项标签生成器
        /// </summary>
        public MenuItemBuilder() : base( "li" ) {
            base.Attribute( "nz-menu-item" );
        }
    }
}