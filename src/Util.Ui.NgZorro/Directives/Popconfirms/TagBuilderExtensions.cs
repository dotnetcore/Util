using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Directives.Popconfirms;

/// <summary>
/// 气泡确认框扩展
/// </summary>
public static class TagBuilderExtensions {
    /// <summary>
    /// 气泡确认框指令扩展
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="config">配置</param>
    public static TBuilder Popconfirm<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
        builder.PopconfirmTitle( config.GetValue( UiConst.PopconfirmTitle ) );
        builder.BindPopconfirmTitle( config.GetValue( AngularConst.BindPopconfirmTitle ) );
        builder.AttributeIfNotEmpty( "nzPopconfirmTrigger", config.GetValue<PopconfirmTrigger?>( UiConst.PopconfirmTrigger )?.Description() );
        builder.AttributeIfNotEmpty( "[nzPopconfirmTrigger]", config.GetValue( AngularConst.BindPopconfirmTrigger ) );
        builder.AttributeIfNotEmpty( "nzPopconfirmPlacement", config.GetValue<PopconfirmPlacement?>( UiConst.PopconfirmPlacement )?.Description() );
        builder.AttributeIfNotEmpty( "[nzPopconfirmPlacement]", config.GetValue( AngularConst.BindPopconfirmPlacement ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmOrigin]", config.GetValue( UiConst.PopconfirmOrigin ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmVisible]", config.GetValue( UiConst.PopconfirmVisible ) );
        builder.AttributeIfNotEmpty( "[(nzPopconfirmVisible)]", config.GetValue( AngularConst.BindonPopconfirmVisible ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmShowArrow]", config.GetValue( UiConst.PopconfirmShowArrow ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmArrowPointAtCenter]", config.GetValue( UiConst.PopconfirmArrowPointAtCenter ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmMouseEnterDelay]", config.GetValue( UiConst.PopconfirmMouseEnterDelay ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmMouseLeaveDelay]", config.GetValue( UiConst.PopconfirmMouseLeaveDelay ) );
        builder.AttributeIfNotEmpty( "nzPopconfirmOverlayClassName", config.GetValue( UiConst.PopconfirmOverlayClassName ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmOverlayClassName]", config.GetValue( AngularConst.BindPopconfirmOverlayClassName ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmOverlayStyle]", config.GetValue( UiConst.PopconfirmOverlayStyle ) );
        builder.AttributeIfNotEmpty( "[nzPopconfirmBackdrop]", config.GetValue( UiConst.PopconfirmBackdrop ) );
        builder.AttributeIfNotEmpty( "nzCancelText", config.GetValue( UiConst.PopconfirmCancelText ) );
        builder.AttributeIfNotEmpty( "[nzCancelText]", config.GetValue( AngularConst.BindPopconfirmCancelText ) );
        builder.AttributeIfNotEmpty( "nzOkText", config.GetValue( UiConst.PopconfirmOkText ) );
        builder.AttributeIfNotEmpty( "[nzOkText]", config.GetValue( AngularConst.BindPopconfirmOkText ) );
        builder.AttributeIfNotEmpty( "nzOkType", config.GetValue<ButtonType?>( UiConst.PopconfirmOkType )?.Description() );
        builder.AttributeIfNotEmpty( "[nzOkType]", config.GetValue( AngularConst.BindPopconfirmOkType ) );
        builder.AttributeIfNotEmpty( "[nzOkDanger]", config.GetValue( UiConst.PopconfirmOkDanger ) );
        builder.AttributeIfNotEmpty( "[nzOkDisabled]", config.GetValue( UiConst.PopconfirmOkDisabled ) );
        builder.AttributeIfNotEmpty( "nzAutoFocus", config.GetValue<PopconfirmAutoFocus?>( UiConst.PopconfirmAutoFocus )?.Description() );
        builder.AttributeIfNotEmpty( "[nzAutoFocus]", config.GetValue( AngularConst.BindPopconfirmAutoFocus ) );
        builder.AttributeIfNotEmpty( "[nzCondition]", config.GetValue( UiConst.PopconfirmCondition ) );
        builder.AttributeIfNotEmpty( "nzIcon", config.GetValue<AntDesignIcon?>( UiConst.PopconfirmIcon )?.Description() );
        builder.AttributeIfNotEmpty( "[nzIcon]", config.GetValue( AngularConst.BindPopconfirmIcon ) );
        builder.AttributeIfNotEmpty( "[nzBeforeConfirm]", config.GetValue( UiConst.PopconfirmBeforeConfirm ) );
        builder.AttributeIfNotEmpty( "(nzPopconfirmVisibleChange)", config.GetValue( UiConst.OnPopconfirmVisibleChange ) );
        builder.AttributeIfNotEmpty( "(nzOnCancel)", config.GetValue( UiConst.OnPopconfirmCancel ) );
        builder.AttributeIfNotEmpty( "(nzOnConfirm)", config.GetValue( UiConst.OnPopconfirmConfirm ) );
        return builder;
    }

    /// <summary>
    /// nzPopconfirmTitle,气泡确认框标题
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="value">值</param>
    public static TBuilder PopconfirmTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
        builder.AttributeIf( "nz-popconfirm", value.IsEmpty() == false );
        SetPopconfirmTitle( builder, value );
        return builder;
    }

    /// <summary>
    /// 设置标题
    /// </summary>
    public static void SetPopconfirmTitle( TagBuilder builder, string value ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            builder.AttributeByI18n( "[nzPopconfirmTitle]", value );
            return;
        }
        builder.AttributeIfNotEmpty( "nzPopconfirmTitle", value );
    }

    /// <summary>
    /// [nzPopconfirmTitle],气泡确认框标题
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="value">值</param>
    public static TBuilder BindPopconfirmTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
        builder.AttributeIf( "nz-popconfirm", value.IsEmpty() == false );
        builder.AttributeIfNotEmpty( "[nzPopconfirmTitle]", value );
        return builder;
    }
}