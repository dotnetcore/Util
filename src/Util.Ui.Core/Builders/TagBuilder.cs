using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.Builders {
    /// <summary>
    /// 标签生成器，注意：已禁用Html编码
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
        /// 空标签生成器
        /// </summary>
        public static readonly TagBuilder Null = new EmptyTagBuilder();

        /// <summary>
        /// Html内容
        /// </summary>
        public IHtmlContentBuilder InnerHtml => _tagBuilder.InnerHtml;

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        public Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetTagBuilder() {
            return _tagBuilder;
        }

        /// <summary>
        /// 添加class属性
        /// </summary>
        /// <param name="class">class属性值</param>
        public TagBuilder Class( string @class ) {
            _tagBuilder.AddCssClass( @class );
            return this;
        }

        /// <summary>
        /// 添加属性,当属性名已存在则忽略，也可进行替换
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        public TagBuilder Attribute( string name, string value, bool replaceExisting = false ) {
            _tagBuilder.MergeAttribute( name, value, replaceExisting );
            return this;
        }

        /// <summary>
        /// 添加属性,当属性名已存在则忽略
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="ignoreIfValueIsEmpty">当值为空时忽略</param>
        public TagBuilder AddAttribute( string name, string value, bool ignoreIfValueIsEmpty = true ) {
            if( ignoreIfValueIsEmpty && string.IsNullOrWhiteSpace( value ) )
                return this;
            Attribute( name, value );
            return this;
        }

        /// <summary>
        /// 设置子组件
        /// </summary>
        /// <param name="child">子组件</param>
        public TagBuilder AddChild( IHtmlContent child ) {
            _tagBuilder.InnerHtml.AppendHtml( child );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public TagBuilder SetContent( string content ) {
            _tagBuilder.InnerHtml.SetHtmlContent( content );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public TagBuilder SetContent( IHtmlContent content ) {
            _tagBuilder.InnerHtml.SetHtmlContent( content );
            return this;
        }

        /// <summary>
        /// 添加子组件
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public TagBuilder AppendChild( TagBuilder tagBuilder ) {
            _tagBuilder.InnerHtml.AppendHtml( tagBuilder.GetTagBuilder() );
            return this;
        }

        /// <summary>
        /// 设置子组件
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public TagBuilder SetChild( TagBuilder tagBuilder ) {
            _tagBuilder.InnerHtml.SetHtmlContent( tagBuilder.GetTagBuilder() );
            return this;
        }

        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public virtual void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            _tagBuilder.WriteTo( writer, NullHtmlEncoder.Default );
        }

        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public void RenderStartTag( TextWriter writer ) {
            _tagBuilder.RenderStartTag().WriteTo( writer, NullHtmlEncoder.Default );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public void RenderEndTag( TextWriter writer ) {
            _tagBuilder.RenderEndTag().WriteTo( writer, NullHtmlEncoder.Default );
        }

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public override string ToString() {
            using( var writer = new StringWriter() ) {
                _tagBuilder.WriteTo( writer, NullHtmlEncoder.Default );
                return writer.ToString();
            }
        }
    }
}
