using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Configs;
using Util.Ui.Material.Buttons.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Buttons {
    /// <summary>
    /// 按钮
    /// </summary>
    public class Button : ComponentBase, IButton {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly ButtonConfig _config;

        /// <summary>
        /// 初始化按钮
        /// </summary>
        public Button() {
            _config = new ButtonConfig();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new ButtonRender( _config );
        }
    }
}
