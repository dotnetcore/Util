using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Util.Helpers;
using Util.Webs.Controllers;
using Util.Webs.Razors;

namespace Util.Samples.Webs.Apis.Tools
{
    /// <summary>
    /// 初始化Razor控制器
    /// </summary>
    public class InitRazorController : WebApiControllerBase
    {
        /// <summary>
        /// Razor静态Html生成器
        /// </summary>
        public IRazorHtmlGenerator RazorHtmlGenerator { get; set; }

        /// <summary>
        /// 初始化一个<see cref="InitRazorController"/>类型的实例
        /// </summary>
        /// <param name="razorHtmlGenerator"></param>
        public InitRazorController(IRazorHtmlGenerator razorHtmlGenerator)
        {
            RazorHtmlGenerator = razorHtmlGenerator;
        }

        /// <summary>
        /// 初始化路由
        /// </summary>
        /// <returns></returns>
        [Route("/api/init")]
        [HttpPost]
        public async Task<IActionResult> Init()
        {
            await RazorHtmlGenerator.Generate();
            return new JsonResult("");
        }
    }
}
