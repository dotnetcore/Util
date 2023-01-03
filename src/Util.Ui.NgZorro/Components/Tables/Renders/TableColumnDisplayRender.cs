using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表格编辑列显示区域渲染器
    /// </summary>
    public class TableColumnDisplayRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格编辑列显示区域渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableColumnDisplayRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableColumnDisplayBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TableColumnDisplayRender( _config.Copy() );
        }
    }
}