using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Util.Helpers {
    /// <summary>
    /// 正则操作
    /// </summary>
    public static class Regex {
        /// <summary>
        /// 获取匹配的结果
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="resultPatterns">结果模式字符串数组,范例：new[]{"$1","$2"}</param>
        /// <param name="options">选项</param>
        public static Dictionary<string, string> GetResults( string input, string pattern, string[] resultPatterns, RegexOptions options = RegexOptions.IgnoreCase ) {
            var result = new Dictionary<string, string>();
            if( string.IsNullOrWhiteSpace( input ) )
                return result;
            var match = System.Text.RegularExpressions.Regex.Match( input, pattern, options );
            if( match.Success == false )
                return result;
            AddResults( result, match, resultPatterns );
            return result;
        }

        /// <summary>
        /// 添加匹配结果
        /// </summary>
        private static void AddResults( Dictionary<string, string> result, Match match, string[] resultPatterns ) {
            if( resultPatterns == null ) {
                result.Add( string.Empty, match.Value );
                return;
            }
            foreach( var resultPattern in resultPatterns )
                result.Add( resultPattern, match.Result( resultPattern ) );
        }

        /// <summary>
        /// 获取匹配的结果
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="resultPattern">结果模式字符串,范例："$1"用来获取第一个()内的值</param>
        /// <param name="options">选项</param>
        public static string GetResult( string input, string pattern, string resultPattern = "", RegexOptions options = RegexOptions.IgnoreCase ) {
            if( string.IsNullOrWhiteSpace( input ) )
                return string.Empty;
            var match = System.Text.RegularExpressions.Regex.Match( input, pattern, options );
            if( match.Success == false )
                return string.Empty;
            return string.IsNullOrWhiteSpace( resultPattern ) ? match.Value : match.Result( resultPattern );
        }

        /// <summary>
        /// 分割成字符串数组
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">选项</param>
        public static string[] Split( string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase ) {
            if( string.IsNullOrWhiteSpace( input ) )
                return new string[]{};
            return System.Text.RegularExpressions.Regex.Split( input, pattern, options );
        }

        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="replacement">替换字符串</param>
        /// <param name="options">选项</param>
        public static string Replace( string input, string pattern,string replacement, RegexOptions options = RegexOptions.IgnoreCase ) {
            if( string.IsNullOrWhiteSpace( input ) )
                return string.Empty;
            return System.Text.RegularExpressions.Regex.Replace( input, pattern, replacement, options );
        }
    }
}
