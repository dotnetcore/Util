using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Components.Inputs.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Inputs {
    /// <summary>
    /// 多行文本域,生成的标签为&lt;textarea nz-input&gt;&lt;/textarea&gt;
    /// </summary>
    [HtmlTargetElement( "util-textarea" )]
    public class TextareaTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// name,名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [name],名称
        /// </summary>
        public string BindName { get; set; }
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
        /// [minlength],最小长度验证
        /// </summary>
        public string MinLength { get; set; }
        /// <summary>
        /// 扩展属性 minLengthMessage,最小长度验证消息
        /// </summary>
        public string MinLengthMessage { get; set; }
        /// <summary>
        /// 扩展属性 [minLengthMessage],最小长度验证消息
        /// </summary>
        public string BindMinLengthMessage { get; set; }
        /// <summary>
        /// [maxlength],最大长度验证
        /// </summary>
        public string MaxLength { get; set; }
        /// <summary>
        /// [disabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [disabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [readOnly],只读
        /// </summary>
        public bool Readonly { get; set; }
        /// <summary>
        /// [readOnly],只读
        /// </summary>
        public string BindReadonly { get; set; }
        /// <summary>
        /// placeholder,占位符提示信息
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [placeholder],占位符提示信息
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// rows,行数
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// [rows],行数
        /// </summary>
        public string BindRows { get; set; }
        /// <summary>
        /// cols,列数
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// [cols],列数
        /// </summary>
        public string BindColumns { get; set; }
        /// <summary>
        /// [nzAutosize],自适应内容高度
        /// </summary>
        public bool Autosize { get; set; }
        /// <summary>
        /// [nzAutosize],自适应内容高度,可设置为布尔值,或对象形式{ minRows: number, maxRows: number },范例: { minRows: 2, maxRows: 6 }
        /// </summary>
        public string BindAutosize { get; set; }
        /// <summary>
        /// [nzAutosize],最小行数,设置为 { minRows: number }
        /// </summary>
        public int MinRows { get; set; }
        /// <summary>
        /// [nzAutosize],最大行数,设置为 { maxRows: number }
        /// </summary>
        public int MaxRows { get; set; }
        /// <summary>
        /// nzSize,设置输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public InputSize Size { get; set; }
        /// <summary>
        /// [nzSize],设置输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// 是否允许清除内容,设置为 true 将显示清除图标,注意:必须设置ngModel
        /// </summary>
        public bool AllowClear { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (input),输入事件
        /// </summary>
        public string OnInput { get; set; }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new InputService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TextareaRender( _config );
        }
    }
}