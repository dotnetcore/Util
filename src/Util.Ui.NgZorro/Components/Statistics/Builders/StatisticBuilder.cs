using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Statistics.Builders {
    /// <summary>
    /// 统计标签生成器
    /// </summary>
    public class StatisticBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化统计标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public StatisticBuilder( Config config ) : base( config,"nz-statistic" ) {
            _config = config;
        }

        /// <summary>
        /// 配置前缀
        /// </summary>
        public StatisticBuilder Prefix() {
            AttributeIfNotEmpty( "nzPrefix", _config.GetValue( UiConst.Prefix ) );
            AttributeIfNotEmpty( "[nzPrefix]", _config.GetValue( AngularConst.BindPrefix ) );
            return this;
        }

        /// <summary>
        /// 配置后缀
        /// </summary>
        public StatisticBuilder Suffix() {
            AttributeIfNotEmpty( "nzSuffix", _config.GetValue( UiConst.Suffix ) );
            AttributeIfNotEmpty( "[nzSuffix]", _config.GetValue( AngularConst.BindSuffix ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public StatisticBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置数值
        /// </summary>
        public StatisticBuilder Value() {
            AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
            AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
            return this;
        }

        /// <summary>
        /// 配置样式
        /// </summary>
        public StatisticBuilder ValueStyle() {
            AttributeIfNotEmpty( "[nzValueStyle]", _config.GetValue( UiConst.ValueStyle ) );
            return this;
        }

        /// <summary>
        /// 配置模板
        /// </summary>
        public StatisticBuilder ValueTemplate() {
            AttributeIfNotEmpty( "[nzValueTemplate]", _config.GetValue( UiConst.ValueTemplate ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Prefix().Suffix().Title().Value().ValueStyle().ValueTemplate();
        }
    }
}