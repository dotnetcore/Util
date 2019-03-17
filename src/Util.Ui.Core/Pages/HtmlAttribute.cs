using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Ui.Pages {
    /// <summary>
    /// 生成Html静态文件
    /// </summary>
    public class HtmlAttribute : ActionFilterAttribute {
        /// <summary>
        /// 生成路径，相对根路径，范例：/Typings/app/app.component.html
        /// </summary>
        public string Path { get; set; }

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
            bool isPage = false;
            if( context.Result is ViewResult result ) {
                viewName = result.ViewName;
                viewName = string.IsNullOrWhiteSpace( viewName ) ? context.RouteData.Values["action"].SafeString() : viewName;
                model = result.Model;
            }

            if( context.Result is PageResult pageResult ) {
                if( context.ActionDescriptor is PageActionDescriptor pageActionDescriptor ) {
                    isPage = true;
                    model = pageResult.Model;
                    viewName = pageActionDescriptor.RelativePath;
                }
            }
            var razorViewEngine = Ioc.Create<IRazorViewEngine>();
            var compositeViewEngine = Ioc.Create<ICompositeViewEngine>();
            var tempDataProvider = Ioc.Create<ITempDataProvider>();
            var serviceProvider = Ioc.Create<IServiceProvider>();
            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var actionContext = new ActionContext( httpContext, context.RouteData, new ActionDescriptor() );
            using( var stringWriter = new StringWriter() ) {
                var viewResult = isPage
                    ? GetView( compositeViewEngine, viewName )
                    : GetView( razorViewEngine, actionContext, viewName );
                if( viewResult.View == null )
                    throw new ArgumentNullException( $"未找到视图： {viewName}" );
                var viewDictionary = new ViewDataDictionary( new EmptyModelMetadataProvider(), new ModelStateDictionary() ) { Model = model };
                var viewContext = new ViewContext( actionContext, viewResult.View, viewDictionary, new TempDataDictionary( actionContext.HttpContext, tempDataProvider ), stringWriter, new HtmlHelperOptions() );
                await viewResult.View.RenderAsync( viewContext );
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// 获取视图
        /// </summary>
        /// <param name="razorViewEngine">Razor视图引擎</param>
        /// <param name="actionContext">操作上下文</param>
        /// <param name="viewName">视图名</param>
        private ViewEngineResult GetView( IRazorViewEngine razorViewEngine, ActionContext actionContext, string viewName ) {
            return razorViewEngine.FindView( actionContext, viewName, true );
        }

        /// <summary>
        /// 获取视图
        /// </summary>
        /// <param name="compositeViewEngine">复合视图引擎</param>
        /// <param name="path">路径</param>
        private ViewEngineResult GetView( ICompositeViewEngine compositeViewEngine, string path ) {
            return compositeViewEngine.GetView( "~/", $"~{path}", true );
        }

        /// <summary>
        /// 获取Html默认生成路径
        /// </summary>
        protected virtual string GetPath( ResultExecutingContext context ) {
            if( context.ActionDescriptor is PageActionDescriptor pageActionDescriptor ) {
                var paths = pageActionDescriptor.RelativePath.Replace( "/Pages", "/typings/app" ).TrimStart( '/' ).Split( '/' );
                var result = new StringBuilder();
                for( int i = 0; i < paths.Length; i++ ) {
                    var path = paths[i];
                    var name = Util.Helpers.String.SplitWordGroup( path );
                    if( i == paths.Length - 2 ) {
                        result.Append( $"{name}/html/" );
                        continue;
                    }
                    if( i == paths.Length - 1 ) {
                        name = Util.Helpers.String.SplitWordGroup( path.RemoveEnd( ".cshtml" ) );
                        result.Append( $"{name}.component.html" );
                        break;
                    }
                    result.Append( $"{name}/" );
                }
                return $"/{result}";
            }
            return string.Empty;
        }
    }
}
