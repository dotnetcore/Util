using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Empties.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Empties.Renders {
    /// <summary>
    /// 空状态渲染器
    /// </summary>
    public class EmptyRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化空状态渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public EmptyRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new EmptyBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new EmptyRender( _config.Copy() );
        }
    }
}