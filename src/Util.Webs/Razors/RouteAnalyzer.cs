using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Util.Webs.Filters;

namespace Util.Webs.Razors
{
    /// <summary>
    /// 路由分析器
    /// </summary>
    public class RouteAnalyzer:IRouteAnalyzer
    {
        /// <summary>
        /// 操作描述集合提供程序
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        /// <summary>
        /// 初始化一个<see cref="RouteAnalyzer"/>类型的实例
        /// </summary>
        /// <param name="actionDescriptorCollectionProvider">操作描述集合提供程序</param>
        public RouteAnalyzer(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        /// <summary>
        /// 获取所有路由信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RouteInformation> GetAllRouteInformations()
        {
            List<RouteInformation> list=new List<RouteInformation>();

            var actionDescriptors = this._actionDescriptorCollectionProvider.ActionDescriptors.Items;
            foreach (var actionDescriptor in actionDescriptors)
            {
                RouteInformation info=new RouteInformation();

                if (actionDescriptor.RouteValues.ContainsKey("area"))
                {
                    info.AreaName = actionDescriptor.RouteValues["area"];
                }

                // Razor页面路径以及调用
                if (actionDescriptor is PageActionDescriptor pageActionDescriptor)
                {
                    info.Path = pageActionDescriptor.ViewEnginePath;
                    info.Invocation = pageActionDescriptor.RelativePath;
                }

                // 路由属性路径
                if (actionDescriptor.AttributeRouteInfo != null)
                {
                    info.Path = $"/{actionDescriptor.AttributeRouteInfo.Template}";
                }

                // Controller/Action 的路径以及调用
                if (actionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    if (info.Path.IsEmpty())
                    {
                        info.Path =
                            $"/{controllerActionDescriptor.ControllerName}/{controllerActionDescriptor.ActionName}";
                    }

                    var controllerHtmlAttribute = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<HtmlAttribute>();

                    if (controllerHtmlAttribute != null)
                    {
                        info.FilePath = controllerHtmlAttribute.Path;
                        info.TemplatePath = controllerHtmlAttribute.Template;
                    }

                    var htmlAttribute = controllerActionDescriptor.MethodInfo.GetCustomAttribute<HtmlAttribute>();

                    if (htmlAttribute != null)
                    {
                        info.FilePath = htmlAttribute.Path;
                        info.TemplatePath = htmlAttribute.Template;
                    }

                    info.ControllerName = controllerActionDescriptor.ControllerName;
                    info.ActionName = controllerActionDescriptor.ActionName;
                    info.Invocation = $"{controllerActionDescriptor.ControllerName}Controller.{controllerActionDescriptor.ActionName}";
                }

                info.Invocation += $"({actionDescriptor.DisplayName})";

                list.Add(info);
            }

            return list;
        }
    }
}
