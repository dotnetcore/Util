using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.PageHeaders.Builders;

namespace Util.Ui.NgZorro.Components.PageHeaders.Renders {
    /// <summary>
    /// 页头标题渲染器
    /// </summary>
    public class PageHeaderTitleRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化页头标题渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderTitleRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PageHeaderTitleBuilder();
            ConfigContent( builder );
            return builder;
        }
    }
}