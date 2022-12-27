using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Timelines.Builders {
    /// <summary>
    /// 时间轴节点标签生成器
    /// </summary>
    public class TimelineItemBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化时间轴节点标签生成器
        /// </summary>
        public TimelineItemBuilder( Config config ) : base( config,"nz-timeline-item" ) {
            _config = config;
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        public TimelineItemBuilder Color() {
            AttributeIfNotEmpty( "nzColor", _config.GetValue( UiConst.Color ) );
            AttributeIfNotEmpty( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
            return this;
        }

        /// <summary>
        /// 配置自定义时间轴点
        /// </summary>
        public TimelineItemBuilder Dot() {
            AttributeIfNotEmpty( "[nzDot]", _config.GetValue( UiConst.Dot ) );
            return this;
        }

        /// <summary>
        /// 配置自定义节点位置
        /// </summary>
        public TimelineItemBuilder Position() {
            AttributeIfNotEmpty( "nzPosition", _config.GetValue<TimelineItemPosition?>( UiConst.Position )?.Description() );
            AttributeIfNotEmpty( "[nzPosition]", _config.GetValue( AngularConst.BindPosition ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Color().Dot().Position();
        }
    }
}