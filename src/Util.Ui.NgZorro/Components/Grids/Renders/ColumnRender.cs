using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Grids.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Grids.Renders {
    /// <summary>
    /// 栅格列渲染器
    /// </summary>
    public class ColumnRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化栅格列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ColumnBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new ColumnRender( _config.Copy() );
        }
    }
}