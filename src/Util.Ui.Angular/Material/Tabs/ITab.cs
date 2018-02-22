using System;
using Util.Ui.Components;
using Util.Ui.Operations;

namespace Util.Ui.Material.Tabs {
    /// <summary>
    /// 选项卡
    /// </summary>
    public interface ITab : IContainer<IDisposable>, ILabel, ISetIcon,IDisabled {
    }
}