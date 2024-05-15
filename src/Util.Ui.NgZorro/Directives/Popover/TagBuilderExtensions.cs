using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Directives.Popover;

/// <summary>
/// 气泡框扩展
/// </summary>
public static class TagBuilderExtensions {
    /// <summary>
    /// 气泡框指令扩展
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="config">配置</param>
    public static TBuilder Popover<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
        builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( config.GetValue( UiConst.PopoverContent ) ) == false );
        builder.AttributeIf( "nz-popover", string.IsNullOrWhiteSpace( config.GetValue( AngularConst.BindPopoverContent ) ) == false );
        builder.PopoverTitle( config.GetValue( UiConst.PopoverTitle ) );
        builder.BindPopoverTitle( config.GetValue( AngularConst.BindPopoverTitle ) );
        builder.AttributeIfNotEmpty( "nzPopoverContent", config.GetValue( UiConst.PopoverContent ) );
        builder.AttributeIfNotEmpty( "[nzPopoverContent]", config.GetValue( AngularConst.BindPopoverContent ) );
        builder.AttributeIfNotEmpty( "nzPopoverTrigger", config.GetValue<PopoverTrigger?>( UiConst.PopoverTrigger )?.Description() );
        builder.AttributeIfNotEmpty( "[nzPopoverTrigger]", config.GetValue( AngularConst.BindPopoverTrigger ) );
        builder.AttributeIfNotEmpty( "nzPopoverPlacement", config.GetValue<PopoverPlacement?>( UiConst.PopoverPlacement )?.Description() );
        builder.AttributeIfNotEmpty( "[nzPopoverPlacement]", config.GetValue( AngularConst.BindPopoverPlacement ) );
        builder.AttributeIfNotEmpty( "[nzPopoverArrowPointAtCenter]", config.GetValue( UiConst.PopoverArrowPointAtCenter ) );
        builder.AttributeIfNotEmpty( "[nzPopoverOrigin]", config.GetValue( UiConst.PopoverOrigin ) );
        builder.AttributeIfNotEmpty( "[nzPopoverVisible]", config.GetValue( UiConst.PopoverVisible ) );
        builder.AttributeIfNotEmpty( "[(nzPopoverVisible)]", config.GetValue( AngularConst.BindonPopoverVisible ) );
        builder.AttributeIfNotEmpty( "[nzPopoverMouseEnterDelay]", config.GetValue( UiConst.PopoverMouseEnterDelay ) );
        builder.AttributeIfNotEmpty( "[nzPopoverMouseLeaveDelay]", config.GetValue( UiConst.PopoverMouseLeaveDelay ) );
        builder.AttributeIfNotEmpty( "nzPopoverOverlayClassName", config.GetValue( UiConst.PopoverOverlayClassName ) );
        builder.AttributeIfNotEmpty( "[nzPopoverOverlayClassName]", config.GetValue( AngularConst.BindPopoverOverlayClassName ) );
        builder.AttributeIfNotEmpty( "[nzPopoverOverlayStyle]", config.GetValue( UiConst.PopoverOverlayStyle ) );
        builder.AttributeIfNotEmpty( "[nzPopoverBackdrop]", config.GetValue( UiConst.PopoverBackdrop ) );
        builder.AttributeIfNotEmpty( "(nzPopoverVisibleChange)", config.GetValue( UiConst.OnPopoverVisibleChange ) );
        return builder;
    }

    /// <summary>
    /// nzPopoverTitle,气泡卡片标题
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="value">值</param>
    public static TBuilder PopoverTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
        builder.AttributeIf( "nz-popover", value.IsEmpty() == false );
        SetPopoverTitle( builder, value );
        return builder;
    }

    /// <summary>
    /// 设置标题
    /// </summary>
    public static void SetPopoverTitle( TagBuilder builder, string value ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            builder.AttributeByI18n( "[nzPopoverTitle]", value );
            return;
        }
        builder.AttributeIfNotEmpty( "nzPopoverTitle", value );
    }

    /// <summary>
    /// [nzPopoverTitle],气泡卡片标题
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="value">值</param>
    public static TBuilder BindPopoverTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
        builder.AttributeIf( "nz-popover", value.IsEmpty() == false );
        builder.AttributeIfNotEmpty( "[nzPopoverTitle]", value );
        return builder;
    }
}