using Util.Ui.Components;
using Util.Ui.Material.Buttons.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Buttons {
    /// <summary>
    /// 链接
    /// </summary>
    public class Anchor : ComponentBase, IAnchor {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new AnchorRender( OptionConfig );
        }
    }
}