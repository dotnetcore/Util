using Util.Properties;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Tables.Builders;
using Util.Ui.Zorro.Tables.Configs;
using TableHeadColumnBuilder = Util.Ui.Zorro.Tables.Builders.TableHeadColumnBuilder;

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
            ConfigSort( builder );
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
            return _config.WrapperId;
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
        /// 配置排序
        /// </summary>
        private void ConfigSort( TagBuilder builder ) {
            builder.AddAttribute( "sortKey", _config.GetValue( UiConst.Sort ) );
        }

        /// <summary>
        /// 配置表格
        /// </summary>
        protected virtual void ConfigTable( TagBuilder builder ) {
            var tableBuilder = new TableBuilder();
            ConfigTableDefault( tableBuilder );
            ConfigPage( tableBuilder );
            AddHead( tableBuilder );
            AddRow( tableBuilder );
            ConfigContent( tableBuilder );
            builder.AppendContent( tableBuilder );
        }

        /// <summary>
        /// 配置表格默认属性
        /// </summary>
        private void ConfigTableDefault( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( $"#{_config.Id}" );
            tableBuilder.AddAttribute( "[nzData]", $"{GetWrapperId()}.dataSource" );
            tableBuilder.AddAttribute( "[nzTotal]", $"{GetWrapperId()}.totalCount" );
            tableBuilder.AddAttribute( "[nzShowPagination]", $"{GetWrapperId()}.showPagination" );
            tableBuilder.AddAttribute( "[nzLoading]", $"{GetWrapperId()}.loading" );
        }

        /// <summary>
        /// 配置分页
        /// </summary>
        private void ConfigPage( TagBuilder tableBuilder ) {
            ConfigFrontPage( tableBuilder );
            ConfigShowSizeChanger( tableBuilder );
            ConfigOnPageSizeChange( tableBuilder );
            ConfigOnPageIndexChange( tableBuilder );
        }

        /// <summary>
        /// 配置前端分页
        /// </summary>
        private void ConfigFrontPage( TagBuilder tableBuilder ) {
            if ( _config.Contains( UiConst.FrontPage ) ) {
                tableBuilder.AddAttribute( "[nzFrontPagination]", _config.GetBoolValue( UiConst.FrontPage ) );
                return;
            }
            tableBuilder.AddAttribute( "[nzFrontPagination]", "false" );
        }

        /// <summary>
        /// 配置分页大小下拉框
        /// </summary>
        private void ConfigShowSizeChanger( TagBuilder tableBuilder ) {
            if( _config.Contains( UiConst.ShowSizeChanger ) ) {
                tableBuilder.AddAttribute( "[nzShowSizeChanger]", _config.GetBoolValue( UiConst.ShowSizeChanger ) );
                return;
            }
            tableBuilder.AddAttribute( "[nzShowSizeChanger]", "true" );
        }

        /// <summary>
        /// 配置分页大小变更事件
        /// </summary>
        private void ConfigOnPageSizeChange( TagBuilder tableBuilder ) {
            if( _config.Contains( UiConst.OnPageSizeChange ) ) {
                tableBuilder.AddAttribute( "(nzPageSizeChange)", _config.GetValue( UiConst.OnPageSizeChange ) );
                return;
            }
            tableBuilder.AddAttribute( "(nzPageSizeChange)", $"{GetWrapperId()}.pageSizeChange($event)" );
        }

        /// <summary>
        /// 配置页索引变更事件
        /// </summary>
        private void ConfigOnPageIndexChange( TagBuilder tableBuilder ) {
            if( _config.Contains( UiConst.OnPageIndexChange ) ) {
                tableBuilder.AddAttribute( "(nzPageIndexChange)", _config.GetValue( UiConst.OnPageIndexChange ) );
                return;
            }
            tableBuilder.AddAttribute( "(nzPageIndexChange)", $"{GetWrapperId()}.pageIndexChange($event)" );
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
            if( _config.Columns.Count == 0 || _config.AutoCreateHead == false )
                return;
            var headBuilder = new TableHeadBuilder();
            tableBuilder.AppendContent( headBuilder );
            AddSortChange( headBuilder );
            var rowBuilder = new TableRowBuilder();
            AddHeadColumns( rowBuilder );
            headBuilder.AppendContent( rowBuilder );
        }

        /// <summary>
        /// 添加排序变更事件处理
        /// </summary>
        private void AddSortChange( TableHeadBuilder headBuilder ) {
            if ( _config.IsSort == false )
                return;
            headBuilder.AddSortChange( $"{GetWrapperId()}.sort($event)" );
        }

        /// <summary>
        /// 添加标题列
        /// </summary>
        private void AddHeadColumns( TableRowBuilder rowBuilder ) {
            foreach( var column in _config.Columns ) {
                var headColumnBuilder = new TableHeadColumnBuilder();
                headColumnBuilder.AddWidth( column.Width );
                if ( column.IsCheckbox ) {
                    headColumnBuilder.AddCheckBox( _config.Id );
                }
                else {
                    headColumnBuilder.Title( column.Title );
                    headColumnBuilder.AddSort( column.GetSortKey() );
                }
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