using Util.Helpers;

namespace Util.Contexts {
    /// <summary>
    /// Web上下文
    /// </summary>
    public class WebContext : IContext {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId => Web.HttpContext?.TraceIdentifier;

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">对象</param>
        public void Add<T>( string key, T value ) {
            if( Web.HttpContext == null )
                return;
            Web.HttpContext.Items[key] = value;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        public T Get<T>( string key ) {
            if( Web.HttpContext == null )
                return default( T );
            return Util.Helpers.Convert.To<T>( Web.HttpContext.Items[key] );
        }

        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="key">键名</param>
        public void Remove( string key ) {
            Web.HttpContext?.Items.Remove( key );
        }
    }
}
