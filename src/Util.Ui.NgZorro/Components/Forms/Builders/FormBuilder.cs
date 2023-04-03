using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Forms.Builders {
    /// <summary>
    /// 表单标签生成器
    /// </summary>
    public class FormBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public FormBuilder( Config config ) : base( config,"form" ) {
            base.Attribute( "nz-form" );
            _config = config;
        }

        /// <summary>
        /// 配置布局方式
        /// </summary>
        public FormBuilder Layout() {
            AttributeIfNotEmpty( "nzLayout", _config.GetValue<FormLayout?>( UiConst.Layout )?.Description() );
            AttributeIfNotEmpty( "[nzLayout]", _config.GetValue( AngularConst.BindLayout ) );
            return this;
        }

        /// <summary>
        /// 配置自动提示
        /// </summary>
        public FormBuilder AutoTips() {
            AttributeIfNotEmpty( "[nzAutoTips]", _config.GetValue( UiConst.AutoTips ) );
            return this;
        }

        /// <summary>
        /// 配置禁用自动提示
        /// </summary>
        public FormBuilder DisableAutoTips() {
            AttributeIfNotEmpty( "[nzDisableAutoTips]", _config.GetValue( UiConst.DisableAutoTips ) );
            return this;
        }

        /// <summary>
        /// 配置不显示标签冒号
        /// </summary>
        public FormBuilder NoColon() {
            AttributeIfNotEmpty( "[nzNoColon]", _config.GetBoolValue( UiConst.NoColon ) );
            AttributeIfNotEmpty( "[nzNoColon]", _config.GetValue( AngularConst.BindNoColon ) );
            return this;
        }

        /// <summary>
        /// 配置标签提示图标
        /// </summary>
        public FormBuilder TooltipIcon() {
            AttributeIfNotEmpty( "nzTooltipIcon", _config.GetValue<AntDesignIcon?>( UiConst.TooltipIcon )?.Description() );
            AttributeIfNotEmpty( "[nzTooltipIcon]", _config.GetValue( AngularConst.BindTooltipIcon ) );
            return this;
        }

        /// <summary>
        /// 配置自动完成
        /// </summary>
        public FormBuilder AutoComplete() {
            var isAutoComplete = _config.GetValue<bool?>( UiConst.Autocomplete );
            if ( isAutoComplete == null )
                return this;
            if( isAutoComplete == true ) {
                Attribute( "autocomplete", "on" );
                return this;
            }
            Attribute( "autocomplete", "off" );
            return this;
        }

        /// <summary>
        /// 配置表单组
        /// </summary>
        public FormBuilder FormGroup() {
            AttributeIfNotEmpty( "[formGroup]", _config.GetValue( UiConst.FormGroup ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public FormBuilder Events() {
            AttributeIfNotEmpty( "(ngSubmit)", _config.GetValue( UiConst.OnSubmit ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Layout().AutoTips().DisableAutoTips().NoColon().TooltipIcon().AutoComplete().FormGroup().Events();
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( Config config ) {
            this.RawId( _config );
            if ( config.Contains( UiConst.Id ) )
                Attribute( $"#{_config.GetValue( UiConst.Id )}", "ngForm" );
        }
    }
}
