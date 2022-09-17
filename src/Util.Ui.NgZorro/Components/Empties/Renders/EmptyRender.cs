using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Empties.Builders;

namespace Util.Ui.NgZorro.Components.Empties.Renders {
    /// <summary>
    /// 空状态渲染器
    /// </summary>
    public class EmptyRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化空状态渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public EmptyRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new EmptyBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}