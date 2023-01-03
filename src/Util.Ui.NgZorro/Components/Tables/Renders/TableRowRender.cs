using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表格行渲染器
    /// </summary>
    public class TableRowRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格行渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableRowRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = GetTableRowBuilder();
            builder.Config();
            return builder;
        }

        /// <summary>
        /// 获取表格行标签生成器
        /// </summary>
        private TableRowBuilder GetTableRowBuilder() {
            if( IsHeadRow )
                return new TableHeadRowBuilder( _config );
            return new TableBodyRowBuilder( _config );
        }

        /// <summary>
        /// 是否表头行
        /// </summary>
        private bool IsHeadRow => GetTableHeadShareConfig() != null;

        /// <summary>
        /// 获取表格头共享配置
        /// </summary>
        private TableHeadShareConfig GetTableHeadShareConfig() {
            return _config.GetValueFromItems<TableHeadShareConfig>();
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TableRowRender( _config.Copy() );
        }
    }
}