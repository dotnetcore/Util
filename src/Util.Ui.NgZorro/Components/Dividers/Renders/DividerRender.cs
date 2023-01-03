using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Dividers.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Dividers.Renders {
    /// <summary>
    /// 分隔线渲染器
    /// </summary>
    public class DividerRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化分隔线渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DividerRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DividerBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new DividerRender( _config.Copy() );
        }
    }
}