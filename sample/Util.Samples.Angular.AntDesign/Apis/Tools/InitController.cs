using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Ui.Pages;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Tools {
    /// <summary>
    /// 初始化控制器
    /// </summary>
    public class InitController : WebApiControllerBase {
        /// <summary>
        /// Html生成器
        /// </summary>
        public IHtmlGenerator HtmlGenerator { get; set; }

        /// <summary>
        /// 初始化一个<see cref="InitController"/>类型的实例
        /// </summary>
        public InitController( IHtmlGenerator htmlGenerator ) {
            HtmlGenerator = htmlGenerator;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        [HttpGet]
        [Route( "/init" )]
        public async Task<IActionResult> Init() {
            await HtmlGenerator.BuildAsync();
            return Content( "ok" );
        }
    }
}
