using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Expressions;

namespace Util.Ui.TagHelpers {
    /// <summary>
    /// TagHelper包装器
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    public class TagHelperWrapper<TModel> : TagHelperWrapper {
        /// <summary>
        /// 初始化TagHelper包装器
        /// </summary>
        public TagHelperWrapper( ITagHelper tagHelper ) : base( tagHelper ) {
        }

        /// <summary>
        /// 设置属性表达式
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        public TagHelperWrapper SetExpression<TProperty>( Expression<Func<TModel, TProperty>> propertyExpression ) {
            return SetExpression( UiConst.For, propertyExpression );
        }

        /// <summary>
        /// 设置属性表达式
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="name">属性名</param>
        /// <param name="propertyExpression">属性表达式</param>
        public TagHelperWrapper SetExpression<TProperty>( string name, Expression<Func<TModel, TProperty>> propertyExpression ) {
            var modelExpression = ModelExpressionHelper.Create( Util.Helpers.Lambda.GetName( propertyExpression ), propertyExpression );
            SetContextAttribute( name, modelExpression );
            return this;
        }
    }

    /// <summary>
    /// TagHelper包装器
    /// </summary>
    public class TagHelperWrapper {
        /// <summary>
        /// 上下文属性集合
        /// </summary>
        private readonly TagHelperAttributeList _contextAttributes;
        /// <summary>
        /// 输出属性集合
        /// </summary>
        private readonly TagHelperAttributeList _outputAttributes;
        /// <summary>
        /// 共享项集合
        /// </summary>
        private readonly IDictionary<object, object> _items;
        /// <summary>
        /// 组件
        /// </summary>
        private readonly ITagHelper _component;
        /// <summary>
        /// 内容
        /// </summary>
        private readonly TagHelperContent _content;
        /// <summary>
        /// 子组件
        /// </summary>
        private readonly List<TagHelperWrapper> _children;

        /// <summary>
        /// 初始化TagHelper包装器
        /// </summary>
        public TagHelperWrapper( ITagHelper tagHelper ) {
            _component = tagHelper ?? throw new ArgumentNullException( nameof( tagHelper ) );
            _contextAttributes = new TagHelperAttributeList();
            _outputAttributes = new TagHelperAttributeList();
            _items = new Dictionary<object, object>();
            _content = new DefaultTagHelperContent();
            _children = new List<TagHelperWrapper>();
        }

        /// <summary>
        /// 获取TagHelper
        /// </summary>
        public ITagHelper GetTagHelper() {
            return _component;
        }

        /// <summary>
        /// 设置上下文属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        public TagHelperWrapper SetContextAttribute( string name, object value, bool replaceExisting = true ) {
            if ( replaceExisting == false && _contextAttributes.ContainsName( name ) )
                return this;
            _contextAttributes.SetAttribute( new TagHelperAttribute( name, value ) );
            return this;
        }

        /// <summary>
        /// 设置输出属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        public TagHelperWrapper SetOutputAttribute( string name, object value, bool replaceExisting = true ) {
            if ( replaceExisting == false && _outputAttributes.ContainsName( name ) )
                return this;
            _outputAttributes.SetAttribute( new TagHelperAttribute( name, value ) );
            return this;
        }

        /// <summary>
        /// 设置共享项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public TagHelperWrapper SetItem( object key, object value ) {
            if ( key != null )
                _items[key] = value;
            return this;
        }

        /// <summary>
        /// 设置共享项
        /// </summary>
        /// <param name="value">值</param>
        public TagHelperWrapper SetItem<T>( T value ) {
            var key = typeof( T );
            return SetItem( key, value );
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="value">值</param>
        public TagHelperWrapper AppendContent( string value ) {
            if ( string.IsNullOrWhiteSpace( value ) )
                return this;
            _content.AppendHtml( value );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="value">值</param>
        public TagHelperWrapper AppendContent( IHtmlContent value ) {
            if ( value == null )
                return this;
            _content.AppendHtml( value );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="childComponent">子组件</param>
        public TagHelperWrapper AppendContent( ITagHelper childComponent ) {
            if ( childComponent == null )
                return this;
            _children.Add( new TagHelperWrapper( childComponent ) );
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="childComponent">子组件</param>
        public TagHelperWrapper AppendContent( TagHelperWrapper childComponent ) {
            if ( childComponent == null )
                return this;
            _children.Add( childComponent );
            return this;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public string GetResult() {
            TagHelperContent content = new DefaultTagHelperContent();
            _content.CopyTo( content );
            var context = new TagHelperContext( _contextAttributes, _items, Guid.NewGuid().ToString() );
            var output = new TagHelperOutput( "", _outputAttributes, ( useCachedResult, encoder ) => {
                foreach ( var child in _children )
                    content.AppendHtml( child.GetContent( _items ) );
                return Task.FromResult( content );
            } );
            _component.ProcessAsync( context, output ).GetAwaiter().GetResult();
            var writer = new StringWriter();
            output.WriteTo( writer, HtmlEncoder.Default );
            return writer.ToString();
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <param name="items">上下文</param>
        public TagHelperContent GetContent( IDictionary<object, object> items ) {
            TagHelperContent content = new DefaultTagHelperContent();
            _content.CopyTo( content );
            IDictionary<object, object> newItems = items.ToDictionary( t => t.Key, t => t.Value );
            var context = new TagHelperContext( _contextAttributes, newItems, Guid.NewGuid().ToString() );
            var output = new TagHelperOutput( "", _outputAttributes, ( useCachedResult, encoder ) => {
                foreach ( var child in _children )
                    content.AppendHtml( child.GetContent( newItems ) );
                return Task.FromResult( content );
            } );
            _component.ProcessAsync( context, output );
            var result = new DefaultTagHelperContent();
            result.AppendHtml( output );
            return result;
        }
    }
}
