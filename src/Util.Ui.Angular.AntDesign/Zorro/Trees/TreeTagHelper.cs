using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Trees.Renders;

namespace Util.Ui.Zorro.Trees {
    /// <summary>
    /// 树形
    /// </summary>
    [HtmlTargetElement("util-tree")]
    public class TreeTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// nzCheckable,是否显示复选框，默认为 false
        /// </summary>
        public bool ShowCheckbox { get; set; }
        /// <summary>
        /// nzShowExpand,是否显示展开图标，默认为 true
        /// </summary>
        public bool ShowExpand { get; set; }
        /// <summary>
        /// nzShowLine,是否显示连接线，默认为 false
        /// </summary>
        public bool ShowLine { get; set; }
        /// <summary>
        /// nzShowIcon,是否显示图标，默认为 true
        /// </summary>
        public bool ShowIcon { get; set; }
        /// <summary>
        /// nzBlockNode,节点是否占据一行
        /// </summary>
        public bool BlockNode { get; set; }
        /// <summary>
        /// nzExpandAll,是否展开所有节点，默认为 false
        /// </summary>
        public bool ExpandAll { get; set; }
        /// <summary>
        /// nzMultiple,是否允许选中多个节点，默认为 false
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// (nzClick),单击事件处理函数
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// (nzDblClick),双击事件处理函数
        /// </summary>
        public string OnDblClick { get; set; }
        /// <summary>
        /// (nzExpandChange),节点展开事件处理函数
        /// </summary>
        public string OnExpand { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TreeRender( new Config( context ) );
        }
    }
}
