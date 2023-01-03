using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Components.TimePickers.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.TimePickers {
    /// <summary>
    /// 时间选择,生成的标签为&lt;nz-time-picker&gt;&lt;/nz-time-picker&gt;
    /// </summary>
    [HtmlTargetElement( "util-time-picker" )]
    public class TimePickerTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// [nzAddOn],选择框底部显示自定义内容,类型: TemplateRef&lt;void>
        /// </summary>
        public string AddOn { get; set; }
        /// <summary>
        /// [nzAllowEmpty],是否展示清除按钮,默认值: true
        /// </summary>
        public bool AllowEmpty { get; set; }
        /// <summary>
        /// [nzAllowEmpty],是否展示清除按钮,默认值: true
        /// </summary>
        public string BindAllowEmpty { get; set; }
        /// <summary>
        /// nzClearText,清除按钮的提示文本,默认值: 'clear'
        /// </summary>
        public string ClearText { get; set; }
        /// <summary>
        /// [nzClearText],清除按钮的提示文本,默认值: 'clear'
        /// </summary>
        public string BindClearText { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦,默认值: false
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦,默认值: false
        /// </summary>
        public string BindAutoFocus { get; set; }
        /// <summary>
        /// nzDefaultOpenValue,打开时默认选中的值,当 [ngModel] 不存在时有效,类型: Date,默认值: new Date()
        /// </summary>
        public string DefaultOpenValue { get; set; }
        /// <summary>
        /// [nzDefaultOpenValue],打开时默认选中的值,当 [ngModel] 不存在时有效,类型: Date,默认值: new Date()
        /// </summary>
        public string BindDefaultOpenValue { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzDisabledHours],不可选择小时函数,函数定义：() => number[]
        /// </summary>
        public string DisabledHours { get; set; }
        /// <summary>
        /// [nzDisabledMinutes],不可选择分钟函数,函数定义：(hour: number) => number[]
        /// </summary>
        public string DisabledMinutes { get; set; }
        /// <summary>
        /// [nzDisabledSeconds],不可选择秒函数,函数定义：(hour: number, minute: number) => number[]
        /// </summary>
        public string DisabledSeconds { get; set; }
        /// <summary>
        /// nzFormat,格式化字符串，格式说明：时(HH) 分(mm) 秒(ss) 毫秒(SSS),默认值:"HH:mm:ss"
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// [nzFormat],格式化字符串，格式说明：时(HH) 分(mm) 秒(ss) 毫秒(SSS),默认值:"HH:mm:ss"
        /// </summary>
        public string BindFormat { get; set; }
        /// <summary>
        /// [nzHideDisabledOptions],是否隐藏禁止选择的选项,默认值: false
        /// </summary>
        public bool HideDisabledOptions { get; set; }
        /// <summary>
        /// [nzHideDisabledOptions],是否隐藏禁止选择的选项,默认值: false
        /// </summary>
        public string BindHideDisabledOptions { get; set; }
        /// <summary>
        /// nzHourStep,小时选项间隔,默认值: 1
        /// </summary>
        public int HourStep { get; set; }
        /// <summary>
        /// [nzHourStep],小时选项间隔,默认值: 1
        /// </summary>
        public string BindHourStep { get; set; }
        /// <summary>
        /// nzMinuteStep,分钟选项间隔,默认值: 1
        /// </summary>
        public int MinuteStep { get; set; }
        /// <summary>
        /// [nzMinuteStep],分钟选项间隔,默认值: 1
        /// </summary>
        public string BindMinuteStep { get; set; }
        /// <summary>
        /// nzSecondStep,秒选项间隔,默认值: 1
        /// </summary>
        public int SecondStep { get; set; }
        /// <summary>
        /// [nzSecondStep],秒选项间隔,默认值: 1
        /// </summary>
        public string BindSecondStep { get; set; }
        /// <summary>
        /// [nzOpen],面板是否打开,默认值: false
        /// </summary>
        public bool Open { get; set; }
        /// <summary>
        /// [nzOpen],面板是否打开,默认值: false
        /// </summary>
        public string BindOpen { get; set; }
        /// <summary>
        /// [(nzOpen)],面板是否打开,默认值: false
        /// </summary>
        public string BindonOpen { get; set; }
        /// <summary>
        /// nzPlaceHolder,输入框占位文本
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceHolder],输入框占位文本
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// nzPopupClassName,弹出层样式类名
        /// </summary>
        public string PopupClassName { get; set; }
        /// <summary>
        /// [nzPopupClassName],弹出层样式类名
        /// </summary>
        public string BindPopupClassName { get; set; }
        /// <summary>
        /// [nzUse12Hours],是否使用12小时制，为 true 时 format 默认为 h:mm:ss a,默认值: false
        /// </summary>
        public bool Use12Hours { get; set; }
        /// <summary>
        /// [nzUse12Hours],是否使用12小时制，为 true 时 format 默认为 h:mm:ss a,默认值: false
        /// </summary>
        public string BindUse12Hours { get; set; }
        /// <summary>
        /// nzSuffixIcon,后缀图标
        /// </summary>
        public AntDesignIcon SuffixIcon { get; set; }
        /// <summary>
        /// [nzSuffixIcon],后缀图标
        /// </summary>
        public string BindSuffixIcon { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (nzOpenChange),打开关闭面板事件
        /// </summary>
        public string OnOpenChange { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new InputService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TimePickerRender( _config );
        }
    }
}