using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Directives.Popconfirms;
using Util.Ui.NgZorro.Directives.Tooltips;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 按钮标签生成器基类
    /// </summary>
    public abstract class ButtonBuilderBase<TBuilder> : AngularTagBuilder where TBuilder : ButtonBuilderBase<TBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化按钮标签生成器基类
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tagName">标签名称，范例：div</param>
        /// <param name="renderMode">渲染模式</param>
        protected ButtonBuilderBase( Config config, string tagName, TagRenderMode renderMode = TagRenderMode.Normal ) : base( config, tagName, renderMode ) {
            _config = config;
        }

        /// <summary>
        /// 配置按钮类型
        /// </summary>
        public TBuilder Type() {
            AttributeIfNotEmpty( "nzType", _config.GetValue<ButtonType?>( UiConst.Type )?.Description() );
            AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置按钮尺寸
        /// </summary>
        public TBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<ButtonSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置按钮形状
        /// </summary>
        public TBuilder Shape() {
            AttributeIfNotEmpty( "nzShape", _config.GetValue<ButtonShape?>( UiConst.Shape )?.Description() );
            AttributeIfNotEmpty( "[nzShape]", _config.GetValue( AngularConst.BindShape ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public TBuilder Disabled() {
            AttributeIfNotEmpty( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[disabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置危险按钮
        /// </summary>
        public virtual TBuilder Danger() {
            AttributeIfNotEmpty( "[nzDanger]", _config.GetBoolValue( UiConst.Danger ) );
            AttributeIfNotEmpty( "[nzDanger]", _config.GetValue( AngularConst.BindDanger ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置加载状态
        /// </summary>
        public TBuilder Loading() {
            AttributeIfNotEmpty( "[nzLoading]", _config.GetBoolValue( UiConst.Loading ) );
            AttributeIfNotEmpty( "[nzLoading]", _config.GetValue( AngularConst.BindLoading ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置幽灵按钮
        /// </summary>
        public TBuilder Ghost() {
            AttributeIfNotEmpty( "[nzGhost]", _config.GetBoolValue( UiConst.Ghost ) );
            AttributeIfNotEmpty( "[nzGhost]", _config.GetValue( AngularConst.BindGhost ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Block按钮
        /// </summary>
        public TBuilder Block() {
            AttributeIfNotEmpty( "[nzBlock]", _config.GetBoolValue( UiConst.Block ) );
            AttributeIfNotEmpty( "[nzBlock]", _config.GetValue( AngularConst.BindBlock ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        public TBuilder Icon() {
            if ( _config.Contains( UiConst.Icon ) == false )
                return (TBuilder)this;
            var iconBuilder = new IconBuilder( _config );
            iconBuilder.Icon();
            AppendContent( iconBuilder );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置路由链接
        /// </summary>
        public TBuilder RouterLink() {
            AttributeIfNotEmpty( "routerLink", _config.GetValue( AngularConst.RouterLink ) );
            AttributeIfNotEmpty( "[routerLink]", _config.GetValue( AngularConst.BindRouterLink ) );
            AttributeIfNotEmpty( "routerLinkActive", _config.GetValue( AngularConst.RouterLinkActive ) );
            AttributeIfNotEmpty( "[routerLinkActive]", _config.GetValue( AngularConst.BindRouterLinkActive ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置下拉菜单
        /// </summary>
        public TBuilder DropdownMenu() {
            var menu = _config.GetValue( UiConst.DropdownMenu );
            if ( string.IsNullOrWhiteSpace( menu ) )
                return (TBuilder)this;
            Attribute( "nz-dropdown" ).Attribute( "[nzDropdownMenu]", menu );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置下拉菜单弹出位置
        /// </summary>
        public TBuilder DropdownMenuPlacement() {
            AttributeIfNotEmpty( "nzPlacement", _config.GetValue<DropdownMenuPlacement?>( UiConst.DropdownMenuPlacement )?.Description() );
            AttributeIfNotEmpty( "[nzPlacement]", _config.GetValue( AngularConst.BindDropdownMenuPlacement ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置下拉菜单触发方式
        /// </summary>
        public TBuilder DropdownMenuTrigger() {
            AttributeIfNotEmpty( "nzTrigger", _config.GetValue<DropdownMenuTrigger?>( UiConst.DropdownMenuTrigger )?.Description() );
            AttributeIfNotEmpty( "[nzTrigger]", _config.GetValue( AngularConst.BindDropdownMenuTrigger ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置点击隐藏下拉菜单
        /// </summary>
        public TBuilder DropdownMenuClickHide() {
            AttributeIfNotEmpty( "[nzClickHide]", _config.GetBoolValue( UiConst.DropdownMenuClickHide ) );
            AttributeIfNotEmpty( "[nzClickHide]", _config.GetValue( AngularConst.BindDropdownMenuClickHide ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置下拉菜单可见性
        /// </summary>
        public TBuilder DropdownMenuVisible() {
            AttributeIfNotEmpty( "[nzVisible]", _config.GetBoolValue( UiConst.DropdownMenuVisible ) );
            AttributeIfNotEmpty( "[nzVisible]", _config.GetValue( AngularConst.BindDropdownMenuVisible ) );
            AttributeIfNotEmpty( "[(nzVisible)]", _config.GetValue( AngularConst.BindonDropdownMenuVisible ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置下拉菜单根元素类名
        /// </summary>
        public TBuilder DropdownMenuOverlayClassName() {
            AttributeIfNotEmpty( "nzOverlayClassName", _config.GetValue( UiConst.DropdownMenuOverlayClassName ) );
            AttributeIfNotEmpty( "[nzOverlayClassName]", _config.GetValue( AngularConst.BindDropdownMenuOverlayClassName ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置下拉菜单根元素样式
        /// </summary>
        public TBuilder DropdownMenuOverlayStyle() {
            AttributeIfNotEmpty( "[nzOverlayStyle]", _config.GetValue( UiConst.DropdownMenuOverlayStyle ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置间距项
        /// </summary>
        public TBuilder SpaceItem() {
            this.SpaceItem( _config );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片标题
        /// </summary>
        public TBuilder PopoverTitle() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverTitle ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverTitle ) ) == false );
            AttributeIfNotEmpty( "nzPopoverTitle", _config.GetValue( UiConst.PopoverTitle ) );
            AttributeIfNotEmpty( "[nzPopoverTitle]", _config.GetValue( AngularConst.BindPopoverTitle ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片内容
        /// </summary>
        public TBuilder PopoverContent() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverContent ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverContent ) ) == false );
            AttributeIfNotEmpty( "nzPopoverContent", _config.GetValue( UiConst.PopoverContent ) );
            AttributeIfNotEmpty( "[nzPopoverContent]", _config.GetValue( AngularConst.BindPopoverContent ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片触发行为
        /// </summary>
        public TBuilder PopoverTrigger() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverTrigger ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverTrigger ) ) == false );
            AttributeIfNotEmpty( "nzPopoverTrigger", _config.GetValue<PopoverTrigger?>( UiConst.PopoverTrigger )?.Description() );
            AttributeIfNotEmpty( "[nzPopoverTrigger]", _config.GetValue( AngularConst.BindPopoverTrigger ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片位置
        /// </summary>
        public TBuilder PopoverPlacement() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverPlacement ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverPlacement ) ) == false );
            AttributeIfNotEmpty( "nzPopoverPlacement", _config.GetValue<PopoverPlacement?>( UiConst.PopoverPlacement )?.Description() );
            AttributeIfNotEmpty( "[nzPopoverPlacement]", _config.GetValue( AngularConst.BindPopoverPlacement ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片定位元素
        /// </summary>
        public TBuilder PopoverOrigin() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverOrigin ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverOrigin ) ) == false );
            AttributeIfNotEmpty( "nzPopoverOrigin", _config.GetValue( UiConst.PopoverOrigin ) );
            AttributeIfNotEmpty( "[nzPopoverOrigin]", _config.GetValue( AngularConst.BindPopoverOrigin ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片是否可见
        /// </summary>
        public TBuilder PopoverVisible() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverVisible ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverVisible ) ) == false );
            AttributeIfNotEmpty( "[nzPopoverVisible]", _config.GetBoolValue( UiConst.PopoverVisible ) );
            AttributeIfNotEmpty( "[nzPopoverVisible]", _config.GetValue( AngularConst.BindPopoverVisible ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片移入延时
        /// </summary>
        public TBuilder PopoverMouseEnterDelay() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverMouseEnterDelay ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverMouseEnterDelay ) ) == false );
            AttributeIfNotEmpty( "nzPopoverMouseEnterDelay", _config.GetValue( UiConst.PopoverMouseEnterDelay ) );
            AttributeIfNotEmpty( "[nzPopoverMouseEnterDelay]", _config.GetValue( AngularConst.BindPopoverMouseEnterDelay ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片移出延时
        /// </summary>
        public TBuilder PopoverMouseLeaveDelay() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverMouseLeaveDelay ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverMouseLeaveDelay ) ) == false );
            AttributeIfNotEmpty( "nzPopoverMouseLeaveDelay", _config.GetValue( UiConst.PopoverMouseLeaveDelay ) );
            AttributeIfNotEmpty( "[nzPopoverMouseLeaveDelay]", _config.GetValue( AngularConst.BindPopoverMouseLeaveDelay ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片样式类名
        /// </summary>
        public TBuilder PopoverOverlayClassName() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverOverlayClassName ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverOverlayClassName ) ) == false );
            AttributeIfNotEmpty( "nzPopoverOverlayClassName", _config.GetValue( UiConst.PopoverOverlayClassName ) );
            AttributeIfNotEmpty( "[nzPopoverOverlayClassName]", _config.GetValue( AngularConst.BindPopoverOverlayClassName ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片样式
        /// </summary>
        public TBuilder PopoverOverlayStyle() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverOverlayStyle ) ) == false );
            AttributeIfNotEmpty( "[nzPopoverOverlayStyle]", _config.GetValue( UiConst.PopoverOverlayStyle ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片浮层是否带背景
        /// </summary>
        public TBuilder PopoverBackdrop() {
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverBackdrop ) ) == false );
            AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverBackdrop ) ) == false );
            AttributeIfNotEmpty( "[nzPopoverBackdrop]", _config.GetBoolValue( UiConst.PopoverBackdrop ) );
            AttributeIfNotEmpty( "[nzPopoverBackdrop]", _config.GetValue( AngularConst.BindPopoverBackdrop ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Ok文本
        /// </summary>
        public TBuilder TextOk() {
            var value = _config.GetValue<bool?>( UiConst.TextOk );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Ok );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Ok" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Cancel文本
        /// </summary>
        public TBuilder TextCancel() {
            var value = _config.GetValue<bool?>( UiConst.TextCancel );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Cancel );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Cancel" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Create文本
        /// </summary>
        public TBuilder TextCreate() {
            var value = _config.GetValue<bool?>( UiConst.TextCreate );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Create );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Create" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Update文本
        /// </summary>
        public TBuilder TextUpdate() {
            var value = _config.GetValue<bool?>( UiConst.TextUpdate );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Update );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Update" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Delete文本
        /// </summary>
        public TBuilder TextDelete() {
            var value = _config.GetValue<bool?>( UiConst.TextDelete );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Delete );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Delete" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Detail文本
        /// </summary>
        public TBuilder TextDetail() {
            var value = _config.GetValue<bool?>( UiConst.TextDetail );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Detail );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Detail" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Query文本
        /// </summary>
        public TBuilder TextQuery() {
            var value = _config.GetValue<bool?>( UiConst.TextQuery );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Query );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Query" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Refresh文本
        /// </summary>
        public TBuilder TextRefresh() {
            var value = _config.GetValue<bool?>( UiConst.TextRefresh );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Refresh );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Refresh" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Save文本
        /// </summary>
        public TBuilder TextSave() {
            var value = _config.GetValue<bool?>( UiConst.TextSave );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Save );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Save" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Enable文本
        /// </summary>
        public TBuilder TextEnable() {
            var value = _config.GetValue<bool?>( UiConst.TextEnable );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Enable );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Enable" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Disable文本
        /// </summary>
        public TBuilder TextDisable() {
            var value = _config.GetValue<bool?>( UiConst.TextDisable );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.Disable );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Disable" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Select All文本
        /// </summary>
        public TBuilder TextSelectAll() {
            var value = _config.GetValue<bool?>( UiConst.TextSelectAll );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.SelectAll );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Select All" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Deselect All文本
        /// </summary>
        public TBuilder TextDeselectAll() {
            var value = _config.GetValue<bool?>( UiConst.TextDeselectAll );
            if ( value != true )
                return (TBuilder)this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, I18nKeys.DeselectAll );
                return (TBuilder)this;
            }
            _config.SetAttribute( UiConst.Text, "Deselect All" );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        public TBuilder Text() {
            var options = NgZorroOptionsService.GetOptions();
            var text = _config.GetValue( UiConst.Text );
            if ( text.IsEmpty() )
                return (TBuilder)this;
            if ( options.EnableI18n ) {
                this.AppendContentByI18n( text );
                return (TBuilder)this;
            }
            AppendContent( text );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置单击事件
        /// </summary>
        public TBuilder OnClick() {
            this.OnClick( _config );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置下拉菜单显示状态变化事件
        /// </summary>
        public TBuilder OnVisibleChange() {
            AttributeIfNotEmpty( "(nzVisibleChange)", _config.GetValue( UiConst.OnVisibleChange ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置气泡卡片显示状态变化事件
        /// </summary>
        public TBuilder OnPopoverVisibleChange() {
            AttributeIfNotEmpty( "(nzPopoverVisibleChange)", _config.GetValue( UiConst.OnPopoverVisibleChange ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置按钮
        /// </summary>
        protected TBuilder ConfigButton() {
            return Type().Size().Shape().Disabled().Danger().Loading().Ghost().Block().Icon().RouterLink()
                .DropdownMenu().DropdownMenuPlacement().DropdownMenuTrigger().DropdownMenuClickHide()
                .DropdownMenuVisible().DropdownMenuOverlayClassName().DropdownMenuOverlayStyle()
                .SpaceItem()
                .PopoverTitle().PopoverContent().PopoverTrigger().PopoverPlacement().PopoverOrigin()
                .PopoverVisible().PopoverMouseEnterDelay().PopoverMouseLeaveDelay()
                .PopoverOverlayClassName().PopoverOverlayStyle().PopoverBackdrop()
                .Tooltip( _config ).Popconfirm( _config )
                .TextOk().TextCancel().TextCreate().TextUpdate().TextDelete()
                .TextDetail().TextQuery().TextRefresh().TextSave().TextEnable()
                .TextDisable().TextSelectAll().TextDeselectAll().Text()
                .OnClick().OnVisibleChange().OnPopoverVisibleChange()
                .ValidateForm();
        }

        /// <summary>
        /// 是否验证表单
        /// </summary>
        protected TBuilder ValidateForm() {
            var result = _config.GetValue<bool?>( UiConst.ValidateForm );
            if ( result == true )
                Attribute( "x-button-extend" );
            return (TBuilder)this;
        }
    }
}