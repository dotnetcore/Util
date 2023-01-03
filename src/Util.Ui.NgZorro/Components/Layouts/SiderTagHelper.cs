using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Layouts {
    /// <summary>
    /// 侧边栏布局,生成的标签为&lt;nz-sider&gt;&lt;/nz-sider&gt;,它的父容器为&lt;util-layout&gt;&lt;/util-layout&gt;,即&lt;nz-layout&gt;&lt;/nz-layout&gt;
    /// </summary>
    [HtmlTargetElement( "util-sider" )]
    public class SiderTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzWidth,宽度,范例:200px
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// [nzWidth],宽度
        /// </summary>
        public string BindWidth { get; set; }
        /// <summary>
        /// nzTheme,主题颜色,可选值: 'light' | 'dark'
        /// </summary>
        public SiderTheme Theme { get; set; }
        /// <summary>
        /// [nzTheme],主题颜色,可选值: 'light' | 'dark'
        /// </summary>
        public string BindTheme { get; set; }
        /// <summary>
        /// nzBreakpoint,触发响应式布局的断点,窗口宽度小于断点触发宽度时,侧边栏缩小为 nzCollapsedWidth 宽度,若将 nzCollapsedWidth 设置为0，会出现特殊触发器,可选值: 'xs' | 'sm' | 'md' | 'lg' | 'xl' | 'xxl',断点触发宽度:{  xs: '480px',  sm: '768px',  md: '992px',  lg: '1200px',  xl: '1600px',  xxl: '1600px' }
        /// </summary>
        public GridSize Breakpoint { get; set; }
        /// <summary>
        /// [nzBreakpoint],触发响应式布局的断点,窗口宽度小于断点触发宽度时,侧边栏缩小为 nzCollapsedWidth 宽度,若将 nzCollapsedWidth 设置为0，会出现特殊触发器,可选值: 'xs' | 'sm' | 'md' | 'lg' | 'xl' | 'xxl',断点触发宽度:{  xs: '480px',  sm: '768px',  md: '992px',  lg: '1200px',  xl: '1600px',  xxl: '1600px' }
        /// </summary>
        public string BindBreakpoint { get; set; }
        /// <summary>
        /// [nzCollapsedWidth],收缩宽度，设置为 0 会出现特殊触发器,默认值: 64
        /// </summary>
        public double CollapsedWidth { get; set; }
        /// <summary>
        /// [nzCollapsedWidth],收缩宽度，设置为 0 会出现特殊触发器,默认值: 64
        /// </summary>
        public string BindCollapsedWidth { get; set; }
        /// <summary>
        /// [nzCollapsible],是否可收缩
        /// </summary>
        public bool Collapsible { get; set; }
        /// <summary>
        /// [nzCollapsible],是否可收缩
        /// </summary>
        public string BindCollapsible { get; set; }
        /// <summary>
        /// [nzCollapsed],收缩状态
        /// </summary>
        public bool Collapsed { get; set; }
        /// <summary>
        /// [nzCollapsed],收缩状态
        /// </summary>
        public string BindCollapsed { get; set; }
        /// <summary>
        /// [(nzCollapsed)],收缩状态
        /// </summary>
        public string BindonCollapsed { get; set; }
        /// <summary>
        /// [nzReverseArrow],翻转折叠提示箭头的方向，当侧边栏在右边时使用
        /// </summary>
        public bool ReverseArrow { get; set; }
        /// <summary>
        /// [nzReverseArrow],翻转折叠提示箭头的方向，当侧边栏在右边时使用
        /// </summary>
        public string BindReverseArrow { get; set; }
        /// <summary>
        /// [nzTrigger],自定义触发器,即收缩按钮,设置为 null 时隐藏触发器
        /// </summary>
        public string Trigger { get; set; }
        /// <summary>
        /// [nzZeroTrigger],自定义 nzCollapsedWidth 为0时的特殊触发器
        /// </summary>
        public string ZeroTrigger { get; set; }
        /// <summary>
        /// (nzCollapsedChange),展开-收起时的回调函数,注意:自定义触发器不会触发该事件
        /// </summary>
        public string OnCollapsedChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new SiderRender( config );
        }
    }
}