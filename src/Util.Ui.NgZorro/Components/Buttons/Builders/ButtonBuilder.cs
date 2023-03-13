using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Configs;

namespace Util.Ui.NgZorro.Components.Buttons.Builders {
    /// <summary>
    /// 按钮标签生成器
    /// </summary>
    public class ButtonBuilder : ButtonBuilderBase<ButtonBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化按钮标签生成器
        /// </summary>
        public ButtonBuilder( Config config ) : base( config,"button" ) {
            _config = config;
        }

        /// <summary>
        /// 设置提交按钮类型
        /// </summary>
        public ButtonBuilder IsSubmit() {
            AttributeIf( "type", "submit",_config.GetValue<bool?>( UiConst.IsSubmit ) == true,true );
            return this;
        }

        /// <summary>
        /// 设置按钮类型
        /// </summary>
        public ButtonBuilder ButtonType() {
            var formShareConfig = _config.GetValueFromItems<FormShareConfig>();
            if ( formShareConfig != null )
                Attribute( "type", "button" );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            ConfigButton();
            base.Config();
            IsSubmit().ButtonType();
        }
    }
}
