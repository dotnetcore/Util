using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Components.Popover;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Directives.Popconfirms;
using Util.Ui.NgZorro.Directives.Tooltips;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Base;

/// <summary>
/// 按钮标签生成器基类
/// </summary>
public abstract class ButtonBuilderBase<TBuilder> : AngularTagBuilder where TBuilder : ButtonBuilderBase<TBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 标识
    /// </summary>
    private readonly string _id;

    /// <summary>
    /// 初始化按钮标签生成器基类
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="tagName">标签名称，范例：div</param>
    /// <param name="renderMode">渲染模式</param>
    protected ButtonBuilderBase( Config config, string tagName, TagRenderMode renderMode = TagRenderMode.Normal ) : base( config, tagName, renderMode ) {
        _config = config;
        _id = Util.Helpers.Id.Create();
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
        AttributeIfNotEmpty( "[disabled]", _config.GetValue( UiConst.Disabled ) );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置危险按钮
    /// </summary>
    public virtual TBuilder Danger() {
        AttributeIfNotEmpty( "[nzDanger]", _config.GetValue( UiConst.Danger ) );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置加载状态
    /// </summary>
    public TBuilder Loading() {
        AttributeIfNotEmpty( "[nzLoading]", _config.GetValue( UiConst.Loading ) );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置幽灵按钮
    /// </summary>
    public TBuilder Ghost() {
        AttributeIfNotEmpty( "[nzGhost]", _config.GetValue( UiConst.Ghost ) );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Block按钮
    /// </summary>
    public TBuilder Block() {
        AttributeIfNotEmpty( "[nzBlock]", _config.GetValue( UiConst.Block ) );
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
    /// 配置图标
    /// </summary>
    public TBuilder Icon( AntDesignIcon icon ) {
        var iconBuilder = new IconBuilder( _config );
        iconBuilder.Type( icon );
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
        AttributeIfNotEmpty( "[nzClickHide]", _config.GetValue( UiConst.DropdownMenuClickHide ) );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置下拉菜单可见性
    /// </summary>
    public TBuilder DropdownMenuVisible() {
        AttributeIfNotEmpty( "[nzVisible]", _config.GetValue( UiConst.DropdownMenuVisible ) );
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
    /// 配置Upload文本
    /// </summary>
    public TBuilder TextUpload() {
        var value = _config.GetValue<bool?>( UiConst.TextUpload );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Upload );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Upload" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Download文本
    /// </summary>
    public TBuilder TextDownload() {
        var value = _config.GetValue<bool?>( UiConst.TextDownload );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Download );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Download" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Publish文本
    /// </summary>
    public TBuilder TextPublish() {
        var value = _config.GetValue<bool?>( UiConst.TextPublish );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Publish );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Publish" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Run文本
    /// </summary>
    public TBuilder TextRun() {
        var value = _config.GetValue<bool?>( UiConst.TextRun );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Run );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Run" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Start文本
    /// </summary>
    public TBuilder TextStart() {
        var value = _config.GetValue<bool?>( UiConst.TextStart );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Start );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Start" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Stop文本
    /// </summary>
    public TBuilder TextStop() {
        var value = _config.GetValue<bool?>( UiConst.TextStop );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Stop );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Stop" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Add文本
    /// </summary>
    public TBuilder TextAdd() {
        var value = _config.GetValue<bool?>( UiConst.TextAdd );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Add );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Add" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Remove文本
    /// </summary>
    public TBuilder TextRemove() {
        var value = _config.GetValue<bool?>( UiConst.TextRemove );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Remove );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Remove" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Open文本
    /// </summary>
    public TBuilder TextOpen() {
        var value = _config.GetValue<bool?>( UiConst.TextOpen );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Open );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Open" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Close文本
    /// </summary>
    public TBuilder TextClose() {
        var value = _config.GetValue<bool?>( UiConst.TextClose );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Close );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Close" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Send文本
    /// </summary>
    public TBuilder TextSend() {
        var value = _config.GetValue<bool?>( UiConst.TextSend );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Send );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Send" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Clear文本
    /// </summary>
    public TBuilder TextClear() {
        var value = _config.GetValue<bool?>( UiConst.TextClear );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Clear );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Clear" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Import文本
    /// </summary>
    public TBuilder TextImport() {
        var value = _config.GetValue<bool?>( UiConst.TextImport );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Import );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Import" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Export文本
    /// </summary>
    public TBuilder TextExport() {
        var value = _config.GetValue<bool?>( UiConst.TextExport );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Export );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Export" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Reset文本
    /// </summary>
    public TBuilder TextReset() {
        var value = _config.GetValue<bool?>( UiConst.TextReset );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Reset );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "Reset" );
        return (TBuilder)this;
    }

    /// <summary>
    /// 配置Unedit文本
    /// </summary>
    public TBuilder TextUnedit() {
        var value = _config.GetValue<bool?>( UiConst.TextUnedit );
        if ( value != true )
            return (TBuilder)this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Unedit );
            return (TBuilder)this;
        }
        _config.SetAttribute( UiConst.Text, "UnEdit" );
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
        if ( IsValidateForm() ) {
            var value = _config.GetValue( UiConst.OnClick );
            value = $"{GetButtonExtendId()}.validateForm();{value}";
            _config.SetAttribute( UiConst.OnClick, value );
        }
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
    /// 配置按钮
    /// </summary>
    protected TBuilder ConfigButton() {
        var popoverRender = new PopoverRender( _config, this );
        popoverRender.Config();
        EnableExtend();
        return Type().Size().Shape().Disabled().Danger().Loading().Ghost().Block().Icon().RouterLink()
            .DropdownMenu().DropdownMenuPlacement().DropdownMenuTrigger().DropdownMenuClickHide()
            .DropdownMenuVisible().DropdownMenuOverlayClassName().DropdownMenuOverlayStyle()
            .SpaceItem().Tooltip( _config ).Popconfirm( _config )
            .TextOk().TextCancel().TextCreate().TextUpdate().TextDelete()
            .TextDetail().TextQuery().TextRefresh().TextSave().TextEnable()
            .TextDisable().TextSelectAll().TextDeselectAll()
            .TextUpload().TextDownload().TextPublish().TextRun()
            .TextStart().TextStop().TextAdd().TextRemove()
            .TextOpen().TextClose().TextSend().TextClear()
            .TextImport().TextExport().TextReset().TextUnedit()
            .Text().OnClick().OnVisibleChange();
    }

    /// <summary>
    /// 启用扩展
    /// </summary>
    protected void EnableExtend() {
        if ( IsEnableExtend() == false )
            return;
        Attribute( "x-button-extend" );
        Attribute( $"#{GetButtonExtendId()}", "xButtonExtend" );
        DisableButton();
    }

    /// <summary>
    /// 是否启用扩展
    /// </summary>
    protected virtual bool IsEnableExtend() {
        if ( IsValidateForm() )
            return true;
        if ( IsScreenFull() )
            return true;
        return false;
    }

    /// <summary>
    /// 是否验证表单
    /// </summary>
    protected bool IsValidateForm() {
        return _config.GetValue<bool?>( UiConst.ValidateForm ) == true;
    }

    /// <summary>
    /// 是否全屏
    /// </summary>
    protected bool IsScreenFull() {
        return _config.Contains( UiConst.Fullscreen );
    }

    /// <summary>
    /// 获取按钮扩展指令标识
    /// </summary>
    protected string GetButtonExtendId() {
        var id = _config.GetValue( UiConst.Id );
        if ( id.IsEmpty() )
            id = _id;
        return $"x_{id}";
    }

    /// <summary>
    /// 表单验证禁用按钮
    /// </summary>
    protected void DisableButton() {
        if ( IsValidateForm() == false )
            return;
        var formShareConfig = _config.GetValueFromItems<FormShareConfig>();
        if ( formShareConfig == null )
            return;
        Attribute( "[disabled]", $"{GetButtonExtendId()}.isDisabled({formShareConfig.FormId}.invalid)" );
    }

    /// <summary>
    /// 获取全屏外层容器样式类名
    /// </summary>
    protected string GetFullscreenWrapClass() {
        var className = _config.GetValue( UiConst.FullscreenWrapClass );
        if (className.IsEmpty()) {
            if(_config.Contains( UiConst.FullscreenPack ) || _config.Contains( UiConst.FullscreenTitle ) )
                return ",null";
            return null;
        }
        return $",'{className}'";
    }

    /// <summary>
    /// 获取全屏包装
    /// </summary>
    protected string GetFullscreenPack() {
        var isPack = _config.GetBoolValue( UiConst.FullscreenPack );
        if (isPack.IsEmpty()) {
            if ( _config.Contains( UiConst.FullscreenTitle ) )
                return ",true";
            return null;
        }
        return $",{isPack}";
    }

    /// <summary>
    /// 获取全屏标题
    /// </summary>
    protected string GetFullscreenTitle() {
        var title = _config.GetValue( UiConst.FullscreenTitle );
        if ( title.IsEmpty() )
            return null;
        return $",'{title}'";
    }
}