using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Selects.Configs {
    /// <summary>
    /// 选择框配置
    /// </summary>
    public class SelectConfig : Config {
        /// <summary>
        /// 扩展标识
        /// </summary>
        public string ExtendId { get; set; }

        /// <summary>
        /// 初始化选择框配置
        /// </summary>
        public SelectConfig() : this( null, null ) {
        }

        /// <summary>
        /// 初始化选择框配置
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        public SelectConfig( TagHelperContext context, TagHelperOutput output ) : base( context, output ) {
        }

        /// <summary>
        /// 复制配置
        /// </summary>
        public new SelectConfig Copy() {
            var content = new DefaultTagHelperContent();
            Content.CopyTo( content );
            return new SelectConfig {
                Context = new TagHelperContext( AllAttributes, Context.Items, Util.Helpers.Id.Create() ),
                AllAttributes = new TagHelperAttributeList( AllAttributes ),
                OutputAttributes = new TagHelperAttributeList( OutputAttributes ),
                Content = content,
                ExtendId = ExtendId
            };
        }
    }
}
