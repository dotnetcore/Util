using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Rates.Builders {
    /// <summary>
    /// 评分标签生成器
    /// </summary>
    public class RateBuilder : FormControlBuilderBase<RateBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化评分标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public RateBuilder( Config config ) : base( config, "nz-rate" ) {
            _config = config;
        }

        /// <summary>
        /// 配置允许清除
        /// </summary>
        public RateBuilder AllowClear() {
            AttributeIfNotEmpty( "[nzAllowClear]", _config.GetBoolValue( UiConst.AllowClear ) );
            AttributeIfNotEmpty( "[nzAllowClear]", _config.GetValue( AngularConst.BindAllowClear ) );
            return this;
        }

        /// <summary>
        /// 配置允许半选
        /// </summary>
        public RateBuilder AllowHalf() {
            AttributeIfNotEmpty( "[nzAllowHalf]", _config.GetBoolValue( UiConst.AllowHalf ) );
            AttributeIfNotEmpty( "[nzAllowHalf]", _config.GetValue( AngularConst.BindAllowHalf ) );
            return this;
        }

        /// <summary>
        /// 配置自动聚焦
        /// </summary>
        public RateBuilder AutoFocus() {
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( AngularConst.BindAutoFocus ) );
            return this;
        }

        /// <summary>
        /// 配置自定义字符
        /// </summary>
        public RateBuilder Character() {
            AttributeIfNotEmpty( "[nzCharacter]", _config.GetValue( UiConst.Character ) );
            return this;
        }

        /// <summary>
        /// 配置数量
        /// </summary>
        public RateBuilder Count() {
            AttributeIfNotEmpty( "nzCount", _config.GetValue( UiConst.Count ) );
            AttributeIfNotEmpty( "[nzCount]", _config.GetValue( AngularConst.BindCount ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public RateBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置提示信息
        /// </summary>
        public RateBuilder Tooltips() {
            AttributeIfNotEmpty( "[nzTooltips]", _config.GetValue( UiConst.Tooltips ) );
            return this;
        }
        
        /// <summary>
        /// 配置事件
        /// </summary>
        public RateBuilder Events() {
            AttributeIfNotEmpty( "(nzOnFocus)", _config.GetValue( UiConst.OnFocus ) );
            AttributeIfNotEmpty( "(nzOnBlur)", _config.GetValue( UiConst.OnBlur ) );
            AttributeIfNotEmpty( "(nzOnHoverChange)", _config.GetValue( UiConst.OnHoverChange ) );
            AttributeIfNotEmpty( "(nzOnKeyDown)", _config.GetValue( UiConst.OnKeydown ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().AllowClear().AllowHalf().AutoFocus()
                .Character().Count().Disabled().Tooltips().Events();
        }
    }
}