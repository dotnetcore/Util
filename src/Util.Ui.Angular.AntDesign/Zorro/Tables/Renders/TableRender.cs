using Util.Helpers;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
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
            ConfigEdit( builder );
            ConfigTableWrapperPage( builder );
            ConfigData( builder );
            ConfigUrl( builder );
            ConfigAutoLoad( builder );
            ConfigSort( builder );
            ConfigMultiple( builder );
            ConfigKeys( builder );
            ConfigTableWrapperEvents( builder );
        }

        /// <summary>
        /// 配置表格包装器标识
        /// </summary>
        protected void ConfigWrapperId( TagBuilder builder ) {
            builder.AddAttribute( $"#{GetWrapperId()}" );
        }

        /// <summary>
        /// 获取表格包装器标识
        /// </summary>
        protected string GetWrapperId() {
            return _config.WrapperId;
        }

        /// <summary>
        /// 配置编辑模式
        /// </summary>
        protected void ConfigEdit( TagBuilder builder ) {
            if( _config.IsEdit == false )
                return;
            builder.AddAttribute( "x-edit-table" );
            builder.AddAttribute( $"#{_config.EditTableId}", "utilEditTable" );
            ConfigDoubleClickStartEdit( builder );
        }

        /// <summary>
        /// 配置双击启动编辑
        /// </summary>
        protected void ConfigDoubleClickStartEdit( TagBuilder builder ) {
            builder.AddAttribute( "[dblClickStartEdit]", _config.GetBoolValue( UiConst.DoubleClickStartEdit ) );
        }

        /// <summary>
        /// 配置表格包装器分页信息
        /// </summary>
        private void ConfigTableWrapperPage( TagBuilder builder ) {
            builder.AddAttribute( "[showPagination]", _config.GetBoolValue( UiConst.ShowPagination ) );
            builder.AddAttribute( "[pageSizeOptions]", _config.GetValue( UiConst.PageSizeOptions ) );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigData( TagBuilder builder ) {
            if( _config.Contains( UiConst.Data ) == false )
                return;
            builder.AddAttribute( "[dataSource]", _config.GetValue( UiConst.Data ) );
            builder.AddAttribute( "[loading]", "false" );
        }

        /// <summary>
        /// 配置地址
        /// </summary>
        private void ConfigUrl( TagBuilder builder ) {
            builder.AddAttribute( "baseUrl", _config.GetValue( UiConst.BaseUrl ) );
            builder.AddAttribute( "url", _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "deleteUrl", _config.GetValue( UiConst.DeleteUrl ) );
            builder.AddAttribute( "saveUrl", _config.GetValue( UiConst.SaveUrl ) );
            builder.AddAttribute( "[baseUrl]", _config.GetValue( AngularConst.BindBaseUrl ) );
            builder.AddAttribute( "[url]", _config.GetValue( AngularConst.BindUrl ) );
            builder.AddAttribute( "[deleteUrl]", _config.GetValue( AngularConst.BindDeleteUrl ) );
            builder.AddAttribute( "[saveUrl]", _config.GetValue( AngularConst.BindSaveUrl ) );
            builder.AddAttribute( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
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
        /// 配置多选
        /// </summary>
        private void ConfigMultiple( TagBuilder builder ) {
            builder.AddAttribute( "[multiple]", _config.GetValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置标识列表
        /// </summary>
        private void ConfigKeys( TagBuilder builder ) {
            builder.AddAttribute( "[checkedKeys]", _config.GetValue( UiConst.CheckedKeys ) );
        }

        /// <summary>
        /// 配置表格包装器事件
        /// </summary>
        private void ConfigTableWrapperEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onLoad)", _config.GetValue( UiConst.OnLoad ) );
        }

        /// <summary>
        /// 配置表格
        /// </summary>
        protected virtual void ConfigTable( TagBuilder builder ) {
            var tableBuilder = new TableBuilder();
            builder.AppendContent( tableBuilder );
            ConfigTableDefault( tableBuilder );
            ConfigStyle( tableBuilder );
            ConfigScroll( tableBuilder );
            ConfigPage( tableBuilder );
            AddHead( tableBuilder );
            AddBody( tableBuilder );
            ConfigTotalTemplate( builder, tableBuilder );
            ConfigContent( tableBuilder );
        }

        /// <summary>
        /// 配置表格默认属性
        /// </summary>
        private void ConfigTableDefault( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( $"#{_config.Id}" );
            tableBuilder.AddAttribute( "[nzData]", $"{GetWrapperId()}.dataSource" );
            tableBuilder.AddAttribute( "[nzTotal]", $"{GetWrapperId()}.totalCount" );
            tableBuilder.AddAttribute( "[nzLoading]", $"{GetWrapperId()}.loading" );
        }

        /// <summary>
        /// 配置表格样式
        /// </summary>
        private void ConfigStyle( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "nzBordered", _config.GetBoolValue( UiConst.ShowBorder ) );
            tableBuilder.AddAttribute( "nzSize", _config.GetValue<TableSize?>( UiConst.Size )?.Description() );
        }

        /// <summary>
        /// 配置滚动
        /// </summary>
        private void ConfigScroll( TagBuilder tableBuilder ) {
            var scroll = new ScrollInfo( _config.GetValue( UiConst.ScrollWidth ), _config.GetValue( UiConst.ScrollHeight ) );
            if( scroll.IsNull )
                return;
            tableBuilder.AddAttribute( "[nzScroll]", Json.ToJson( scroll, true ) );
        }

        /// <summary>
        /// 配置分页
        /// </summary>
        private void ConfigPage( TagBuilder tableBuilder ) {
            ConfigShowPage( tableBuilder );
            ConfigPageInfo( tableBuilder );
            ConfigShowJumper( tableBuilder );
            ConfigFrontPage( tableBuilder );
            ConfigPageSizeOptions( tableBuilder );
            ConfigShowSizeChanger( tableBuilder );
            ConfigOnPageSizeChange( tableBuilder );
            ConfigOnPageIndexChange( tableBuilder );
        }

        /// <summary>
        /// 配置显示分页
        /// </summary>
        private void ConfigShowPage( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "[nzShowPagination]", $"{GetWrapperId()}.showPagination" );
        }

        /// <summary>
        /// 配置分页信息
        /// </summary>
        private void ConfigPageInfo( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "[(nzPageSize)]", $"{GetWrapperId()}.queryParam.pageSize" );
            tableBuilder.AddAttribute( "[(nzPageIndex)]", $"{GetWrapperId()}.queryParam.page" );
        }

        /// <summary>
        /// 配置显示跳转文本框
        /// </summary>
        private void ConfigShowJumper( TagBuilder tableBuilder ) {
            if( _config.Contains( UiConst.ShowJumper ) ) {
                tableBuilder.AddAttribute( "[nzShowQuickJumper]", _config.GetBoolValue( UiConst.ShowJumper ) );
                return;
            }
            tableBuilder.AddAttribute( "[nzShowQuickJumper]", "true" );
        }

        /// <summary>
        /// 配置前端分页
        /// </summary>
        private void ConfigFrontPage( TagBuilder tableBuilder ) {
            if( _config.Contains( UiConst.FrontPage ) ) {
                tableBuilder.AddAttribute( "[nzFrontPagination]", _config.GetBoolValue( UiConst.FrontPage ) );
                return;
            }
            tableBuilder.AddAttribute( "[nzFrontPagination]", "false" );
        }

        /// <summary>
        /// 配置分页长度下拉框
        /// </summary>
        private void ConfigPageSizeOptions( TagBuilder tableBuilder ) {
            if( _config.Contains( UiConst.PageSizeOptions ) == false )
                return;
            tableBuilder.AddAttribute( "[nzPageSizeOptions]", $"{GetWrapperId()}.pageSizeOptions" );
        }

        /// <summary>
        /// 配置是否显示分页大小
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
        protected void AddSortChange( TableHeadBuilder headBuilder ) {
            if( _config.IsSort == false )
                return;
            headBuilder.AddSortChange( $"{GetWrapperId()}.sort($event)" );
        }

        /// <summary>
        /// 添加标题列
        /// </summary>
        protected virtual void AddHeadColumns( TableRowBuilder rowBuilder ) {
            foreach( var column in _config.Columns ) {
                var headColumnBuilder = new TableHeadColumnBuilder();
                headColumnBuilder.AddWidth( column.Width );
                if( column.IsCheckbox ) {
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
        /// 添加内容
        /// </summary>
        protected void AddBody( TagBuilder tableBuilder ) {
            if( _config.AutoCreateRow == false )
                return;
            var tableBodyBuilder = new TableBodyBuilder();
            AddBody( tableBodyBuilder );
            tableBuilder.AppendContent( tableBodyBuilder );
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        protected virtual void AddBody( TableBodyBuilder tableBodyBuilder ) {
            var rowBuilder = new RowBuilder();
            rowBuilder.ConfigIterationVar( _config.Id );
            AddEditRow( rowBuilder );
            AddRowEvents( rowBuilder );
            AddSelectedRowBackgroundColor( rowBuilder );
            rowBuilder.AppendContent( _config.Content );
            tableBodyBuilder.AppendContent( rowBuilder );
        }

        /// <summary>
        /// 添加行编辑属性
        /// </summary>
        private void AddEditRow( RowBuilder rowBuilder ) {
            if ( _config.IsEdit == false )
                return;
            rowBuilder.ConfigEdit( _config.EditTableId, _config.RowId );
        }

        /// <summary>
        /// 添加行事件
        /// </summary>
        private void AddRowEvents( RowBuilder rowBuilder ) {
            rowBuilder.Click( _config.GetValue( UiConst.OnClickRow ) );
        }

        /// <summary>
        /// 添加选中行的背景色
        /// </summary>
        private void AddSelectedRowBackgroundColor( RowBuilder rowBuilder ) {
            if ( _config.Contains( UiConst.SelectedRowBackgroundColor ) == false )
                return;
            rowBuilder.Click( $"{_config.WrapperId}.selectRowOnly(row)" );
            rowBuilder.AddAttribute( "[style.background-color]", $"{_config.WrapperId}.isSelected(row)?{_config.GetValue( UiConst.SelectedRowBackgroundColor )}:''" );
        }

        /// <summary>
        /// 配置总行数模板
        /// </summary>
        protected void ConfigTotalTemplate( TagBuilder builder, TableBuilder tableBuilder ) {
            if( _config.GetValue<bool?>( UiConst.ShowTotal ) == false )
                return;
            var templateId = $"template_{_config.Id}";
            tableBuilder.AddAttribute( "[nzShowTotal]", templateId );
            var templateBuilder = CreateTotalTemplateBuilder( templateId, GetTotalTemplate() );
            builder.AppendContent( templateBuilder );
        }

        /// <summary>
        /// 创建总行数模板生成器
        /// </summary>
        private TemplateBuilder CreateTotalTemplateBuilder( string templateId, string content ) {
            var templateBuilder = new TemplateBuilder();
            templateBuilder.AddAttribute( $"#{templateId}" );
            templateBuilder.AddAttribute( "let-range", "range" );
            templateBuilder.AddAttribute( "let-total" );
            templateBuilder.AppendContent( content );
            return templateBuilder;
        }

        /// <summary>
        /// 获取总行数模板
        /// </summary>
        private string GetTotalTemplate() {
            var result = _config.GetValue( UiConst.TotalTemplate );
            if( result.IsEmpty() == false )
                return result;
            return TableConfig.TotalTemplate;
        }
    }
}