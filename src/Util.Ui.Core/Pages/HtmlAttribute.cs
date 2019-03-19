using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            if (context.Result is PageResult)
                await WriteViewToFileAsync(context);
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
            var relativePath = "";
            var viewEnginePath = "";
            PageModel pageModel = null;
            if (context.Result is PageResult pageResult &&context.ActionDescriptor is PageActionDescriptor pageActionDescriptor) {
                pageModel = pageResult.Model as PageModel;
                relativePath = pageActionDescriptor.RelativePath;
                viewEnginePath = pageActionDescriptor.ViewEnginePath;
            }
            if (pageModel == null)
                throw new ArgumentException(nameof(pageModel));
            var razorViewEngine = Ioc.Create<IRazorViewEngine>();
            var activator = Ioc.Create<IRazorPageActivator>();
            var actionContext = GetActionContext(pageModel);
            var razorPage = FindPage(razorViewEngine, actionContext, relativePath);
            using( var stringWriter = new StringWriter() ) {
                var view = new RazorView(razorViewEngine, activator, new List<IRazorPage>(), razorPage, HtmlEncoder.Default,
                    new DiagnosticListener("ViewRenderService"));
                var viewContext = new ViewContext(actionContext, view, pageModel?.ViewData, pageModel?.TempData,
                    stringWriter, new HtmlHelperOptions())
                {
                    ExecutingFilePath = relativePath
                };
                var pageNormal = ((Page)razorPage);
                pageNormal.PageContext = pageModel.PageContext;
                pageNormal.ViewContext = viewContext;
                activator.Activate(pageNormal, viewContext);
                await razorPage.ExecuteAsync();
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// 获取操作上下文
        /// </summary>
        /// <param name="pageModel">页面实体</param>
        private ActionContext GetActionContext(PageModel pageModel) {
            return new ActionContext(pageModel.HttpContext, pageModel.RouteData,
                pageModel.PageContext.ActionDescriptor);
        }

        /// <summary>
        /// 查找Razor页面
        /// </summary>
        /// <param name="razorViewEngine">Razor视图引擎</param>
        /// <param name="actionContext">操作上下文</param>
        /// <param name="pageName">页面名称。执行文件路径：/Pages/Components/Forms/Form.cshtml</param>
        private IRazorPage FindPage(IRazorViewEngine razorViewEngine, ActionContext actionContext, string pageName) {
            var getPageResult = razorViewEngine.GetPage(null, pageName);
            if (getPageResult.Page != null)
                return getPageResult.Page;
            var findPageResult = razorViewEngine.FindPage(actionContext, pageName);
            if (findPageResult.Page != null)
                return findPageResult.Page;
            throw new ArgumentNullException($"未找到视图： {pageName}");
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
