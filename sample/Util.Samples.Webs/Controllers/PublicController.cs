using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Util.Samples.Webs.Controllers
{
    public class PublicController : Controller
    {
        /// <summary>
        /// 搜索栏
        /// </summary>
        /// <returns></returns>
        public IActionResult SearchMenu()
        {
            return PartialView("SearchMenu");
        }
    }
}
