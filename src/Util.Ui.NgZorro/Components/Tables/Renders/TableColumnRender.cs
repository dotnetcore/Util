using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.TreeTables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表格单元格渲染器
    /// </summary>
    public class TableColumnRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格列共享配置
        /// </summary>
        private TableColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格单元格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="shareConfig">共享配置</param>
        public TableColumnRender( Config config, TableColumnShareConfig shareConfig = null ) {
            _config = config;
            _shareConfig = shareConfig ?? GetTableColumnShareConfig();
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        protected TableColumnShareConfig GetTableColumnShareConfig() {
            return _shareConfig ??= _config.GetValueFromItems<TableColumnShareConfig>() ?? new TableColumnShareConfig( GetTableShareConfig() );
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = CreateTableColumnBuilder();
            builder.Config();
            return builder;
        }

        /// <summary>
        /// 创建表格单元格标签生成器
        /// </summary>
        private TableColumnBuilder CreateTableColumnBuilder() {
            if( _shareConfig.IsTreeTable )
                return new TreeTableColumnBuilder( _config, _shareConfig );
            return new TableColumnBuilder( _config, _shareConfig );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TableColumnRender( _config.Copy(), new TableColumnShareConfig( GetTableShareConfig() ) );
        }
    }
}