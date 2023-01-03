using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.DatePickers.Builders {
    /// <summary>
    /// 日期选择标签生成器
    /// </summary>
    public class DatePickerBuilder : FormControlBuilderBase<DatePickerBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化日期选择标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public DatePickerBuilder( Config config ) : base( config, "nz-date-picker" ) {
            _config = config;
        }

        /// <summary>
        /// 配置输入框标识
        /// </summary>
        public DatePickerBuilder InputId() {
            AttributeIfNotEmpty( "nzId", _config.GetValue( UiConst.InputId ) );
            return this;
        }

        /// <summary>
        /// 配置允许清除
        /// </summary>
        public DatePickerBuilder AllowClear() {
            AttributeIfNotEmpty( "[nzAllowClear]", _config.GetBoolValue( UiConst.AllowClear ) );
            AttributeIfNotEmpty( "[nzAllowClear]", _config.GetValue( AngularConst.BindAllowClear ) );
            return this;
        }

        /// <summary>
        /// 配置自动聚焦
        /// </summary>
        public DatePickerBuilder AutoFocus() {
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( AngularConst.BindAutoFocus ) );
            return this;
        }

        /// <summary>
        /// 配置默认面板日期
        /// </summary>
        public DatePickerBuilder DefaultPickerValue() {
            AttributeIfNotEmpty( "nzDefaultPickerValue", _config.GetValue( UiConst.DefaultPickerValue ) );
            AttributeIfNotEmpty( "[nzDefaultPickerValue]", _config.GetValue( AngularConst.BindDefaultPickerValue ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public DatePickerBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置不可选择日期函数
        /// </summary>
        public DatePickerBuilder DisabledDate() {
            AttributeIfNotEmpty( "[nzDisabledDate]", _config.GetValue( UiConst.DisabledDate ) );
            return this;
        }

        /// <summary>
        /// 配置不可选择时间函数
        /// </summary>
        public DatePickerBuilder DisabledTime() {
            AttributeIfNotEmpty( "[nzDisabledTime]", _config.GetValue( UiConst.DisabledTime ) );
            return this;
        }

        /// <summary>
        /// 配置弹出日历样式类名
        /// </summary>
        public DatePickerBuilder DropdownClassName() {
            AttributeIfNotEmpty( "nzDropdownClassName", _config.GetValue( UiConst.DropdownClassName ) );
            AttributeIfNotEmpty( "[nzDropdownClassName]", _config.GetValue( AngularConst.BindDropdownClassName ) );
            return this;
        }

        /// <summary>
        /// 配置弹出日历样式
        /// </summary>
        public DatePickerBuilder PopupStyle() {
            AttributeIfNotEmpty( "nzPopupStyle", _config.GetValue( UiConst.PopupStyle ) );
            AttributeIfNotEmpty( "[nzPopupStyle]", _config.GetValue( AngularConst.BindPopupStyle ) );
            return this;
        }

        /// <summary>
        /// 配置日期格式
        /// </summary>
        public DatePickerBuilder Format() {
            AttributeIfNotEmpty( "nzFormat", _config.GetValue( UiConst.Format ) );
            AttributeIfNotEmpty( "[nzFormat]", _config.GetValue( AngularConst.BindFormat ) );
            return this;
        }

        /// <summary>
        /// 配置只读
        /// </summary>
        public DatePickerBuilder InputReadonly() {
            AttributeIfNotEmpty( "[nzInputReadOnly]", _config.GetBoolValue( UiConst.InputReadonly ) );
            AttributeIfNotEmpty( "[nzInputReadOnly]", _config.GetValue( AngularConst.BindInputReadonly ) );
            return this;
        }

        /// <summary>
        /// 配置国际化
        /// </summary>
        public DatePickerBuilder Locale() {
            AttributeIfNotEmpty( "[nzLocale]", _config.GetValue( UiConst.Locale ) );
            return this;
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        public DatePickerBuilder Mode() {
            AttributeIfNotEmpty( "nzMode", _config.GetValue<DatePickerMode?>( UiConst.Mode )?.Description() );
            AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
            return this;
        }

        /// <summary>
        /// 配置占位提示
        /// </summary>
        public DatePickerBuilder Placeholder() {
            AttributeIfNotEmpty( "nzPlaceHolder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[nzPlaceHolder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置额外页脚
        /// </summary>
        public DatePickerBuilder RenderExtraFooter() {
            AttributeIfNotEmpty( "nzRenderExtraFooter", _config.GetValue( UiConst.RenderExtraFooter ) );
            AttributeIfNotEmpty( "[nzRenderExtraFooter]", _config.GetValue( AngularConst.BindRenderExtraFooter ) );
            return this;
        }

        /// <summary>
        /// 配置输入框大小
        /// </summary>
        public DatePickerBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置后缀图标
        /// </summary>
        public DatePickerBuilder SuffixIcon() {
            AttributeIfNotEmpty( "nzSuffixIcon", _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon )?.Description() );
            AttributeIfNotEmpty( "[nzSuffixIcon]", _config.GetValue( AngularConst.BindSuffixIcon ) );
            return this;
        }

        /// <summary>
        /// 配置移除边框
        /// </summary>
        public DatePickerBuilder Borderless() {
            AttributeIfNotEmpty( "[nzBorderless]", _config.GetBoolValue( UiConst.Borderless ) );
            AttributeIfNotEmpty( "[nzBorderless]", _config.GetValue( AngularConst.BindBorderless ) );
            return this;
        }

        /// <summary>
        /// 配置自定义日期单元格内容
        /// </summary>
        public DatePickerBuilder DateRender() {
            AttributeIfNotEmpty( "[nzDateRender]", _config.GetValue( UiConst.DateRender ) );
            return this;
        }

        /// <summary>
        /// 配置显示时间选择
        /// </summary>
        public DatePickerBuilder ShowTime() {
            AttributeIfNotEmpty( "[nzShowTime]", _config.GetBoolValue( UiConst.ShowTime ) );
            AttributeIfNotEmpty( "[nzShowTime]", _config.GetValue( AngularConst.BindShowTime ) );
            return this;
        }

        /// <summary>
        /// 配置显示“今天”按钮
        /// </summary>
        public DatePickerBuilder ShowToday() {
            AttributeIfNotEmpty( "[nzShowToday]", _config.GetBoolValue( UiConst.ShowToday ) );
            AttributeIfNotEmpty( "[nzShowToday]", _config.GetValue( AngularConst.BindShowToday ) );
            return this;
        }

        /// <summary>
        /// 配置显示“此刻”按钮
        /// </summary>
        public DatePickerBuilder ShowNow() {
            AttributeIfNotEmpty( "[nzShowNow]", _config.GetBoolValue( UiConst.ShowNow ) );
            AttributeIfNotEmpty( "[nzShowNow]", _config.GetValue( AngularConst.BindShowNow ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public DatePickerBuilder Events() {
            AttributeIfNotEmpty( "(nzOnOpenChange)", _config.GetValue( UiConst.OnOpenChange ) );
            AttributeIfNotEmpty( "(nzOnOk)", _config.GetValue( UiConst.OnOk ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().InputId().AllowClear().AutoFocus().DefaultPickerValue()
                .Disabled().DisabledDate().DisabledTime()
                .DropdownClassName().PopupStyle().Format().InputReadonly().Locale().Mode()
                .Placeholder().RenderExtraFooter().Size().SuffixIcon().Borderless().DateRender()
                .ShowTime().ShowToday().ShowNow().Events();
        }
    }
}