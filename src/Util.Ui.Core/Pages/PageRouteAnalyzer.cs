using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Util.Webs.Razors;

namespace Util.Ui.Pages
{
    /// <summary>
    /// Page路由分析器
    /// </summary>
    public class PageRouteAnalyzer : IRouteAnalyzer
    {
        /// <summary>
        /// 操作描述集合提供程序
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        /// <summary>
        /// 页面加载器
        /// </summary>
        private readonly IPageLoader _pageLoader;

        /// <summary>
        /// 初始化一个<see cref="PageRouteAnalyzer"/>类型的实例
        /// </summary>
        /// <param name="actionDescriptorCollectionProvider">操作描述集合提供程序</param>
        /// <param name="pageLoader">页面加载器</param>
        public PageRouteAnalyzer(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
            IPageLoader pageLoader)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _pageLoader = pageLoader;
        }

        /// <summary>
        /// 获取所有路由信息
        /// </summary>
        public IEnumerable<RouteInformation> GetAllRouteInformations()
        {
            List<RouteInformation> list = new List<RouteInformation>();
            var actionDescriptors = this._actionDescriptorCollectionProvider.ActionDescriptors.Items;
            foreach (var actionDescriptor in actionDescriptors)
            {
                var info = new RouteInformation();
                if (actionDescriptor is PageActionDescriptor pageActionDescriptor)
                {
                    var compiledPage = _pageLoader.Load(pageActionDescriptor);
                    info.Path = pageActionDescriptor.ViewEnginePath;
                    info.Invocation = pageActionDescriptor.RelativePath;
                    SetHtmlInfo(info, compiledPage);
                    if (!list.Exists(x => x.Invocation == info.Invocation))
                    {
                        list.Add(info);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 设置Html信息
        /// </summary>
        /// <param name="routeInformation">路由信息</param>
        /// <param name="compiledPageActionDescriptor">编译后的页面</param>
        private void SetHtmlInfo(RouteInformation routeInformation,
            CompiledPageActionDescriptor compiledPageActionDescriptor)
        {
            routeInformation.IsPageRoute = true;
            var htmlAttribute = compiledPageActionDescriptor.PageTypeInfo.GetCustomAttribute<HtmlPathAttribute>() ??
                                compiledPageActionDescriptor.DeclaredModelTypeInfo.GetCustomAttribute<HtmlPathAttribute>();
            if (htmlAttribute == null)
                return;
            routeInformation.FilePath = htmlAttribute.Path;
            routeInformation.Ignore = htmlAttribute.Ignore;
        }
    }
}
