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
        /// 渲染器
        /// </summary>
        private ContainerRender _render;

        /// <summary>
        /// 渲染
        /// </summary>
        public override void Process( TagHelperContext context, TagHelperOutput output ) {
            base.Process( context, output );
            if( _render != null )
                WriteLog( _render, "渲染ng-container容器" );
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            _render = new ContainerRender( new Config( context ) );
            return _render;
        }
    }
}