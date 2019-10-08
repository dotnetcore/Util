using Microsoft.AspNetCore.Mvc;
using Util.Ui.Viser.Data;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Viser {
    /// <summary>
    /// 饼图控制器
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

        /// <summary>
        /// 获取南丁格尔玫瑰图数据
        /// </summary>
        [HttpGet("rose")]
        public IActionResult GetRosePie() {
            var data = new ChartData();
            data.Add( "2001", 41.8 );
            data.Add( "2002", 38 );
            data.Add( "2003", 33.7 );
            data.Add( "2004", 30.7 );
            data.Add( "2005", 25.8 );
            data.Add( "2006", 31.7 );
            data.Add( "2007", 33 );
            data.Add( "2008", 46 );
            data.Add( "2009", 38.3 );
            data.Add( "2010", 28 );
            data.Add( "2011", 42.5 );
            data.Add( "2012", 30.3 );
            return Success( data.ToResult() );
        }
    }
}