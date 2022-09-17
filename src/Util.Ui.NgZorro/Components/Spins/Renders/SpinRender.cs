using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spins.Builders;

namespace Util.Ui.NgZorro.Components.Spins.Renders {
    /// <summary>
    /// 加载中渲染器
    /// </summary>
    public class SpinRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化加载中渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SpinRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SpinBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}