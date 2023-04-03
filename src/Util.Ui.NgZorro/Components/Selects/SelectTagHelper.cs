using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Selects.Helpers;
using Util.Ui.NgZorro.Components.Selects.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Selects {
    /// <summary>
    /// 选择器,生成的标签为&lt;nz-select&gt;&lt;/nz-select&gt;
    /// </summary>
    [HtmlTargetElement( "util-select" )]
    public class SelectTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 扩展属性,是否启用扩展指令,当设置Url或Data属性时自动启用,默认为 false
        /// </summary>
        public bool EnableExtend { get; set; }
        /// <summary>
        /// 扩展属性 [autoLoad],初始化时是否自动加载数据，默认为true,设置成false则手工加载
        /// </summary>
        public bool AutoLoad { get; set; }
        /// <summary>
        /// 扩展属性 [(queryParam)],查询参数
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
        /// 扩展属性 [data],数据源
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 扩展属性,是否显示默认项，默认项显示在列表的第一行
        /// </summary>
        public bool ShowDefaultOption { get; set; }
        /// <summary>
        /// 扩展属性,默认项文本，默认项显示在列表的第一行
        /// </summary>
        public string DefaultOptionText { get; set; }
        /// <summary>
        /// 扩展属性,是否启用服务端搜索关键字,在搜索框输入时,设置查询参数的Keyword属性并发送请求,默认值：false
        /// </summary>
        public bool SearchKeyword { get; set; }
        /// <summary>
        /// 扩展属性 [searchDelay],搜索关键字延迟时间,单位:毫秒,默认值: 500
        /// </summary>
        public int SearchDelay { get; set; }
        /// <summary>
        /// 扩展属性 [isScrollLoad],滚动到底部是否自动加载，默认值：false
        /// </summary>
        public bool ScrollLoad { get; set; }
        /// <summary>
        /// [compareWith],比较算法函数,函数定义:(o1: any, o2: any) => boolean
        /// </summary>
        public string CompareWith { get; set; }
        /// <summary>
        /// [nzAutoClearSearchValue],是否在选中项后清空搜索框，只在 mode 为 multiple 或 tags 时有效,默认值: true
        /// </summary>
        public bool AutoClearSearchValue { get; set; }
        /// <summary>
        /// [nzAutoClearSearchValue],是否在选中项后清空搜索框，只在 mode 为 multiple 或 tags 时有效,默认值: true
        /// </summary>
        public string BindAutoClearSearchValue { get; set; }
        /// <summary>
        /// [nzAllowClear],允许清除,默认值: false
        /// </summary>
        public bool AllowClear { get; set; }
        /// <summary>
        /// [nzAllowClear],允许清除,默认值: false
        /// </summary>
        public string BindAllowClear { get; set; }
        /// <summary>
        /// [nzBorderless],是否移除边框
        /// </summary>
        public bool Borderless { get; set; }
        /// <summary>
        /// [nzBorderless],是否移除边框
        /// </summary>
        public string BindBorderless { get; set; }
        /// <summary>
        /// [nzOpen],是否打开下拉菜单
        /// </summary>
        public bool Open { get; set; }
        /// <summary>
        /// [nzOpen],是否打开下拉菜单
        /// </summary>
        public string BindOpen { get; set; }
        /// <summary>
        /// [(nzOpen)],是否打开下拉菜单
        /// </summary>
        public string BindonOpen { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦,默认值: false
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦,默认值: false
        /// </summary>
        public string BindAutoFocus { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzDropdownClassName,下拉菜单样式类名
        /// </summary>
        public string DropdownClassName { get; set; }
        /// <summary>
        /// [nzDropdownClassName],下拉菜单样式类名
        /// </summary>
        public string BindDropdownClassName { get; set; }
        /// <summary>
        /// [nzDropdownStyle],下拉菜单样式,类型: { [key: string]: string; },范例: { 'max-height': '300px' }
        /// </summary>
        public string DropdownStyle { get; set; }
        /// <summary>
        /// [nzDropdownMatchSelectWidth],是否下拉菜单和选择器同宽,默认值: true
        /// </summary>
        public bool DropdownMatchSelectWidth { get; set; }
        /// <summary>
        /// [nzDropdownMatchSelectWidth],是否下拉菜单和选择器同宽,默认值: true
        /// </summary>
        public string BindDropdownMatchSelectWidth { get; set; }
        /// <summary>
        /// [nzCustomTemplate],自定义选择框模板,类型:TemplateRef&lt;{ $implicit: NzOptionComponent }&gt;
        /// </summary>
        public string CustomTemplate { get; set; }
        /// <summary>
        /// [nzServerSearch],是否使用服务端搜索，当为 true 时，将不在前端对 nz-option 进行过滤，默认值： false
        /// </summary>
        public bool ServerSearch { get; set; }
        /// <summary>
        /// [nzServerSearch],是否使用服务端搜索，当为 true 时，将不在前端对 nz-option 进行过滤，默认值： false
        /// </summary>
        public string BindServerSearch { get; set; }
        /// <summary>
        /// [nzFilterOption],过滤项函数，接收 inputValue,option 两个参数，当 option 符合筛选条件时，应返回 true，反之则返回 false。函数定义: (input?: string, option?: NzOptionComponent) => boolean;
        /// </summary>
        public string FilterOption { get; set; }
        /// <summary>
        /// nzMaxMultipleCount,允许选中的最大数量
        /// </summary>
        public int MaxMultipleCount { get; set; }
        /// <summary>
        /// [nzMaxMultipleCount],允许选中的最大数量
        /// </summary>
        public string BindMaxMultipleCount { get; set; }
        /// <summary>
        /// nzMode,选择模式,可选模式: 'multiple' | 'tags' | 'default',默认值: 'default'
        /// </summary>
        public SelectMode Mode { get; set; }
        /// <summary>
        /// [nzMode],选择模式,可选模式: 'multiple' | 'tags' | 'default',默认值: 'default'
        /// </summary>
        public string BindMode { get; set; }
        /// <summary>
        /// nzNotFoundContent,当下拉列表为空时显示的内容,类型: string | TemplateRef&lt;/void&gt;
        /// </summary>
        public string NotFoundContent { get; set; }
        /// <summary>
        /// [nzNotFoundContent],当下拉列表为空时显示的内容,类型: string | TemplateRef&lt;/void&gt;
        /// </summary>
        public string BindNotFoundContent { get; set; }
        /// <summary>
        /// nzPlaceHolder,占位提示
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceHolder],占位提示
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// [nzShowArrow],是否显示下拉小箭头,默认值: 单选为 true，多选为 false
        /// </summary>
        public bool ShowArrow { get; set; }
        /// <summary>
        /// [nzShowArrow],是否显示下拉小箭头,默认值: 单选为 true，多选为 false
        /// </summary>
        public string BindShowArrow { get; set; }
        /// <summary>
        /// [nzShowSearch],使单选模式可搜索,默认值: false
        /// </summary>
        public bool ShowSearch { get; set; }
        /// <summary>
        /// [nzShowSearch],使单选模式可搜索,默认值: false
        /// </summary>
        public string BindShowSearch { get; set; }
        /// <summary>
        /// nzSize,选择框大小，可选值: 'large'|'small'|'default',默认值: 'default'
        /// </summary>
        public InputSize Size { get; set; }
        /// <summary>
        /// [nzSize],选择框大小，可选值: 'large'|'small'|'default',默认值: 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzSuffixIcon,选择框后缀图标,类型: string | TemplateRef&lt;/any&gt;
        /// </summary>
        public AntDesignIcon SuffixIcon { get; set; }
        /// <summary>
        /// [nzSuffixIcon],选择框后缀图标,类型:	string | TemplateRef&lt;/any&gt;
        /// </summary>
        public string BindSuffixIcon { get; set; }
        /// <summary>
        /// [nzRemoveIcon],多选框清除图标,类型: TemplateRef&lt;/any&gt;
        /// </summary>
        public string RemoveIcon { get; set; }
        /// <summary>
        /// [nzClearIcon],多选框清空图标,类型: TemplateRef&lt;/any&gt;
        /// </summary>
        public string ClearIcon { get; set; }
        /// <summary>
        /// [nzMenuItemSelectedIcon],当前选中项图标,类型: TemplateRef&lt;/any&gt;
        /// </summary>
        public string MenuItemSelectedIcon { get; set; }
        /// <summary>
        /// [nzTokenSeparators],在 tags 和 multiple 模式下自动分词的分隔符,类型: string[]
        /// </summary>
        public string TokenSeparators { get; set; }
        /// <summary>
        /// [nzLoading],加载状态,类型: boolean,默认值: false
        /// </summary>
        public string Loading { get; set; }
        /// <summary>
        /// nzMaxTagCount,最多显示的标签数量,类型: number
        /// </summary>
        public int MaxTagCount { get; set; }
        /// <summary>
        /// [nzMaxTagCount],最多显示的标签数量,类型: number
        /// </summary>
        public string BindMaxTagCount { get; set; }
        /// <summary>
        /// [nzMaxTagPlaceholder],隐藏标签时显示的占位内容,类型: TemplateRef&lt;{ $implicit: any[] }>
        /// </summary>
        public string MaxTagPlaceholder { get; set; }
        /// <summary>
        /// [nzOptions],选项列表,可以取代 nz-option,类型: Array&lt;{ label: string | TemplateRef&lt;any&gt;; value: any; disabled?: boolean; hide?: boolean; groupLabel?: string | TemplateRef&lt;any&gt;;}&gt;
        /// </summary>
        public string Options { get; set; }
        /// <summary>
        /// nzOptionHeightPx,下拉菜单中每个选项的高度,单位像素,默认值: 32
        /// </summary>
        public int OptionHeightPx { get; set; }
        /// <summary>
        /// [nzOptionHeightPx],下拉菜单中每个选项的高度,单位像素,默认值: 32
        /// </summary>
        public string BindOptionHeightPx { get; set; }
        /// <summary>
        /// nzOptionOverflowSize,下拉菜单中最多展示的选项数量，超出部分滚动,默认值: 8
        /// </summary>
        public int OptionOverflowSize { get; set; }
        /// <summary>
        /// [nzOptionOverflowSize],下拉菜单中最多展示的选项数量，超出部分滚动,默认值: 8
        /// </summary>
        public string BindOptionOverflowSize { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// [nzDropdownRender],设置下拉扩展模板,类型: TemplateRef
        /// </summary>
        public string DropdownRender { get; set; }
        /// <summary>
        /// (nzOpenChange),下拉菜单打开状态变更事件,类型: EventEmitter&lt;boolean&gt;
        /// </summary>
        public string OnOpenChange { get; set; }
        /// <summary>
        /// (nzScrollToBottom),下拉列表滚动到底部事件,类型: EventEmitter&lt;any&gt;
        /// </summary>
        public string OnScrollToBottom { get; set; }
        /// <summary>
        /// (nzOnSearch),文本框值变更事件,类型: EventEmitter&lt;string&gt;
        /// </summary>
        public string OnSearch { get; set; }
        /// <summary>
        /// (nzFocus),获得焦点事件,类型: EventEmitter&lt;any&gt;
        /// </summary>
        public string OnFocus { get; set; }
        /// <summary>
        /// (nzBlur),失去焦点事件,类型: EventEmitter&lt;any&gt;
        /// </summary>
        public string OnBlur { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new SelectService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new SelectRender( _config );
        }
    }
}