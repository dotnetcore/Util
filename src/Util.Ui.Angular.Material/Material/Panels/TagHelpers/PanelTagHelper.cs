using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Panels.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Panels.TagHelpers {
    /// <summary>
    /// 面板
    /// </summary>
    [HtmlTargetElement( "util-panel" )]
    public class PanelTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 面板打开事件
        /// </summary>
        public string OnOpen { get; set; }
        /// <summary>
        /// 面板关闭事件
        /// </summary>
        public string OnClose { get; set; }
        /// <summary>
        /// 隐藏折叠开关
        /// </summary>
        public bool HideToggle { get; set; }
        /// <summary>
        /// 展开面板
        /// </summary>
        public string Expanded { get; set; }
        /// <summary>
        /// 禁用面板
        /// </summary>
        public string Disabled { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new PanelRender( new Config( context ) );
        }
    }
}