using Microsoft.AspNetCore.Mvc;
using Util.Ui.Viser.Data;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Viser {
    /// <summary>
    /// 柱状图控制器
    /// </summary>
    public class ColumnController : WebApiControllerBase {
        /// <summary>
        /// 获取基础柱状图数据
        /// </summary>
        [HttpGet]
        public IActionResult GetBasicColumn() {
            var data = new ChartData();
            data.Add( "1991", 3 );
            data.Add( "1992", 4 );
            data.Add( "1993", 3.5 );
            data.Add( "1994", 5 );
            data.Add( "1995", 4.9 );
            data.Add( "1996", 6 );
            data.Add( "1997", 7 );
            data.Add( "1998", 9 );
            data.Add( "1999", 13 );
            return Success( data.ToColumnResult() );
        }

        /// <summary>
        /// 获取分组柱状图数据
        /// </summary>
        [HttpGet("group")]
        public IActionResult GetGroupColumn() {
            var data = new ChartData();
            data.Add( "Jan", new Point( "Tokyo", 7.0 ), new Point( "London", 3.9 ) );
            data.Add( "Feb", new Point( "Tokyo", 6.9 ), new Point( "London", 4.2 ) );
            data.Add( "Mar", new Point( "Tokyo", 9.5 ), new Point( "London", 5.7 ) );
            data.Add( "Apr", new Point( "Tokyo", 14.5 ), new Point( "London", 8.5 ) );
            data.Add( "May", new Point( "Tokyo", 18.4 ), new Point( "London", 11.9 ) );
            data.Add( "Jun", new Point( "Tokyo", 21.5 ), new Point( "London", 15.2 ) );
            data.Add( "Jul", new Point( "Tokyo", 25.2 ), new Point( "London", 17.0 ) );
            data.Add( "Aug", new Point( "Tokyo", 26.5 ), new Point( "London", 16.6 ) );
            data.Add( "Sep", new Point( "Tokyo", 23.3 ), new Point( "London", 14.2 ) );
            data.Add( "Oct", new Point( "Tokyo", 18.3 ), new Point( "London", 10.3 ) );
            data.Add( "Nov", new Point( "Tokyo", 13.9 ), new Point( "London", 6.6 ) );
            data.Add( "Dec", new Point( "Tokyo", 9.6 ), new Point( "London", 4.8 ) );
            return Success( data.ToColumnResult() );
        }
    }
}