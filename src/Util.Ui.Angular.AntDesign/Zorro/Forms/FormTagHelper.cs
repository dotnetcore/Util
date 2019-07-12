using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Renders;
using Util.Ui.Zorro.Grid.Configs;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 表单
    /// </summary>
    [HtmlTargetElement( "util-form" )]
    public class FormTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzLayout,布局方式
        /// </summary>
        public FormLayout Layout { get; set; }
        /// <summary>
        /// 是否显示表单标签的冒号，默认值：true
        /// </summary>
        public bool ShowColon { get; set; }
        /// <summary>
        /// 标签在栅格布局中的占位格数
        /// </summary>
        public int LabelSpan { get; set; }
        /// <summary>
        /// 控件在栅格布局中的占位格数
        /// </summary>
        public int ControlSpan { get; set; }
        /// <summary>
        /// 标签与控件之间间隔，可以是数字，单位为像素，也可以是响应式写法,范例：{ xs: 8, sm: 16, md: 24, lg: 32, xl: 32, xxl: 32 }
        /// </summary>
        public string Gutter { get; set; }
        /// <summary>
        /// 是否打开浏览器自动完成功能，默认值：false
        /// </summary>
        public bool AutoComplete { get; set; }
        /// <summary>
        /// 提交事件处理函数，范例：handle()
        /// </summary>
        public string OnSubmit { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new FormRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            InitShare( context );
        }

        /// <summary>
        /// 初始化共享实例
        /// </summary>
        public void InitShare( TagHelperContext context ) {
            var shareConfig = new GridShareConfig();
            InitShareConfig( context, shareConfig );
            context.SetValueToItems( GridShareConfig.Key, shareConfig );
        }

        /// <summary>
        /// 初始化共享配置
        /// </summary>
        protected virtual void InitShareConfig( TagHelperContext context, GridShareConfig config ) {
            config.LabelSpan = context.GetValueFromAttributes<string>( UiConst.LabelSpan );
            config.ControlSpan = context.GetValueFromAttributes<string>( UiConst.ControlSpan );
            config.Gutter = context.GetValueFromAttributes<string>( UiConst.Gutter );
        }
    }
}