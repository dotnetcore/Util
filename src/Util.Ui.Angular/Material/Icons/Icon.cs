using Util.Ui.Components;
using Util.Ui.Material.Icons.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Icons {
    /// <summary>
    /// 图标
    /// </summary>
    public class Icon : ComponentBase, IIcon {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new IconRender( OptionConfig );
        }
    }
}
