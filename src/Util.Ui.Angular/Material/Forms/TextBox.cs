using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms {
    /// <summary>
    /// 文本框
    /// </summary>
    public class TextBox : ComponentBase,ITextBox {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 初始化文本框
        /// </summary>
        /// <param name="gridConfig">栅格配置</param>
        public TextBox( IConfig gridConfig = null ) {
            _config = new TextBoxConfig();
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
            return new TextBoxRender( _config );
        }
    }
}
