using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Forms.Builders {
    /// <summary>
    /// 表单分隔符标签生成器
    /// </summary>
    public class FormSplitBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单分隔符标签生成器
        /// </summary>
        public FormSplitBuilder( Config config ) : base( config,"nz-form-split" ) {
            _config = config;
        }
    }
}
