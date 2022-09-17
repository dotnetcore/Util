using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.Extensions {
    /// <summary>
    /// TagHelper扩展
    /// </summary>
    public static class TagHelperExtensions {
        /// <summary>
        /// 内容是否为空
        /// </summary>
        /// <param name="content">内容</param>
        public static bool IsEmpty( this TagHelperContent content ) {
            return content == null || content.IsEmptyOrWhiteSpace;
        }

        /// <summary>
        /// 将内容添加到标签生成器
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="builder">标签生成器</param>
        public static void AppendTo( this TagHelperContent content,TagBuilder builder ) {
            if( content.IsEmpty() )
                return;
            builder.AppendContent( content );
        }

        /// <summary>
        /// 从TagHelperContext Items里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="context">上下文</param>
        /// <param name="key">键</param>
        public static T GetValueFromItems<T>( this TagHelperContext context, object key = null ) {
            key ??= typeof(T);
            var exists = context.Items.TryGetValue( key, out var value );
            if( exists == false )
                return default( T );
            if( !( value is TagHelperAttribute tagHelperAttribute ) )
                return Util.Helpers.Convert.To<T>( value );
            return Util.Helpers.Convert.To<T>( tagHelperAttribute.Value );
        }

        /// <summary>
        /// 设置TagHelperContext Items值
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="value">值</param>
        public static void SetValueToItems<T>( this TagHelperContext context, T value ) {
            var key = typeof( T );
            SetValueToItems( context, key, value );
        }

        /// <summary>
        /// 设置TagHelperContext Items值
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetValueToItems( this TagHelperContext context, object key, object value ) {
            if ( key == null )
                return;
            context.Items[key] = value;
        }

        /// <summary>
        /// 从TagHelperContext AllAttributes里获取值
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="key">键</param>
        public static string GetValueFromAttributes( this TagHelperContext context, string key ) {
            return context.GetValueFromAttributes<string>( key );
        }

        /// <summary>
        /// 判断TagHelperContext AllAttributes是否存在指定项
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="key">键</param>
        public static bool ContainsByAttributes( this TagHelperContext context, string key ) {
            return context.AllAttributes.ContainsName( key );
        }

        /// <summary>
        /// 从TagHelperContext AllAttributes里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="context">上下文</param>
        /// <param name="key">键</param>
        public static T GetValueFromAttributes<T>( this TagHelperContext context, string key ) {
            var exists = context.AllAttributes.TryGetAttribute( key, out var value );
            if( exists == false )
                return default( T );
            if( !( value is { } tagHelperAttribute ) )
                return default( T );
            return Util.Helpers.Convert.To<T>( tagHelperAttribute?.Value );
        }
    }
}
