using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Checkboxes.Builders {
    /// <summary>
    /// 复选框包装器标签生成器
    /// </summary>
    public class CheckboxWrapperBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框包装器标签生成器
        /// </summary>
        public CheckboxWrapperBuilder( Config config ) : base( "nz-checkbox-wrapper" ) {
            _config = config;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CheckboxWrapperBuilder Events() {
            AttributeIfNotEmpty( "(nzOnChange)", _config.GetValue( UiConst.OnChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Events();
        }
    }
}