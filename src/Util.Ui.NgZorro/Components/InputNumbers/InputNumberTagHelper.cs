using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.InputNumbers.Renders;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.InputNumbers {
    /// <summary>
    /// 数字输入框,生成的标签为&lt;nz-input-number&gt;&lt;/nz-input-number&gt;
    /// </summary>
    [HtmlTargetElement( "util-input-number" )]
    public class InputNumberTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// nzId,组件内部 input 的 id 值
        /// </summary>
        public string InputId { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦
        /// </summary>
        public string BindAutoFocus { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
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
        /// nzMax,最大值
        /// </summary>
        public double Max { get; set; }
        /// <summary>
        /// [nzMax],最大值
        /// </summary>
        public string BindMax { get; set; }
        /// <summary>
        /// nzMin,最小值
        /// </summary>
        public double Min { get; set; }
        /// <summary>
        /// [nzMin],最小值
        /// </summary>
        public string BindMin { get; set; }
        /// <summary>
        /// [nzFormatter],格式化函数,函数定义:	(value: number | string) => string | number
        /// </summary>
        public string Formatter { get; set; }
        /// <summary>
        /// [nzParser],转换函数,指定从 nzFormatter 里转换回数字的方式，和 nzFormatter 搭配使用,函数定义: (value: string) => string | number
        /// </summary>
        public string Parser { get; set; }
        /// <summary>
        /// nzPrecision,精度,即小数位数
        /// </summary>
        public int Precision { get; set; }
        /// <summary>
        /// [nzPrecision],精度,即小数位数
        /// </summary>
        public string BindPrecision { get; set; }
        /// <summary>
        /// nzPrecisionMode,数值精度的取值方式,可选值: 'cut' | 'toFixed' | ((value: number | string, precision?: number) => number)
        /// </summary>
        public InputNumberPrecisionMode PrecisionMode { get; set; }
        /// <summary>
        /// nzPrecisionMode,数值精度的取值方式,可选值: 'cut' | 'toFixed' | ((value: number | string, precision?: number) => number)
        /// </summary>
        public string BindPrecisionMode { get; set; }
        /// <summary>
        /// nzSize,输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public InputSize Size { get; set; }
        /// <summary>
        /// [nzSize],输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzStep,每次改变步数，可以为小数
        /// </summary>
        public double Step { get; set; }
        /// <summary>
        /// [nzStep],每次改变步数，可以为小数
        /// </summary>
        public string BindStep { get; set; }
        /// <summary>
        /// nzInputMode,输入模式,提供了用户在编辑元素或其内容时可能输入的数据类型的提示,默认值:decimal
        /// </summary>
        public InputMode InputMode { get; set; }
        /// <summary>
        /// [nzInputMode],输入模式,提供了用户在编辑元素或其内容时可能输入的数据类型的提示,默认值:decimal
        /// </summary>
        public string BindInputMode { get; set; }
        /// <summary>
        /// nzPlaceHolder,输入框占位文本
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceHolder],输入框占位文本
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (nzFocus),获得焦点事件
        /// </summary>
        public string OnFocus { get; set; }
        /// <summary>
        /// (nzBlur),失去焦点事件
        /// </summary>
        public string OnBlur { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new InputService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new InputNumberRender( _config );
        }
    }
}