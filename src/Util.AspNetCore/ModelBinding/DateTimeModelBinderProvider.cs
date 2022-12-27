using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace Util.ModelBinding {
    /// <summary>
    /// 日期模型绑定器提供程序
    /// </summary>
    public class DateTimeModelBinderProvider : IModelBinderProvider {
        /// <summary>
        /// 获取期模型绑定器
        /// </summary>
        /// <param name="context">模型绑定器提供程序上下文</param>
        public IModelBinder GetBinder( ModelBinderProviderContext context ) {
            context.CheckNull( nameof( context ) );
            const DateTimeStyles supportedStyles = DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal;
            var dateTimeModelBinder = new Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DateTimeModelBinder( supportedStyles, context.Services.GetRequiredService<ILoggerFactory>() );
            return new DateTimeModelBinder( dateTimeModelBinder );
        }
    }
}
