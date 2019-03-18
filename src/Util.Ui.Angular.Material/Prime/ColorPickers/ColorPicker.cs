using Util.Ui.Components;
using Util.Ui.Prime.ColorPickers.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Prime.ColorPickers {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public class ColorPicker : ComponentBase, IColorPicker {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new ColorPickerRender( OptionConfig );
        }
    }
}