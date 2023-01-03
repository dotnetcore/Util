using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Applications.Trees;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Components.TreeTables.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.TreeTables {
    /// <summary>
    /// 树形表格,生成的标签为&lt;nz-table>&lt;/nz-table>
    /// </summary>
    [HtmlTargetElement( "util-tree-table" )]
    public class TreeTableTagHelper : TableTagHelper {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 扩展属性 loadUrl,首次加载地址，对于异步请求,仅加载第一级节点,如果未设置该属性,则使用 Url 属性地址
        /// </summary>
        public string LoadUrl { get; set; }
        /// <summary>
        /// 扩展属性 [loadUrl],首次加载地址，对于异步请求,仅加载第一级节点,如果未设置该属性,则使用 Url 属性地址
        /// </summary>
        public string BindLoadUrl { get; set; }
        /// <summary>
        /// 扩展属性 queryUrl,查询地址，如果未设置该属性,则使用 Url 属性地址
        /// </summary>
        public string QueryUrl { get; set; }
        /// <summary>
        /// 扩展属性 [queryUrl],查询地址，如果未设置该属性,则使用 Url 属性地址
        /// </summary>
        public string BindQueryUrl { get; set; }
        /// <summary>
        /// 扩展属性 loadChildrenUrl,加载子节点地址，如果未设置该属性,则使用 Url 属性地址
        /// </summary>
        public string LoadChildrenUrl { get; set; }
        /// <summary>
        /// 扩展属性 [loadChildrenUrl],加载子节点地址，如果未设置该属性,则使用 Url 属性地址
        /// </summary>
        public string BindLoadChildrenUrl { get; set; }
        /// <summary>
        /// 扩展属性 loadMode,加载模式，默认为同步加载
        /// </summary>
        public LoadMode LoadMode { get; set; }
        /// <summary>
        /// 扩展属性 [isExpandAll],是否展开所有节点,仅对同步加载有效,默认为 false
        /// </summary>
        public bool ExpandAll { get; set; }
        /// <summary>
        /// 扩展属性 [isExpandForRootAsync],根节点异步加载模式是否展开子节点,默认为 true
        /// </summary>
        public bool ExpandForRootAsync { get; set; }
        /// <summary>
        /// 扩展属性 [isCheckLeafOnly],是否只能选择叶节点,仅对单选框有效，类型: boolean,默认为 false
        /// </summary>
        public string CheckLeafOnly { get; set; }
        /// <summary>
        /// 扩展属性 [onLoadChildrenBefore],子节点加载前事件,返回false停止加载,类型: (node) => boolean,参数为父节点
        /// </summary>
        public string OnLoadChildrenBefore { get; set; }
        /// <summary>
        /// 扩展事件 (onLoadChildren),子节点加载完成事件,参数为{ node: TreeNode, result: PageList&lt;any> }
        /// </summary>
        public string OnLoadChildren { get; set; }
        /// <summary>
        /// 扩展事件 (onExpand),节点展开事件,参数为 TreeNode
        /// </summary>
        public string OnExpand { get; set; }
        /// <summary>
        /// 扩展事件 (onCollapse),节点折叠事件,参数为 TreeNode
        /// </summary>
        public string OnCollapse { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new TableService( _config );
            service.Init();
            service.InitTreeTable();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TreeTableRender( _config );
        }
    }
}