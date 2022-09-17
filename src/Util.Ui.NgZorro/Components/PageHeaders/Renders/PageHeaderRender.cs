using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.PageHeaders.Builders;

namespace Util.Ui.NgZorro.Components.PageHeaders.Renders {
    /// <summary>
    /// 页头渲染器
    /// </summary>
    public class PageHeaderRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化页头渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PageHeaderBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}