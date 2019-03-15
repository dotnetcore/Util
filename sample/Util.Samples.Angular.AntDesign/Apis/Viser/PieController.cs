using Microsoft.AspNetCore.Mvc;
using Util.Ui.Viser.Data;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Viser {
    /// <summary>
    /// 饼图Api控制器
    /// </summary>
    public class PieController : WebApiControllerBase {
        /// <summary>
        /// 获取基础饼图数据
        /// </summary>
        [HttpGet]
        public IActionResult GetBasicPie() {
            var data = new ChartData();
            data.Add( "事例一", 40 );
            data.Add( "事例二", 21 );
            data.Add( "事例三", 17 );
            data.Add( "事例四", 13 );
            data.Add( "事例五", 9 );
            return Success( data.ToResult() );
        }
    }
}