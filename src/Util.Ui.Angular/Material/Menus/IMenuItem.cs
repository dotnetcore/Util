using Util.Ui.Components;
using Util.Ui.Operations;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Navigation;

namespace Util.Ui.Material.Menus {
    /// <summary>
    /// 菜单项
    /// </summary>
    public interface IMenuItem : IComponent,ILabel,ISetIcon,IDisabled,ILink,IOnClick, IMenuId {
    }
}