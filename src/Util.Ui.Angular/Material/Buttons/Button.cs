using Util.Ui.Components;
using Util.Ui.Material.Buttons.Configs;
using Util.Ui.Material.Buttons.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Buttons {
    /// <summary>
    /// 按钮
    /// </summary>
    public class Button : ComponentBase<ButtonConfig>, IButton {
        /// <summary>
        /// 获取配置
        /// </summary>
        protected override ButtonConfig GetConfig() {
            return new ButtonConfig();
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new ButtonRender( OptionConfig );
        }
    }
}
