using Util.Ui.Components;
using Util.Ui.Material.Tabs.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Tabs {
    /// <summary>
    /// 链接选项卡
    /// </summary>
    public class TabLink : ComponentBase, ITabLink {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TabLinkRender( OptionConfig );
        }
    }
}