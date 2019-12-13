using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Helpers {
    /// <summary>
    /// 类型转换
    /// </summary>
    public static partial class Convert {
        /// <summary>
        /// 转换为32位整型
        /// </summary>
        /// <param name="input">输入值</param>
        public static int ToInt( object input ) {
            return ToIntOrNull( input ) ?? 0;
        }

        /// <summary>
        /// 转换为32位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        public static int? ToIntOrNull( object input ) {
            var success = int.TryParse( input.SafeString(), out var result );
            if( success )
                return result;
            try {
                var temp = ToDoubleOrNull( input, 0 );
                if( temp == null )
                    return null;
                return System.Convert.ToInt32( temp );
            }
            catch {
                return null;
            }
        }

        /// <summary>
        /// 转换为64位整型
        /// </summary>
        /// <param name="input">输入值</param>
        public static long ToLong( object input ) {
            return ToLongOrNull( input ) ?? 0;
        }

        /// <summary>
        /// 转换为64位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        public static long? ToLongOrNull( object input ) {
            var success = long.TryParse( input.SafeString(), out var result );
            if( success )
                return result;
            try {
                var temp = ToDecimalOrNull( input, 0 );
                if( temp == null )
                    return null;
                return System.Convert.ToInt64( temp );
            }
            catch {
                return null;
            }
        }

        /// <summary>
        /// 转换为32位浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static float ToFloat( object input, int? digits = null ) {
            return ToFloatOrNull( input, digits ) ?? 0;
        }

        /// <summary>
        /// 转换为32位可空浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static float? ToFloatOrNull( object input, int? digits = null ) {
            var success = float.TryParse( input.SafeString(), out var result );
            if( !success )
                return null;
            if( digits == null )
                return result;
            return (float)Math.Round( result, digits.Value );
        }

        /// <summary>
        /// 转换为64位浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static double ToDouble( object input, int? digits = null ) {
            return ToDoubleOrNull( input, digits ) ?? 0;
        }

        /// <summary>
        /// 转换为64位可空浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static double? ToDoubleOrNull( object input, int? digits = null ) {
            var success = double.TryParse( input.SafeString(), out var result );
            if( !success )
                return null;
            if( digits == null )
                return result;
            return Math.Round( result, digits.Value );
        }

        /// <summary>
        /// 转换为128位浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal( object input, int? digits = null ) {
            return ToDecimalOrNull( input, digits ) ?? 0;
        }

        /// <summary>
        /// 转换为128位可空浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static decimal? ToDecimalOrNull( object input, int? digits = null ) {
            var success = decimal.TryParse( input.SafeString(), out var result );
            if( !success )
                return null;
            if( digits == null )
                return result;
            return Math.Round( result, digits.Value );
        }

        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        public static bool ToBool( object input ) {
            return ToBoolOrNull( input ) ?? false;
        }

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        public static bool? ToBoolOrNull( object input ) {
            bool? value = GetBool( input );
            if( value != null )
                return value.Value;
            return bool.TryParse( input.SafeString(), out var result ) ? (bool?)result : null;
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        private static bool? GetBool( object input ) {
            switch( input.SafeString().ToLower() ) {
                case "0":
                    return false;
                case "否":
                    return false;
                case "不":
                    return false;
                case "no":
                    return false;
                case "fail":
                    return false;
                case "1":
                    return true;
                case "是":
                    return true;
                case "ok":
                    return true;
                case "yes":
                    return true;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="input">输入值</param>
        public static DateTime ToDate( object input ) {
            return ToDateOrNull( input ) ?? DateTime.MinValue;
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="input">输入值</param>
        public static DateTime? ToDateOrNull( object input ) {
            return DateTime.TryParse( input.SafeString(), out var result ) ? (DateTime?)result : null;
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="input">输入值</param>
        public static Guid ToGuid( object input ) {
            return ToGuidOrNull( input ) ?? Guid.Empty;
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="input">输入值</param>
        public static Guid? ToGuidOrNull( object input ) {
            return Guid.TryParse( input.SafeString(), out var result ) ? (Guid?)result : null;
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="input">以逗号分隔的Guid集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        public static List<Guid> ToGuidList( string input ) {
            return ToList<Guid>( input );
        }

        /// <summary>
        /// 泛型集合转换
        /// </summary>
        /// <typeparam name="T">目标元素类型</typeparam>
        /// <param name="input">以逗号分隔的元素集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        public static List<T> ToList<T>( string input ) {
            var result = new List<T>();
            if( string.IsNullOrWhiteSpace( input ) )
                return result;
            var array = input.Split( ',' );
            result.AddRange( from each in array where !string.IsNullOrWhiteSpace( each ) select To<T>( each ) );
            return result;
        }

        /// <summary>
        /// 通用泛型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="input">输入值</param>
        public static T To<T>( object input ) {
            if( input == null )
                return default( T );
            if( input is string && string.IsNullOrWhiteSpace( input.ToString() ) )
                return default( T );
            Type type = Common.GetType<T>();
            var typeName = type.Name.ToLower();
            try {
                if( typeName == "string" )
                    return (T)(object)input.ToString();
                if( typeName == "guid" )
                    return (T)(object)new Guid( input.ToString() );
                if( type.IsEnum )
                    return Enum.Parse<T>( input );
                if( input is IConvertible )
                    return (T)System.Convert.ChangeType( input, type );
                return (T)input;
            }
            catch {
                return default( T );
            }
        }

        /// <summary>
        /// 转换为字节数组
        /// </summary>
        /// <param name="input">输入值</param>        
        public static byte[] ToBytes( string input ) {
            return ToBytes( input, Encoding.UTF8 );
        }

        /// <summary>
        /// 转换为字节数组
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] ToBytes( string input, Encoding encoding ) {
            return string.IsNullOrWhiteSpace( input ) ? new byte[] { } : encoding.GetBytes( input );
        }
    }
}
