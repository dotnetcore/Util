using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 标签生成器扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加输出属性列表
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder AddOutputAttributes( this TagBuilder builder, IConfig config ) {
            foreach ( var attribute in config.OutputAttributes )
                builder.Attribute( attribute.Name, attribute.Value.SafeString() );
            return builder;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Style( this TagBuilder builder, IConfig config ) {
            if ( config.Contains( UiConst.Style ) )
                builder.Attribute( UiConst.Style, config.GetValue( UiConst.Style ) );
            return builder;
        }

        /// <summary>
        /// 添加class
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Class( this TagBuilder builder, IConfig config ) {
            if( config.Contains( UiConst.Class ) )
                config.AddClass( config.GetValue( UiConst.Class ) );
            config.GetClassList().ForEach( s => builder.Class( s ) );
            return builder;
        }
    }
}
