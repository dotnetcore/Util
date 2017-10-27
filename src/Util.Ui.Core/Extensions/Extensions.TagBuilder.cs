using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 标签生成器扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加属性列表
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder AddOtherAttributes( this TagBuilder builder, IConfig config ) {
            foreach( var attribute in config.OtherAttributes ) {
                if( attribute.Name.ToLower() == UiConst.Class )
                    continue;
                builder.Attribute( attribute.Name, attribute.Value.SafeString() );
            }
            return builder;
        }

        /// <summary>
        /// 添加属性列表
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Class( this TagBuilder builder, IConfig config ) {
            if( config.OtherAttributes.ContainsName( UiConst.Class ) )
                config.AddClass( config.OtherAttributes[UiConst.Class].Value.SafeString() );
            config.GetClassList().ForEach( s => builder.Class( s ) );
            return builder;
        }

        /// <summary>
        /// 设置Id
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Id( this TagBuilder builder, IConfig config ) {
            if( config.Contains( UiConst.Id ) )
                builder.Attribute( UiConst.Id, config.GetValue( UiConst.Id ), true );
            return builder;
        }

        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Text( this TagBuilder builder, IConfig config ) {
            if( config.Contains( UiConst.Text ) ) {
                builder.SetContent( config.GetValue( UiConst.Text ) );
                return builder;
            }
            builder.SetContent( config.Content );
            return builder;
        }
    }
}
