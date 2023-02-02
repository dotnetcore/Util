using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Tinymce.Renders;
using Util.Ui.NgAlain.Enums;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Tinymce {
    /// <summary>
    /// Tinymce富文本编辑器,生成的标签为&lt;tinymce&gt;&lt;/tinymce&gt;
    /// </summary>
    [HtmlTargetElement( "util-tinymce" )]
    public class TinymceTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// [branding],是否显示品牌,设为false时，隐藏编辑器界面右下角的“Powered by Tiny”,默认值: false
        /// </summary>
        public bool Branding { get; set; }
        /// <summary>
        /// [pasteDataImages],是否允许粘贴图片,默认值: true
        /// </summary>
        public bool PasteDataImages { get; set; }
        /// <summary>
        /// menubar,菜单栏,可以是布尔值,设置为false隐藏菜单栏,也可以是空格分隔的菜单列表,范例: file edit insert view format table tools help
        /// </summary>
        public string Menubar { get; set; }
        /// <summary>
        /// toolbarMode,工具栏模式,当工具栏按钮超出编辑器宽度时的排列方式,默认值: wrap
        /// </summary>
        public TinymceToolbarMode ToolbarMode { get; set; }
        /// <summary>
        /// plugins,空格分隔的插件列表
        /// </summary>
        public string Plugins { get; set; }
        /// <summary>
        /// toolbar,空格分隔的工具栏
        /// </summary>
        public string Toolbar { get; set; }
        /// <summary>
        /// [config],配置
        /// </summary>
        public string Config { get; set; }
        /// <summary>
        /// [disabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [disabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [required],是否必填项
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// 扩展属性 requiredMessage,必填项验证消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// 扩展属性 [requiredMessage],必填项验证消息
        /// </summary>
        public string BindRequiredMessage { get; set; }
        /// <summary>
        /// placeholder,占位文本
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [placeholder],占位文本
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// [change],内容变更事件,类型: (html: string) => void;
        /// </summary>
        public string OnChange { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new InputService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TinymceRender( _config );
        }
    }
}