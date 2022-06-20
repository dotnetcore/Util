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
        public DateTimeValueConverter( ConverterMappingHints mappingHints = null )
            : base(
                date => date.HasValue ? Time.Normalize( date.Value ) : date,
                date => date.HasValue ? Time.Normalize( date.Value ) : date, mappingHints 
            ) {
        }
    }
}