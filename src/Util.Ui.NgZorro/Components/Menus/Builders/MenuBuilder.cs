using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单标签生成器
    /// </summary>
    public class MenuBuilder : TagBuilder {
        /// <summary>
        /// 初始化菜单标签生成器
        /// </summary>
        public MenuBuilder() : base( "ul" ) {
            base.Attribute( "nz-menu" );
        }
    }
}