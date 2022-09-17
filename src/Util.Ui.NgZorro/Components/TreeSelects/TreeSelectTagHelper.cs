using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.TreeSelects.Renders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.TreeSelects {
    /// <summary>
    /// 树选择,生成的标签为&lt;nz-tree-select>&lt;/nz-tree-select>
    /// </summary>
    [HtmlTargetElement( "util-tree-select" )]
    public class TreeSelectTagHelper : FormControlTagHelperBase {
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

        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TreeSelectRender( config );
        }
    }
}