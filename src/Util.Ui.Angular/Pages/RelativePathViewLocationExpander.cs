using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Util.Ui.Pages {
    /// <summary>
    /// 相对路径视图位置扩展器
    /// </summary>
    public class RelativePathViewLocationExpander : IViewLocationExpander {
        /// <summary>
        /// 填充值
        /// </summary>
        public void PopulateValues( ViewLocationExpanderContext context ) {
            context.Values["customviewlocation"] = nameof( RelativePathViewLocationExpander );
        }

        /// <summary>
        /// 扩展视图位置
        /// </summary>
        public IEnumerable<string> ExpandViewLocations( ViewLocationExpanderContext context, IEnumerable<string> viewLocations ) {
            if( !context.ViewName.StartsWith( "~" ) && context.ActionContext is ViewContext viewContext ) {
                var executingFilePaths = viewContext.ExecutingFilePath.Split( '/' );
                var result = $"{JoinUrl( executingFilePaths )}{context.ViewName}.cshtml";
                return new[] { result };
            }
            return viewLocations;
        }

        /// <summary>
        /// 拼接Url
        /// </summary>
        /// <param name="paths">路径</param>
        private string JoinUrl( string[] paths ) {
            var result = new StringBuilder();
            for( var i = 0; i < paths.Length - 1; i++ ) {
                result.Append( paths[i] );
                result.Append( "/" );
            }
            return result.ToString();
        }
    }
}
