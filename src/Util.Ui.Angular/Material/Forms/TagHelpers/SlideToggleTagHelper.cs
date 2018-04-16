using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Material.Internal;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 滑动开关
    /// </summary>
    [HtmlTargetElement( "util-slide-toggle" )]
    public class SlideToggleTagHelper : TagHelperBase {
        /// <summary>
        /// 控件的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 标签位置
        /// </summary>
        public XPosition Position { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 模型绑定
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 变更事件处理函数,范例：handle()
        /// </summary>
        public string OnChange { get; set; }
        /// <summary>
        /// 选中
        /// </summary>
        public string Checked { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SlideToggleRender( new Config( context ) );
        }
    }
}