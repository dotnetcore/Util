using Microsoft.AspNetCore.Html;

namespace Util.Ui.Renders {
    /// <summary>
    /// 渲染器
    /// </summary>
    public interface IRender : IHtmlContent {
        /// <summary>
        /// 复制副本
        /// </summary>
        IHtmlContent Clone();
    }
}
