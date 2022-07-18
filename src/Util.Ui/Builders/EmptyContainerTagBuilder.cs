using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.Builders {
    /// <summary>
    /// 空容器标签生成器
    /// </summary>
    public class EmptyContainerTagBuilder : TagBuilder {
        /// <summary>
        /// html内容生成器
        /// </summary>
        private readonly HtmlContentBuilder _builder;

        /// <summary>
        /// 初始化空容器标签生成器
        /// </summary>
        public EmptyContainerTagBuilder() : base( "i" ) {
            _builder = new HtmlContentBuilder();
        }

        /// <summary>
        /// Html内容
        /// </summary>
        public override IHtmlContentBuilder InnerHtml => null;

        /// <summary>
        /// 是否包含Html内容
        /// </summary>
        public override bool HasInnerHtml => _builder.Count > 0;

        /// <summary>
        /// 添加class属性
        /// </summary>
        /// <param name="class">class属性值</param>
        public override TagBuilder Class( string @class ) {
            return this;
        }

        /// <summary>
        /// 添加属性,当属性名已存在则忽略，也可进行替换
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        /// <param name="append">相同名称的属性值是否累加</param>
        public override TagBuilder Attribute( string name, string value = "", bool replaceExisting = false, bool append = false ) {
            return this;
        }

        /// <summary>
        /// 添加属性,当值为空时忽略
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        /// <param name="append">相同名称的属性值是否累加</param>
        public override TagBuilder AttributeIfNotEmpty( string name, string value, bool replaceExisting = false, bool append = false ) {
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="content">内容</param>
        public override TagBuilder AppendContent( string content ) {
            _builder.AppendHtml( content );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="content">内容</param>
        public override TagBuilder AppendContent( IHtmlContent content ) {
            _builder.AppendHtml( content );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public override TagBuilder AppendContent( TagBuilder tagBuilder ) {
            AppendContent( (IHtmlContent)tagBuilder );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public override TagBuilder SetContent( string content ) {
            _builder.SetHtmlContent( content );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public override TagBuilder SetContent( IHtmlContent content ) {
            _builder.SetHtmlContent( content );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public override TagBuilder SetContent( TagBuilder tagBuilder ) {
            SetContent( (IHtmlContent)tagBuilder );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
        }

        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            _builder.WriteTo( writer, NullHtmlEncoder.Default );
        }

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public override string ToString() {
            using var writer = new StringWriter();
            _builder.WriteTo( writer, NullHtmlEncoder.Default );
            return writer.ToString();
        }
    }
}
