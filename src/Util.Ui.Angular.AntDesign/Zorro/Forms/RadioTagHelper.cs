using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 单选框
    /// </summary>
    [HtmlTargetElement( "util-radio" )]
    public class RadioTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 是否显示标签，默认值：false
        /// </summary>
        public bool ShowLabel { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string LabelText { get; set; }
        /// <summary>
        /// 标签的栅格占位格数
        /// </summary>
        public int LabelSpan { get; set; }
        /// <summary>
        /// 是否flex布局，默认值：false
        /// </summary>
        public bool IsFlex { get; set; }
        /// <summary>
        /// [(ngModel)],模型绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// nzName,控件的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [nzName],控件的名称
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// 按钮样式
        /// </summary>
        public RadioButtonStyle ButtonStyle { get; set; }
        /// <summary>
        /// 是否垂直布局
        /// </summary>
        public bool Vertical { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// [url],请求地址
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// nzSpan,24栅格占位格数，可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// (ngModelChange),变更事件处理函数
        /// </summary>
        public string OnChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RadioRender( new SelectConfig( context ) );
        }
    }
}