using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tags.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;
using TagMode = Microsoft.AspNetCore.Razor.TagHelpers.TagMode;

namespace Util.Ui.NgZorro.Components.Tags {
    /// <summary>
    /// 标签,生成的标签为&lt;nz-tag>&lt;/nz-tag>
    /// </summary>
    [HtmlTargetElement( "util-tag" )]
    public class TagTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzMode,模式,可选值: 'closeable' | 'default' | 'checkable',默认值: 'default'
        /// </summary>
        public TagMode Mode { get; set; }
        /// <summary>
        /// [nzMode],模式,可选值: 'closeable' | 'default' | 'checkable',默认值: 'default'
        /// </summary>
        public string BindMode { get; set; }
        /// <summary>
        /// [nzChecked],是否选中,在 nzMode="checkable" 时可用,默认值: false
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// [nzChecked],是否选中,在 nzMode="checkable" 时可用,默认值: false
        /// </summary>
        public string BindChecked { get; set; }
        /// <summary>
        /// [(nzChecked)],是否选中,在 nzMode="checkable" 时可用,默认值: false
        /// </summary>
        public string BindonChecked { get; set; }
        /// <summary>
        /// nzColor,颜色枚举类型
        /// </summary>
        public AntDesignColor ColorType { get; set; }
        /// <summary>
        /// nzColor,颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// [nzColor],颜色
        /// </summary>
        public string BindColor { get; set; }
        /// <summary>
        /// (nzOnClose),关闭事件,在 nzMode="closable" 时可用,类型: EventEmitter&lt;MouseEvent>
        /// </summary>
        public string OnClose { get; set; }
        /// <summary>
        /// (nzCheckedChange),选中状态变化事件,在 nzMode="checkable" 时可用,类型: EventEmitter&lt;void>
        /// </summary>
        public string OnCheckedChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TagRender( config );
        }
    }
}