using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.TreeTables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表头单元格渲染器
    /// </summary>
    public class TableHeadColumnRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表头列共享配置
        /// </summary>
        private readonly TableHeadColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表头单元格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="shareConfig">共享配置</param>
        public TableHeadColumnRender( Config config, TableHeadColumnShareConfig shareConfig = null ) {
            _config = config;
            _shareConfig = shareConfig ?? GetTableHeadColumnShareConfig();
        }

        /// <summary>
        /// 获取表头列共享配置
        /// </summary>
        protected TableHeadColumnShareConfig GetTableHeadColumnShareConfig() {
            return _config.GetValueFromItems<TableHeadColumnShareConfig>() ?? new TableHeadColumnShareConfig( GetTableShareConfig() );
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
            var builder = CreateTableHeadColumnBuilder();
            builder.Config();
            return builder;
        }

        /// <summary>
        /// 创建表头单元格标签生成器
        /// </summary>
        private TableHeadColumnBuilder CreateTableHeadColumnBuilder() {
            if ( _shareConfig.IsTreeTable )
                return new TreeTableHeadColumnBuilder( _config, _shareConfig );
            return new TableHeadColumnBuilder( _config, _shareConfig );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TableHeadColumnRender( _config.Copy(), new TableHeadColumnShareConfig( GetTableShareConfig() ) );
        }
    }
}