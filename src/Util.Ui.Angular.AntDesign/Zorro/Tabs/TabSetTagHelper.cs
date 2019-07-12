using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tabs.Renders;

namespace Util.Ui.Zorro.Tabs {
    /// <summary>
    /// 标签页
    /// </summary>
    [HtmlTargetElement( "util-tabs" )]
    public class TabSetTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzSelectedIndex],激活选项卡的索引
        /// </summary>
        public int SelectedIndex { get; set; }
        /// <summary>
        /// [(nzSelectedIndex)],激活选项卡的索引
        /// </summary>
        public string BindOnSelectedIndex { get; set; }
        /// <summary>
        /// (nzSelectedIndexChange),选项卡索引变更事件
        /// </summary>
        public string OnSelectedIndexChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TabSetRender( new Config( context ) );
        }
    }
}