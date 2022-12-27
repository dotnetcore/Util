using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using Util.Helpers;

namespace Util.ModelBinding {
    /// <summary>
    /// 日期模型绑定器
    /// </summary>
    public class DateTimeModelBinder : IModelBinder {
        /// <summary>
        /// 日期模型绑定器
        /// </summary>
        private readonly Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DateTimeModelBinder _dateTimeModelBinder;

        /// <summary>
        /// 初始化日期模型绑定器
        /// </summary>
        /// <param name="dateTimeModelBinder">日期模型绑定器</param>
        public DateTimeModelBinder( Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DateTimeModelBinder dateTimeModelBinder ) {
            _dateTimeModelBinder = dateTimeModelBinder;
        }

        /// <summary>
        /// 绑定模型
        /// </summary>
        /// <param name="bindingContext">模型绑定上下文</param>
        public async Task BindModelAsync( ModelBindingContext bindingContext ) {
            await _dateTimeModelBinder.BindModelAsync( bindingContext );
            if ( bindingContext.Result.IsModelSet && bindingContext.Result.Model is DateTime dateTime ) {
                bindingContext.Result = ModelBindingResult.Success( Time.Normalize( dateTime ) );
            }
        }
    }
}
