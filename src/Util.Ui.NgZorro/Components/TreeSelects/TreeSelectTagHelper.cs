using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Applications.Trees;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Components.TreeSelects.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.TreeSelects {
    /// <summary>
    /// 树选择,生成的标签为&lt;nz-tree-select>&lt;/nz-tree-select>
    /// </summary>
    [HtmlTargetElement( "util-tree-select" )]
    public class TreeSelectTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 扩展属性,是否启用扩展指令,当设置Api地址时自动启用,默认为 false
        /// </summary>
        public bool EnableExtend { get; set; }
        /// <summary>
        /// 扩展属性 [autoLoad],初始化时是否自动加载数据，默认为true,设置成false则手工加载
        /// </summary>
        public bool AutoLoad { get; set; }
        /// <summary>
        /// 扩展属性 loadMode,加载模式，默认为同步加载
        /// </summary>
        public LoadMode LoadMode { get; set; }
        /// <summary>
        /// 扩展属性 [isExpandForRootAsync],根节点异步加载模式是否展开子节点,默认为 true
        /// </summary>
        public bool ExpandForRootAsync { get; set; }
        /// <summary>
        /// 扩展属性[(queryParam)],查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 扩展属性 order,排序条件,范例: creationTime desc
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 扩展属性 [order],排序条件,范例: creationTime desc
        /// </summary>
        public string BindSort { get; set; }
        /// <summary>
        /// 扩展属性 url,Api地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 扩展属性 [url],Api地址
        /// </summary>
        public string BindUrl { get; set; }
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
        /// 扩展属性,宽度,如果设置数字,则单位为px,范例:100,表示style="width:100px",也可以设置百分比,范例:25%,表示style="width:25%"
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// [nzAllowClear],允许清除,默认值: false
        /// </summary>
        public bool AllowClear { get; set; }
        /// <summary>
        /// [nzAllowClear],允许清除,默认值: false
        /// </summary>
        public string BindAllowClear { get; set; }
        /// <summary>
        /// nzPlaceHolder,占位提示
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceHolder],占位提示
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示图标,默认值: false
        /// </summary>
        public bool ShowIcon { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示图标,默认值: false
        /// </summary>
        public string BindShowIcon { get; set; }
        /// <summary>
        /// nzNotFoundContent,当下拉列表为空时显示的内容,类型: string
        /// </summary>
        public string NotFoundContent { get; set; }
        /// <summary>
        /// [nzNotFoundContent],当下拉列表为空时显示的内容,类型: string
        /// </summary>
        public string BindNotFoundContent { get; set; }
        /// <summary>
        /// [nzDropdownMatchSelectWidth],是否下拉菜单和选择器同宽,默认值: true
        /// </summary>
        public bool DropdownMatchSelectWidth { get; set; }
        /// <summary>
        /// [nzDropdownMatchSelectWidth],是否下拉菜单和选择器同宽,默认值: true
        /// </summary>
        public string BindDropdownMatchSelectWidth { get; set; }
        /// <summary>
        /// [nzDropdownStyle],下拉菜单样式,类型: { [key: string]: string; },范例: { 'max-height': '300px' }
        /// </summary>
        public string DropdownStyle { get; set; }
        /// <summary>
        /// nzDropdownClassName,下拉菜单样式类名
        /// </summary>
        public string DropdownClassName { get; set; }
        /// <summary>
        /// [nzDropdownClassName],下拉菜单样式类名
        /// </summary>
        public string BindDropdownClassName { get; set; }
        /// <summary>
        /// [nzMultiple],是否支持多选,默认值: false,当设置 nzCheckable 时自动变为true
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// [nzMultiple],是否支持多选,默认值: false,当设置 nzCheckable 时自动变为true
        /// </summary>
        public string BindMultiple { get; set; }
        /// <summary>
        /// [nzHideUnMatched],是否搜索时隐藏未匹配的节点,默认值: false
        /// </summary>
        public bool HideUnmatched { get; set; }
        /// <summary>
        /// [nzHideUnMatched],是否搜索时隐藏未匹配的节点,默认值: false
        /// </summary>
        public string BindHideUnmatched { get; set; }
        /// <summary>
        /// nzSize,选择框大小，可选值: 'large'|'small'|'default',默认值: 'default'
        /// </summary>
        public InputSize Size { get; set; }
        /// <summary>
        /// [nzSize],选择框大小，可选值: 'large'|'small'|'default',默认值: 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// [nzCheckable],节点前是否添加复选框,默认值: false
        /// </summary>
        public bool Checkable { get; set; }
        /// <summary>
        /// [nzCheckable],节点前是否添加复选框,默认值: false
        /// </summary>
        public string BindCheckable { get; set; }
        /// <summary>
        /// [nzCheckStrictly],严格勾选,父子节点选中状态不再关联,默认值: false
        /// </summary>
        public bool CheckStrictly { get; set; }
        /// <summary>
        /// [nzCheckStrictly],严格勾选,父子节点选中状态不再关联,默认值: false
        /// </summary>
        public string BindCheckStrictly { get; set; }
        /// <summary>
        /// [nzShowExpand],节点前是否显示展开图标,默认值: true
        /// </summary>
        public bool ShowExpand { get; set; }
        /// <summary>
        /// [nzShowExpand],节点前是否显示展开图标,默认值: true
        /// </summary>
        public string BindShowExpand { get; set; }
        /// <summary>
        /// [nzShowLine],是否显示连接线,默认值: false
        /// </summary>
        public bool ShowLine { get; set; }
        /// <summary>
        /// [nzShowLine],是否显示连接线,默认值: false
        /// </summary>
        public string BindShowLine { get; set; }
        /// <summary>
        /// [nzAsyncData],是否异步加载,默认值: false
        /// </summary>
        public bool AsyncData { get; set; }
        /// <summary>
        /// [nzAsyncData],是否异步加载,默认值: false
        /// </summary>
        public string BindAsyncData { get; set; }
        /// <summary>
        /// [nzNodes],节点数据,类型: NzTreeNodeOptions[]
        /// </summary>
        public string Nodes { get; set; }
        /// <summary>
        /// [nzDefaultExpandAll],是否默认展开所有节点,默认值: false
        /// </summary>
        public bool DefaultExpandAll { get; set; }
        /// <summary>
        /// [nzDefaultExpandAll],是否默认展开所有节点,默认值: false
        /// </summary>
        public string BindDefaultExpandAll { get; set; }
        /// <summary>
        /// [nzExpandedKeys],默认展开节点的键集合,类型: string[]
        /// </summary>
        public string ExpandedKeys { get; set; }
        /// <summary>
        /// [nzDisplayWith],在输入框显示所选节点值的函数,类型: (node: NzTreeNode) => string,默认值: (node: NzTreeNode) => node.title
        /// </summary>
        public string DisplayWith { get; set; }
        /// <summary>
        /// nzMaxTagCount,最多显示的标签数量,类型: number
        /// </summary>
        public int MaxTagCount { get; set; }
        /// <summary>
        /// [nzMaxTagCount],最多显示的标签数量,类型: number
        /// </summary>
        public string BindMaxTagCount { get; set; }
        /// <summary>
        /// [nzMaxTagPlaceholder],隐藏标签时显示的占位内容,类型: TemplateRef&lt;{ $implicit: NzTreeNode[] }>
        /// </summary>
        public string MaxTagPlaceholder { get; set; }
        /// <summary>
        /// [nzTreeTemplate],自定义节点模板,类型: TemplateRef&lt;{ $implicit: NzTreeNode }>
        /// </summary>
        public string TreeTemplate { get; set; }
        /// <summary>
        /// nzVirtualHeight,虚拟滚动的总高度,范例: '300px'
        /// </summary>
        public string VirtualHeight { get; set; }
        /// <summary>
        /// [nzVirtualHeight],虚拟滚动的总高度,范例: '300px'
        /// </summary>
        public string BindVirtualHeight { get; set; }
        /// <summary>
        /// nzVirtualItemSize,虚拟滚动时每一列的高度,单位:像素,默认值: 28
        /// </summary>
        public int VirtualItemSize { get; set; }
        /// <summary>
        /// [nzVirtualItemSize],虚拟滚动时每一列的高度,单位:像素,默认值: 28
        /// </summary>
        public string BindVirtualItemSize { get; set; }
        /// <summary>
        /// nzVirtualMaxBufferPx,虚拟滚动缓冲区最大高度,单位:像素,默认值: 500
        /// </summary>
        public int VirtualMaxBufferPx { get; set; }
        /// <summary>
        /// [nzVirtualMaxBufferPx],虚拟滚动缓冲区最大高度,单位:像素,默认值: 500
        /// </summary>
        public string BindVirtualMaxBufferPx { get; set; }
        /// <summary>
        /// nzVirtualMinBufferPx,虚拟滚动缓冲区最小高度，低于该值时将加载新结构,单位:像素,默认值: 28
        /// </summary>
        public int VirtualMinBufferPx { get; set; }
        /// <summary>
        /// [nzVirtualMinBufferPx],虚拟滚动缓冲区最小高度，低于该值时将加载新结构,单位:像素,默认值: 28
        /// </summary>
        public string BindVirtualMinBufferPx { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (nzExpandChange),展开收缩节点事件,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnExpandChange { get; set; }
        /// <summary>
        /// 扩展属性 [onLoadChildrenBefore],子节点加载前事件,返回false停止加载,类型: (node:NzTreeNode) => boolean,参数为父节点
        /// </summary>
        public string OnLoadChildrenBefore { get; set; }
        /// <summary>
        /// 扩展事件 (onLoadChildren),子节点加载完成事件,参数为{ node: NzTreeNode, result }
        /// </summary>
        public string OnLoadChildren { get; set; }
        /// <summary>
        /// 扩展事件 (onExpand),节点展开事件,参数为 NzTreeNode
        /// </summary>
        public string OnExpand { get; set; }
        /// <summary>
        /// 扩展事件 (onCollapse),节点折叠事件,参数为 NzTreeNode
        /// </summary>
        public string OnCollapse { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new InputService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TreeSelectRender( _config );
        }
    }
}