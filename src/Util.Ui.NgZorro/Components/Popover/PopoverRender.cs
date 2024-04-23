using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Popover;

/// <summary>
/// 气泡卡片渲染器
/// </summary>
public class PopoverRender {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 标签生成器
    /// </summary>
    private readonly TagBuilder _builder;

    /// <summary>
    /// 初始化气泡卡片渲染器
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="builder">标签生成器</param>
    public PopoverRender( Config config, TagBuilder builder ) {
        _config = config;
        _builder = builder;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public void Config() {
        PopoverTitle().PopoverContent().PopoverTrigger().PopoverPlacement().PopoverOrigin()
            .PopoverVisible().PopoverMouseEnterDelay().PopoverMouseLeaveDelay()
            .PopoverOverlayClassName().PopoverOverlayStyle().PopoverBackdrop()
            .OnPopoverVisibleChange();
    }

    /// <summary>
    /// 配置气泡卡片标题
    /// </summary>
    public PopoverRender PopoverTitle() {
        _builder.AttributeIf( "nz-popover", _config.GetValue( UiConst.PopoverTitle ).IsEmpty() == false );
        _builder.AttributeIf( "nz-popover", _config.GetValue( AngularConst.BindPopoverTitle ).IsEmpty() == false );
        _builder.AttributeIfNotEmpty( "nzPopoverTitle", _config.GetValue( UiConst.PopoverTitle ) );
        _builder.AttributeIfNotEmpty( "[nzPopoverTitle]", _config.GetValue( AngularConst.BindPopoverTitle ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片内容
    /// </summary>
    public PopoverRender PopoverContent() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverContent ) ) == false );
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverContent ) ) == false );
        _builder.AttributeIfNotEmpty( "nzPopoverContent", _config.GetValue( UiConst.PopoverContent ) );
        _builder.AttributeIfNotEmpty( "[nzPopoverContent]", _config.GetValue( AngularConst.BindPopoverContent ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片触发行为
    /// </summary>
    public PopoverRender PopoverTrigger() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverTrigger ) ) == false );
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverTrigger ) ) == false );
        _builder.AttributeIfNotEmpty( "nzPopoverTrigger", _config.GetValue<PopoverTrigger?>( UiConst.PopoverTrigger )?.Description() );
        _builder.AttributeIfNotEmpty( "[nzPopoverTrigger]", _config.GetValue( AngularConst.BindPopoverTrigger ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片位置
    /// </summary>
    public PopoverRender PopoverPlacement() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverPlacement ) ) == false );
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverPlacement ) ) == false );
        _builder.AttributeIfNotEmpty( "nzPopoverPlacement", _config.GetValue<PopoverPlacement?>( UiConst.PopoverPlacement )?.Description() );
        _builder.AttributeIfNotEmpty( "[nzPopoverPlacement]", _config.GetValue( AngularConst.BindPopoverPlacement ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片定位元素
    /// </summary>
    public PopoverRender PopoverOrigin() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverOrigin ) ) == false );
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverOrigin ) ) == false );
        _builder.AttributeIfNotEmpty( "nzPopoverOrigin", _config.GetValue( UiConst.PopoverOrigin ) );
        _builder.AttributeIfNotEmpty( "[nzPopoverOrigin]", _config.GetValue( AngularConst.BindPopoverOrigin ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片是否可见
    /// </summary>
    public PopoverRender PopoverVisible() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverVisible ) ) == false );
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindonPopoverVisible ) ) == false );
        _builder.AttributeIfNotEmpty( "[nzPopoverVisible]", _config.GetValue( UiConst.PopoverVisible ) );
        _builder.AttributeIfNotEmpty( "[(nzPopoverVisible)]", _config.GetValue( AngularConst.BindonPopoverVisible ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片移入延时
    /// </summary>
    public PopoverRender PopoverMouseEnterDelay() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverMouseEnterDelay ) ) == false );
        _builder.AttributeIfNotEmpty( "[nzPopoverMouseEnterDelay]", _config.GetValue( UiConst.PopoverMouseEnterDelay ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片移出延时
    /// </summary>
    public PopoverRender PopoverMouseLeaveDelay() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverMouseLeaveDelay ) ) == false );
        _builder.AttributeIfNotEmpty( "[nzPopoverMouseLeaveDelay]", _config.GetValue( UiConst.PopoverMouseLeaveDelay ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片样式类名
    /// </summary>
    public PopoverRender PopoverOverlayClassName() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverOverlayClassName ) ) == false );
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( AngularConst.BindPopoverOverlayClassName ) ) == false );
        _builder.AttributeIfNotEmpty( "nzPopoverOverlayClassName", _config.GetValue( UiConst.PopoverOverlayClassName ) );
        _builder.AttributeIfNotEmpty( "[nzPopoverOverlayClassName]", _config.GetValue( AngularConst.BindPopoverOverlayClassName ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片样式
    /// </summary>
    public PopoverRender PopoverOverlayStyle() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverOverlayStyle ) ) == false );
        _builder.AttributeIfNotEmpty( "[nzPopoverOverlayStyle]", _config.GetValue( UiConst.PopoverOverlayStyle ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片浮层是否带背景
    /// </summary>
    public PopoverRender PopoverBackdrop() {
        _builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( _config.GetValue( UiConst.PopoverBackdrop ) ) == false );
        _builder.AttributeIfNotEmpty( "[nzPopoverBackdrop]", _config.GetValue( UiConst.PopoverBackdrop ) );
        return this;
    }

    /// <summary>
    /// 配置气泡卡片显示状态变化事件
    /// </summary>
    public PopoverRender OnPopoverVisibleChange() {
        _builder.AttributeIfNotEmpty( "(nzPopoverVisibleChange)", _config.GetValue( UiConst.OnPopoverVisibleChange ) );
        return this;
    }
}