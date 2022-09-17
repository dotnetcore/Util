using Microsoft.AspNetCore.Mvc;
using Util.ModelBinding;

namespace Util {
    /// <summary>
    /// Mvc配置扩展
    /// </summary>
    public static class MvcOptionsExtensions {
        /// <summary>
        /// 添加日期模型绑定器
        /// </summary>
        /// <param name="options">Mvc配置</param>
        public static void AddDateTimeModelBinder( this MvcOptions options ) {
            options.ModelBinderProviders.Insert( 0, new DateTimeModelBinderProvider() );
        }
    }
}
