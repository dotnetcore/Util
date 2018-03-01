using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms {
    /// <summary>
    /// 复选框
    /// </summary>
    public class CheckBox : ComponentBase, ICheckBox {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框
        /// </summary>
        /// <param name="gridConfig">栅格配置</param>
        public CheckBox( IConfig gridConfig = null ) {
            _config = new Config();
            _config.AddColspan( gridConfig );
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
            return new CheckBoxRender( _config );
        }
    }
}
