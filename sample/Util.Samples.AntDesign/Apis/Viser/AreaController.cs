using Microsoft.AspNetCore.Mvc;
using Util.Ui.Viser.Data;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Viser {
    /// <summary>
    /// 面积图控制器
    /// </summary>
    public class AreaController : WebApiControllerBase {
        /// <summary>
        /// 获取基础面积图数据
        /// </summary>
        [HttpGet]
        public IActionResult GetBasicArea() {
            var data = new ChartData();
            data.Add( "1991", 15468 );
            data.Add( "1992", 16100 );
            data.Add( "1993", 15900 );
            data.Add( "1994", 17409 );
            data.Add( "1995", 17000 );
            data.Add( "1996", 31056 );
            data.Add( "1997", 31982 );
            data.Add( "1998", 32040 );
            data.Add( "1999", 33233 );
            return Success( data.ToResult() );
        }

        /// <summary>
        /// 获取多区域面积图数据
        /// </summary>
        [HttpGet("multi")]
        public IActionResult GetMultiArea() {
            var data = new ChartData();
            data.Add( "1996", new Point( "north", 322 ), new Point( "south", 162 ) );
            data.Add( "1997", new Point( "north", 324 ), new Point( "south", 90 ) );
            data.Add( "1998", new Point( "north", 329 ), new Point( "south", 50 ) );
            data.Add( "1999", new Point( "north", 342 ), new Point( "south", 77 ) );
            data.Add( "2000", new Point( "north", 348 ), new Point( "south", 35 ) );
            data.Add( "2001", new Point( "north", 334 ), new Point( "south", -45 ) );
            data.Add( "2002", new Point( "north", 325 ), new Point( "south", -88 ) );
            data.Add( "2003", new Point( "north", 316 ), new Point( "south", -120 ) );
            data.Add( "2004", new Point( "north", 318 ), new Point( "south", -156 ) );
            data.Add( "2005", new Point( "north", 330 ), new Point( "south", -123 ) );
            data.Add( "2006", new Point( "north", 355 ), new Point( "south", -88 ) );
            data.Add( "2007", new Point( "north", 366 ), new Point( "south", -66 ) );
            data.Add( "2008", new Point( "north", 337 ), new Point( "south", -45 ) );
            data.Add( "2009", new Point( "north", 352 ), new Point( "south", -29 ) );
            data.Add( "2010", new Point( "north", 377 ), new Point( "south", -45 ) );
            data.Add( "2011", new Point( "north", 383 ), new Point( "south", -88 ) );
            data.Add( "2012", new Point( "north", 344 ), new Point( "south", -132 ) );
            data.Add( "2013", new Point( "north", 366 ), new Point( "south", -146 ) );
            data.Add( "2014", new Point( "north", 389 ), new Point( "south", -169 ) );
            data.Add( "2015", new Point( "north", 334 ), new Point( "south", -184 ) );
            return Success( data.ToResult() );
        }
    }
}