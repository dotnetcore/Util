using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Forms.Builders {
    /// <summary>
    /// 表单文本标签生成器
    /// </summary>
    public class FormTextBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化表单文本标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public FormTextBuilder( Config config ) : base( config,"nz-form-text" ) {
        }
    }
}
