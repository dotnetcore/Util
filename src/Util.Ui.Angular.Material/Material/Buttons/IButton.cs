using System;
using Util.Ui.Components;
using Util.Ui.Operations.Navigation;

namespace Util.Ui.Material.Buttons {
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IButton : IComponent, IContainer<IDisposable>, Components.IButton, IMenuId {
    }
}