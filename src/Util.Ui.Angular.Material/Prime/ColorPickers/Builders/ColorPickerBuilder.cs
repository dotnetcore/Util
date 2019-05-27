using Util.Ui.Builders;

namespace Util.Ui.Prime.ColorPickers.Builders {
    /// <summary>
    /// Prime颜色选择器生成器
    /// </summary>
    public class ColorPickerBuilder : TagBuilder {
        /// <summary>
        /// 初始化颜色选择器生成器
        /// </summary>
        public ColorPickerBuilder() : base( "p-colorPicker" ) {
        }
    }
}