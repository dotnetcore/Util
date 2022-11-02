using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Statistics.Builders {
    /// <summary>
    /// 倒计时标签生成器
    /// </summary>
    public class CountdownBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化倒计时标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CountdownBuilder( Config config ) : base( config,"nz-countdown" ) {
            _config = config;
        }

        /// <summary>
        /// 配置格式化
        /// </summary>
        public CountdownBuilder Format() {
            AttributeIfNotEmpty( "nzFormat", _config.GetValue( UiConst.Format ) );
            AttributeIfNotEmpty( "[nzFormat]", _config.GetValue( AngularConst.BindFormat ) );
            return this;
        }

        /// <summary>
        /// 配置前缀
        /// </summary>
        public CountdownBuilder Prefix() {
            AttributeIfNotEmpty( "nzPrefix", _config.GetValue( UiConst.Prefix ) );
            AttributeIfNotEmpty( "[nzPrefix]", _config.GetValue( AngularConst.BindPrefix ) );
            return this;
        }

        /// <summary>
        /// 配置后缀
        /// </summary>
        public CountdownBuilder Suffix() {
            AttributeIfNotEmpty( "nzSuffix", _config.GetValue( UiConst.Suffix ) );
            AttributeIfNotEmpty( "[nzSuffix]", _config.GetValue( AngularConst.BindSuffix ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public CountdownBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置值
        /// </summary>
        public CountdownBuilder Value() {
            AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
            AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
            return this;
        }

        /// <summary>
        /// 配置模板
        /// </summary>
        public CountdownBuilder ValueTemplate() {
            AttributeIfNotEmpty( "[nzValueTemplate]", _config.GetValue( UiConst.ValueTemplate ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CountdownBuilder Events() {
            AttributeIfNotEmpty( "(nzCountdownFinish)", _config.GetValue( UiConst.OnCountdownFinish ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Format().Prefix().Suffix().Title().Value().ValueTemplate().Events();
        }
    }
}