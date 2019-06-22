using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Messages.Renders;

namespace Util.Ui.Zorro.Messages {
    /// <summary>
    /// 警告提示
    /// </summary>
    [HtmlTargetElement( "util-alert" )]
    public class AlertTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzType,警告提示样式
        /// </summary>
        public AlertType Type { get; set; }
        /// <summary>
        /// [nzShowIcon],是否显示图标，默认值为 false,nzBanner 模式下默认值为 true
        /// </summary>
        public bool ShowIcon { get; set; }
        /// <summary>
        /// nzMessage,警告提示内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// [nzMessage],警告提示内容
        /// </summary>
        public string BindMessage { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new AlertRender( new Config( context ) );
        }
    }
}