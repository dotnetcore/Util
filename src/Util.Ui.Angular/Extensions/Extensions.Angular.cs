using Util.Ui.Angular;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Extensions {
    /// <summary>
    /// Angular扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加Angular指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder Angular<TBuilder>( this TBuilder builder, IConfig config ) where TBuilder : TagBuilder {
            builder.NgIf( config ).NgFor( config ).NgClass( config );
            return builder;
        }

        /// <summary>
        /// 添加NgIf指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder NgIf<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AddAttribute( "*ngIf", value );
            return builder;
        }

        /// <summary>
        /// 添加NgIf指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgIf<TBuilder>( this TBuilder builder, IConfig config ) where TBuilder : TagBuilder {
            builder.NgIf( config.GetValue( AngularConst.NgIf ) );
            return builder;
        }

        /// <summary>
        /// 添加NgFor指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgFor<TBuilder>( this TBuilder builder, IConfig config ) where TBuilder : TagBuilder {
            builder.NgFor( config.GetValue( AngularConst.NgFor ) );
            return builder;
        }

        /// <summary>
        /// 添加NgFor指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder NgFor<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AddAttribute( "*ngFor", value );
            return builder;
        }

        /// <summary>
        /// 添加NgModel指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        /// <param name="modelName">model名称,默认值:model,表示[(model)]</param>
        public static TBuilder NgModel<TBuilder>( this TBuilder builder, string value, string modelName ="model") where TBuilder : TagBuilder {
            builder.AddAttribute( $"[({modelName})]", value );
            return builder;
        }

        /// <summary>
        /// 添加NgModel指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        /// <param name="modelName">model名称,默认值:model,表示[(model)]</param>
        public static TBuilder NgModel<TBuilder>( this TBuilder builder, IConfig config, string modelName = "model" ) where TBuilder : TagBuilder {
            var value = config.GetValue( AngularConst.NgModel );
            if( value.IsEmpty() )
                return NgModel( builder, config.GetValue( UiConst.Model ), modelName );
            return NgModel( builder, value, modelName );
        }

        /// <summary>
        /// 添加NgClass指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgClass<TBuilder>( this TBuilder builder, IConfig config ) where TBuilder : TagBuilder {
            builder.AddAttribute( "[ngClass]", config.GetValue( AngularConst.NgClass ) );
            return builder;
        }

        /// <summary>
        /// 添加路由链接指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder Link<TBuilder>( this TBuilder builder, IConfig config ) where TBuilder : TagBuilder {
            builder.AddAttribute( "href", config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "routerLink", config.GetValue( UiConst.Link ) );
            builder.AddAttribute( "[routerLink]", config.GetValue( AngularConst.BindLink ) );
            builder.AddAttribute( "routerLinkActive", config.GetValue( UiConst.Active ) );
            builder.AddAttribute( "[routerLinkActive]", config.GetValue( AngularConst.BindActive ) );
            builder.AddAttribute( "[queryParams]", config.GetValue( UiConst.QueryParams ) );
            if( config.GetValue<bool>( UiConst.Exact ) )
                builder.AddAttribute( "[routerLinkActiveOptions]", "{exact: true}" );
            return builder;
        }

        /// <summary>
        /// 添加click指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder OnClick<TBuilder>( this TBuilder builder, IConfig config ) where TBuilder : TagBuilder {
            builder.AddAttribute( "(click)", config.GetValue( UiConst.OnClick ) );
            return builder;
        }
    }
}
