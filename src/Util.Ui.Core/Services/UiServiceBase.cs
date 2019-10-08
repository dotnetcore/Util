using Microsoft.AspNetCore.Mvc.Rendering;

namespace Util.Ui.Services {
    /// <summary>
    /// 组件服务
    /// </summary>
    public class UiServiceBase<TModel> : IContext<TModel> {
        /// <summary>
        /// 初始化组件服务
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        public UiServiceBase( IHtmlHelper<TModel> helper ) {
            Helper = helper;
        }

        /// <summary>
        /// HtmlHelper
        /// </summary>
        public IHtmlHelper<TModel> Helper { get; }
    }
}
