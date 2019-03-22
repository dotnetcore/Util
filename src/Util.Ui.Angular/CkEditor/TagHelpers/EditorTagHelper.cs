using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.CkEditor.Renders;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.CkEditor.TagHelpers {
    /// <summary>
    /// 富文本框编辑器
    /// </summary>
    [HtmlTargetElement( "util-editor" )]
    public class EditorTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 控件的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 控件的绑定名称 [name]
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// 模型绑定
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 上传地址
        /// </summary>
        public string UploadUrl { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// 禁用过滤
        /// </summary>
        public bool DisableFilter { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new EditorRender( new Config( context ) );
        }
    }
}