using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格标签生成器
    /// </summary>
    public class TableBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private TableShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TableBuilder( Config config ) : base( config, "nz-table" ) {
            _config = config;
            _shareConfig = GetShareConfig();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        public Config GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        public TableShareConfig GetShareConfig() {
            return _shareConfig ??= _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 创建表头标签生成器
        /// </summary>
        public virtual TableHeadBuilder CreateTableHeadBuilder() {
            return new TableHeadBuilder( _config.CopyRemoveId() );
        }

        /// <summary>
        /// 创建表格主体标签生成器
        /// </summary>
        public virtual TableBodyBuilder CreateTableBodyBuilder() {
            return new TableBodyBuilder( _config.CopyRemoveId() );
        }

        /// <summary>
        /// 表格扩展标识
        /// </summary>
        protected string ExtendId => _shareConfig.TableExtendId;

        /// <summary>
        /// 表格编辑扩展标识
        /// </summary>
        protected string EditId => _shareConfig.TableEditId;

        /// <summary>
        /// 配置数据
        /// </summary>
        public TableBuilder Data() {
            if ( _shareConfig.IsEnableExtend == false )
                return Data( _config.GetValue( UiConst.Data ) );
            Data( $"{ExtendId}.dataSource" );
            AttributeIfNotEmpty( "[dataSource]", _config.GetValue( UiConst.Data ) );
            return this;
        }

        /// <summary>
        /// 配置数据
        /// </summary>
        protected TableBuilder Data( string data ) {
            AttributeIfNotEmpty( "[nzData]", data );
            return this;
        }

        /// <summary>
        /// 配置是否前端分页
        /// </summary>
        public TableBuilder FrontPagination() {
            FrontPagination( _config.GetBoolValue( UiConst.FrontPagination ) );
            FrontPagination( _config.GetValue( AngularConst.BindFrontPagination ) );
            return this;
        }

        /// <summary>
        /// 配置是否前端分页
        /// </summary>
        protected TableBuilder FrontPagination( string value ) {
            AttributeIfNotEmpty( "[nzFrontPagination]", value );
            return this;
        }

        /// <summary>
        /// 配置数据总行数
        /// </summary>
        public TableBuilder Total() {
            Total( _config.GetValue( UiConst.Total ) );
            return this;
        }

        /// <summary>
        /// 配置数据总行数
        /// </summary>
        protected TableBuilder Total( string value ) {
            AttributeIfNotEmpty( "[nzTotal]", value );
            return this;
        }

        /// <summary>
        /// 配置当前页
        /// </summary>
        public TableBuilder PageIndex() {
            AttributeIfNotEmpty( "nzPageIndex", _config.GetValue( UiConst.PageIndex ) );
            AttributeIfNotEmpty( "[nzPageIndex]", _config.GetValue( AngularConst.BindPageIndex ) );
            BindonPageIndex( _config.GetValue( AngularConst.BindonPageIndex ) );
            return this;
        }

        /// <summary>
        /// 配置当前页
        /// </summary>
        protected TableBuilder BindonPageIndex( string value ) {
            AttributeIfNotEmpty( "[(nzPageIndex)]", value );
            return this;
        }

        /// <summary>
        /// 配置每页显示行数
        /// </summary>
        public TableBuilder PageSize() {
            AttributeIfNotEmpty( "nzPageSize", _config.GetValue( UiConst.PageSize ) );
            AttributeIfNotEmpty( "[nzPageSize]", _config.GetValue( AngularConst.BindPageSize ) );
            BindonPageSize( _config.GetValue( AngularConst.BindonPageSize ) );
            return this;
        }

        /// <summary>
        /// 配置每页显示行数
        /// </summary>
        protected TableBuilder BindonPageSize( string value ) {
            AttributeIfNotEmpty( "[(nzPageSize)]", value );
            return this;
        }

        /// <summary>
        /// 配置是否显示分页
        /// </summary>
        public TableBuilder ShowPagination() {
            ShowPagination( _config.GetBoolValue( UiConst.ShowPagination ) );
            ShowPagination( _config.GetValue( AngularConst.BindShowPagination ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示分页
        /// </summary>
        public TableBuilder ShowPagination( string value ) {
            AttributeIfNotEmpty( "[nzShowPagination]", value );
            return this;
        }

        /// <summary>
        /// 配置分页位置
        /// </summary>
        public TableBuilder PaginationPosition() {
            AttributeIfNotEmpty( "nzPaginationPosition", _config.GetValue<TablePaginationPosition?>( UiConst.PaginationPosition )?.Description() );
            AttributeIfNotEmpty( "[nzPaginationPosition]", _config.GetValue( AngularConst.BindPaginationPosition ) );
            return this;
        }

        /// <summary>
        /// 配置分页类型
        /// </summary>
        public TableBuilder PaginationType() {
            AttributeIfNotEmpty( "nzPaginationType", _config.GetValue<TablePaginationSize?>( UiConst.PaginationType )?.Description() );
            AttributeIfNotEmpty( "[nzPaginationType]", _config.GetValue( AngularConst.BindPaginationType ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示边框
        /// </summary>
        public TableBuilder Bordered() {
            AttributeIfNotEmpty( "[nzBordered]", _config.GetBoolValue( UiConst.Bordered ) );
            AttributeIfNotEmpty( "[nzBordered]", _config.GetValue( AngularConst.BindBordered ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示外边框
        /// </summary>
        public TableBuilder OuterBordered() {
            AttributeIfNotEmpty( "[nzOuterBordered]", _config.GetBoolValue( UiConst.OuterBordered ) );
            AttributeIfNotEmpty( "[nzOuterBordered]", _config.GetValue( AngularConst.BindOuterBordered ) );
            return this;
        }

        /// <summary>
        /// 配置列宽度配置
        /// </summary>
        public TableBuilder WidthConfig() {
            AttributeIfNotEmpty( "[nzWidthConfig]", _config.GetValue( UiConst.WidthConfig ) );
            return this;
        }

        /// <summary>
        /// 配置表格大小
        /// </summary>
        public TableBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<TableSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置是否加载状态
        /// </summary>
        public TableBuilder Loading() {
            return Loading( _config.GetValue( UiConst.Loading ) );
        }

        /// <summary>
        /// 配置是否加载状态
        /// </summary>
        public TableBuilder Loading( string value ) {
            AttributeIfNotEmpty( "[nzLoading]", value );
            return this;
        }

        /// <summary>
        /// 配置加载指示符
        /// </summary>
        public TableBuilder LoadingIndicator() {
            AttributeIfNotEmpty( "[nzLoadingIndicator]", _config.GetValue( UiConst.LoadingIndicator ) );
            return this;
        }

        /// <summary>
        /// 配置延迟显示加载时间
        /// </summary>
        public TableBuilder LoadingDelay() {
            AttributeIfNotEmpty( "nzLoadingDelay", _config.GetValue( UiConst.LoadingDelay ) );
            AttributeIfNotEmpty( "[nzLoadingDelay]", _config.GetValue( AngularConst.BindLoadingDelay ) );
            return this;
        }

        /// <summary>
        /// 配置滚动
        /// </summary>
        public TableBuilder Scroll() {
            Scroll( _config.GetValue( UiConst.Scroll ) );
            var scroll = new ScrollInfo( _config.GetValue( UiConst.ScrollWidth ), _config.GetValue( UiConst.ScrollHeight ) );
            if ( scroll.IsNull == false )
                Scroll( Util.Helpers.Json.ToJson( scroll, new JsonOptions { IgnoreNullValues = true, ToSingleQuotes = true } ) );
            return this;
        }

        /// <summary>
        /// 配置滚动
        /// </summary>
        public TableBuilder Scroll( string value ) {
            AttributeIfNotEmpty( "[nzScroll]", value );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public TableBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置底部
        /// </summary>
        public TableBuilder Footer() {
            AttributeIfNotEmpty( "nzFooter", _config.GetValue( UiConst.Footer ) );
            AttributeIfNotEmpty( "[nzFooter]", _config.GetValue( AngularConst.BindFooter ) );
            return this;
        }

        /// <summary>
        /// 配置无数据显示内容
        /// </summary>
        public TableBuilder NoResult() {
            AttributeIfNotEmpty( "nzNoResult", _config.GetValue( UiConst.NoResult ) );
            AttributeIfNotEmpty( "[nzNoResult]", _config.GetValue( AngularConst.BindNoResult ) );
            return this;
        }

        /// <summary>
        /// 配置每页行数选择列表
        /// </summary>
        public TableBuilder PageSizeOptions() {
            AttributeIfNotEmpty( "[nzPageSizeOptions]", _config.GetValue( UiConst.PageSizeOptions ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示快速跳转
        /// </summary>
        public TableBuilder ShowQuickJumper() {
            ShowQuickJumper( _config.GetBoolValue( UiConst.ShowQuickJumper ) );
            ShowQuickJumper( _config.GetValue( AngularConst.BindShowQuickJumper ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示快速跳转
        /// </summary>
        public TableBuilder ShowQuickJumper( string value ) {
            AttributeIfNotEmpty( "[nzShowQuickJumper]", value );
            return this;
        }

        /// <summary>
        /// 配置是否显示改变分页大小按钮
        /// </summary>
        public TableBuilder ShowSizeChanger() {
            ShowSizeChanger( _config.GetBoolValue( UiConst.ShowSizeChanger ) );
            ShowSizeChanger( _config.GetValue( AngularConst.BindShowSizeChanger ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示改变分页大小按钮
        /// </summary>
        protected TableBuilder ShowSizeChanger( string value ) {
            AttributeIfNotEmpty( "[nzShowSizeChanger]", value );
            return this;
        }

        /// <summary>
        /// 配置显示总行数和当前数据范围的模板
        /// </summary>
        public TableBuilder ShowTotal() {
            return ShowTotal( _config.GetValue( UiConst.ShowTotal ) );
        }

        /// <summary>
        /// 配置显示总行数和当前数据范围的模板
        /// </summary>
        protected TableBuilder ShowTotal( string value ) {
            AttributeIfNotEmpty( "[nzShowTotal]", value );
            return this;
        }

        /// <summary>
        /// 配置自定义页码结构
        /// </summary>
        public TableBuilder ItemRender() {
            AttributeIfNotEmpty( "[nzItemRender]", _config.GetValue( UiConst.ItemRender ) );
            return this;
        }

        /// <summary>
        /// 配置只有一页时是否隐藏分页器
        /// </summary>
        public TableBuilder HideOnSinglePage() {
            AttributeIfNotEmpty( "[nzHideOnSinglePage]", _config.GetBoolValue( UiConst.HideOnSinglePage ) );
            AttributeIfNotEmpty( "[nzHideOnSinglePage]", _config.GetValue( AngularConst.BindHideOnSinglePage ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示简单分页
        /// </summary>
        public TableBuilder Simple() {
            AttributeIfNotEmpty( "[nzSimple]", _config.GetBoolValue( UiConst.Simple ) );
            AttributeIfNotEmpty( "[nzSimple]", _config.GetValue( AngularConst.BindSimple ) );
            return this;
        }

        /// <summary>
        /// 配置是否模板模式
        /// </summary>
        public TableBuilder TemplateMode() {
            AttributeIfNotEmpty( "[nzTemplateMode]", _config.GetBoolValue( UiConst.TemplateMode ) );
            AttributeIfNotEmpty( "[nzTemplateMode]", _config.GetValue( AngularConst.BindTemplateMode ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动列高
        /// </summary>
        public TableBuilder VirtualItemSize() {
            AttributeIfNotEmpty( "nzVirtualItemSize", _config.GetValue( UiConst.VirtualItemSize ) );
            AttributeIfNotEmpty( "[nzVirtualItemSize]", _config.GetValue( AngularConst.BindVirtualItemSize ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动缓冲区最大高度
        /// </summary>
        public TableBuilder VirtualMaxBufferPx() {
            AttributeIfNotEmpty( "nzVirtualMaxBufferPx", _config.GetValue( UiConst.VirtualMaxBufferPx ) );
            AttributeIfNotEmpty( "[nzVirtualMaxBufferPx]", _config.GetValue( AngularConst.BindVirtualMaxBufferPx ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动缓冲区最小高度
        /// </summary>
        public TableBuilder VirtualMinBufferPx() {
            AttributeIfNotEmpty( "nzVirtualMinBufferPx", _config.GetValue( UiConst.VirtualMinBufferPx ) );
            AttributeIfNotEmpty( "[nzVirtualMinBufferPx]", _config.GetValue( AngularConst.BindVirtualMinBufferPx ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动跟踪函数
        /// </summary>
        public TableBuilder VirtualForTrackBy() {
            AttributeIfNotEmpty( "[nzVirtualForTrackBy]", _config.GetValue( UiConst.VirtualForTrackBy ) );
            return this;
        }

        /// <summary>
        /// 配置表格布局
        /// </summary>
        public TableBuilder Layout() {
            if ( _shareConfig.IsEnableEllipsis )
                _config.SetAttribute( UiConst.Layout, TableLayout.Fixed.Description() );
            AttributeIfNotEmpty( "nzTableLayout", _config.GetValue<TableLayout?>( UiConst.Layout )?.Description() );
            AttributeIfNotEmpty( "[nzTableLayout]", _config.GetValue( AngularConst.BindLayout ) );

            return this;
        }

        /// <summary>
        /// 配置查询参数
        /// </summary>
        public TableBuilder QueryParam() {
            AttributeIfNotEmpty( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
            return this;
        }

        /// <summary>
        /// 配置Api地址
        /// </summary>
        public TableBuilder Url() {
            AttributeIfNotEmpty( "url", _config.GetValue( UiConst.Url ) );
            AttributeIfNotEmpty( "[url]", _config.GetValue( AngularConst.BindUrl ) );
            return this;
        }

        /// <summary>
        /// 配置删除地址
        /// </summary>
        public TableBuilder DeleteUrl() {
            AttributeIfNotEmpty( "deleteUrl", _config.GetValue( UiConst.DeleteUrl ) );
            AttributeIfNotEmpty( "[deleteUrl]", _config.GetValue( AngularConst.BindDeleteUrl ) );
            return this;
        }

        /// <summary>
        /// 配置排序条件
        /// </summary>
        public TableBuilder Sort() {
            AttributeIfNotEmpty( "order", _config.GetValue( UiConst.Sort ) );
            AttributeIfNotEmpty( "[order]", _config.GetValue( AngularConst.BindSort ) );
            return this;
        }

        /// <summary>
        /// 配置自动加载
        /// </summary>
        public TableBuilder AutoLoad() {
            AttributeIfNotEmpty( "[autoLoad]", _config.GetBoolValue( UiConst.AutoLoad ) );
            return this;
        }

        /// <summary>
        /// 配置标识列表
        /// </summary>
        public TableBuilder ConfigKeys() {
            AttributeIfNotEmpty( "[checkedKeys]", _config.GetValue( UiConst.CheckedKeys ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TableBuilder Events() {
            return OnPageIndexChange( _config.GetValue( UiConst.OnPageIndexChange ) )
                .OnPageSizeChange( _config.GetValue( UiConst.OnPageSizeChange ) )
                .OnCurrentPageDataChange( _config.GetValue( UiConst.OnCurrentPageDataChange ) )
                .OnQueryParams( _config.GetValue( UiConst.OnQueryParams ) )
                .OnLoad( _config.GetValue( UiConst.OnLoad ) );
        }

        /// <summary>
        /// 页索引变化事件
        /// </summary>
        protected TableBuilder OnPageIndexChange( string value ) {
            AttributeIfNotEmpty( "(nzPageIndexChange)", value );
            return this;
        }

        /// <summary>
        /// 页大小变化事件
        /// </summary>
        protected TableBuilder OnPageSizeChange( string value ) {
            AttributeIfNotEmpty( "(nzPageSizeChange)", value );
            return this;
        }

        /// <summary>
        /// 当前页数据变化事件
        /// </summary>
        protected TableBuilder OnCurrentPageDataChange( string value ) {
            AttributeIfNotEmpty( "(nzCurrentPageDataChange)", value );
            return this;
        }

        /// <summary>
        /// 查询参数变化事件
        /// </summary>
        protected TableBuilder OnQueryParams( string value ) {
            AttributeIfNotEmpty( "(nzQueryParams)", value );
            return this;
        }

        /// <summary>
        /// 数据加载完成事件
        /// </summary>
        protected TableBuilder OnLoad( string value ) {
            AttributeIfNotEmpty( "(onLoad)", value );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            Data().FrontPagination().Total().PageIndex().PageSize()
                .ShowPagination().PaginationPosition().PaginationType()
                .Bordered().OuterBordered().WidthConfig().Size()
                .Loading().LoadingIndicator().LoadingDelay()
                .Scroll().Title().Footer().NoResult().PageSizeOptions()
                .ShowQuickJumper().ShowSizeChanger().ShowTotal()
                .ItemRender().HideOnSinglePage().Simple().TemplateMode()
                .VirtualItemSize().VirtualMaxBufferPx().VirtualMinBufferPx().VirtualForTrackBy()
                .Layout()
                .QueryParam().Url().DeleteUrl()
                .Sort().AutoLoad().ConfigKeys()
                .Events();
            ConfigAutoCreate();
            if ( _shareConfig.IsEnableExtend )
                ConfigExtend();
            ConfigEdit();
            ConfigContent();
        }

        /// <summary>
        /// 配置自动创建嵌套结构
        /// </summary>
        private void ConfigAutoCreate() {
            var service = new TableAutoCreateService( this );
            service.Init();
        }

        /// <summary>
        /// 配置表格扩展指令及默认属性
        /// </summary>
        protected virtual void ConfigExtend() {
            Attribute( "x-table-extend" );
            Attribute( $"#{ExtendId}", "xTableExtend" );
            ConfigDefault();
        }

        /// <summary>
        /// 配置默认属性
        /// </summary>
        protected void ConfigDefault() {
            Loading( $"{ExtendId}.loading" );
            ShowSizeChanger( "true" );
            ShowQuickJumper( "true" );
            FrontPagination( "false" );
            Total( $"{ExtendId}.total" );
            OnPageIndexChange( $"{ExtendId}.pageIndexChange($event)" );
            OnPageSizeChange( $"{ExtendId}.pageSizeChange($event)" );
            BindonPageIndex( $"{ExtendId}.queryParam.page" );
            BindonPageSize( $"{ExtendId}.queryParam.pageSize" );
            ShowTotal( _shareConfig.TotalTemplateId );
        }

        /// <summary>
        /// 配置编辑模式
        /// </summary>
        private void ConfigEdit() {
            if ( _shareConfig.IsEnableEdit == false )
                return;
            Attribute( "x-edit-table" );
            Attribute( $"#{EditId}", "xEditTable" );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent() {
            if ( _shareConfig.BodyAutoCreated )
                return;
            if ( _shareConfig.BodyRowAutoCreated )
                return;
            _config.Content.AppendTo( this );
        }
    }
}