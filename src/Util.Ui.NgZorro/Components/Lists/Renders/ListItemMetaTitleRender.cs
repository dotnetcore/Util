using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists.Renders {
    /// <summary>
    /// 列表项元信息标题渲染器
    /// </summary>
    public class ListItemMetaTitleRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项元信息标题渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ListItemMetaTitleRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ListItemMetaTitleBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new ListItemMetaTitleRender( _config.Copy() );
        }
    }
}