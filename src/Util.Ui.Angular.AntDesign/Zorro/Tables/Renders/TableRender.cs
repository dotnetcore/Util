using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Tables.Builders;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
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
            ConfigWrapperId( builder );
            ConfigQueryParam( builder );
            ConfigUrl( builder );
            ConfigSize( builder );
            ConfigAutoLoad( builder );
        }

        /// <summary>
        /// 配置表格包装器标识
        /// </summary>
        protected void ConfigWrapperId( TagBuilder builder ) {
            builder.AddAttribute( $"#{GetWrapperId()}" );
            builder.AddAttribute( "key", _config.GetValue( UiConst.Key ) );
        }

        /// <summary>
        /// 获取表格包装器标识
        /// </summary>
        private string GetWrapperId() {
            return $"{_config.Id}_wrapper";
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
            builder.AddAttribute( "[baseUrl]", _config.GetValue( AngularConst.BindBaseUrl ) );
            builder.AddAttribute( "[url]", _config.GetValue( AngularConst.BindUrl ) );
            builder.AddAttribute( "[deleteUrl]", _config.GetValue( AngularConst.BindDeleteUrl ) );
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
        /// 配置表格
        /// </summary>
        protected virtual void ConfigTable( TagBuilder builder ) {
            var tableBuilder = new TableBuilder();
            ConfigId( tableBuilder );
            ConfigTableDefault( tableBuilder );
            AddHead( tableBuilder );
            AddRow( tableBuilder );
            ConfigContent( tableBuilder );
            builder.AppendContent( tableBuilder );
        }

        /// <summary>
        /// 配置表格包装器标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            builder.AddAttribute( $"#{_config.Id}" );
        }

        /// <summary>
        /// 配置表格默认属性
        /// </summary>
        private void ConfigTableDefault( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "[nzData]", $"{GetWrapperId()}.dataSource" );
            tableBuilder.AddAttribute( "[nzTotal]", $"{GetWrapperId()}.totalCount" );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null || _config.Content.IsEmptyOrWhiteSpace )
                return;
            if( _config.AutoCreateRow )
                return;
            builder.AppendContent( _config.Content );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        protected virtual void AddHead( TagBuilder tableBuilder ) {
            if( _config.Titles.Count == 0 || _config.AutoCreateHead == false )
                return;
            var headBuilder = new TableHeadBuilder();
            tableBuilder.AppendContent( headBuilder );
            var rowBuilder = new TableRowBuilder();
            headBuilder.AppendContent( rowBuilder );
            foreach ( var title in _config.Titles ) {
                var headColumnBuilder = new TableHeadColumnBuilder();
                headColumnBuilder.Title( title );
                rowBuilder.AppendContent( headColumnBuilder );
            }
        }

        /// <summary>
        /// 添加行
        /// </summary>
        protected void AddRow( TagBuilder tableBuilder ) {
            if( _config.AutoCreateRow == false )
                return;
            var tableBodyBuilder = new TableBodyBuilder();
            var rowBuilder = new TableRowBuilder();
            rowBuilder.NgFor( $"let row of {_config.Id}.data" );
            rowBuilder.AppendContent( _config.Content );
            tableBodyBuilder.AppendContent( rowBuilder );
            tableBuilder.AppendContent( tableBodyBuilder );
        }
    }
}