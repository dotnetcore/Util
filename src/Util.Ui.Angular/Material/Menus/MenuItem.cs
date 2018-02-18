using Util.Ui.Components;
using Util.Ui.Material.Menus.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Menus {
    /// <summary>
    /// 菜单项
    /// </summary>
    public class MenuItem : ComponentBase, IMenuItem {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new MenuItemRender( OptionConfig );
        }
    }
}