using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 子菜单标签生成器
    /// </summary>
    public class SubMenuBuilder : TagBuilder {
        /// <summary>
        /// 初始化子菜单标签生成器
        /// </summary>
        public SubMenuBuilder() : base( "li" ) {
            base.Attribute( "nz-submenu" );
        }
    }
}