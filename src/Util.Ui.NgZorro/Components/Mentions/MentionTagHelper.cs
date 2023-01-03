using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Mentions.Configs;
using Util.Ui.NgZorro.Components.Mentions.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Mentions {
    /// <summary>
    /// 提及,生成的标签为&lt;nz-mention&gt;&lt;/nz-mention&gt;
    /// </summary>
    [HtmlTargetElement( "util-mention" )]
    public class MentionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// [nzSuggestions],建议内容,类型:any[]
        /// </summary>
        public string Suggestions { get; set; }
        /// <summary>
        /// [nzLoading],加载状态,类型: boolean
        /// </summary>
        public string Loading { get; set; }
        /// <summary>
        /// [nzValueWith],建议选项的取值函数,函数定义: (any) => string | (value: string) => string
        /// </summary>
        public string ValueWith { get; set; }
        /// <summary>
        /// [nzPrefix],触发弹出下拉框的字符,类型: string | string[],默认值: '@', 范例: ['#', '@']
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// nzPlacement,建议框位置,可选值: 'bottom' | 'top',默认值: 'bottom'
        /// </summary>
        public MentionPlacement Placement { get; set; }
        /// <summary>
        /// [nzPlacement],建议框位置,可选值: 'bottom' | 'top',默认值: 'bottom'
        /// </summary>
        public string BindPlacement { get; set; }
        /// <summary>
        /// nzNotFoundContent,建议列表为空时显示的内容,默认值: '无匹配结果，轻敲空格完成输入'
        /// </summary>
        public string NotFoundContent { get; set; }
        /// <summary>
        /// [nzNotFoundContent],建议列表为空时显示的内容,默认值: '无匹配结果，轻敲空格完成输入'
        /// </summary>
        public string BindNotFoundContent { get; set; }
        /// <summary>
        /// (nzOnSelect),选择事件,类型: EventEmitter&lt;any&gt;
        /// </summary>
        public string OnSelect { get; set; }
        /// <summary>
        /// (nzOnSearchChange),搜索改变事件,当输入框中 @ 变化时触发,类型: EventEmitter&lt;MentionOnSearchTypes&gt;
        /// </summary>
        public string OnSearchChange { get; set; }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var formItemShareService = new FormItemShareService( _config );
            formItemShareService.Init();
            formItemShareService.InitId();
            context.SetValueToItems( new MentionShareConfig() );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new MentionRender( _config );
        }
    }
}