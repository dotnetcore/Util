using System;

namespace Util.Ui.Material.Tabs.Wrappers {
    /// <summary>
    /// 选项卡组包装器
    /// </summary>
    public interface ITabGroupWrapper : IDisposable {
        /// <summary>
        /// 选项卡
        /// </summary>
        ITab Tab();
    }
}