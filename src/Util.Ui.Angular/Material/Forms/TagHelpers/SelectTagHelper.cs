using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Enums;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 下拉列表
    /// </summary>
    [HtmlTargetElement( "util-select" )]
    public class SelectTagHelper : TagHelperBase {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string DatasSource { get; set; }
        /// <summary>
        /// 占位提示符
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// 占位符浮动类型
        /// </summary>
        public FloatType FloatPlaceholder { get; set; }
        /// <summary>
        /// 起始提示，显示在控件左下方
        /// </summary>
        public string StartHint { get; set; }
        /// <summary>
        /// 结束提示，显示在控件右下方
        /// </summary>
        public string EndHint { get; set; }
        /// <summary>
        /// 启用重置项，重置项显示在列表的第一行，用于清空当前选择的值
        /// </summary>
        public bool EnableResetOption { get; set; }
        /// <summary>
        /// 重置项文本，重置项显示在列表的第一行，用于清空当前选择的值
        /// </summary>
        public string ResetOptionText { get; set; }
        /// <summary>
        /// 启用多选
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// 模型绑定
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 必填项错误消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// 显示模板，值用|表示，范例：当前选中：| ,显示为 当前选中：1,2,3
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 变更事件处理函数,用$event访问值,范例：change($event)
        /// </summary>
        public string OnChange { get; set; }
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 后缀文本
        /// </summary>
        public string SuffixText { get; set; }
        /// <summary>
        /// 后缀FontAwesome图标
        /// </summary>
        public FontAwesomeIcon SuffixFontAwesomeIcon { get; set; }
        /// <summary>
        /// 后缀Material图标
        /// </summary>
        public MaterialIcon SuffixMaterialIcon { get; set; }
        /// <summary>
        /// 后缀图标单击事件,范例：click()
        /// </summary>
        public string OnSuffixIconClick { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SelectRender( new SelectConfig( context ) );
        }
    }
}
