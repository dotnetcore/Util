using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Transfers.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Transfers {
    /// <summary>
    /// 穿梭框,生成的标签为&lt;nz-transfer>&lt;/nz-transfer>
    /// </summary>
    [HtmlTargetElement( "util-transfer" )]
    public class TransferTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzDataSource],数据源
        /// </summary>
        public string Datasource { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzTitles],标题集合，顺序从左至右,类型: string[],默认值: ['', ''],范例: ['Source', 'Target']
        /// </summary>
        public string Titles { get; set; }
        /// <summary>
        /// [nzOperations],操作按钮标题集合，顺序从下至上,类型: string[],默认值: ['', ''],范例: ['to right', 'to left']
        /// </summary>
        public string Operations { get; set; }
        /// <summary>
        /// [nzListStyle],自定义样式，等同 ngStyle,范例: { 'width.px': 300, 'height.px': 300 }
        /// </summary>
        public string ListStyle { get; set; }
        /// <summary>
        /// nzItemUnit,项目单位，只有一个项目时显示的单位,默认值: '项'
        /// </summary>
        public string ItemUnit { get; set; }
        /// <summary>
        /// [nzItemUnit],项目单位，只有一个项目时显示的单位,默认值: '项'
        /// </summary>
        public string BindItemUnit { get; set; }
        /// <summary>
        /// nzItemsUnit,项目单位，存在多个项目时显示的单位,默认值: '项'
        /// </summary>
        public string ItemsUnit { get; set; }
        /// <summary>
        /// [nzItemsUnit],项目单位，存在多个项目时显示的单位,默认值: '项'
        /// </summary>
        public string BindItemsUnit { get; set; }
        /// <summary>
        /// [nzRenderList],渲染列表,类型: Array&lt;TemplateRef&lt;void> | null>
        /// </summary>
        public string RenderList { get; set; }
        /// <summary>
        /// [nzRender],	每行数据渲染模板,类型: TemplateRef&lt;void>
        /// </summary>
        public string Render { get; set; }
        /// <summary>
        /// [nzFooter],	底部渲染模板,类型: TemplateRef&lt;void>
        /// </summary>
        public string Footer { get; set; }
        /// <summary>
        /// [nzShowSearch],是否显示搜索框,默认值: false
        /// </summary>
        public bool ShowSearch { get; set; }
        /// <summary>
        /// [nzShowSearch],是否显示搜索框,默认值: false
        /// </summary>
        public string BindShowSearch { get; set; }
        /// <summary>
        /// [nzFilterOption],过滤项函数，接收 inputValue,item 两个参数，当 item 符合筛选条件时，应返回 true，反之则返回 false。函数定义: (inputValue: string, item: TransferItem) => boolean;
        /// </summary>
        public string FilterOption { get; set; }
        /// <summary>
        /// nzSearchPlaceholder,搜索框占位提示
        /// </summary>
        public string SearchPlaceholder { get; set; }
        /// <summary>
        /// [nzSearchPlaceholder],搜索框占位提示
        /// </summary>
        public string BindSearchPlaceholder { get; set; }
        /// <summary>
        /// nzNotFoundContent,当列表为空时显示的内容
        /// </summary>
        public string NotFoundContent { get; set; }
        /// <summary>
        /// [nzNotFoundContent],当列表为空时显示的内容
        /// </summary>
        public string BindNotFoundContent { get; set; }
        /// <summary>
        /// [nzCanMove],可移动项函数,用于穿梭时二次校验,注意：穿梭组件内部始终只保留一份数据，二次校验过程中需取消穿梭项则直接删除该项,函数定义: (arg: TransferCanMove) => Observable&lt;TransferItem[]>
        /// </summary>
        public string CanMove { get; set; }
        /// <summary>
        /// [nzSelectedKeys],设置被选中的键列表,类型: string[]
        /// </summary>
        public string SelectedKeys { get; set; }
        /// <summary>
        /// [nzTargetKeys],设置显示在右侧框的键列表,类型: string[]
        /// </summary>
        public string TargetKeys { get; set; }
        /// <summary>
        /// (nzChange),转移改变事件,选项在两栏之间转移时触发,类型: EventEmitter&lt;TransferChange>
        /// </summary>
        public string OnChange { get; set; }
        /// <summary>
        /// (nzSearchChange),搜索改变事件,搜索框内容改变时触发,类型: EventEmitter&lt;TransferSearchChange>
        /// </summary>
        public string OnSearchChange { get; set; }
        /// <summary>
        /// (nzSelectChange),选中状态改变事件,选中项发生改变时触发,类型: EventEmitter&lt;TransferSearchChange>
        /// </summary>
        public string OnSelectChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TransferRender( config );
        }
    }
}