using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单分隔线标签生成器
    /// </summary>
    public class MenuDividerBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化菜单分隔线标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuDividerBuilder( Config config ) : base( config, "li" ) {
            base.Attribute( "nz-menu-divider" );
        }
    }
}