using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Display.Helpers;
using Util.Ui.NgZorro.Components.Display.Renders;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Display {
    /// <summary>
    /// 数据项展示,生成的标签为&lt;span&gt;&lt;/span&gt;
    /// </summary>
    [HtmlTargetElement( "util-display" )]
    public class DisplayTagHelper : FormContainerTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 值,范例: 设置 a,结果为 {{a}}
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 是否显示左侧的标签,默认不显示,注意:设置For属性时生效
        /// </summary>
        public bool ShowLabel { get; set; }
        /// <summary>
        /// 日期格式化字符串，默认值: yyyy-MM-dd HH:mm,仅在使用属性表达式For时有效,格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string DateFormat { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            LoadExpression();
            InitFormShareService();
            InitFormItemShareService();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var loader = new DisplayExpressionLoader();
            loader.Load( _config );
        }

        /// <summary>
        /// 初始化表单共享服务
        /// </summary>
        private void InitFormShareService() {
            var service = new FormShareService( _config );
            service.Init();
        }

        /// <summary>
        /// 初始化表单项共享服务
        /// </summary>
        private void InitFormItemShareService() {
            var service = new FormItemShareService( _config );
            service.Init();
            service.InitId();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new DisplayRender( _config );
        }
    }
}