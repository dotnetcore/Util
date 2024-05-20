using Util.Ui.Enums;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base; 

/// <summary>
/// 按钮基类
/// </summary>
public abstract class ButtonTagHelperBase : TooltipTagHelperBase {
    /// <summary>
    /// 扩展属性,全屏切换,设置需要全屏的内容区引用变量,范例 &lt;div #id> , 传入 id
    /// </summary>
    public string Fullscreen { get; set; }
    /// <summary>
    /// 扩展属性,全屏标题
    /// </summary>
    public string FullscreenTitle { get; set; }
    /// <summary>
    /// 扩展属性,进入全屏时,外层容器添加的样式类名, 设置为true,则设置默认样式类 x-fullscreen
    /// </summary>
    public string FullscreenWrapClass { get; set; }
    /// <summary>
    /// 扩展属性,全屏是否创建标题和页脚进行包装,默认值: true, 设置为 false 则完全受控,fullscreen-title 和 fullscreen-wrap-class 将无效
    /// </summary>
    public bool FullscreenPack { get; set; }
    /// <summary>
    /// 扩展属性,内容文本,支持多语言
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// 扩展属性,是否显示ok文本,默认文本为'Ok',i18n文本为'util.ok'
    /// </summary>
    public bool TextOk { get; set; }
    /// <summary>
    /// 扩展属性,是否显示cancel文本,默认文本为'Cancel',i18n文本为'util.cancel'
    /// </summary>
    public bool TextCancel { get; set; }
    /// <summary>
    /// 扩展属性,是否显示create文本,默认文本为'Create',i18n文本为'util.create'
    /// </summary>
    public bool TextCreate { get; set; }
    /// <summary>
    /// 扩展属性,是否显示update文本,默认文本为'Update',i18n文本为'util.update'
    /// </summary>
    public bool TextUpdate { get; set; }
    /// <summary>
    /// 扩展属性,是否显示delete文本,默认文本为'Delete',i18n文本为'util.delete'
    /// </summary>
    public bool TextDelete { get; set; }
    /// <summary>
    /// 扩展属性,是否显示detail文本,默认文本为'Detail',i18n文本为'util.detail'
    /// </summary>
    public bool TextDetail { get; set; }
    /// <summary>
    /// 扩展属性,是否显示query文本,默认文本为'Query',i18n文本为'util.query'
    /// </summary>
    public bool TextQuery { get; set; }
    /// <summary>
    /// 扩展属性,是否显示refresh文本,默认文本为'Refresh',i18n文本为'util.refresh'
    /// </summary>
    public bool TextRefresh { get; set; }
    /// <summary>
    /// 扩展属性,是否显示save文本,默认文本为'Save',i18n文本为'util.save'
    /// </summary>
    public bool TextSave { get; set; }
    /// <summary>
    /// 扩展属性,是否显示enable文本,默认文本为'Enable',i18n文本为'util.enable'
    /// </summary>
    public bool TextEnable { get; set; }
    /// <summary>
    /// 扩展属性,是否显示disable文本,默认文本为'Disable',i18n文本为'util.disable'
    /// </summary>
    public bool TextDisable { get; set; }
    /// <summary>
    /// 扩展属性,是否显示select all文本,默认文本为'Select All',i18n文本为'util.selectAll'
    /// </summary>
    public bool TextSelectAll { get; set; }
    /// <summary>
    /// 扩展属性,是否显示deselect all文本,默认文本为'Deselect All',i18n文本为'util.deselectAll'
    /// </summary>
    public bool TextDeselectAll { get; set; }
    /// <summary>
    /// 扩展属性,是否显示upload文本,默认文本为'Upload',i18n文本为'util.upload'
    /// </summary>
    public bool TextUpload { get; set; }
    /// <summary>
    /// 扩展属性,是否显示download文本,默认文本为'Download',i18n文本为'util.download'
    /// </summary>
    public bool TextDownload { get; set; }
    /// <summary>
    /// 扩展属性,是否显示publish文本,默认文本为'Publish',i18n文本为'util.publish'
    /// </summary>
    public bool TextPublish { get; set; }
    /// <summary>
    /// 扩展属性,是否显示run文本,默认文本为'Run',i18n文本为'util.run'
    /// </summary>
    public bool TextRun { get; set; }
    /// <summary>
    /// 扩展属性,是否显示start文本,默认文本为'Start',i18n文本为'util.start'
    /// </summary>
    public bool TextStart { get; set; }
    /// <summary>
    /// 扩展属性,是否显示stop文本,默认文本为'Stop',i18n文本为'util.stop'
    /// </summary>
    public bool TextStop { get; set; }
    /// <summary>
    /// 扩展属性,是否显示add文本,默认文本为'Add',i18n文本为'util.add'
    /// </summary>
    public bool TextAdd { get; set; }
    /// <summary>
    /// 扩展属性,是否显示remove文本,默认文本为'Remove',i18n文本为'util.remove'
    /// </summary>
    public bool TextRemove { get; set; }
    /// <summary>
    /// 扩展属性,是否显示open文本,默认文本为'Open',i18n文本为'util.open'
    /// </summary>
    public bool TextOpen { get; set; }
    /// <summary>
    /// 扩展属性,是否显示close文本,默认文本为'Close',i18n文本为'util.close'
    /// </summary>
    public bool TextClose { get; set; }
    /// <summary>
    /// 扩展属性,是否显示send文本,默认文本为'Send',i18n文本为'util.send'
    /// </summary>
    public bool TextSend { get; set; }
    /// <summary>
    /// 扩展属性,是否显示clear文本,默认文本为'Clear',i18n文本为'util.clear'
    /// </summary>
    public bool TextClear { get; set; }
    /// <summary>
    /// 扩展属性,是否显示import文本,默认文本为'Import',i18n文本为'util.import'
    /// </summary>
    public bool TextImport { get; set; }
    /// <summary>
    /// 扩展属性,是否显示export文本,默认文本为'Export',i18n文本为'util.export'
    /// </summary>
    public bool TextExport { get; set; }
    /// <summary>
    /// 扩展属性,是否显示reset文本,默认文本为'Reset',i18n文本为'util.reset'
    /// </summary>
    public bool TextReset { get; set; }
    /// <summary>
    /// 扩展属性,是否显示unedit文本,默认文本为'UnEdit',i18n文本为'util.unedit'
    /// </summary>
    public bool TextUnedit { get; set; }
    /// <summary>
    /// [nzDropdownMenu],设置下拉菜单
    /// </summary>
    public string DropdownMenu { get; set; }
    /// <summary>
    /// nzPlacement,下拉菜单弹出位置, 可选值: bottomLeft' | 'bottomCenter' | 'bottomRight' | 'topLeft' | 'topCenter' | 'topRight'
    /// </summary>
    public DropdownMenuPlacement DropdownMenuPlacement { get; set; }
    /// <summary>
    /// [nzPlacement],下拉菜单弹出位置, 可选值: bottomLeft' | 'bottomCenter' | 'bottomRight' | 'topLeft' | 'topCenter' | 'topRight'
    /// </summary>
    public string BindDropdownMenuPlacement { get; set; }
    /// <summary>
    /// nzTrigger,下拉菜单触发方式
    /// </summary>
    public DropdownMenuTrigger DropdownMenuTrigger { get; set; }
    /// <summary>
    /// [nzTrigger],下拉菜单触发方式
    /// </summary>
    public string BindDropdownMenuTrigger { get; set; }
    /// <summary>
    /// [nzClickHide],点击后是否隐藏下拉菜单,默认值:true
    /// </summary>
    public string DropdownMenuClickHide { get; set; }
    /// <summary>
    /// [nzVisible],下拉菜单是否可见
    /// </summary>
    public string DropdownMenuVisible { get; set; }
    /// <summary>
    /// [(nzVisible)],下拉菜单是否可见
    /// </summary>
    public string BindonDropdownMenuVisible { get; set; }
    /// <summary>
    /// nzOverlayClassName,下拉菜单根元素类名
    /// </summary>
    public string DropdownMenuOverlayClassName { get; set; }
    /// <summary>
    /// [nzOverlayClassName],下拉菜单根元素类名
    /// </summary>
    public string BindDropdownMenuOverlayClassName { get; set; }
    /// <summary>
    /// [nzOverlayStyle],下拉菜单根元素样式
    /// </summary>
    public string DropdownMenuOverlayStyle { get; set; }
    /// <summary>
    /// *nzSpaceItem,值为 true 时设置为间距项,放入 &lt;util-space> 中使用
    /// </summary>
    public bool SpaceItem { get; set; }
    /// <summary>
    /// 扩展属性,是否查询表单链接,折叠时显示`展开`文本,展开时显示`收起`文本
    /// </summary>
    public bool IsSearch { get; set; }
    /// <summary>
    /// 扩展属性,显示表格设置,参数值为表格标识
    /// </summary>
    public string ShowTableSettings { get; set; }
    /// <summary>
    /// href,链接地址
    /// </summary>
    public string Href { get; set; }
    /// <summary>
    /// [href],链接地址
    /// </summary>
    public string BindHref { get; set; }
    /// <summary>
    /// target,链接打开目标, 可选值: '_self' | '_blank' | '_parent' | '_top'
    /// </summary>
    public ATarget Target { get; set; }
    /// <summary>
    /// [target],链接打开目标, 可选值: '_self' | '_blank' | '_parent' | '_top'
    /// </summary>
    public string BindTarget { get; set; }
    /// <summary>
    /// rel,指定当前文档与被链接文档的关系
    /// </summary>
    public string Rel { get; set; }
    /// <summary>
    /// [rel],指定当前文档与被链接文档的关系
    /// </summary>
    public string BindRel { get; set; }
    /// <summary>
    /// routerLink,路由链接地址
    /// </summary>
    public string RouterLink { get; set; }
    /// <summary>
    /// [routerLink],路由链接地址
    /// </summary>
    public string BindRouterLink { get; set; }
    /// <summary>
    /// routerLinkActive,设置当前活动路由链接的css类
    /// </summary>
    public string RouterLinkActive { get; set; }
    /// <summary>
    /// [routerLinkActive],设置当前活动路由链接的css类
    /// </summary>
    public string BindRouterLinkActive { get; set; }
    /// <summary>
    /// [queryParams],路由查询参数
    /// </summary>
    public string QueryParams { get; set; }
    /// <summary>
    /// queryParamsHandling,路由链接查询参数处理方式, 可选值: 'merge' | 'preserve', merge 将新参数与当前参数合并, preserve 保留当前参数.
    /// </summary>
    public QueryParamsHandling QueryParamsHandling { get; set; }
    /// <summary>
    /// [queryParamsHandling],路由链接查询参数处理方式, 可选值: 'merge' | 'preserve', merge 将新参数与当前参数合并, preserve 保留当前参数.
    /// </summary>
    public string BindQueryParamsHandling { get; set; }
    /// <summary>
    /// *nzTabLink nz-tab-link, 选项卡路由联动
    /// </summary>
    public string TabLink { get; set; }
    /// <summary>
    /// (click),单击事件
    /// </summary>
    public string OnClick { get; set; }
    /// <summary>
    /// (nzVisibleChange),下拉菜单显示状态变化事件
    /// </summary>
    public string OnVisibleChange { get; set; }
}