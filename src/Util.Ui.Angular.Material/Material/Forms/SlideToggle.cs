using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms {
    /// <summary>
    /// 滑动开关
    /// </summary>
    public class SlideToggle : ComponentBase, ISlideToggle {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化滑动开关
        /// </summary>
        public SlideToggle() {
            _config = new Config();
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
            return new SlideToggleRender( _config );
        }
    }
}