using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Extensions;

namespace Util.Ui.Configs {
    /// <summary>
    /// 配置
    /// </summary>
    public class Config {
        /// <summary>
        /// 初始化配置
        /// </summary>
        public Config() : this( null, null ) {
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        public Config( TagHelperContext context, TagHelperOutput output ) : this( context, output, null ) {
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        /// <param name="content">Html内容</param>
        public Config( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            Id = context?.UniqueId;
            context ??= new TagHelperContext( new TagHelperAttributeList(), new Dictionary<object, object>(), Guid.NewGuid().ToString() );
            Output = output ?? new TagHelperOutput( "", new TagHelperAttributeList(), ( useCachedResult, encoder ) => Task.FromResult( content ) );
            Content = content;
            AllAttributes = new TagHelperAttributeList( context.AllAttributes );
            OutputAttributes = new TagHelperAttributeList( Output.Attributes );
            Context = new TagHelperContext( AllAttributes, context.Items, context.UniqueId );
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 上下文
        /// </summary>
        protected TagHelperContext Context { get; set; }

        /// <summary>
        /// 输出
        /// </summary>
        protected TagHelperOutput Output { get; set; }

        /// <summary>
        /// Html内容
        /// </summary>
        public TagHelperContent Content { get; set; }

        /// <summary>
        /// 全部属性集合
        /// </summary>
        public TagHelperAttributeList AllAttributes { get; set; }

        /// <summary>
        /// 输出属性集合，TagHelper中未明确定义的属性从该集合获取
        /// </summary>
        public TagHelperAttributeList OutputAttributes { get; set; }

        /// <summary>
        /// 属性集合是否包含指定属性
        /// </summary>
        /// <param name="name">属性名</param>
        public bool Contains( string name ) {
            return AllAttributes.ContainsName( name );
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetValue( string name ) {
            return Contains( name ) ? AllAttributes[name].Value.SafeString() : string.Empty;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="name">属性名</param>
        public T GetValue<T>( string name ) {
            return Contains( name ) ? Util.Helpers.Convert.To<T>( AllAttributes[name].Value ) : default;
        }

        /// <summary>
        /// 获取布尔属性值
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetBoolValue( string name ) {
            return Util.Helpers.String.FirstLowerCase( GetValue( name ) );
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        public void SetAttribute( string name, object value, bool replaceExisting = true ) {
            if ( replaceExisting == false && Contains( name ) )
                return;
            AllAttributes.SetAttribute( new TagHelperAttribute( name, value ) );
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="name">属性名</param>
        public void RemoveAttribute( string name ) {
            AllAttributes.RemoveAll( name );
        }

        /// <summary>
        /// 从TagHelperContext Items里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">键</param>
        public T GetValueFromItems<T>( object key = null ) {
            return Context.GetValueFromItems<T>( key );
        }

        /// <summary>
        /// 设置TagHelperContext Items值
        /// </summary>
        /// <param name="value">值</param>
        public void SetValueToItems<T>( T value ) {
            Context.SetValueToItems( value );
        }

        /// <summary>
        /// 从TagHelperContext AllAttributes里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">键</param>
        public T GetValueFromAttributes<T>( string key ) {
            if ( Context == null )
                return default( T );
            return Context.GetValueFromAttributes<T>( key );
        }

        /// <summary>
        /// 从TagHelperContext AllAttributes里获取值
        /// </summary>
        /// <param name="key">键</param>
        public string GetValueFromAttributes( string key ) {
            return GetValueFromAttributes<string>( key );
        }

        /// <summary>
        /// 复制配置
        /// </summary>
        public Config Copy() {
            var content = new DefaultTagHelperContent();
            Content?.CopyTo( content );
            return new Config {
                Context = new TagHelperContext( AllAttributes, Context.Items, Util.Helpers.Id.Create() ),
                AllAttributes = new TagHelperAttributeList( AllAttributes ),
                OutputAttributes = new TagHelperAttributeList( OutputAttributes ),
                Content = content
            };
        }
    }
}
