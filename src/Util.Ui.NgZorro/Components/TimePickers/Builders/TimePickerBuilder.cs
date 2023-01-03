using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.TimePickers.Builders {
    /// <summary>
    /// 时间选择标签生成器
    /// </summary>
    public class TimePickerBuilder : FormControlBuilderBase<TimePickerBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化时间选择标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TimePickerBuilder( Config config ) : base( config, "nz-time-picker" ) {
            _config = config;
        }

        /// <summary>
        /// 配置底部自定义内容
        /// </summary>
        public TimePickerBuilder AddOn() {
            AttributeIfNotEmpty( "[nzAddOn]", _config.GetValue( UiConst.AddOn ) );
            return this;
        }

        /// <summary>
        /// 配置允许清除
        /// </summary>
        public TimePickerBuilder AllowEmpty() {
            AttributeIfNotEmpty( "[nzAllowEmpty]", _config.GetBoolValue( UiConst.AllowEmpty ) );
            AttributeIfNotEmpty( "[nzAllowEmpty]", _config.GetValue( AngularConst.BindAllowEmpty ) );
            return this;
        }

        /// <summary>
        /// 配置清除按钮显示文本
        /// </summary>
        public TimePickerBuilder ClearText() {
            AttributeIfNotEmpty( "nzClearText", _config.GetValue( UiConst.ClearText ) );
            AttributeIfNotEmpty( "[nzClearText]", _config.GetValue( AngularConst.BindClearText ) );
            return this;
        }

        /// <summary>
        /// 配置自动聚焦
        /// </summary>
        public TimePickerBuilder AutoFocus() {
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( AngularConst.BindAutoFocus ) );
            return this;
        }

        /// <summary>
        /// 配置默认值
        /// </summary>
        public TimePickerBuilder DefaultOpenValue() {
            AttributeIfNotEmpty( "nzDefaultOpenValue", _config.GetValue( UiConst.DefaultOpenValue ) );
            AttributeIfNotEmpty( "[nzDefaultOpenValue]", _config.GetValue( AngularConst.BindDefaultOpenValue ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public TimePickerBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置不可选择小时函数
        /// </summary>
        public TimePickerBuilder DisabledHours() {
            AttributeIfNotEmpty( "[nzDisabledHours]", _config.GetValue( UiConst.DisabledHours ) );
            return this;
        }

        /// <summary>
        /// 配置不可选择分钟函数
        /// </summary>
        public TimePickerBuilder DisabledMinutes() {
            AttributeIfNotEmpty( "[nzDisabledMinutes]", _config.GetValue( UiConst.DisabledMinutes ) );
            return this;
        }

        /// <summary>
        /// 配置不可选择秒函数
        /// </summary>
        public TimePickerBuilder DisabledSeconds() {
            AttributeIfNotEmpty( "[nzDisabledSeconds]", _config.GetValue( UiConst.DisabledSeconds ) );
            return this;
        }

        /// <summary>
        /// 配置时间格式
        /// </summary>
        public TimePickerBuilder Format() {
            AttributeIfNotEmpty( "nzFormat", _config.GetValue( UiConst.Format ) );
            AttributeIfNotEmpty( "[nzFormat]", _config.GetValue( AngularConst.BindFormat ) );
            return this;
        }

        /// <summary>
        /// 配置隐藏禁止选择的选项
        /// </summary>
        public TimePickerBuilder HideDisabledOptions() {
            AttributeIfNotEmpty( "[nzHideDisabledOptions]", _config.GetBoolValue( UiConst.HideDisabledOptions ) );
            AttributeIfNotEmpty( "[nzHideDisabledOptions]", _config.GetValue( AngularConst.BindHideDisabledOptions ) );
            return this;
        }

        /// <summary>
        /// 配置小时选项间隔
        /// </summary>
        public TimePickerBuilder HourStep() {
            AttributeIfNotEmpty( "nzHourStep", _config.GetValue( UiConst.HourStep ) );
            AttributeIfNotEmpty( "[nzHourStep]", _config.GetValue( AngularConst.BindHourStep ) );
            return this;
        }

        /// <summary>
        /// 配置分钟选项间隔
        /// </summary>
        public TimePickerBuilder MinuteStep() {
            AttributeIfNotEmpty( "nzMinuteStep", _config.GetValue( UiConst.MinuteStep ) );
            AttributeIfNotEmpty( "[nzMinuteStep]", _config.GetValue( AngularConst.BindMinuteStep ) );
            return this;
        }

        /// <summary>
        /// 配置秒选项间隔
        /// </summary>
        public TimePickerBuilder SecondStep() {
            AttributeIfNotEmpty( "nzSecondStep", _config.GetValue( UiConst.SecondStep ) );
            AttributeIfNotEmpty( "[nzSecondStep]", _config.GetValue( AngularConst.BindSecondStep ) );
            return this;
        }

        /// <summary>
        /// 配置面板是否打开
        /// </summary>
        public TimePickerBuilder Open() {
            AttributeIfNotEmpty( "[nzOpen]", _config.GetBoolValue( UiConst.Open ) );
            AttributeIfNotEmpty( "[nzOpen]", _config.GetValue( AngularConst.BindOpen ) );
            AttributeIfNotEmpty( "[(nzOpen)]", _config.GetValue( AngularConst.BindonOpen ) );
            return this;
        }

        /// <summary>
        /// 配置占位提示
        /// </summary>
        public TimePickerBuilder Placeholder() {
            AttributeIfNotEmpty( "nzPlaceHolder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[nzPlaceHolder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置弹出层样式类名
        /// </summary>
        public TimePickerBuilder PopupClassName() {
            AttributeIfNotEmpty( "nzPopupClassName", _config.GetValue( UiConst.PopupClassName ) );
            AttributeIfNotEmpty( "[nzPopupClassName]", _config.GetValue( AngularConst.BindPopupClassName ) );
            return this;
        }

        /// <summary>
        /// 配置12小时制
        /// </summary>
        public TimePickerBuilder Use12Hours() {
            AttributeIfNotEmpty( "[nzUse12Hours]", _config.GetBoolValue( UiConst.Use12Hours ) );
            AttributeIfNotEmpty( "[nzUse12Hours]", _config.GetValue( AngularConst.BindUse12Hours ) );
            return this;
        }

        /// <summary>
        /// 配置后缀图标
        /// </summary>
        public TimePickerBuilder SuffixIcon() {
            AttributeIfNotEmpty( "nzSuffixIcon", _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon )?.Description() );
            AttributeIfNotEmpty( "[nzSuffixIcon]", _config.GetValue( AngularConst.BindSuffixIcon ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TimePickerBuilder Events() {
            AttributeIfNotEmpty( "(nzOpenChange)", _config.GetValue( UiConst.OnOpenChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().AddOn().AllowEmpty().AutoFocus().ClearText().DefaultOpenValue()
                .Disabled().DisabledHours().DisabledMinutes().DisabledSeconds()
                .Format().HideDisabledOptions().HourStep().MinuteStep().SecondStep()
                .Open().Placeholder().PopupClassName().Use12Hours().SuffixIcon()
                .Events();
        }
    }
}