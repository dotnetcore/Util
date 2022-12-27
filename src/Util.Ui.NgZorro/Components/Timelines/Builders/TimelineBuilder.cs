using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Timelines.Builders {
    /// <summary>
    /// 时间轴标签生成器
    /// </summary>
    public class TimelineBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化时间轴标签生成器
        /// </summary>
        public TimelineBuilder( Config config ) : base( config,"nz-timeline" ) {
            _config = config;
        }

        /// <summary>
        /// 配置幽灵节点
        /// </summary>
        public TimelineBuilder Pending() {
            AttributeIfNotEmpty( "nzPending", _config.GetValue( UiConst.Pending ) );
            AttributeIfNotEmpty( "[nzPending]", _config.GetValue( AngularConst.BindPending ) );
            return this;
        }

        /// <summary>
        /// 配置幽灵节点时间图点
        /// </summary>
        public TimelineBuilder PendingDot() {
            AttributeIfNotEmpty( "nzPendingDot", _config.GetValue( UiConst.PendingDot ) );
            AttributeIfNotEmpty( "[nzPendingDot]", _config.GetValue( AngularConst.BindPendingDot ) );
            return this;
        }

        /// <summary>
        /// 配置是否倒序排列
        /// </summary>
        public TimelineBuilder Reverse() {
            AttributeIfNotEmpty( "[nzReverse]", _config.GetBoolValue( UiConst.Reverse ) );
            AttributeIfNotEmpty( "[nzReverse]", _config.GetValue( AngularConst.BindReverse ) );
            return this;
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        public TimelineBuilder Mode() {
            AttributeIfNotEmpty( "nzMode", _config.GetValue<TimelineMode?>( UiConst.Mode )?.Description() );
            AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Pending().PendingDot().Reverse().Mode();
        }
    }
}