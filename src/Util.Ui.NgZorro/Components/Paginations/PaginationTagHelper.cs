using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Paginations.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Paginations {
    /// <summary>
    /// 分页,生成的标签为&lt;nz-pagination&gt;&lt;/nz-pagination&gt;
    /// </summary>
    [HtmlTargetElement( "util-pagination" )]
    public class PaginationTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzTotal],总行数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// [nzTotal],总行数
        /// </summary>
        public string BindTotal { get; set; }
        /// <summary>
        /// [nzPageIndex],当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// [nzPageIndex],当前页
        /// </summary>
        public string BindPageIndex { get; set; }
        /// <summary>
        /// [(nzPageIndex)],当前页
        /// </summary>
        public string BindonPageIndex { get; set; }
        /// <summary>
        /// [nzPageSize],每页显示行数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// [nzPageSize],每页显示行数
        /// </summary>
        public string BindPageSize { get; set; }
        /// <summary>
        /// [(nzPageSize)],每页显示行数
        /// </summary>
        public string BindonPageSize { get; set; }
        /// <summary>
        /// [nzShowSizeChanger],是否显示改变分页大小按钮
        /// </summary>
        public bool ShowSizeChanger { get; set; }
        /// <summary>
        /// [nzShowSizeChanger],是否显示改变分页大小按钮
        /// </summary>
        public string BindShowSizeChanger { get; set; }
        /// <summary>
        /// [nzShowQuickJumper],是否显示快速跳转
        /// </summary>
        public bool ShowQuickJumper { get; set; }
        /// <summary>
        /// [nzShowQuickJumper],是否显示快速跳转
        /// </summary>
        public string BindShowQuickJumper { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzSize,分页尺寸,可选值: 'default' | 'small'
        /// </summary>
        public PaginationSize Size { get; set; }
        /// <summary>
        /// [nzSize],分页尺寸,可选值: 'default' | 'small'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// [nzShowTotal],设置显示总行数和当前数据范围的模板
        /// </summary>
        public string ShowTotal { get; set; }
        /// <summary>
        /// [nzSimple],是否显示简单分页
        /// </summary>
        public bool Simple { get; set; }
        /// <summary>
        /// [nzSimple],是否显示简单分页
        /// </summary>
        public string BindSimple { get; set; }
        /// <summary>
        /// [nzResponsive],响应式,根据屏幕宽度自动调整尺寸,未指定 nzSize 时有效
        /// </summary>
        public bool Responsive { get; set; }
        /// <summary>
        /// [nzResponsive],响应式,根据屏幕宽度自动调整尺寸,未指定 nzSize 时有效
        /// </summary>
        public string BindResponsive { get; set; }
        /// <summary>
        /// [nzPageSizeOptions],设置每页显示行数选择列表,默认值: [10, 20, 30, 40]
        /// </summary>
        public string PageSizeOptions { get; set; }
        /// <summary>
        /// [nzItemRender],自定义页码结构
        /// </summary>
        public string ItemRender { get; set; }
        /// <summary>
        /// [nzHideOnSinglePage],只有一页时是否隐藏分页器
        /// </summary>
        public bool HideOnSinglePage { get; set; }
        /// <summary>
        /// [nzHideOnSinglePage],只有一页时是否隐藏分页器
        /// </summary>
        public string BindHideOnSinglePage { get; set; }
        /// <summary>
        /// (nzPageIndexChange),页码变化事件,类型: EventEmitter&lt;number>
        /// </summary>
        public string OnPageIndexChange { get; set; }
        /// <summary>
        /// (nzPageSizeChange),每页显示行数变化事件,类型: EventEmitter&lt;number>
        /// </summary>
        public string OnPageSizeChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new PaginationRender( config );
        }
    }
}