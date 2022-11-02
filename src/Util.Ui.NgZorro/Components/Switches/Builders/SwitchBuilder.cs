using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Switches.Builders {
    /// <summary>
    /// 开关标签生成器
    /// </summary>
    public class SwitchBuilder : FormControlBuilderBase<SwitchBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化开关标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public SwitchBuilder( Config config ) : base( config, "nz-switch" ) {
            _config = config;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public SwitchBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置选中显示标签
        /// </summary>
        public SwitchBuilder CheckedChildren() {
            AttributeIfNotEmpty( "nzCheckedChildren", _config.GetValue( UiConst.CheckedChildren ) );
            AttributeIfNotEmpty( "[nzCheckedChildren]", _config.GetValue( AngularConst.BindCheckedChildren ) );
            return this;
        }

        /// <summary>
        /// 配置未选中显示标签
        /// </summary>
        public SwitchBuilder UncheckedChildren() {
            AttributeIfNotEmpty( "nzUnCheckedChildren", _config.GetValue( UiConst.UncheckedChildren ) );
            AttributeIfNotEmpty( "[nzUnCheckedChildren]", _config.GetValue( AngularConst.BindUncheckedChildren ) );
            return this;
        }

        /// <summary>
        /// 配置尺寸
        /// </summary>
        public SwitchBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<SwitchSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置加载状态
        /// </summary>
        public SwitchBuilder Loading() {
            AttributeIfNotEmpty( "[nzLoading]", _config.GetValue( UiConst.Loading ) );
            return this;
        }

        /// <summary>
        /// 配置用户控制状态
        /// </summary>
        public SwitchBuilder Control() {
            AttributeIfNotEmpty( "[nzControl]", _config.GetBoolValue( UiConst.Control ) );
            AttributeIfNotEmpty( "[nzControl]", _config.GetValue( AngularConst.BindControl ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public SwitchBuilder Events() {
            this.OnClick( _config );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().Disabled().CheckedChildren().UncheckedChildren()
                .Size().Loading().Control().Events();
        }
    }
}
