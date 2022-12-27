using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Alerts.Builders {
    /// <summary>
    /// 警告提示标签生成器
    /// </summary>
    public class AlertBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化警告提示标签生成器
        /// </summary>
        public AlertBuilder( Config config ) : base( config, "nz-alert" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否顶部公告
        /// </summary>
        public AlertBuilder Banner() {
            AttributeIfNotEmpty( "[nzBanner]", _config.GetBoolValue( UiConst.Banner ) );
            AttributeIfNotEmpty( "[nzBanner]", _config.GetValue( AngularConst.BindBanner ) );
            return this;
        }

        /// <summary>
        /// 配置是否可关闭
        /// </summary>
        public AlertBuilder Closeable() {
            AttributeIfNotEmpty( "[nzCloseable]", _config.GetBoolValue( UiConst.Closeable ) );
            AttributeIfNotEmpty( "[nzCloseable]", _config.GetValue( AngularConst.BindCloseable ) );
            return this;
        }

        /// <summary>
        /// 配置关闭按钮文字
        /// </summary>
        public AlertBuilder CloseText() {
            AttributeIfNotEmpty( "nzCloseText", _config.GetValue( UiConst.CloseText ) );
            AttributeIfNotEmpty( "[nzCloseText]", _config.GetValue( AngularConst.BindCloseText ) );
            return this;
        }

        /// <summary>
        /// 配置描述
        /// </summary>
        public AlertBuilder Description() {
            AttributeIfNotEmpty( "nzDescription", _config.GetValue( UiConst.Description ) );
            AttributeIfNotEmpty( "[nzDescription]", _config.GetValue( AngularConst.BindDescription ) );
            return this;
        }

        /// <summary>
        /// 配置提示内容
        /// </summary>
        public AlertBuilder Message() {
            AttributeIfNotEmpty( "nzMessage", _config.GetValue( UiConst.Message ) );
            BindMessage( _config.GetValue( AngularConst.BindMessage ) );
            return this;
        }

        /// <summary>
        /// 配置提示内容
        /// </summary>
        public AlertBuilder BindMessage( string value ) {
            AttributeIfNotEmpty( "[nzMessage]", value );
            return this;
        }

        /// <summary>
        /// 配置是否显示图标
        /// </summary>
        public AlertBuilder ShowIcon() {
            AttributeIfNotEmpty( "[nzShowIcon]", _config.GetBoolValue( UiConst.ShowIcon ) );
            AttributeIfNotEmpty( "[nzShowIcon]", _config.GetValue( AngularConst.BindShowIcon ) );
            return this;
        }

        /// <summary>
        /// 配置图标类型
        /// </summary>
        public AlertBuilder IconType() {
            AttributeIfNotEmpty( "nzIconType", _config.GetValue<AntDesignIcon?>( UiConst.IconType )?.Description() );
            AttributeIfNotEmpty( "[nzIconType]", _config.GetValue( AngularConst.BindIconType ) );
            return this;
        }

        /// <summary>
        /// 配置警告类型
        /// </summary>
        public AlertBuilder Type() {
            AttributeIfNotEmpty( "nzType", _config.GetValue<AlertType?>( UiConst.Type )?.Description() );
            AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public AlertBuilder Events() {
            AttributeIfNotEmpty( "(nzOnClose)", _config.GetValue( UiConst.OnClose ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            Banner().Closeable().CloseText().Description()
                .Message().ShowIcon().IconType().Type()
                .Events();
        }
    }
}