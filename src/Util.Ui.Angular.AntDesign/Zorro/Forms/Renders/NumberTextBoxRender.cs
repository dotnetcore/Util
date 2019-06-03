using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 数字文本框渲染器
    /// </summary>
    public class NumberTextBoxRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 标签生成器
        /// </summary>
        private readonly TagBuilder _builder;

        /// <summary>
        /// 初始化数字文本框渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tagBuilder">标签生成器</param>
        public NumberTextBoxRender( Config config,TagBuilder tagBuilder ) {
            _config = config;
            _builder = tagBuilder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public void Config() {
            ConfigPrecision();
            ConfigAutoFocus();
            ConfigValidation();
        }

        /// <summary>
        /// 配置精度
        /// </summary>
        private void ConfigPrecision() {
            _builder.AddAttribute( "[precision]", _config.GetValue( UiConst.Precision ) );
            _builder.AddAttribute( "[step]", _config.GetValue( UiConst.Step ) );
        }

        /// <summary>
        /// 配置自动获取焦点
        /// </summary>
        private void ConfigAutoFocus() {
            _builder.AddAttribute( "[autoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
        }

        /// <summary>
        /// 配置验证
        /// </summary>
        private void ConfigValidation() {
            _builder.AddAttribute( "[min]", _config.GetValue( UiConst.Min ) );
            _builder.AddAttribute( "[max]", _config.GetValue( UiConst.Max ) );
        }
    }
}
