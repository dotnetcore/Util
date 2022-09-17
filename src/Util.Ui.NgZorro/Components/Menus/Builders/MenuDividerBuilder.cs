using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单分隔线标签生成器
    /// </summary>
    public class MenuDividerBuilder : TagBuilder {
        /// <summary>
        /// 初始化菜单分隔线标签生成器
        /// </summary>
        public MenuDividerBuilder() : base( "li" ) {
            base.Attribute( "nz-menu-divider" );
        }
    }
}