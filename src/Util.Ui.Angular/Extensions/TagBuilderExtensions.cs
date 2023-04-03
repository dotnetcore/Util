using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Angular.Extensions {
    /// <summary>
    /// Angular标签生成器扩展
    /// </summary>
    public static class TagBuilderExtensions {
        /// <summary>
        /// 添加Angular指令
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder Angular<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.NgIf( config )
                .NgSwitch( config ).NgSwitchCase( config ).NgSwitchDefault( config )
                .NgFor( config )
                .NgClass( config )
                .NgStyle( config )
                .Acl( config )
                .BindAcl( config );
            return builder;
        }

        /// <summary>
        /// *ngIf
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder NgIf<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "*ngIf", value );
            return builder;
        }

        /// <summary>
        /// *ngIf
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgIf<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.NgIf( config.GetValue( AngularConst.NgIf ) );
            return builder;
        }

        /// <summary>
        /// [ngSwitch]
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder NgSwitch<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "[ngSwitch]", value );
            return builder;
        }

        /// <summary>
        /// [ngSwitch]
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgSwitch<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.NgSwitch( config.GetValue( AngularConst.NgSwitch ) );
            return builder;
        }

        /// <summary>
        /// *ngSwitchCase
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder NgSwitchCase<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "*ngSwitchCase", value );
            return builder;
        }

        /// <summary>
        /// *ngSwitchCase
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgSwitchCase<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.NgSwitchCase( config.GetValue( AngularConst.NgSwitchCase ) );
            return builder;
        }

        /// <summary>
        /// *ngSwitchDefault
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值,为true时添加指令</param>
        public static TBuilder NgSwitchDefault<TBuilder>( this TBuilder builder, bool? value ) where TBuilder : TagBuilder {
            if( value == true )
                builder.Attribute( "*ngSwitchDefault" );
            return builder;
        }

        /// <summary>
        /// *ngSwitchDefault
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgSwitchDefault<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            return builder.NgSwitchDefault( config.GetValue<bool?>( AngularConst.NgSwitchDefault ) );
        }

        /// <summary>
        /// *ngFor
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgFor<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.NgFor( config.GetValue( AngularConst.NgFor ) );
            return builder;
        }

        /// <summary>
        /// *ngFor
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder NgFor<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "*ngFor", value );
            return builder;
        }

        /// <summary>
        /// [ngClass]
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgClass<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "[ngClass]", config.GetValue( AngularConst.NgClass ) );
            return builder;
        }

        /// <summary>
        /// [ngStyle]
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgStyle<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "[ngStyle]", config.GetValue( AngularConst.NgStyle ) );
            return builder;
        }

        /// <summary>
        /// *aclIf,设置访问控制
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder Acl<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            var value = config.GetValue( UiConst.Acl );
            if ( value.IsEmpty() )
                return builder;
            builder.Attribute( "*aclIf", $"'{value}'" );
            return builder;
        }

        /// <summary>
        /// [acl],设置访问控制
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder BindAcl<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "[acl]", config.GetValue( AngularConst.BindAcl ) );
            return builder;
        }

        /// <summary>
        /// [(ngModel)]
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder NgModel<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "[(ngModel)]", value );
            return builder;
        }

        /// <summary>
        /// [ngModel]
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder BindNgModel<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "[ngModel]", value );
            return builder;
        }

        /// <summary>
        /// 添加[(ngModel)]和[ngModel]
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder NgModel<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.NgModel( config.GetValue( AngularConst.NgModel ) );
            builder.BindNgModel( config.GetValue( AngularConst.BindNgModel ) );
            return builder;
        }

        /// <summary>
        /// 添加单击事件(click)
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder OnClick<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            return builder.OnClick( config.GetValue( UiConst.OnClick ) );
        }

        /// <summary>
        /// 添加单击事件(click)
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="onclick">事件处理函数</param>
        public static TBuilder OnClick<TBuilder>( this TBuilder builder, string onclick ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "(click)", onclick );
            return builder;
        }

        /// <summary>
        /// 添加原始Id
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder RawId<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( "id", config.GetValue( AngularConst.RawId ) );
            return builder;
        }
        
        /// <summary>
        /// 添加引用变量
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        /// <param name="value">引用变量的值</param>
        public static TBuilder Id<TBuilder>( this TBuilder builder, Config config,string value = null ) where TBuilder : TagBuilder {
            return builder.Id( config.GetValue( UiConst.Id ),value );
        }

        /// <summary>
        /// 添加引用变量
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="name">引用变量名</param>
        /// <param name="value">引用变量值</param>
        public static TBuilder Id<TBuilder>( this TBuilder builder, string name, string value = null ) where TBuilder : TagBuilder {
            if ( string.IsNullOrWhiteSpace( name ) == false )
                builder.Attribute( $"#{name}", value );
            return builder;
        }
    }
}
