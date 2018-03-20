using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Util.Helpers;

namespace Util.Ui.Attributes {
    /// <summary>
    /// 生成Html静态文件
    /// </summary>
    public class HtmlAttribute : ActionFilterAttribute {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path">生成路径，相对根路径，范例：/Typings/app/app.component.html</param>
        public HtmlAttribute( string path ) {
            Path = path;
        }

        /// <summary>
        /// 生成路径，相对根路径，范例：/Typings/app/app.component.html
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 执行生成
        /// </summary>
        public override async Task OnActionExecutionAsync( ActionExecutingContext context, ActionExecutionDelegate next ) {
            await WriteViewToFileAsync( context );
            await base.OnActionExecutionAsync( context, next );
        }

        /// <summary>
        /// 将视图写入html文件
        /// </summary>
        private async Task WriteViewToFileAsync( ActionExecutingContext context ) {
            var viewName = $"{context.RouteData.Values["controller"]}/{context.RouteData.Values["action"]}";
            object model = null;
            if( context.Result is ViewResult result ) {
                viewName = string.IsNullOrWhiteSpace( result.ViewName ) ? viewName : result.ViewName;
                model = result.Model;
            }
            var html = await RenderToStringAsync( viewName, model );
            File.WriteAllText( Util.Helpers.Common.GetPhysicalPath( Path ), html );
        }

        /// <summary>
        /// 渲染视图
        /// </summary>
        /// <param name="viewName">视图名称</param>
        /// <param name="model">视图模型</param>
        public async Task<string> RenderToStringAsync( string viewName, object model ) {
            var razorViewEngine = Ioc.Create<IRazorViewEngine>();
            var tempDataProvider = Ioc.Create<ITempDataProvider>();
            var serviceProvider = Ioc.Create<IServiceProvider>();
            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var actionContext = new ActionContext( httpContext, new RouteData(), new ActionDescriptor() );
            using( var stringWriter = new StringWriter() ) {
                var viewResult = razorViewEngine.FindView( actionContext, viewName, false );
                if( viewResult.View == null ) {
                    throw new ArgumentNullException( $"未找到视图： {viewName}" );
                }
                var viewDictionary = new ViewDataDictionary( new EmptyModelMetadataProvider(), new ModelStateDictionary() ) {
                    Model = model
                };
                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary( actionContext.HttpContext, tempDataProvider ),
                    stringWriter,
                    new HtmlHelperOptions()
                );
                await viewResult.View.RenderAsync( viewContext );
                return stringWriter.ToString();
            }
        }
    }
}
