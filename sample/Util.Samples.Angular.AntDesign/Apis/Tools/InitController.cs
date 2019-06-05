using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;
using Util.Webs.Razors;

namespace Util.Samples.Apis.Tools
{
    /// <summary>
    /// 初始化控制器
    /// </summary>
    public class InitController : WebApiControllerBase
    {
        /// <summary>
        /// Razor静态Html生成器
        /// </summary>
        public IRazorHtmlGenerator RazorHtmlGenerator { get; set; }

        /// <summary>
        /// 初始化一个<see cref="InitController"/>类型的实例
        /// </summary>
        public InitController(IRazorHtmlGenerator razorHtmlGenerator)
        {
            RazorHtmlGenerator = razorHtmlGenerator;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        [HttpGet("init")]
        public async Task<IActionResult> Init()
        {
            await RazorHtmlGenerator.Generate();
            return Success();
        }
    }
}
