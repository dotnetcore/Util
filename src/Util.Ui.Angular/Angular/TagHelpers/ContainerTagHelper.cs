using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Renders;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Angular.TagHelpers {
    /// <summary>
    /// ng-container容器
    /// </summary>
    [HtmlTargetElement( "util-container" )]
    public class ContainerTagHelper : TagHelperBase {
        /// <summary>
        /// 处理后操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="render">渲染器</param>
        protected override void ProcessAfter( Context context, IRender render ) {
            WriteLog( render, "渲染ng-container容器" );
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ContainerRender( new Config( context ) );
        }
    }
}