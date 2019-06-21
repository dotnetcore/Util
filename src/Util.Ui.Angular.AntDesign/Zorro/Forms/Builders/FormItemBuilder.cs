using Util.Ui.Builders;

namespace Util.Ui.Zorro.Forms.Builders {
    /// <summary>
    /// NgZorro表单项生成器
    /// </summary>
    public class FormItemBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro表单项生成器
        /// </summary>
        public FormItemBuilder( ) : base( "nz-form-item" ) {
        }

        /// <summary>
        /// 添加间隔
        /// </summary>
        /// <param name="value">值</param>
        public void AddGutter(string value) {
            AddAttribute( "[nzGutter]", value );
        }
    }
}
