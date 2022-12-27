using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Inputs.Builders {
    /// <summary>
    /// 文本域计数标签生成器
    /// </summary>
    public class TextareaCountBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化文本域计数标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TextareaCountBuilder( Config config ) : base( config,"nz-textarea-count" ) {
            _config = config;
        }

        /// <summary>
        /// 配置数字提示最大值
        /// </summary>
        public TextareaCountBuilder MaxCharacterCount() {
            AttributeIfNotEmpty( "[nzMaxCharacterCount]", _config.GetValue( UiConst.MaxCharacterCount ) );
            AttributeIfNotEmpty( "[nzMaxCharacterCount]", _config.GetValue( AngularConst.BindMaxCharacterCount ) );
            return this;
        }

        /// <summary>
        /// 配置数字提示最大值计算函数
        /// </summary>
        public TextareaCountBuilder ComputeCharacterCount() {
            AttributeIfNotEmpty( "[nzComputeCharacterCount]", _config.GetValue( UiConst.ComputeCharacterCount ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            MaxCharacterCount().ComputeCharacterCount();
        }
    }
}