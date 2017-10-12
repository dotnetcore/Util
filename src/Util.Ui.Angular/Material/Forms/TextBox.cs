using Util.Ui.Components;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms {
    /// <summary>
    /// 文本框
    /// </summary>
    public class TextBox : ComponentBase<TextBoxConfig>,ITextBox {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TextBoxRender( OptionConfig );
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override TextBoxConfig GetConfig() {
            return new TextBoxConfig();
        }
    }
}
