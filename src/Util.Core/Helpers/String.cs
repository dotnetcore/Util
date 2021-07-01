using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Util.Helpers {
    /// <summary>
    /// 字符串操作
    /// </summary>
    public static class String {
        /// <summary>
        /// 将集合连接为带分隔符的字符串
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="values">值</param>
        /// <param name="quotes">引号，默认不带引号，范例：单引号 "'"</param>
        /// <param name="separator">分隔符，默认使用逗号分隔</param>
        public static string Join<T>( IEnumerable<T> values, string quotes = "", string separator = "," ) {
            if( values == null )
                return string.Empty;
            var result = new StringBuilder();
            foreach( var each in values )
                result.AppendFormat( "{0}{1}{0}{2}", quotes, each, separator );
            return result.ToString().RemoveEnd( separator );
        }

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="value">值</param>
        public static string FirstLowerCase( string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return string.Empty;
            var result = Rune.DecodeFromUtf16( value, out var rune, out var charsConsumed );
            if( result != OperationStatus.Done || Rune.IsLower( rune ) )
                return value;
            return Rune.ToLowerInvariant( rune ) + value[charsConsumed..];
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="value">值</param>
        public static string FirstUpperCase( string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return string.Empty;
            var result = Rune.DecodeFromUtf16( value, out var rune, out var charsConsumed );
            if( result != OperationStatus.Done || Rune.IsUpper( rune ) )
                return value;
            return Rune.ToUpperInvariant( rune ) + value[charsConsumed..];
        }

        /// <summary>
        /// 移除起始字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="start">要移除的值</param>
        public static string RemoveStart( string value, string start ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return string.Empty;
            if( string.IsNullOrEmpty( start ) )
                return value;
            if ( value.StartsWith( start, StringComparison.Ordinal ) == false )
                return value;
            return value.Substring( start.Length, value.Length - start.Length );
        }


        /// <summary>
        /// 移除末尾字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="end">要移除的值</param>
        public static string RemoveEnd( string value, string end ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return string.Empty;
            if( string.IsNullOrEmpty( end ) )
                return value;
            if( value.EndsWith( end, StringComparison.Ordinal ) == false )
                return value;
            return value.Substring( 0, value.LastIndexOf( end, StringComparison.Ordinal ) );
        }

        /// <summary>
        /// 移除起始字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="start">要移除的值</param>
        public static StringBuilder RemoveStart( StringBuilder value, string start ) {
            if( value == null || value.Length == 0 )
                return null;
            if( string.IsNullOrEmpty( start ) )
                return value;
            if ( start.Length > value.Length )
                return value;
            var chars = start.ToCharArray();
            for ( int i = 0; i < chars.Length; i++ ) {
                if ( value[i] != chars[i] )
                    return value;
            }
            return value.Remove( 0, start.Length );
        }

        /// <summary>
        /// 移除末尾字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="end">要移除的值</param>
        public static StringBuilder RemoveEnd( StringBuilder value, string end ) {
            if( value == null || value.Length == 0 )
                return null;
            if( string.IsNullOrEmpty( end ) )
                return value;
            if( end.Length > value.Length )
                return value;
            var chars = end.ToCharArray();
            for( int i = chars.Length-1; i >= 0; i-- ) {
                var j = value.Length - ( chars.Length - i );
                if( value[j] != chars[i] )
                    return value;
            }
            return value.Remove( value.Length - end.Length, end.Length );
        }
    }
}
