using System;
using System.Text;

namespace Util {
    /// <summary>
    /// 系统扩展 - 格式化
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="value">布尔值</param>
        public static string Description( this bool value ) {
            return value ? "是" : "否";
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="value">布尔值</param>
        public static string Description( this bool? value ) {
            return value == null ? "" : Description( value.Value );
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="span">时间间隔</param>
        public static string Description( this TimeSpan span ) {
            StringBuilder result = new StringBuilder();
            if( span.Days > 0 )
                result.AppendFormat( "{0}天", span.Days );
            if( span.Hours > 0 )
                result.AppendFormat( "{0}小时", span.Hours );
            if( span.Minutes > 0 )
                result.AppendFormat( "{0}分", span.Minutes );
            if( span.Seconds > 0 )
                result.AppendFormat( "{0}秒", span.Seconds );
            return result.ToString();
        }
    }
}
