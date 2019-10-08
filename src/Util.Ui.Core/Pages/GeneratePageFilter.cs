using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Ui.Pages {
    /// <summary>
    /// 生成页面过滤器
    /// </summary>
    public class GeneratePageFilter : IAsyncPageFilter {
        /// <summary>
        /// 选择页面
        /// </summary>
        public async Task OnPageHandlerSelectionAsync( PageHandlerSelectedContext context ) {
            if ( context.ActionDescriptor == null )
                return;
            await WriteViewToFileAsync( context );
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        public async Task OnPageHandlerExecutionAsync( PageHandlerExecutingContext context, PageHandlerExecutionDelegate next ) {
            await next();
        }

        /// <summary>
        /// 将视图写入html文件
        /// </summary>
        private async Task WriteViewToFileAsync( PageHandlerSelectedContext context ) {
            try {
                var html = await RenderToStringAsync( context );
                if( string.IsNullOrWhiteSpace( html ) )
                    return;
                var relativePath = GetPath( context );
                if ( string.IsNullOrWhiteSpace( relativePath ) )
                    return;
                var path = Util.Helpers.Common.GetPhysicalPath( relativePath );
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
        protected async Task<string> RenderToStringAsync( PageHandlerSelectedContext context ) {
            var relativePath = "";
            dynamic pageModel = System.Convert.ChangeType( context.HandlerInstance, context.HandlerInstance.GetType() );
            if( context.ActionDescriptor is CompiledPageActionDescriptor pageActionDescriptor ) {
                relativePath = pageActionDescriptor.RelativePath;
            }
            if ( relativePath == "/Pages/Index.cshtml" )
                return string.Empty;
            if( pageModel == null )
                throw new ArgumentException( nameof( pageModel ) );
            var razorViewEngine = Ioc.Create<IRazorViewEngine>();
            var activator = Ioc.Create<IRazorPageActivator>();
            var actionContext = new ActionContext( context.HttpContext, pageModel.RouteData,
                context.ActionDescriptor );
            var razorPage = FindPage( razorViewEngine, actionContext, relativePath );
            using( var stringWriter = new StringWriter() ) {
                var view = new RazorView( razorViewEngine, activator, new List<IRazorPage>(), razorPage, HtmlEncoder.Default,
                    new DiagnosticListener( "ViewRenderService" ) );
                var viewContext = new ViewContext( actionContext, view, pageModel?.ViewData, pageModel?.TempData,
                    stringWriter, new HtmlHelperOptions() ) {
                    ExecutingFilePath = relativePath
                };
                var pageNormal = ( (Page)razorPage );
                pageNormal.PageContext = pageModel.PageContext;
                pageNormal.ViewContext = viewContext;
                activator.Activate( pageNormal, viewContext );
                await razorPage.ExecuteAsync();
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// 获取Html默认生成路径
        /// </summary>
        protected virtual string GetPath( PageHandlerSelectedContext context ) {
            var htmlPath = context.ActionDescriptor.ModelTypeInfo.GetCustomAttribute<HtmlPathAttribute>();
            if( htmlPath != null ) {
                if ( htmlPath.Ignore )
                    return string.Empty;
                if( !string.IsNullOrWhiteSpace( htmlPath.Path ) )
                    return htmlPath.Path;
            }

            if( context.ActionDescriptor is CompiledPageActionDescriptor pageActionDescriptor ) {
                var paths = pageActionDescriptor.RelativePath.TrimStart( '/' ).Split( '/' );
                var result = new StringBuilder();
                for( var i = 0; i < paths.Length; i++ ) {
                    var path = paths[i];                    
                    var name = Util.Helpers.String.SplitWordGroup( path );
                    if (name == "pages" && i == 0)
                    {
                        result.Append("typings/app/");
                        continue;
                    }
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

        /// <summary>
        /// 查找Razor页面
        /// </summary>
        /// <param name="razorViewEngine">Razor视图引擎</param>
        /// <param name="actionContext">操作上下文</param>
        /// <param name="pageName">页面名称。执行文件路径：/Pages/Components/Forms/Form.cshtml</param>
        private IRazorPage FindPage( IRazorViewEngine razorViewEngine, ActionContext actionContext, string pageName ) {
            var getPageResult = razorViewEngine.GetPage( null, pageName );
            if( getPageResult.Page != null )
                return getPageResult.Page;
            var findPageResult = razorViewEngine.FindPage( actionContext, pageName );
            if( findPageResult.Page != null )
                return findPageResult.Page;
            throw new ArgumentNullException( $"未找到视图： {pageName}" );
        }
    }
}
