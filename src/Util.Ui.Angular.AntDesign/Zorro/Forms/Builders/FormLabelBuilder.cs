using Util.Ui.Builders;

namespace Util.Ui.Zorro.Forms.Builders {
    /// <summary>
    /// NgZorro表单标签生成器
    /// </summary>
    public class FormLabelBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro表单标签生成器
        /// </summary>
        public FormLabelBuilder( ) : base( "nz-form-label" ) {
        }

        /// <summary>
        /// 添加必填项
        /// </summary>
        /// <param name="value">值</param>
        public void AddRequired( string value ) {
            AddAttribute( "[nzRequired]", value );
        }

        /// <summary>
        /// 添加跨度
        /// </summary>
        /// <param name="value">值</param>
        public void AddSpan( string value ) {
            AddAttribute( "[nzSpan]", value );
        }
    }
}
