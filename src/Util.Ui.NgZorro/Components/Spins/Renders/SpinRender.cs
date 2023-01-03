using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spins.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Spins.Renders {
    /// <summary>
    /// 加载中渲染器
    /// </summary>
    public class SpinRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化加载中渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SpinRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SpinBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new SpinRender( _config.Copy() );
        }
    }
}