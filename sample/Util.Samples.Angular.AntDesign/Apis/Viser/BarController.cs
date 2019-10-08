using Microsoft.AspNetCore.Mvc;
using Util.Ui.Viser.Data;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Viser {
    /// <summary>
    /// 条形图控制器
    /// </summary>
    public class BarController : WebApiControllerBase {
        /// <summary>
        /// 获取基础条形图数据
        /// </summary>
        [HttpGet]
        public IActionResult GetBasicBar() {
            var data = new ChartData();
            data.Add( "印度", 104970 );
            data.Add( "美国", 29034 );
            data.Add( "巴西", 18203 );
            data.Add( "中国", 131744 );
            data.Add( "印尼", 23489 );
            return Success( data.ToResult() );
        }

        /// <summary>
        /// 获取分组条形图数据
        /// </summary>
        [HttpGet( "group" )]
        public IActionResult GetGroupBar() {
            var data = new ChartData();
            data.Add( "Mon", new Point( "series1", 2800 ), new Point( "series2", 2260 ) );
            data.Add( "Fri", new Point( "series1", 170 ), new Point( "series2", 100 ) );
            data.Add( "Wed", new Point( "series1", 950 ), new Point( "series2", 900 ) );
            data.Add( "Thur", new Point( "series1", 500 ), new Point( "series2", 390 ) );
            data.Add( "Tues", new Point( "series1", 1800 ), new Point( "series2", 1300 ) );
            return Success( data.ToResult() );
        }
    }
}