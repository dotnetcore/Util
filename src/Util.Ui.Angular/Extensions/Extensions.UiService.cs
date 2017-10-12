using Util.Ui.Components;
using Util.Ui.Material.Forms;
using Util.Ui.Services;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 文本框
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ITextBox TextBox( this IUiService service ) {
            return new TextBox();
        }
    }
}
