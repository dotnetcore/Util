using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Util.Helpers {
    /// <summary>
    /// 类型转换
    /// </summary>
    public static class Convert {

        #region ToInt(转换为32位整型)

        /// <summary>
        /// 转换为32位整型
        /// </summary>
        /// <param name="input">输入值</param>
        public static int ToInt( object input ) {
            return ToIntOrNull( input ) ?? 0;
        }

        #endregion

        #region ToIntOrNull(转换为32位可空整型)

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

        #endregion

        #region ToLong(转换为64位整型)

        /// <summary>
        /// 转换为64位整型
        /// </summary>
        /// <param name="input">输入值</param>
        public static long ToLong( object input ) {
            return ToLongOrNull( input ) ?? 0;
        }

        #endregion

        #region ToLongOrNull(转换为64位可空整型)

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

        #endregion

        #region ToFloat(转换为32位浮点型)

        /// <summary>
        /// 转换为32位浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static float ToFloat( object input, int? digits = null ) {
            return ToFloatOrNull( input, digits ) ?? 0;
        }

        #endregion

        #region ToFloatOrNull(转换为32位可空浮点型)

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

        #endregion

        #region ToDouble(转换为64位浮点型)

        /// <summary>
        /// 转换为64位浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static double ToDouble( object input, int? digits = null ) {
            return ToDoubleOrNull( input, digits ) ?? 0;
        }

        #endregion

        #region ToDoubleOrNull(转换为64位可空浮点型)

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

        #endregion

        #region ToDecimal(转换为128位浮点型)

        /// <summary>
        /// 转换为128位浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal( object input, int? digits = null ) {
            return ToDecimalOrNull( input, digits ) ?? 0;
        }

        #endregion

        #region ToDecimalOrNull(转换为128位可空浮点型)

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

        #endregion

        #region ToBool(转换为布尔值)

        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        public static bool ToBool( object input ) {
            return ToBoolOrNull( input ) ?? false;
        }

        #endregion

        #region ToBoolOrNull(转换为可空布尔值)

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        public static bool? ToBoolOrNull( object input ) {
            var value = input.SafeString();
            switch ( value ) {
                case "1":
                    return true;
                case "0":
                    return false;
            }
            return bool.TryParse( value, out var result ) ? result : null;
        }

        #endregion

        #region ToDateTime(转换为日期)

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="input">输入值</param>
        public static DateTime ToDateTime( object input ) {
            return ToDateTimeOrNull( input ) ?? DateTime.MinValue;
        }

        #endregion

        #region ToDateTimeOrNull(转换为可空日期)

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="input">输入值</param>
        public static DateTime? ToDateTimeOrNull( object input ) {
            var success = DateTime.TryParse( input.SafeString(), out var result );
            if ( success == false )
                return null;
            return result;
        }

        #endregion

        #region ToGuid(转换为Guid)

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="input">输入值</param>
        public static Guid ToGuid( object input ) {
            return ToGuidOrNull( input ) ?? Guid.Empty;
        }

        #endregion

        #region ToGuidOrNull(转换为可空Guid)

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="input">输入值</param>
        public static Guid? ToGuidOrNull( object input ) {
            return Guid.TryParse( input.SafeString(), out var result ) ? result : null;
        }

        #endregion

        #region ToGuidList(转换为Guid集合)

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="input">以逗号分隔的Guid集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        public static List<Guid> ToGuidList( string input ) {
            return ToList<Guid>( input );
        }

        #endregion

        #region ToBytes(转换为字节数组)

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

        #endregion

        #region ToList(泛型集合转换)

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

        #endregion

        #region To(通用泛型转换)

        /// <summary>
        /// 通用泛型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="input">输入值</param>
        public static T To<T>( object input ) {
            if( input == null )
                return default;
            if( input is string && string.IsNullOrWhiteSpace( input.ToString() ) )
                return default;
            Type type = Common.GetType<T>();
            var typeName = type.Name.ToUpperInvariant();
            try {
                if( typeName == "STRING" || typeName == "GUID" )
                    return (T)TypeDescriptor.GetConverter( typeof( T ) ).ConvertFromInvariantString( input.ToString() );
                if ( type.IsEnum )
                    return Enum.Parse<T>( input );
                if ( input is IConvertible )
                    return (T)System.Convert.ChangeType( input, type, CultureInfo.InvariantCulture );
                if ( input is JsonElement element ) {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return Json.ToObject<T>( element.GetRawText(), options );
                }
                return (T)input;
            }
            catch {
                return default;
            }
        }

        #endregion

        #region ToDictionary(对象转换为属性名值对)

        /// <summary>
        /// 对象转换为属性名值对
        /// </summary>
        /// <param name="data">对象</param>
        public static IDictionary<string, object> ToDictionary( object data ) {
            if( data == null )
                return null;
            if ( data is IEnumerable<KeyValuePair<string, object>> dic )
                return new Dictionary<string, object>( dic );
            var result = new Dictionary<string, object>();
            foreach ( PropertyDescriptor property in TypeDescriptor.GetProperties( data ) ) {
                var value = property.GetValue( data );
                result.Add( property.Name, value );
            }
            return result;
        }

        #endregion
    }
}
