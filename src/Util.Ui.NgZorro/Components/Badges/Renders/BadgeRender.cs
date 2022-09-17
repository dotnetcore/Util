using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Badges.Builders;

namespace Util.Ui.NgZorro.Components.Badges.Renders {
    /// <summary>
    /// 徽标渲染器
    /// </summary>
    public class BadgeRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化徽标渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public BadgeRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new BadgeBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}