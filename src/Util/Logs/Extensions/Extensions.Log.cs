using System.Collections.Generic;
using System.Linq;
using Util.Logs.Abstractions;

namespace Util.Logs.Extensions {
    /// <summary>
    /// 日志扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="log">日志操作</param>
        public static ILog Content( this ILog log ) {
            return log.Set<ILogContent>( content => content.Content( "" ) );
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="value">值</param>
        public static ILog Content( this ILog log, string value ) {
            return log.Set<ILogContent>( content => content.Content( value ) );
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="dictionary">字典</param>
        public static ILog Content( this ILog log, IDictionary<string, object> dictionary ) {
            if( dictionary == null )
                return log;
            return Content( log, dictionary.ToDictionary( t => t.Key, t => t.Value.SafeString() ) );
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="dictionary">字典</param>
        public static ILog Content( this ILog log, IDictionary<string, string> dictionary ) {
            if( dictionary == null )
                return log;
            foreach( var keyValue in dictionary )
                log.Set<ILogContent>( content => content.Content( $"{keyValue.Key} : {keyValue.Value}" ) );
            return log;
        }
    }
}
