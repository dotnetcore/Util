using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Containers.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Containers.Renders {
    /// <summary>
    /// ng-container容器渲染器
    /// </summary>
    public class ContainerRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化ng-container容器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ContainerRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ContainerBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new ContainerRender( _config.Copy() );
        }
    }
}