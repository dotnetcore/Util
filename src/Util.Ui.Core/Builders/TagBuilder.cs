using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Util.Ui.Builders {
    /// <summary>
    /// 标签生成器
    /// </summary>
    public class TagBuilder : ITagBuilder {
        /// <summary>
        /// 标签生成器
        /// </summary>
        private readonly Microsoft.AspNetCore.Mvc.Rendering.TagBuilder _tagBuilder;

        /// <summary>
        /// 初始化标签生成器
        /// </summary>
        /// <param name="tagName">标签名称，范例：div</param>
        /// <param name="renderMode">渲染模式</param>
        public TagBuilder( string tagName, TagRenderMode renderMode = TagRenderMode.Normal ) {
            _tagBuilder = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder( tagName ) { TagRenderMode = renderMode };
        }

        /// <summary>
        /// Html内容
        /// </summary>
        public IHtmlContentBuilder InnerHtml => _tagBuilder.InnerHtml;

        /// <summary>
        /// 添加标识
        /// </summary>
        /// <param name="id">标识</param>
        public ITagBuilder Id( string id ) {
            _tagBuilder.GenerateId( id, string.Empty );
            return this;
        }

        /// <summary>
        /// 添加class属性
        /// </summary>
        /// <param name="class">class属性值</param>
        public ITagBuilder Class( string @class ) {
            _tagBuilder.AddCssClass( @class );
            return this;
        }

        /// <summary>
        /// 添加属性,当属性名已存在则忽略，也可进行替换
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        public ITagBuilder Attribute( string name, string value, bool replaceExisting = false ) {
            _tagBuilder.MergeAttribute( name, value, replaceExisting );
            return this;
        }

        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            _tagBuilder.WriteTo( writer,encoder );
        }

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public override string ToString() {
            using( var writer = new StringWriter() ) {
                _tagBuilder.WriteTo( writer, HtmlEncoder.Default );
                return writer.ToString();
            }
        }
    }
}
