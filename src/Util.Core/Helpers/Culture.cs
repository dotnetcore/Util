using System.Collections.Generic;
using System.Globalization;

namespace Util.Helpers {
    /// <summary>
    /// 区域文化
    /// </summary>
    public static class Culture {
        /// <summary>
        /// 获取当前区域文化信息列表,包含所有父区域文化
        /// </summary>
        public static List<CultureInfo> GetCurrentCultures() {
            return GetCultures( CultureInfo.CurrentCulture );
        }

        /// <summary>
        /// 获取当前UI区域文化信息列表,包含所有父区域文化
        /// </summary>
        public static List<CultureInfo> GetCurrentUICultures() {
            return GetCultures( CultureInfo.CurrentUICulture );
        }

        /// <summary>
        /// 获取区域文化信息列表,包含所有父区域文化
        /// </summary>
        /// <param name="culture">区域文化信息</param>
        public static List<CultureInfo> GetCultures( CultureInfo culture ) {
            var result = new List<CultureInfo>();
            if ( culture == null )
                return result;
            while ( culture.Equals( culture.Parent ) == false ) {
                result.Add( culture );
                culture = culture.Parent;
            }
            return result;
        }
    }
}
