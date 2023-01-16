using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Util.Helpers;

namespace Util.Data.EntityFrameworkCore.ValueConverters {
    /// <summary>
    /// 日期值转换器,用于处理Utc日期
    /// </summary>
    public class DateTimeValueConverter : ValueConverter<DateTime?, DateTime?> {
        /// <summary>
        /// 初始化日期值转换器
        /// </summary>
        public DateTimeValueConverter()
            : base( date => Normalize( date ), date => ToLocalTime( date ) ) {
        }

        /// <summary>
        /// 转换为标准化日期
        /// </summary>
        public static DateTime? Normalize( DateTime? date ) {
            return date.HasValue ? Time.Normalize( date.Value ) : null;
        }

        /// <summary>
        /// 转换为本地化日期
        /// </summary>
        public static DateTime? ToLocalTime( DateTime? date ) {
            return date.HasValue ? Time.UtcToLocalTime( date.Value ) : null;
        }
    }
}