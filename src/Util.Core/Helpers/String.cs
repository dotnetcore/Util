using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Util.Helpers {
    /// <summary>
    /// 字符串操作
    /// </summary>
    public static class String {

        #region Join(将集合连接为带分隔符的字符串)

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

        #endregion

        #region FirstLowerCase(首字母小写)

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

        #endregion

        #region FirstUpperCase(首字母大写)

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

        #endregion

        #region RemoveStart(移除起始字符串)

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
        /// 移除起始字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="start">要移除的值</param>
        public static StringBuilder RemoveStart( StringBuilder value, string start ) {
            if( value == null || value.Length == 0 )
                return null;
            if( string.IsNullOrEmpty( start ) )
                return value;
            if( start.Length > value.Length )
                return value;
            var chars = start.ToCharArray();
            for( int i = 0; i < chars.Length; i++ ) {
                if( value[i] != chars[i] )
                    return value;
            }
            return value.Remove( 0, start.Length );
        }

        #endregion

        #region RemoveEnd(移除末尾字符串)

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

        #endregion

        #region PinYin(获取汉字的拼音简码)

        /// <summary>
        /// 获取汉字的拼音简码，即首字母缩写,范例：中国,返回zg
        /// </summary>
        /// <param name="chineseText">汉字文本,范例： 中国</param>
        public static string PinYin( string chineseText ) {
            if( chineseText.IsEmpty() )
                return string.Empty;
            var result = new StringBuilder();
            foreach( char text in chineseText )
                result.Append( ResolvePinYin( text ) );
            return result.ToString().ToLower();
        }

        /// <summary>
        /// 解析单个汉字的拼音简码
        /// </summary>
        private static string ResolvePinYin( char text ) {
            byte[] charBytes = Encoding.UTF8.GetBytes( text.ToString() );
            if( charBytes[0] <= 127 )
                return text.ToString();
            var unicode = (ushort)( charBytes[0] * 256 + charBytes[1] );
            string pinYin = ResolveByCode( unicode );
            if( pinYin.IsEmpty() == false )
                return pinYin;
            return ResolveByConst( text.ToString() );
        }

        /// <summary>
        /// 使用字符编码方式获取拼音简码
        /// </summary>
        private static string ResolveByCode( ushort unicode ) {
            if( unicode >= '\uB0A1' && unicode <= '\uB0C4' )
                return "A";
            if( unicode >= '\uB0C5' && unicode <= '\uB2C0' && unicode != 45464 )
                return "B";
            if( unicode >= '\uB2C1' && unicode <= '\uB4ED' )
                return "C";
            if( unicode >= '\uB4EE' && unicode <= '\uB6E9' )
                return "D";
            if( unicode >= '\uB6EA' && unicode <= '\uB7A1' )
                return "E";
            if( unicode >= '\uB7A2' && unicode <= '\uB8C0' )
                return "F";
            if( unicode >= '\uB8C1' && unicode <= '\uB9FD' )
                return "G";
            if( unicode >= '\uB9FE' && unicode <= '\uBBF6' )
                return "H";
            if( unicode >= '\uBBF7' && unicode <= '\uBFA5' )
                return "J";
            if( unicode >= '\uBFA6' && unicode <= '\uC0AB' )
                return "K";
            if( unicode >= '\uC0AC' && unicode <= '\uC2E7' )
                return "L";
            if( unicode >= '\uC2E8' && unicode <= '\uC4C2' )
                return "M";
            if( unicode >= '\uC4C3' && unicode <= '\uC5B5' )
                return "N";
            if( unicode >= '\uC5B6' && unicode <= '\uC5BD' )
                return "O";
            if( unicode >= '\uC5BE' && unicode <= '\uC6D9' )
                return "P";
            if( unicode >= '\uC6DA' && unicode <= '\uC8BA' )
                return "Q";
            if( unicode >= '\uC8BB' && unicode <= '\uC8F5' )
                return "R";
            if( unicode >= '\uC8F6' && unicode <= '\uCBF9' )
                return "S";
            if( unicode >= '\uCBFA' && unicode <= '\uCDD9' )
                return "T";
            if( unicode >= '\uCDDA' && unicode <= '\uCEF3' )
                return "W";
            if( unicode >= '\uCEF4' && unicode <= '\uD188' )
                return "X";
            if( unicode >= '\uD1B9' && unicode <= '\uD4D0' )
                return "Y";
            if( unicode >= '\uD4D1' && unicode <= '\uD7F9' )
                return "Z";
            return string.Empty;
        }

        /// <summary>
        /// 通过拼音简码常量获取
        /// </summary>
        private static string ResolveByConst( string text ) {
            int index = Const.ChinesePinYin.IndexOf( text, StringComparison.Ordinal );
            if( index < 0 )
                return string.Empty;
            return Const.ChinesePinYin.Substring( index + 1, 1 );
        }

        #endregion
    }
}
