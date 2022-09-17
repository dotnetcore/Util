using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Builders;

namespace Util.Ui.NgZorro.Components.Layouts.Renders {
    /// <summary>
    /// 底部布局渲染器
    /// </summary>
    public class FooterRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化底部布局渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FooterRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FooterBuilder();
            ConfigContent( builder );
            return builder;
        }
    }
}