using System;
using System.Threading.Tasks;
using Convert = Util.Helpers.Convert;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql查询对象操作扩展 - 获取单值扩展
    /// </summary>
    public static partial class SqlQueryExtensions {

        #region ToStringAsync(获取字符串值)

        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<string> ToStringAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return result.SafeString();
        }

        #endregion

        #region ToInt(获取整型值)

        /// <summary>
        /// 获取32位整型值
        /// </summary>
        /// <param name="source">源</param>
        public static int ToInt( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToInt( source.ExecuteScalar() );
        }

        #endregion

        #region ToIntAsync(获取整型值)

        /// <summary>
        /// 获取32位整型值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<int> ToIntAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToInt( result );
        }

        #endregion

        #region ToIntOrNull(获取可空整型值)

        /// <summary>
        /// 获取32位可空整型值
        /// </summary>
        /// <param name="source">源</param>
        public static int? ToIntOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToIntOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToIntOrNullAsync(获取可空整型值)

        /// <summary>
        /// 获取32位可空整型值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<int?> ToIntOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToIntOrNull( result );
        }

        #endregion

        #region ToLong(获取整型值)

        /// <summary>
        /// 获取64位整型值
        /// </summary>
        /// <param name="source">源</param>
        public static long ToLong( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToLong( source.ExecuteScalar() );
        }

        #endregion

        #region ToLongAsync(获取整型值)

        /// <summary>
        /// 获取64位整型值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<long> ToLongAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToLong( result );
        }

        #endregion

        #region ToLongOrNull(获取可空整型值)

        /// <summary>
        /// 获取64位可空整型值
        /// </summary>
        /// <param name="source">源</param>
        public static long? ToLongOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToLongOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToLongOrNullAsync(获取可空整型值)

        /// <summary>
        /// 获取64位可空整型值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<long?> ToLongOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToLongOrNull( result );
        }

        #endregion

        #region ToGuid(获取Guid值)

        /// <summary>
        /// 获取Guid值
        /// </summary>
        /// <param name="source">源</param>
        public static Guid ToGuid( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToGuid( source.ExecuteScalar() );
        }

        #endregion

        #region ToGuidAsync(获取Guid值)

        /// <summary>
        /// 获取Guid值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<Guid> ToGuidAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToGuid( result );
        }

        #endregion

        #region ToGuidOrNull(获取可空Guid值)

        /// <summary>
        /// 获取可空Guid值
        /// </summary>
        /// <param name="source">源</param>
        public static Guid? ToGuidOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToGuidOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToGuidOrNullAsync(获取可空Guid值)

        /// <summary>
        /// 获取可空Guid值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<Guid?> ToGuidOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToGuidOrNull( result );
        }

        #endregion

        #region ToBool(获取布尔值)

        /// <summary>
        /// 获取布尔值
        /// </summary>
        /// <param name="source">源</param>
        public static bool ToBool( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToBool( source.ExecuteScalar() );
        }

        #endregion

        #region ToBoolAsync(获取布尔值)

        /// <summary>
        /// 获取布尔值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<bool> ToBoolAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToBool( result );
        }

        #endregion

        #region ToBoolOrNull(获取可空布尔值)

        /// <summary>
        /// 获取可空布尔值
        /// </summary>
        /// <param name="source">源</param>
        public static bool? ToBoolOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToBoolOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToBoolOrNullAsync(获取可空布尔值)

        /// <summary>
        /// 获取可空布尔值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<bool?> ToBoolOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToBoolOrNull( result );
        }

        #endregion

        #region ToFloat(获取浮点值)

        /// <summary>
        /// 获取32位浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static float ToFloat( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToFloat( source.ExecuteScalar() );
        }

        #endregion

        #region ToFloatAsync(获取浮点值)

        /// <summary>
        /// 获取32位浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<float> ToFloatAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToFloat( result );
        }

        #endregion

        #region ToFloatOrNull(获取可空浮点值)

        /// <summary>
        /// 获取32位可空浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static float? ToFloatOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToFloatOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToFloatOrNullAsync(获取可空浮点值)

        /// <summary>
        /// 获取32位可空浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<float?> ToFloatOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToFloatOrNull( result );
        }

        #endregion

        #region ToDouble(获取浮点值)

        /// <summary>
        /// 获取64位浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static double ToDouble( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToDouble( source.ExecuteScalar() );
        }

        #endregion

        #region ToDoubleAsync(获取浮点值)

        /// <summary>
        /// 获取64位浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<double> ToDoubleAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToDouble( result );
        }

        #endregion

        #region ToDoubleOrNull(获取可空浮点值)

        /// <summary>
        /// 获取64位可空浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static double? ToDoubleOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToDoubleOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToDoubleOrNullAsync(获取可空浮点值)

        /// <summary>
        /// 获取64位可空浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<double?> ToDoubleOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToDoubleOrNull( result );
        }

        #endregion

        #region ToDecimal(获取浮点值)

        /// <summary>
        /// 获取128位浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static decimal ToDecimal( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToDecimal( source.ExecuteScalar() );
        }

        #endregion

        #region ToDecimalAsync(获取浮点值)

        /// <summary>
        /// 获取128位浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<decimal> ToDecimalAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToDecimal( result );
        }

        #endregion

        #region ToDecimalOrNull(获取可空浮点值)

        /// <summary>
        /// 获取128位可空浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static decimal? ToDecimalOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToDecimalOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToDecimalOrNullAsync(获取可空浮点值)

        /// <summary>
        /// 获取128位可空浮点值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<decimal?> ToDecimalOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToDecimalOrNull( result );
        }

        #endregion

        #region ToDateTime(获取日期值)

        /// <summary>
        /// 获取日期值
        /// </summary>
        /// <param name="source">源</param>
        public static DateTime ToDateTime( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToDateTime( source.ExecuteScalar() );
        }

        #endregion

        #region ToDateTimeAsync(获取日期值)

        /// <summary>
        /// 获取日期值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<DateTime> ToDateTimeAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToDateTime( result );
        }

        #endregion

        #region ToDateTimeOrNull(获取可空日期值)

        /// <summary>
        /// 获取可空日期值
        /// </summary>
        /// <param name="source">源</param>
        public static DateTime? ToDateTimeOrNull( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return Convert.ToDateTimeOrNull( source.ExecuteScalar() );
        }

        #endregion

        #region ToDateTimeOrNullAsync(获取可空日期值)

        /// <summary>
        /// 获取可空日期值
        /// </summary>
        /// <param name="source">源</param>
        public static async Task<DateTime?> ToDateTimeOrNullAsync( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            var result = await source.ExecuteScalarAsync();
            return Convert.ToDateTimeOrNull( result );
        }

        #endregion
    }
}
