using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 标签生成器扩展
    /// </summary>
    public static class TagBuilderExtensions {
        /// <summary>
        /// 添加属性列表
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="attributes">属性列表</param>
        public static TagBuilder Attributes( this TagBuilder builder, TagHelperAttributeList attributes ) {
            foreach ( var attribute in attributes )
                builder.Attribute( attribute.Name, attribute.Value.SafeString() );
            return builder;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Style( this TagBuilder builder, Config config ) {
            builder.AttributeIfNotEmpty( UiConst.Style, config.GetValue( UiConst.Style ) );
            return builder;
        }

        /// <summary>
        /// 添加样式类
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Class( this TagBuilder builder, Config config ) {
            return builder.Class( config.GetValue( UiConst.Class ) );
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public static TagBuilder Hidden( this TagBuilder builder, Config config ) {
            builder.AttributeIfNotEmpty( "[hidden]", config.GetValue( UiConst.Hidden ) );
            return builder;
        }
    }
}
