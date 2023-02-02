using System.Text;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Extensions {
    /// <summary>
    /// ng-zorro扩展
    /// </summary>
    public static class TagBuilderExtensions {
        /// <summary>
        /// *nzSpaceItem,间距项
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder SpaceItem<TBuilder>( this TBuilder builder, bool? value ) where TBuilder : TagBuilder {
            if( value == true )
                builder.Attribute( "*nzSpaceItem" );
            return builder;
        }

        /// <summary>
        /// *nzSpaceItem,间距项
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="config">配置</param>
        public static TBuilder SpaceItem<TBuilder>( this TBuilder builder, Config config ) where TBuilder : TagBuilder {
            builder.SpaceItem( config.GetValue<bool?>( UiConst.SpaceItem ) );
            return builder;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        /// <param name="attributeName">属性名</param>
        public static TBuilder Width<TBuilder>( this TBuilder builder, string value,string attributeName = "nzWidth" ) where TBuilder : TagBuilder {
            builder.AttributeIfNotEmpty( attributeName, GetPixelValue( value ) );
            return builder;
        }

        /// <summary>
        /// 获取像素值，如果传入数字，后加px，否则按原样返回
        /// </summary>
        /// <param name="value">值</param>
        private static string GetPixelValue( string value ) {
            if ( value.IsEmpty() )
                return null;
            if ( Util.Helpers.Validation.IsNumber( value ) )
                return $"{value}px";
            return value;
        }

        /// <summary>
        /// 添加到内容,支持i18n管道
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="value">值</param>
        public static TBuilder AppendContentByI18n<TBuilder>( this TBuilder builder, string value ) where TBuilder : TagBuilder {
            if ( value.IsEmpty() )
                return builder;
            var result = new StringBuilder();
            result.Append( "{{" );
            result.Append( $"'{value}'|i18n" );
            result.Append( "}}" );
            builder.AppendContent( result.ToString() );
            return builder;
        }

        /// <summary>
        /// 添加属性,支持i18n管道
        /// </summary>
        /// <typeparam name="TBuilder">生成器类型</typeparam>
        /// <param name="builder">生成器实例</param>
        /// <param name="name">属性名</param>
        /// <param name="value">值</param>
        public static TBuilder AttributeByI18n<TBuilder>( this TBuilder builder, string name, string value ) where TBuilder : TagBuilder {
            if ( value.IsEmpty() )
                return builder;
            builder.Attribute( name, $"'{value}'|i18n" );
            return builder;
        }
    }
}
