using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Samples.Pages.Components.Forms;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Demo {
    /// <summary>
    /// 表单控制器
    /// </summary>
    public class FormController : WebApiControllerBase {
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public IActionResult Create( [FromBody] FormModel model ) {
            Thread.Sleep( 2000 );
            return Success();
        }

        /// <summary>
        /// 获取列表项
        /// </summary>
        [HttpGet( "items" )]
        public IActionResult GetItems() {
            var list = new List<Item> {
                new Item( "汽车", 1 ),
                new Item( "飞机", 2 ),
                new Item( "轮船", 3,disabled:true ),
                new Item( "火箭", 4 )
            };
            return Success( list );
        }

        /// <summary>
        /// 获取分组列表项
        /// </summary>
        [HttpGet( "groupItems" )]
        public async Task<IActionResult> GetGroupItems() {
            await Task.Delay( 3000 );
            var list = new List<Item> {
                new Item( "汽车", 1,group:"交通工具" ),
                new Item( "飞机", 2,group:"交通工具" ),
                new Item( "轮船", 3,group:"交通工具",disabled:true ),
                new Item( "飞刀", 5,group:"武器" ),
                new Item( "手枪", 6,group:"武器" ),
                new Item( "AK47", 7,group:"武器",disabled:true ),
            };
            return Success( list );
        }
    }
}