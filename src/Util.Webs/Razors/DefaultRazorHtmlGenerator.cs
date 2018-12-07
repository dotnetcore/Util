using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Webs.Razors
{
    /// <summary>
    /// Razor静态Html生成器
    /// </summary>
    public class DefaultRazorHtmlGenerator:IRazorHtmlGenerator
    {
        private readonly IRouteAnalyzer _routeAnalyzer;

        /// <summary>
        /// 初始化一个<see cref="DefaultRazorHtmlGenerator"/>类型的实例
        /// </summary>
        /// <param name="routeAnalyzer">路由分析器</param>
        public DefaultRazorHtmlGenerator(IRouteAnalyzer routeAnalyzer)
        {
            _routeAnalyzer = routeAnalyzer;
        }

        /// <summary>
        /// 生成Html文件
        /// </summary>
        /// <returns></returns>
        public async Task Generate()
        {
            foreach (var routeInformation in _routeAnalyzer.GetAllRouteInformations())
            {
                // 跳过API的处理
                if (routeInformation.Path.StartsWith("/api"))
                {
                    continue;
                }
                await WriteViewToFileAsync(routeInformation);
            }
        }

        /// <summary>
        /// 渲染视图为字符串
        /// </summary>
        /// <param name="info">路由信息</param>
        /// <returns></returns>
        public async Task<string> RenderToStringAsync(RouteInformation info)
        {
            var razorViewEngine = Ioc.Create<IRazorViewEngine>();
            var tempDataProvider = Ioc.Create<ITempDataProvider>();
            var serviceProvider = Ioc.Create<IServiceProvider>();
            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var actionContext = new ActionContext(httpContext, GetRouteData(info), new ActionDescriptor());
            var viewResult = GetView(razorViewEngine, actionContext, info);
            if (!viewResult.Success)
            {
                throw new InvalidOperationException($"找不到视图模板 {info.ActionName}");
            }
            using (var stringWriter = new StringWriter())
            {
                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
                var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, new TempDataDictionary(actionContext.HttpContext, tempDataProvider), stringWriter, new HtmlHelperOptions());
                await viewResult.View.RenderAsync(viewContext);
                return stringWriter.ToString();
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
                    return;
                var path = Util.Helpers.Common.GetPhysicalPath(string.IsNullOrWhiteSpace(info.FilePath) ? GetPath(info) : info.FilePath);
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
        /// 获取Html默认生成路径
        /// </summary>
        /// <param name="info">路由信息</param>
        /// <returns></returns>
        protected virtual string GetPath(RouteInformation info)
        {
            var area = info.AreaName.SafeString();
            var controller = info.ControllerName.SafeString();
            var action = info.ActionName.SafeString();
            var path = info.TemplatePath.Replace("{area}", area).Replace("{controller}", controller).Replace("{action}", action);
            return path.ToLower();
        }

        /// <summary>
        /// 获取Razor视图
        /// </summary>
        /// <param name="razorViewEngine">Razor视图引擎</param>
        /// <param name="actionContext">操作上下文</param>
        /// <param name="info">路由信息</param>
        /// <returns></returns>
        protected virtual ViewEngineResult GetView(IRazorViewEngine razorViewEngine,ActionContext actionContext,RouteInformation info)
        {
            return razorViewEngine.FindView(actionContext, info.ViewName.IsEmpty() ? info.ActionName : info.ViewName,
                !info.IsPartialView);
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
            return routeData;
        }
    }
}
