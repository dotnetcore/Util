using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Badges.Builders {
    /// <summary>
    /// 徽标标签生成器
    /// </summary>
    public class BadgeBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化徽标标签生成器
        /// </summary>
        public BadgeBuilder( Config config ) : base( config,"nz-badge" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否独立使用
        /// </summary>
        public BadgeBuilder Standalone() {
            AttributeIfNotEmpty( "[nzStandalone]", _config.GetBoolValue( UiConst.Standalone ) );
            AttributeIfNotEmpty( "[nzStandalone]", _config.GetValue( AngularConst.BindStandalone ) );
            return this;
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        public BadgeBuilder Color() {
            AttributeIfNotEmpty( "nzColor", _config.GetValue( UiConst.Color ) );
            AttributeIfNotEmpty( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
            return this;
        }

        /// <summary>
        /// 配置显示的数字
        /// </summary>
        public BadgeBuilder Count() {
            AttributeIfNotEmpty( "nzCount", _config.GetValue( UiConst.Count ) );
            AttributeIfNotEmpty( "[nzCount]", _config.GetValue( AngularConst.BindCount ) );
            return this;
        }

        /// <summary>
        /// 配置是否不显示数字,仅显示小红点
        /// </summary>
        public BadgeBuilder Dot() {
            AttributeIfNotEmpty( "[nzDot]", _config.GetBoolValue( UiConst.Dot ) );
            AttributeIfNotEmpty( "[nzDot]", _config.GetValue( AngularConst.BindDot ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示小红点
        /// </summary>
        public BadgeBuilder ShowDot() {
            AttributeIfNotEmpty( "[nzShowDot]", _config.GetBoolValue( UiConst.ShowDot ) );
            AttributeIfNotEmpty( "[nzShowDot]", _config.GetValue( AngularConst.BindShowDot ) );
            return this;
        }

        /// <summary>
        /// 配置封顶数字
        /// </summary>
        public BadgeBuilder OverflowCount() {
            AttributeIfNotEmpty( "nzOverflowCount", _config.GetValue( UiConst.OverflowCount ) );
            AttributeIfNotEmpty( "[nzOverflowCount]", _config.GetValue( AngularConst.BindOverflowCount ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示0值
        /// </summary>
        public BadgeBuilder ShowZero() {
            AttributeIfNotEmpty( "[nzShowZero]", _config.GetBoolValue( UiConst.ShowZero ) );
            AttributeIfNotEmpty( "[nzShowZero]", _config.GetValue( AngularConst.BindShowZero ) );
            return this;
        }

        /// <summary>
        /// 配置状态
        /// </summary>
        public BadgeBuilder Status() {
            AttributeIfNotEmpty( "nzStatus", _config.GetValue<BadgeStatus?>( UiConst.Status )?.Description() );
            AttributeIfNotEmpty( "[nzStatus]", _config.GetValue( AngularConst.BindStatus ) );
            return this;
        }

        /// <summary>
        /// 配置状态点文本
        /// </summary>
        public BadgeBuilder Text() {
            AttributeIfNotEmpty( "nzText", _config.GetValue( UiConst.Text ) );
            AttributeIfNotEmpty( "[nzText]", _config.GetValue( AngularConst.BindText ) );
            return this;
        }

        /// <summary>
        /// 配置状态点提示
        /// </summary>
        public BadgeBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置状态点位置偏移
        /// </summary>
        public BadgeBuilder Offset() {
            AttributeIfNotEmpty( "[nzOffset]", _config.GetValue( UiConst.Offset ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Standalone().Color().Count().Dot().ShowDot().OverflowCount()
                .ShowZero().Status().Text().Title().Offset();
        }
    }
}