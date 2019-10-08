using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Prime.TreeTables.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Prime.TreeTables.TagHelpers {
    /// <summary>
    /// 树型表格
    /// </summary>
    [HtmlTargetElement( "util-tree-table" )]
    public class TreeTableTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 用于还原查询参数的标识
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 基地址，基于该地址构建加载地址和删除地址，范例：传入test,则加载地址为/api/test,删除地址为/api/test/delete
        /// </summary>
        public string BaseUrl { get; set; }
        /// <summary>
        /// 数据加载地址，范例：/api/test
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 删除地址，注意：由于支持批量删除，所以采用Post提交，范例：/api/test/delete
        /// </summary>
        public string DeleteUrl { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 选择模式
        /// </summary>
        public SelectionMode SelectionMode { get; set; }
        /// <summary>
        /// 初始化时是否自动加载数据，默认为true,设置成false则手工加载
        /// </summary>
        public bool AutoLoad { get; set; }
        /// <summary>
        /// 分页长度列表，值通过逗号分隔，范例：10,20,50,100
        /// </summary>
        public string PageSizeOptions { get; set; }
        /// <summary>
        /// 选中节点集合
        /// </summary>
        public string Selection { get; set; }
        /// <summary>
        /// 单击行时选中复选框或单选框
        /// </summary>
        public bool CheckOnClickRow { get; set; }
        /// <summary>
        /// 数据加载完成事件
        /// </summary>
        public string OnLoad { get; set; }
        /// <summary>
        /// 复选框或单选框单击事件
        /// </summary>
        public string OnCheck { get; set; }
        /// <summary>
        /// 单击行事件
        /// </summary>
        public string OnClickRow { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TreeTableRender( new Config( context ) );
        }
    }
}