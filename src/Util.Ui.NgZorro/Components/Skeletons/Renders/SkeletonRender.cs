using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Skeletons.Builders;

namespace Util.Ui.NgZorro.Components.Skeletons.Renders {
    /// <summary>
    /// 骨架屏渲染器
    /// </summary>
    public class SkeletonRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化骨架屏渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SkeletonRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SkeletonBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}