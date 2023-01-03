using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Steps.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Steps.Renders {
    /// <summary>
    /// 步骤条渲染器
    /// </summary>
    public class StepsRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化步骤条渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public StepsRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new StepsBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new StepsRender( _config.Copy() );
        }
    }
}