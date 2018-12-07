using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Webs.Razors
{
    /// <summary>
    /// 路由信息
    /// </summary>
    public class RouteInformation
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Razor页面路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 调用方法
        /// </summary>
        public string Invocation { get; set; }
        
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 模板路径
        /// </summary>
        public string TemplatePath { get; set; }

        /// <summary>
        /// 视图名称
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        /// 是否部分视图
        /// </summary>
        public bool IsPartialView { get; set; } = false;
    }
}
