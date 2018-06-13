using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Webs.Razors
{
    /// <summary>
    /// 路由分析器
    /// </summary>
    public interface IRouteAnalyzer
    {
        /// <summary>
        /// 获取所有路由信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<RouteInformation> GetAllRouteInformations();
    }
}
