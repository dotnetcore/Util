using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Drawers.Builders;

namespace Util.Ui.NgZorro.Components.Drawers.Renders {
    /// <summary>
    /// 抽屉渲染器
    /// </summary>
    public class DrawerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化抽屉渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DrawerRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DrawerBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}