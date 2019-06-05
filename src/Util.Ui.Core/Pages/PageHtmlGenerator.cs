using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Webs.Razors;

namespace Util.Ui.Pages
{
    /// <summary>
    /// Page静态Html生成器
    /// </summary>
    public class PageHtmlGenerator : IRazorHtmlGenerator
    {
        /// <summary>
        /// 路由分析器
        /// </summary>
        private readonly IRouteAnalyzer _routeAnalyzer;

        /// <summary>
        /// 页面加载器
        /// </summary>
        private readonly IPageLoader _pageLoader;

        /// <summary>
        /// 初始化一个<see cref="PageHtmlGenerator"/>类型的实例
        /// </summary>
        /// <param name="routeAnalyzer">路由分析器</param>
        public PageHtmlGenerator(IRouteAnalyzer routeAnalyzer,IPageLoader pageLoader)
        {
            _routeAnalyzer = routeAnalyzer;
            _pageLoader = pageLoader;
        }

        /// <summary>
        /// 生成Html文件
        /// </summary>
        public async Task Generate()
        {
            foreach (var routeInformation in _routeAnalyzer.GetAllRouteInformations())
            {
                if (routeInformation.Path.StartsWith("/api"))
                {
                    continue;
                }

                await WriteViewToFileAsync(routeInformation);
            }
        }

        /// <summary>
        /// 将视图写入文件
        /// </summary>
        /// <param name="info">路由信息</param>
        /// <returns></returns>
        public async Task WriteViewToFileAsync(RouteInformation info)
        {
            try
            {
                var html = await RenderToStringAsync(info);
                if (string.IsNullOrWhiteSpace(html))
                {
                    return;
                }
                var relativePath = GetPath(info);
                if (string.IsNullOrWhiteSpace(relativePath))
                    return;
                var path = Util.Helpers.Common.GetPhysicalPath(relativePath);
                var directory = System.IO.Path.GetDirectoryName(path);
                if (string.IsNullOrWhiteSpace(directory))
                    return;
                if (Directory.Exists(directory) == false)
                    Directory.CreateDirectory(directory);
                System.IO.File.WriteAllText(path, html);
            }
            catch (Exception ex)
            {
                ex.Log(Log.GetLog().Caption("生成html静态文件失败"));
            }
        }

        /// <summary>
        /// 渲染视图
        /// </summary>
        /// <param name="info">路由信息</param>
        private async Task<string> RenderToStringAsync(RouteInformation info)
        {
            if (info.Invocation == "/Pages/Index.cshtml")
            {
                return string.Empty;
            }

            var engine = Ioc.Create<ICompositeViewEngine>();
            var razorViewEngine = Ioc.Create<IRazorViewEngine>();
            var activator = Ioc.Create<IRazorPageActivator>();
            var serviceProvider = Ioc.Create<IServiceProvider>();
            var tempDataProvider = Ioc.Create<ITempDataProvider>();
            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var actionContext = new ActionContext(httpContext, GetRouteData(info), new ActionDescriptor());

            var razorPage = FindPage(razorViewEngine, actionContext, info.Invocation);
            _pageLoader.Load(razorPage.)
            using (var output = new StringWriter())
            {
                var view = new RazorView(razorViewEngine, activator, new List<IRazorPage>(), razorPage, HtmlEncoder.Default,
                    new DiagnosticListener("ViewRenderService"));
                var viewResult = GetView(engine, info);
                var context = view.RazorPage.ViewContext;
                //var viewContext = new ViewContext(actionContext, view, pageModel?.ViewData, pageModel?.TempData,
                //    output, new HtmlHelperOptions())
                //{
                //    ExecutingFilePath = info.Invocation
                //};
                var viewContext = new ViewContext(actionContext, viewResult.View,
                    new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()),
                    new TempDataDictionary(actionContext.HttpContext, tempDataProvider),
                    output, new HtmlHelperOptions())
                {
                };
                //var pageNormal = ((Page)razorPage);
                //pageNormal.PageContext = pageModel.PageContext;
                //pageNormal.ViewContext = viewContext;
                //activator.Activate(pageNormal, viewContext);
                //await razorPage.ExecuteAsync();
                //return output.ToString();
                var type = razorPage.GetType();
                await viewResult.View.RenderAsync(viewContext);
                return output.ToString();
            }
        }

        /// <summary>
        /// 获取路由数据
        /// </summary>
        /// <param name="info">路由信息</param>
        /// <returns></returns>
        protected virtual RouteData GetRouteData(RouteInformation info)
        {
            var routeData = new RouteData();
            if (!info.AreaName.IsEmpty())
            {
                routeData.Values.Add("area", info.AreaName);
            }
            if (!info.ControllerName.IsEmpty())
            {
                routeData.Values.Add("controller", info.ControllerName);
            }
            if (!info.ActionName.IsEmpty())
            {
                routeData.Values.Add("action", info.ActionName);
            }

            if (info.IsPageRoute)
            {
                routeData.Values.Add("page", info.Path);
            }
            return routeData;
        }

        /// <summary>
        /// 获取Razor视图
        /// </summary>
        /// <param name="engine">复合视图引擎</param>
        /// <param name="info">路由信息</param>
        /// <returns></returns>
        protected virtual ViewEngineResult GetView(ICompositeViewEngine engine, RouteInformation info)
        {
            return engine.GetView("~/", $"~{info.Invocation}", !info.IsPartialView);
        }

        /// <summary>
        /// 获取Html默认生成路径
        /// </summary>
        /// <param name="info">路由信息</param>
        protected virtual string GetPath(RouteInformation info)
        {
            var paths = info.Invocation.TrimStart('/').Split('/');
            var result = new StringBuilder();
            for (var i = 0; i < paths.Length; i++)
            {
                var path = paths[i];
                var name = Util.Helpers.String.SplitWordGroup(path);
                if (name == "pages" && i == 0)
                {
                    result.Append("typings/app/");
                    continue;
                }
                if (i == paths.Length - 2)
                {
                    result.Append($"{name}/html/");
                    continue;
                }
                if (i == paths.Length - 1)
                {
                    name = Util.Helpers.String.SplitWordGroup(path.RemoveEnd(".cshtml"));
                    result.Append($"{name}.component.html");
                    break;
                }
                result.Append($"{name}/");
            }
            return $"/{result}";
        }

        /// <summary>
        /// 查找Razor页面
        /// </summary>
        /// <param name="razorViewEngine">Razor视图引擎</param>
        /// <param name="actionContext">操作上下文</param>
        /// <param name="pageName">页面名称。执行文件路径：/Pages/Components/Forms/Form.cshtml</param>
        private IRazorPage FindPage(IRazorViewEngine razorViewEngine, ActionContext actionContext, string pageName)
        {
            var getPageResult = razorViewEngine.GetPage(null, pageName);
            if (getPageResult.Page != null)
                return getPageResult.Page;
            var findPageResult = razorViewEngine.FindPage(actionContext, pageName);
            if (findPageResult.Page != null)
                return findPageResult.Page;
            throw new ArgumentNullException($"未找到视图： {pageName}");
        }
    }
}
