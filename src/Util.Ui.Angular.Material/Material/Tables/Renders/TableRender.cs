using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Builders;
using Util.Ui.Material.Tables.Configs;

namespace Util.Ui.Material.Tables.Renders {
    /// <summary>
    /// 表格渲染器
    /// </summary>
    public class TableRender : AngularRenderBase {
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
        protected virtual void Config( TagBuilder builder ) {
            ConfigTableWrapper( builder );
            ConfigTable( builder );
        }

        /// <summary>
        /// 配置表格包装器
        /// </summary>
        protected void ConfigTableWrapper( TagBuilder builder ) {
            ConfigId( builder );
            ConfigQueryParam( builder );
            ConfigUrl( builder );
            ConfigSize( builder );
            ConfigAutoLoad( builder );
            ConfigPageSizeOptions( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            builder.AddAttribute( $"#{_config.Id}" );
            builder.AddAttribute( "key", _config.GetValue( UiConst.Key ) );
        }

        /// <summary>
        /// 配置查询参数
        /// </summary>
        private void ConfigQueryParam( TagBuilder builder ) {
            builder.AddAttribute( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
        }

        /// <summary>
        /// 配置地址
        /// </summary>
        private void ConfigUrl( TagBuilder builder ) {
            builder.AddAttribute( "baseUrl", _config.GetValue( UiConst.BaseUrl ) );
            builder.AddAttribute( "url", _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "deleteUrl", _config.GetValue( UiConst.DeleteUrl ) );
        }

        /// <summary>
        /// 配置大小
        /// </summary>
        private void ConfigSize( TagBuilder builder ) {
            builder.AddAttribute( "maxHeight", _config.GetValue( UiConst.MaxHeight ) );
            builder.AddAttribute( "minHeight", _config.GetValue( UiConst.MinHeight ) );
            builder.AddAttribute( "width", _config.GetValue( UiConst.Width ) );
        }

        /// <summary>
        /// 配置自动加载
        /// </summary>
        private void ConfigAutoLoad( TagBuilder builder ) {
            builder.AddAttribute( "[autoLoad]", _config.GetBoolValue( UiConst.AutoLoad ) );
        }

        /// <summary>
        /// 配置分页长度列表
        /// </summary>
        private void ConfigPageSizeOptions( TagBuilder builder ) {
            var value = _config.GetValue( UiConst.PageSizeOptions );
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            if( value.StartsWith( "[" ) == false )
                value = $"[{value}]";
            builder.AddAttribute( "[pageSizeOptions]", value );
        }

        /// <summary>
        /// 配置表格
        /// </summary>
        protected virtual void ConfigTable( TagBuilder builder ) {
            var tableBuilder = new TableBuilder();
            ConfigTableDefault( tableBuilder );
            ConfigSort( tableBuilder );
            ConfigContent( tableBuilder );
            ConfigRow( tableBuilder );
            builder.AppendContent( tableBuilder );
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
        protected void ConfigSort( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "matSortDisableClear" );
            tableBuilder.AddAttribute( "matSortActive", _config.GetValue( UiConst.Sort ) );
            tableBuilder.AddAttribute( "matSortDirection", _config.GetValue( UiConst.SortDirection )?.ToLower() );
        }

        /// <summary>
        /// 配置行
        /// </summary>
        protected virtual void ConfigRow( TagBuilder tableBuilder ) {
            if( _config.Columns.Count == 0 || _config.AutoCreateRow == false )
                return;
            var columns = Util.Helpers.Json.ToJson( _config.Columns, true );
            AddHeaderRow( tableBuilder, columns );
            AddRow( tableBuilder, columns );
        }

        /// <summary>
        /// 添加行头
        /// </summary>
        protected virtual void AddHeaderRow( TagBuilder tableBuilder, string columns ) {
            var headerRowBuilder = new HeaderRowBuilder();
            headerRowBuilder.AddColumns( columns, _config.GetValue( UiConst.StickyHeader ).ToBoolOrNull() );
            tableBuilder.AppendContent( headerRowBuilder );
        }

        /// <summary>
        /// 添加行
        /// </summary>
        protected void AddRow( TagBuilder tableBuilder, string columns ) {
            var rowBuilder = new RowBuilder();
            rowBuilder.AddColumns( columns );
            rowBuilder.OnClick( _config.GetValue( UiConst.OnClickRow ) );
            rowBuilder.AddSelected( _config.Id );
            tableBuilder.AppendContent( rowBuilder );
        }
    }
}