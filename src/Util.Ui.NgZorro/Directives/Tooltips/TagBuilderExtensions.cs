using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Directives.Tooltips;

/// <summary>
/// 文字提示扩展
/// </summary>
public static class TagBuilderExtensions {
    /// <summary>
    /// 文字提示指令扩展
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="config">配置</param>
    public static TBuilder Tooltip<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
        TooltipTitleUpdate( builder, config );
        TooltipTitleDelete( builder, config );
        TooltipTitleDetail( builder, config );
        builder.TooltipTitle( config.GetValue( UiConst.TooltipTitle ) );
        builder.BindTooltipTitle( config.GetValue( AngularConst.BindTooltipTitle ) );
        builder.AttributeIfNotEmpty( "nzTooltipPlacement", config.GetValue<TooltipPlacement?>( UiConst.TooltipPlacement )?.Description() );
        builder.AttributeIfNotEmpty( "[nzTooltipPlacement]", config.GetValue( AngularConst.BindTooltipPlacement ) );
        builder.AttributeIfNotEmpty( "[nzTooltipArrowPointAtCenter]", config.GetValue( UiConst.TooltipArrowPointAtCenter ) );
        builder.AttributeIfNotEmpty( "[nzTooltipTitleContext]", config.GetValue( UiConst.TooltipTitleContext ) );
        builder.AttributeIfNotEmpty( "nzTooltipTrigger", config.GetValue<TooltipTrigger?>( UiConst.TooltipTrigger )?.Description() );
        builder.AttributeIfNotEmpty( "[nzTooltipTrigger]", config.GetValue( AngularConst.BindTooltipTrigger ) );
        builder.AttributeIfNotEmpty( "nzTooltipColor", config.GetValue<AntDesignColor?>( UiConst.TooltipColor )?.Description() );
        builder.AttributeIfNotEmpty( "[nzTooltipColor]", config.GetValue( AngularConst.BindTooltipColor ) );
        builder.AttributeIfNotEmpty( "[nzTooltipOrigin]", config.GetValue( UiConst.TooltipOrigin ) );
        builder.AttributeIfNotEmpty( "[nzTooltipVisible]", config.GetValue( UiConst.TooltipVisible ) );
        builder.AttributeIfNotEmpty( "[(nzTooltipVisible)]", config.GetValue( AngularConst.BindonTooltipVisible ) );
        builder.AttributeIfNotEmpty( "[nzTooltipMouseEnterDelay]", config.GetValue( UiConst.TooltipMouseEnterDelay ) );
        builder.AttributeIfNotEmpty( "[nzTooltipMouseLeaveDelay]", config.GetValue( UiConst.TooltipMouseLeaveDelay ) );
        builder.AttributeIfNotEmpty( "nzTooltipOverlayClassName", config.GetValue( UiConst.TooltipOverlayClassName ) );
        builder.AttributeIfNotEmpty( "[nzTooltipOverlayClassName]", config.GetValue( AngularConst.BindTooltipOverlayClassName ) );
        builder.AttributeIfNotEmpty( "[nzTooltipOverlayStyle]", config.GetValue( UiConst.TooltipOverlayStyle ) );
        builder.AttributeIfNotEmpty( "(nzTooltipVisibleChange)", config.GetValue( UiConst.OnTooltipVisibleChange ) );
        return builder;
    }

    /// <summary>
    /// 设置nzTooltipTitle为update
    /// </summary>
    /// <param name="builder">生成器实例</param>
    /// <param name="config">配置</param>
    private static void TooltipTitleUpdate( TagBuilder builder, Config config ) {
        var value = config.GetValue<bool?>( UiConst.TooltipTitleUpdate );
        if ( value != true )
            return;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            builder.TooltipTitle( I18nKeys.Update );
            return;
        }
        builder.TooltipTitle( "Update" );
    }

    /// <summary>
    /// 设置nzTooltipTitle为delete
    /// </summary>
    /// <param name="builder">生成器实例</param>
    /// <param name="config">配置</param>
    private static void TooltipTitleDelete( TagBuilder builder, Config config ) {
        var value = config.GetValue<bool?>( UiConst.TooltipTitleDelete );
        if ( value != true )
            return;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            builder.TooltipTitle( I18nKeys.Delete );
            return;
        }
        builder.TooltipTitle( "Delete" );
    }

    /// <summary>
    /// 设置nzTooltipTitle为detail
    /// </summary>
    /// <param name="builder">生成器实例</param>
    /// <param name="config">配置</param>
    private static void TooltipTitleDetail( TagBuilder builder, Config config ) {
        var value = config.GetValue<bool?>( UiConst.TooltipTitleDetail );
        if ( value != true )
            return;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            builder.TooltipTitle( I18nKeys.Detail );
            return;
        }
        builder.TooltipTitle( "Detail" );
    }

    /// <summary>
    /// nzTooltipTitle,提示文字
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="value">值</param>
    public static TBuilder TooltipTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
        builder.AttributeIf( "nz-tooltip", value.IsEmpty() == false );
        SetTooltipTitle( builder, value );
        return builder;
    }

    /// <summary>
    /// 设置标题
    /// </summary>
    public static void SetTooltipTitle( TagBuilder builder, string value ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            builder.AttributeByI18n( "[nzTooltipTitle]", value );
            return;
        }
        builder.AttributeIfNotEmpty( "nzTooltipTitle", value );
    }

    /// <summary>
    /// [nzTooltipTitle],提示文字
    /// </summary>
    /// <typeparam name="TBuilder">生成器类型</typeparam>
    /// <param name="builder">生成器实例</param>
    /// <param name="value">值</param>
    public static TBuilder BindTooltipTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
        builder.AttributeIf( "nz-tooltip", value.IsEmpty() == false );
        builder.AttributeIfNotEmpty( "[nzTooltipTitle]", value );
        return builder;
    }
}