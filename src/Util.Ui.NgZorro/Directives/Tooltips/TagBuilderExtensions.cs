using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Directives.Tooltips {
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
            TooltipTitleUpdate( builder,config );
            TooltipTitleDelete( builder, config );
            TooltipTitleDetail( builder, config );
            builder.TooltipTitle( config.GetValue( UiConst.TooltipTitle ) );
            builder.BindTooltipTitle( config.GetValue( AngularConst.BindTooltipTitle ) );
            builder.TooltipTrigger( config.GetValue<TooltipTrigger?>( UiConst.TooltipTrigger )?.Description() );
            builder.BindTooltipTrigger( config.GetValue( AngularConst.BindTooltipTrigger ) );
            builder.TooltipPlacement( config.GetValue<TooltipPlacement?>( UiConst.TooltipPlacement )?.Description() );
            builder.BindTooltipPlacement( config.GetValue( AngularConst.BindTooltipPlacement ) );
            builder.TooltipColor( config.GetValue( UiConst.TooltipColor ) );
            builder.BindTooltipColor( config.GetValue( AngularConst.BindTooltipColor ) );
            builder.TooltipOrigin( config.GetValue( UiConst.TooltipOrigin ) );
            builder.TooltipVisible( config.GetBoolValue( UiConst.TooltipVisible ) );
            builder.TooltipVisible( config.GetValue( AngularConst.BindTooltipVisible ) );
            builder.TooltipMouseEnterDelay( config.GetValue( UiConst.TooltipMouseEnterDelay ) );
            builder.BindTooltipMouseEnterDelay( config.GetValue( AngularConst.BindTooltipMouseEnterDelay ) );
            builder.TooltipMouseLeaveDelay( config.GetValue( UiConst.TooltipMouseLeaveDelay ) );
            builder.BindTooltipMouseLeaveDelay( config.GetValue( AngularConst.BindTooltipMouseLeaveDelay ) );
            builder.TooltipOverlayClassName( config.GetValue( UiConst.TooltipOverlayClassName ) );
            builder.BindTooltipOverlayClassName( config.GetValue( AngularConst.BindTooltipOverlayClassName ) );
            builder.TooltipOverlayStyle( config.GetValue( UiConst.TooltipOverlayStyle ) );
            builder.OnTooltipVisibleChange( config.GetValue( UiConst.OnTooltipVisibleChange ) );
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
            builder.AttributeIf( "nz-tooltip",string.IsNullOrWhiteSpace( value ) == false );
            SetTooltipTitle( builder, value );
            return builder;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        private static void SetTooltipTitle( TagBuilder builder,string value ) {
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
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipTitle]", value );
            return builder;
        }

        /// <summary>
        /// nzTooltipTrigger,文字提示触发行为
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipTrigger<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzTooltipTrigger", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipTrigger],文字提示触发行为
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindTooltipTrigger<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipTrigger]", value );
            return builder;
        }

        /// <summary>
        /// nzTooltipPlacement,提示框位置
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipPlacement<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzTooltipPlacement", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipPlacement],提示框位置
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindTooltipPlacement<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipPlacement]", value );
            return builder;
        }

        /// <summary>
        /// nzTooltipColor,文字提示背景颜色
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipColor<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzTooltipColor", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipColor],文字提示背景颜色
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindTooltipColor<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipColor]", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipOrigin],文字提示定位元素
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipOrigin<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipOrigin]", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipVisible],提示框是否可见
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipVisible<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipVisible]", value );
            return builder;
        }

        /// <summary>
        /// nzTooltipMouseEnterDelay,提示框移入延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipMouseEnterDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzTooltipMouseEnterDelay", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipMouseEnterDelay],提示框移入延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindTooltipMouseEnterDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipMouseEnterDelay]", value );
            return builder;
        }

        /// <summary>
        /// nzTooltipMouseLeaveDelay,提示框移出延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipMouseLeaveDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzTooltipMouseLeaveDelay", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipMouseLeaveDelay],提示框移出延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindTooltipMouseLeaveDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipMouseLeaveDelay]", value );
            return builder;
        }

        /// <summary>
        /// nzTooltipOverlayClassName,提示框样式类名
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipOverlayClassName<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzTooltipOverlayClassName", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipOverlayClassName],提示框样式类名
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindTooltipOverlayClassName<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipOverlayClassName]", value );
            return builder;
        }

        /// <summary>
        /// [nzTooltipOverlayStyle],提示框样式
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder TooltipOverlayStyle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzTooltipOverlayStyle]", value );
            return builder;
        }

        /// <summary>
        /// (nzTooltipVisibleChange),提示框显示状态变化事件
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder OnTooltipVisibleChange<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-tooltip", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "(nzTooltipVisibleChange)", value );
            return builder;
        }
    }
}
