using System.IO;

namespace Util.Helpers {
    /// <summary>
    /// Url操作
    /// </summary>
    public static partial class Url {
        /// <summary>
        /// 合并Url
        /// </summary>
        /// <param name="urls">url片断，范例：Url.Combine( "http://a.com","b" ),返回 "http://a.com/b"</param>
        public static string Combine( params string[] urls ) {
            return Path.Combine( urls ).Replace( @"\", "/" );
        }

        /// <summary>
        /// 连接Url，范例：Url.Join( "http://a.com","b=1" ),返回 "http://a.com?b=1"
        /// </summary>
        /// <param name="url">Url，范例：http://a.com</param>
        /// <param name="param">参数，范例：b=1</param>
        public static string Join( string url, string param ) {
            return $"{GetUrl( url )}{param}";
        }

        /// <summary>
        /// 获取Url
        /// </summary>
        private static string GetUrl( string url ) {
            if( !url.Contains( "?" ) )
                return $"{url}?";
            if( url.EndsWith( "?" ) )
                return url;
            if( url.EndsWith( "&" ) )
                return url;
            return $"{url}&";
        }
    }
}
