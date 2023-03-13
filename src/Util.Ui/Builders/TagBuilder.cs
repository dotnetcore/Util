using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.Builders {
    /// <summary>
    /// 标签生成器
    /// </summary>
    public class TagBuilder : IHtmlContent {
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
        public virtual IHtmlContentBuilder InnerHtml => _tagBuilder.InnerHtml;

        /// <summary>
        /// 是否包含Html内容
        /// </summary>
        public virtual bool HasInnerHtml => _tagBuilder.HasInnerHtml;

        /// <summary>
        /// 前一个标签生成器
        /// </summary>
        public TagBuilder PreBuilder { get; set; }

        /// <summary>
        /// 后一个标签生成器
        /// </summary>
        public TagBuilder PostBuilder { get; set; }

        /// <summary>
        /// 添加class属性
        /// </summary>
        /// <param name="class">class属性值</param>
        public virtual TagBuilder Class( string @class ) {
            if ( string.IsNullOrWhiteSpace( @class ) == false )
                _tagBuilder.AddCssClass( @class );
            return this;
        }

        /// <summary>
        /// 添加属性,当属性名已存在则忽略，也可进行替换
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        /// <param name="append">相同名称的属性值是否累加</param>
        public virtual TagBuilder Attribute( string name, string value = "", bool replaceExisting = false, bool append = false ) {
            if( _tagBuilder.Attributes.ContainsKey( name ) == false ) {
                _tagBuilder.MergeAttribute( name, value );
                return this;
            }
            if( replaceExisting ) {
                _tagBuilder.MergeAttribute( name, value, true );
                return this;
            }
            if( append == false )
                return this;
            var newValue = $"{_tagBuilder.Attributes[name]};{value}";
            _tagBuilder.MergeAttribute( name, newValue, true );
            return this;
        }

        /// <summary>
        /// 添加属性,当条件为true时添加
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="condition">该值为true时添加，否则忽略</param>
        public virtual TagBuilder AttributeIf( string name, bool condition ) {
            if( condition == false )
                return this;
            Attribute( name );
            return this;
        }

        /// <summary>
        /// 添加属性,当条件为true时添加
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="condition">该值为true时添加，否则忽略</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        /// <param name="append">相同名称的属性值是否累加</param>
        public virtual TagBuilder AttributeIf( string name, string value, bool condition, bool replaceExisting = false, bool append = false ) {
            if ( condition == false )
                return this;
            Attribute( name, value, replaceExisting, append );
            return this;
        }

        /// <summary>
        /// 添加属性,当值为空时忽略
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        /// <param name="append">相同名称的属性值是否累加</param>
        public virtual TagBuilder AttributeIfNotEmpty( string name, string value, bool replaceExisting = false, bool append = false ) {
            AttributeIf( name, value, !string.IsNullOrWhiteSpace( value ), replaceExisting, append );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="content">内容</param>
        public virtual TagBuilder AppendContent( string content ) {
            _tagBuilder.InnerHtml.AppendHtml( content );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="content">内容</param>
        public virtual TagBuilder AppendContent( IHtmlContent content ) {
            _tagBuilder.InnerHtml.AppendHtml( content );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public virtual TagBuilder AppendContent( TagBuilder tagBuilder ) {
            AppendContent( (IHtmlContent)tagBuilder );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public virtual TagBuilder SetContent( string content ) {
            _tagBuilder.InnerHtml.SetHtmlContent( content );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public virtual TagBuilder SetContent( IHtmlContent content ) {
            _tagBuilder.InnerHtml.SetHtmlContent( content );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="tagBuilder">标签生成器</param>
        public virtual TagBuilder SetContent( TagBuilder tagBuilder ) {
            SetContent( (IHtmlContent)tagBuilder );
            return this;
        }

        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public virtual void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            if( PreBuilder != null )
                PreBuilder.WriteTo( writer, NullHtmlEncoder.Default );
            _tagBuilder.WriteTo( writer, NullHtmlEncoder.Default );
            if ( PostBuilder != null )
                PostBuilder.WriteTo( writer, NullHtmlEncoder.Default );
        }

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public override string ToString() {
            using var writer = new StringWriter();
            _tagBuilder.WriteTo( writer, NullHtmlEncoder.Default );
            return writer.ToString();
        }

        /// <summary>
        /// 配置
        /// </summary>
        public virtual void Config() {
        }

        /// <summary>
        /// 基础配置
        /// </summary>
        /// <param name="config">配置</param>
        public virtual void ConfigBase( Config config ) {
            ConfigStyle( config );
            ConfigClass( config );
            ConfigHidden( config );
            ConfigOutputAttributes( config );
        }

        /// <summary>
        /// 配置样式
        /// </summary>
        /// <param name="config">配置</param>
        protected virtual void ConfigStyle( Config config ) {
            this.Style( config );
        }

        /// <summary>
        /// 配置样式类
        /// </summary>
        /// <param name="config">配置</param>
        protected virtual void ConfigClass( Config config ) {
            this.Class( config );
        }

        /// <summary>
        /// 配置隐藏
        /// </summary>
        /// <param name="config">配置</param>
        protected virtual void ConfigHidden( Config config ) {
            this.Hidden( config );
        }

        /// <summary>
        /// 配置输出属性
        /// </summary>
        /// <param name="config">配置</param>
        protected virtual void ConfigOutputAttributes( Config config ) {
            this.Attributes( config.OutputAttributes );
        }
    }
}
