using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Trees.Renders;

namespace Util.Ui.NgZorro.Components.Trees {
    /// <summary>
    /// 树形控件,生成的标签为&lt;nz-tree>&lt;/nz-tree>
    /// </summary>
    [HtmlTargetElement( "util-tree" )]
    public class TreeTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzData],设置数据,类型: NzTreeNodeOptions[] | NzTreeNode[],默认值: []
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// [nzBlockNode],是否节点占一行,默认值: false
        /// </summary>
        public bool BlockNode { get; set; }
        /// <summary>
        /// [nzBlockNode],是否节点占一行,默认值: false
        /// </summary>
        public string BindBlockNode { get; set; }
        /// <summary>
        /// [nzCheckable],节点前是否显示复选框,默认值: false
        /// </summary>
        public bool Checkable { get; set; }
        /// <summary>
        /// [nzCheckable],节点前是否显示复选框,默认值: false
        /// </summary>
        public string BindCheckable { get; set; }
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
        /// [nzExpandedIcon],自定义展开图标,类型: TemplateRef&lt;{ $implicit: NzTreeNode }>
        /// </summary>
        public string ExpandedIcon { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示节点文本前图标,没有默认样式,默认值: false
        /// </summary>
        public bool ShowIcon { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示节点文本前图标,没有默认样式,默认值: false
        /// </summary>
        public string BindShowIcon { get; set; }
        /// <summary>
        /// [nzAsyncData],是否异步加载,默认值: false
        /// </summary>
        public bool AsyncData { get; set; }
        /// <summary>
        /// [nzAsyncData],是否异步加载,默认值: false
        /// </summary>
        public string BindAsyncData { get; set; }
        /// <summary>
        /// [nzDraggable],节点是否可拖拽,默认值: false
        /// </summary>
        public bool Draggable { get; set; }
        /// <summary>
        /// [nzDraggable],节点是否可拖拽,默认值: false
        /// </summary>
        public string BindDraggable { get; set; }
        /// <summary>
        /// [nzMultiple],是否支持点选多个节点,默认值: false
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// [nzMultiple],是否支持点选多个节点,默认值: false
        /// </summary>
        public string BindMultiple { get; set; }
        /// <summary>
        /// [nzHideUnMatched],是否隐藏未匹配节点,默认值: false
        /// </summary>
        public bool HideUnmatched { get; set; }
        /// <summary>
        /// [nzHideUnMatched],是否隐藏未匹配节点,默认值: false
        /// </summary>
        public string BindHideUnmatched { get; set; }
        /// <summary>
        /// [nzCheckStrictly],严格勾选,父子节点选中状态不再关联,默认值: false
        /// </summary>
        public bool CheckStrictly { get; set; }
        /// <summary>
        /// [nzCheckStrictly],严格勾选,父子节点选中状态不再关联,默认值: false
        /// </summary>
        public string BindCheckStrictly { get; set; }
        /// <summary>
        /// [nzTreeTemplate],自定义节点模板,类型: TemplateRef&lt;{ $implicit: NzTreeNode }>
        /// </summary>
        public string TreeTemplate { get; set; }
        /// <summary>
        /// [nzExpandAll],是否默认展开所有节点,默认值: false
        /// </summary>
        public bool ExpandAll { get; set; }
        /// <summary>
        /// [nzExpandAll],是否默认展开所有节点,默认值: false
        /// </summary>
        public string BindExpandAll { get; set; }
        /// <summary>
        /// [nzExpandedKeys],展开节点的键集合,类型: string[]
        /// </summary>
        public string ExpandedKeys { get; set; }
        /// <summary>
        /// [nzCheckedKeys],勾选节点复选框的键集合,类型: string[]
        /// </summary>
        public string CheckedKeys { get; set; }
        /// <summary>
        /// [nzSelectedKeys],选中节点的键集合,类型: string[]
        /// </summary>
        public string SelectedKeys { get; set; }
        /// <summary>
        /// nzSearchValue,搜索值,搜索树高亮节点,默认值: null
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// [nzSearchValue],搜索值,搜索树高亮节点,默认值: null
        /// </summary>
        public string BindSearchValue { get; set; }
        /// <summary>
        /// [(nzSearchValue)],搜索值,搜索树高亮节点,默认值: null
        /// </summary>
        public string BindonSearchValue { get; set; }
        /// <summary>
        /// [nzSearchFunc],自定义搜索方法，配合 nzSearchValue 使用,类型: (node: NzTreeNodeOptions) => boolean,默认值: null
        /// </summary>
        public string SearchFunc { get; set; }
        /// <summary>
        /// [nzBeforeDrop],拖拽前二次校验函数，允许用户决定是否允许放置,类型: (confirm: NzFormatBeforeDropEvent) => Observable&lt;boolean>
        /// </summary>
        public string BeforeDrop { get; set; }
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
        /// (nzClick),单击事件,点击树节点时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// (nzDblClick),双击事件,双击树节点时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnDblClick { get; set; }
        /// <summary>
        /// (nzContextMenu),上下文菜单事件,右键点击树节点时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnContextmenu { get; set; }
        /// <summary>
        /// (nzCheckBoxChange),树节点复选框选中状态变化事件,点击树节点复选框时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnCheckBoxChange { get; set; }
        /// <summary>
        /// (nzExpandChange),展开收缩节点事件,点击展开树节点图标时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnExpandChange { get; set; }
        /// <summary>
        /// (nzSearchValueChange),搜索值变化事件,搜索节点时触发,与 nzSearchValue 配合使用,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnSearchValueChange { get; set; }
        /// <summary>
        /// (nzOnDragStart),开始拖拽事件,开始拖拽时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnDragStart { get; set; }
        /// <summary>
        /// (nzOnDragEnter),拖拽树节点进入目标容器范围时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnDragEnter { get; set; }
        /// <summary>
        /// (nzOnDragOver),拖拽树节点在目标容器范围内移动时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnDragOver { get; set; }
        /// <summary>
        /// (nzOnDragLeave),拖拽树节点离开目标容器范围时触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnDragLeave { get; set; }
        /// <summary>
        /// (nzOnDrop),鼠标在拖放目标上释放时,在拖放目标上触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnDrop { get; set; }
        /// <summary>
        /// (nzOnDragEnd),鼠标在拖放目标上释放时,在拖拽元素上触发,类型: EventEmitter&lt;NzFormatEmitEvent>
        /// </summary>
        public string OnDragEnd { get; set; }

        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TreeRender( config );
        }
    }
}