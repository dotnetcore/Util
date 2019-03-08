using Microsoft.AspNetCore.Mvc.RazorPages;
using Util.Webs.Filters;

namespace Util.Ui.Pages {
    /// <summary>
    /// 页面模型
    /// </summary>
    [Html( Template = "Typing/app/{area}/{controller}/{action}.component.html" )]
    public class PageModelBase : PageModel {
    }
}
