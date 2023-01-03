using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Alerts.Helpers;
using Util.Ui.NgZorro.Components.Alerts.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Alerts {
    /// <summary>
    /// 警告提示,生成的标签为&lt;nz-alert>&lt;/nz-alert>
    /// </summary>
    [HtmlTargetElement( "util-alert" )]
    public class AlertTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// [nzBanner],是否顶部公告,默认值: false
        /// </summary>
        public bool Banner { get; set; }
        /// <summary>
        /// [nzBanner],是否顶部公告,默认值: false
        /// </summary>
        public string BindBanner { get; set; }
        /// <summary>
        /// [nzCloseable],是否可关闭
        /// </summary>
        public bool Closeable { get; set; }
        /// <summary>
        /// [nzCloseable],是否可关闭
        /// </summary>
        public string BindCloseable { get; set; }
        /// <summary>
        /// nzCloseText,自定义关闭按钮显示文字,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string CloseText { get; set; }
        /// <summary>
        /// [nzCloseText],自定义关闭按钮显示文字,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindCloseText { get; set; }
        /// <summary>
        /// nzDescription,描述,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// [nzDescription],描述,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindDescription { get; set; }
        /// <summary>
        /// nzMessage,警告提示内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// [nzMessage],警告提示内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindMessage { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示图标,默认值: false,nzBanner 模式下默认值为 true
        /// </summary>
        public bool ShowIcon { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示图标,默认值: false,nzBanner 模式下默认值为 true
        /// </summary>
        public string BindShowIcon { get; set; }
        /// <summary>
        /// nzIconType,自定义图标类型，nzShowIcon 为 true 时有效
        /// </summary>
        public AntDesignIcon IconType { get; set; }
        /// <summary>
        /// [nzIconType],自定义图标类型，nzShowIcon 为 true 时有效
        /// </summary>
        public string BindIconType { get; set; }
        /// <summary>
        /// nzType,警告类型,指定警告提示的样式,可选值: 'success' | 'info' | 'warning' | 'error',默认值: 'info',nzBanner 模式下默认值为 'warning'
        /// </summary>
        public AlertType Type { get; set; }
        /// <summary>
        /// [nzType],警告类型,指定警告提示的样式,可选值: 'success' | 'info' | 'warning' | 'error',默认值: 'info',nzBanner 模式下默认值为 'warning'
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// (nzOnClose),关闭事件,类型: EventEmitter&lt;void>
        /// </summary>
        public string OnClose { get; set; }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new AlertShareConfigService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new AlertRender( _config );
        }
    }
}