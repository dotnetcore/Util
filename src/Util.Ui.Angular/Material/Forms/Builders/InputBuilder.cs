using Microsoft.AspNetCore.Mvc.Rendering;
using TagBuilder = Util.Ui.Builders.TagBuilder;

namespace Util.Ui.Material.Forms.Builders {
    /// <summary>
    /// 输入控件生成器
    /// </summary>
    public class InputBuilder : TagBuilder {
        /// <summary>
        /// 初始化输入控件生成器
        /// </summary>
        public InputBuilder() : base( "input", TagRenderMode.SelfClosing ) {
        }

        /// <summary>
        /// 设置为文本框
        /// </summary>
        public InputBuilder SetText() {
            AddAttribute( "matInput", "matInput" );
            return this;
        }
    }
}
