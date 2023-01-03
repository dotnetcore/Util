using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Paginations.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Paginations.Renders {
    /// <summary>
    /// 分页渲染器
    /// </summary>
    public class PaginationRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化分页渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PaginationRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PaginationBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new PaginationRender( _config.Copy() );
        }
    }
}