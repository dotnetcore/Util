using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Webs.Filters {
    /// <summary>
    /// 生成Html静态文件
    /// </summary>
    public class HtmlAttribute : ActionFilterAttribute {
        /// <summary>
        /// 生成路径，相对根路径，范例：/Typings/app/app.component.html
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 路径模板，范例：Typings/app/{area}/{controller}/{controller}-{action}.component.html
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// 视图名称，范例：/Home/Index
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        /// 是否部分视图，默认：true
        /// </summary>
        public bool IsPartialView { get; set; } = false;

        /// <summary>
        /// 执行生成
        /// </summary>
        public override async Task OnResultExecutionAsync( ResultExecutingContext context, ResultExecutionDelegate next ) {
            await WriteViewToFileAsync( context );
            await base.OnResultExecutionAsync( context, next );
        }

        /// <summary>
        /// 将视图写入html文件
        /// </summary>
        private async Task WriteViewToFileAsync( ResultExecutingContext context ) {
            try {
                var html = await RenderToStringAsync( context );
                if( string.IsNullOrWhiteSpace( html ) )
                    return;
                var path = Util.Helpers.Common.GetPhysicalPath( string.IsNullOrWhiteSpace( Path ) ? GetPath( context ) : Path );
                var directory = System.IO.Path.GetDirectoryName( path );
                if( string.IsNullOrWhiteSpace( directory ) )
                    return;
                if( Directory.Exists( directory ) == false )
                    Directory.CreateDirectory( directory );
                System.IO.File.WriteAllText( path, html );
            }
            catch( Exception ex ) {
                ex.Log( Log.GetLog().Caption( "生成html静态文件失败" ) );
            }
        }

        /// <summary>
        /// 渲染视图
        /// </summary>
        protected async Task<string> RenderToStringAsync( ResultExecutingContext context ) {
            string viewName = "";
            object model = null;
            if( context.Result is ViewResult result ) {
                viewName = result.ViewName;
                viewName = string.IsNullOrWhiteSpace( viewName ) ? context.RouteData.Values["action"].SafeString() : viewName;
                model = result.Model;
            }
            var razorViewEngine = Ioc.Create<IRazorViewEngine>();
            var tempDataProvider = Ioc.Create<ITempDataProvider>();
            var serviceProvider = Ioc.Create<IServiceProvider>();
            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var actionContext = new ActionContext( httpContext, context.RouteData, new ActionDescriptor() );
            using( var stringWriter = new StringWriter() ) {
                var viewResult = razorViewEngine.FindView( actionContext, viewName, true );
                if( viewResult.View == null )
                    throw new ArgumentNullException( $"未找到视图： {viewName}" );
                var viewDictionary = new ViewDataDictionary( new EmptyModelMetadataProvider(), new ModelStateDictionary() ) { Model = model };
                var viewContext = new ViewContext( actionContext, viewResult.View, viewDictionary, new TempDataDictionary( actionContext.HttpContext, tempDataProvider ), stringWriter, new HtmlHelperOptions() );
                await viewResult.View.RenderAsync( viewContext );
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// 获取Html默认生成路径
        /// </summary>
        protected virtual string GetPath( ResultExecutingContext context ) {
            var area = context.RouteData.Values["area"].SafeString();
            var controller = context.RouteData.Values["controller"].SafeString();
            var action = context.RouteData.Values["action"].SafeString();
            var path = Template.Replace( "{area}", area ).Replace( "{controller}", controller ).Replace( "{action}", action );
            return path.ToLower();
        }
    }
}
