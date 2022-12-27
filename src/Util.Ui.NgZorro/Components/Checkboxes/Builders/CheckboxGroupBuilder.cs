using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Checkboxes.Builders {
    /// <summary>
    /// 复选框组合标签生成器
    /// </summary>
    public class CheckboxGroupBuilder : FormControlBuilderBase<CheckboxGroupBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        
        /// <summary>
        /// 初始化复选框组合标签生成器
        /// </summary>
        public CheckboxGroupBuilder( Config config ) : base( config,"nz-checkbox-group" ) {
            _config = config;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public CheckboxGroupBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Disabled();
        }
    }
}
