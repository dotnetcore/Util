using Util.Ui.Builders;

namespace Util.Ui.Zorro.Menus.Builders {
    /// <summary>
    /// NgZorro菜单生成器
    /// </summary>
    public class MenuBuilder : TagBuilder {
        /// <summary>
        /// 初始化菜单生成器
        /// </summary>
        public MenuBuilder() : base( "ul" ) {
            base.AddAttribute( "nz-menu" );
        }
    }
}