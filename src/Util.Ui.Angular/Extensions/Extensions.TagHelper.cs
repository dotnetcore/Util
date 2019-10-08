using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.Extensions {
    /// <summary>
    /// TagHelper组件扩展
    /// </summary>
    public static partial class Extensions {
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
            if( !( value is TagHelperAttribute tagHelperAttribute ) )
                return default( T );
            return Util.Helpers.Convert.To<T>( tagHelperAttribute?.Value );
        }

        /// <summary>
        /// 从TagHelperContext Items里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="context">上下文</param>
        /// <param name="key">键</param>
        public static T GetValueFromItems<T>( this TagHelperContext context, object key = null ) {
            if( key == null )
                key = typeof( T );
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
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetValueToItems( this TagHelperContext context, object key, object value ) {
            if( context.Items.ContainsKey( key ) )
                RemoveFromItems( context, key );
            context.Items[key] = value;
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
        /// 移除TagHelperContext Items值
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="key">键</param>
        public static void RemoveFromItems( this TagHelperContext context, object key ) {
            if( context.Items.ContainsKey( key ) == false )
                return;
            context.Items.Remove( key );
        }

        /// <summary>
        /// 移除TagHelperContext Items值
        /// </summary>
        /// <param name="context">上下文</param>
        public static void RemoveFromItems<T>( this TagHelperContext context ) {
            var key = typeof( T );
            RemoveFromItems( context, key );
        }

        /// <summary>
        /// 是否为空内容
        /// </summary>
        /// <param name="content">内容</param>
        public static bool IsEmpty( this TagHelperContent content ) {
            return content == null || content.IsEmptyOrWhiteSpace;
        }
    }
}
