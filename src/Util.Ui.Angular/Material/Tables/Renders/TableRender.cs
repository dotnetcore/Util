using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Builders;
using Util.Ui.Material.Tables.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Tables.Renders {
    /// <summary>
    /// 表格渲染器
    /// </summary>
    public class TableRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TableConfig _config;

        /// <summary>
        /// 初始化表格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableRender( TableConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableWrapperBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigQueryParam( builder );
            ConfigUrl( builder );
            ConfigTable( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            builder.AddAttribute( $"#{_config.Id}" );
        }

        /// <summary>
        /// 配置查询参数
        /// </summary>
        private void ConfigQueryParam( TagBuilder builder ) {
            builder.AddAttribute( "[queryParam]", _config.GetValue( UiConst.QueryParam ) );
        }

        /// <summary>
        /// 配置地址
        /// </summary>
        private void ConfigUrl( TagBuilder builder ) {
            builder.AddAttribute( "baseUrl", _config.GetValue( UiConst.BaseUrl ) );
        }

        /// <summary>
        /// 配置表格
        /// </summary>
        private void ConfigTable( TagBuilder builder ) {
            var tableBuilder = new TableBuilder();
            ConfigTableDefault( tableBuilder );
            ConfigSort( tableBuilder );
            ConfigContent( tableBuilder );
            ConfigRow( tableBuilder );
            builder.SetContent( tableBuilder );
        }

        /// <summary>
        /// 配置表格默认属性
        /// </summary>
        private void ConfigTableDefault( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "matSort" );
            tableBuilder.AddAttribute( "[dataSource]", $"{_config.Id}.dataSource" );
            tableBuilder.AddAttribute( "[style.min-height]", $"{_config.Id}.minHeight?{_config.Id}.minHeight+'px':null" );
            tableBuilder.AddAttribute( "[style.max-height]", $"{_config.Id}.maxHeight?{_config.Id}.maxHeight+'px':null" );
        }

        /// <summary>
        /// 配置排序
        /// </summary>
        private void ConfigSort( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "matSortDisableClear" );
            tableBuilder.AddAttribute( "matSortActive", _config.GetValue( UiConst.Sort ) );
            tableBuilder.AddAttribute( "matSortDirection", _config.GetValue( UiConst.SortDirection )?.ToLower() );
        }

        /// <summary>
        /// 配置行
        /// </summary>
        private void ConfigRow( TagBuilder tableBuilder ) {
            if ( _config.Columns == null || _config.Columns.Count == 0 )
                return;
            var columns = Util.Helpers.Json.ToJson( _config.Columns,true );
            AddHeaderRow( tableBuilder, columns );
            AddRow( tableBuilder, columns );
        }

        /// <summary>
        /// 添加行头
        /// </summary>
        private void AddHeaderRow( TagBuilder tableBuilder, string columns ) {
            var headerRowBuilder = new TableHeaderRowBuilder();
            headerRowBuilder.AddColumns( columns );
            tableBuilder.AppendContent( headerRowBuilder );
        }

        /// <summary>
        /// 添加行
        /// </summary>
        private void AddRow( TagBuilder tableBuilder, string columns ) {
            var rowBuilder = new TableRowBuilder();
            rowBuilder.AddColumns( columns );
            tableBuilder.AppendContent( rowBuilder );
        }
    }
}