using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Directives.Popconfirms {
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
            builder.PopconfirmTrigger( config.GetValue<PopconfirmTrigger?>( UiConst.PopconfirmTrigger )?.Description() );
            builder.BindPopconfirmTrigger( config.GetValue( AngularConst.BindPopconfirmTrigger ) );
            builder.PopconfirmPlacement( config.GetValue<PopconfirmPlacement?>( UiConst.PopconfirmPlacement )?.Description() );
            builder.BindPopconfirmPlacement( config.GetValue( AngularConst.BindPopconfirmPlacement ) );
            builder.PopconfirmOrigin( config.GetValue( UiConst.PopconfirmOrigin ) );
            builder.PopconfirmVisible( config.GetBoolValue( UiConst.PopconfirmVisible ) );
            builder.PopconfirmVisible( config.GetValue( AngularConst.BindPopconfirmVisible ) );
            builder.PopconfirmShowArrow( config.GetBoolValue( UiConst.PopconfirmShowArrow ) );
            builder.PopconfirmShowArrow( config.GetValue( AngularConst.BindPopconfirmShowArrow ) );
            builder.PopconfirmMouseEnterDelay( config.GetValue( UiConst.PopconfirmMouseEnterDelay ) );
            builder.BindPopconfirmMouseEnterDelay( config.GetValue( AngularConst.BindPopconfirmMouseEnterDelay ) );
            builder.PopconfirmMouseLeaveDelay( config.GetValue( UiConst.PopconfirmMouseLeaveDelay ) );
            builder.BindPopconfirmMouseLeaveDelay( config.GetValue( AngularConst.BindPopconfirmMouseLeaveDelay ) );
            builder.PopconfirmOverlayClassName( config.GetValue( UiConst.PopconfirmOverlayClassName ) );
            builder.BindPopconfirmOverlayClassName( config.GetValue( AngularConst.BindPopconfirmOverlayClassName ) );
            builder.PopconfirmOverlayStyle( config.GetValue( UiConst.PopconfirmOverlayStyle ) );
            builder.PopconfirmBackdrop( config.GetBoolValue( UiConst.PopconfirmBackdrop ) );
            builder.PopconfirmBackdrop( config.GetValue( AngularConst.BindPopconfirmBackdrop ) );
            builder.PopconfirmCancelText( config.GetValue( UiConst.PopconfirmCancelText ) );
            builder.BindPopconfirmCancelText( config.GetValue( AngularConst.BindPopconfirmCancelText ) );
            builder.PopconfirmOkText( config.GetValue( UiConst.PopconfirmOkText ) );
            builder.BindPopconfirmOkText( config.GetValue( AngularConst.BindPopconfirmOkText ) );
            builder.PopconfirmOkType( config.GetValue<ButtonType?>( UiConst.PopconfirmOkType )?.Description() );
            builder.BindPopconfirmOkType( config.GetValue( AngularConst.BindPopconfirmOkType ) );
            builder.PopconfirmCondition( config.GetBoolValue( UiConst.PopconfirmCondition ) );
            builder.PopconfirmCondition( config.GetValue( AngularConst.BindPopconfirmCondition ) );
            builder.PopconfirmIcon( config.GetValue<AntDesignIcon?>( UiConst.PopconfirmIcon )?.Description() );
            builder.BindPopconfirmIcon( config.GetValue( AngularConst.BindPopconfirmIcon ) );
            builder.OnPopconfirmVisibleChange( config.GetValue( UiConst.OnPopconfirmVisibleChange ) );
            builder.OnPopconfirmCancel( config.GetValue( UiConst.OnPopconfirmCancel ) );
            builder.OnPopconfirmConfirm( config.GetValue( UiConst.OnPopconfirmConfirm ) );
            return builder;
        }

        /// <summary>
        /// nzPopconfirmTitle,气泡确认框标题
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzPopconfirmTitle", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmTitle],气泡确认框标题
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmTitle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmTitle]", value );
            return builder;
        }

        /// <summary>
        /// nzPopconfirmTrigger,气泡确认框触发行为
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmTrigger<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzPopconfirmTrigger", value );
            return builder;
        }

        /// <summary>
        /// nzPopconfirmTrigger,气泡确认框触发行为
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmTrigger<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmTrigger]", value );
            return builder;
        }

        /// <summary>
        /// nzPopconfirmPlacement,气泡框位置
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmPlacement<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzPopconfirmPlacement", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmPlacement],气泡框位置
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmPlacement<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmPlacement]", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmOrigin],气泡框定位元素
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmOrigin<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmOrigin]", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmVisible],气泡框是否可见
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmVisible<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmVisible]", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmShowArrow],气泡框是否显示箭头
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmShowArrow<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmShowArrow]", value );
            return builder;
        }

        /// <summary>
        /// nzPopconfirmMouseEnterDelay,气泡框移入延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmMouseEnterDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzPopconfirmMouseEnterDelay", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmMouseEnterDelay],气泡框移入延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmMouseEnterDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmMouseEnterDelay]", value );
            return builder;
        }

        /// <summary>
        /// nzPopconfirmMouseLeaveDelay,气泡框移出延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmMouseLeaveDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzPopconfirmMouseLeaveDelay", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmMouseLeaveDelay],气泡框移出延时
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmMouseLeaveDelay<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmMouseLeaveDelay]", value );
            return builder;
        }

        /// <summary>
        /// nzPopconfirmOverlayClassName,气泡框样式类名
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmOverlayClassName<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzPopconfirmOverlayClassName", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmOverlayClassName],气泡框样式类名
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmOverlayClassName<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmOverlayClassName]", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmOverlayStyle],气泡框样式
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmOverlayStyle<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmOverlayStyle]", value );
            return builder;
        }

        /// <summary>
        /// [nzPopconfirmBackdrop],气泡框浮层是否应带背景
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmBackdrop<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzPopconfirmBackdrop]", value );
            return builder;
        }

        /// <summary>
        /// nzCancelText,气泡框取消按钮文字
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmCancelText<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzCancelText", value );
            return builder;
        }

        /// <summary>
        /// [nzCancelText],气泡框取消按钮文字
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmCancelText<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzCancelText]", value );
            return builder;
        }

        /// <summary>
        /// nzOkText,气泡框确认按钮文字
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmOkText<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzOkText", value );
            return builder;
        }

        /// <summary>
        /// [nzOkText],气泡框确认按钮文字
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmOkText<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzOkText]", value );
            return builder;
        }

        /// <summary>
        /// nzOkType,气泡框确认按钮类型
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmOkType<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzOkType", value );
            return builder;
        }

        /// <summary>
        /// [nzOkType],气泡框确认按钮类型
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmOkType<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzOkType]", value );
            return builder;
        }

        /// <summary>
        /// [nzCondition],气泡框条件触发
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmCondition<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzCondition]", value );
            return builder;
        }

        /// <summary>
        /// nzIcon,气泡框自定义图标
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder PopconfirmIcon<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "nzIcon", value );
            return builder;
        }

        /// <summary>
        /// [nzIcon],气泡框自定义图标
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindPopconfirmIcon<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "[nzIcon]", value );
            return builder;
        }

        /// <summary>
        /// (nzPopconfirmVisibleChange),气泡框显示状态变化事件
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder OnPopconfirmVisibleChange<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "(nzPopconfirmVisibleChange)", value );
            return builder;
        }

        /// <summary>
        /// (nzOnCancel),气泡框取消事件
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder OnPopconfirmCancel<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "(nzOnCancel)", value );
            return builder;
        }

        /// <summary>
        /// (nzOnConfirm),气泡框确认事件
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder OnPopconfirmConfirm<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIf( "nz-popconfirm", string.IsNullOrWhiteSpace( value ) == false );
            builder.AttributeIfNotEmpty( "(nzOnConfirm)", value );
            return builder;
        }
    }
}
