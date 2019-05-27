using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Enums;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 日期选择框渲染器
    /// </summary>
    public class DatePickerRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 标签生成器
        /// </summary>
        private readonly TagBuilder _builder;

        /// <summary>
        /// 初始化日期选择框渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tagBuilder">标签生成器</param>
        public DatePickerRender( Config config,TagBuilder tagBuilder ) {
            _config = config;
            _builder = tagBuilder;
        }

        /// <summary>
        /// 配置日期选择框
        /// </summary>
        public void ConfigDatePicker() {
            ConfigDatePickerType();
            ConfigStyle();
            ConfigDateFormat();
            ConfigShowTime();
            ConfigShowClearButton();
            ConfigAutoFocus();
            ConfigDisabledDate();
            ConfigLocale();
            ConfigIsOpen();
            ConfigEvents();
        }

        /// <summary>
        /// 配置日期选择器类型
        /// </summary>
        private void ConfigDatePickerType() {
            _builder.AddAttribute( "type", _config.GetValue<DatePickerType?>( UiConst.Type ).Description() );
        }

        /// <summary>
        /// 配置样式
        /// </summary>
        private void ConfigStyle() {
            _builder.AddAttribute( "className", _config.GetValue( UiConst.ClassName ) );
            _builder.AddAttribute( "[dateRender]", _config.GetValue( UiConst.DateRender ) );
        }

        /// <summary>
        /// 配置日期格式化
        /// </summary>
        private void ConfigDateFormat() {
            _builder.AddAttribute( "format", _config.GetValue( UiConst.Format ) );
        }

        /// <summary>
        /// 配置显示时间
        /// </summary>
        private void ConfigShowTime() {
            _builder.AddAttribute( "[showTime]", _config.GetBoolValue( UiConst.ShowTime ) );
            _builder.AddAttribute( "[showToday]", _config.GetBoolValue( UiConst.ShowToday ) );
        }

        /// <summary>
        /// 配置是否显示清除按钮
        /// </summary>
        private void ConfigShowClearButton() {
            _builder.AddAttribute( "[allowClear]", _config.GetBoolValue( UiConst.ShowClearButton ) );
        }

        /// <summary>
        /// 配置自动获取焦点
        /// </summary>
        private void ConfigAutoFocus() {
            _builder.AddAttribute( "[autoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
        }

        /// <summary>
        /// 配置禁用日期
        /// </summary>
        private void ConfigDisabledDate() {
            _builder.AddAttribute( "[disabledDateFunc]", _config.GetValue( UiConst.DisabledDate ) );
            _builder.AddAttribute( "[disabledBeforeToday]", _config.GetBoolValue( UiConst.DisabledBeforeToday ) );
            _builder.AddAttribute( "[disabledBeforeTomorrow]", _config.GetBoolValue( UiConst.DisabledBeforeTomorrow ) );
        }

        /// <summary>
        /// 配置国际化
        /// </summary>
        private void ConfigLocale() {
            _builder.AddAttribute( "[locale]", _config.GetValue( UiConst.Locale ) );
        }

        /// <summary>
        /// 配置打开弹出面板
        /// </summary>
        private void ConfigIsOpen() {
            _builder.AddAttribute( "[isOpen]", _config.GetValue( UiConst.IsOpen ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents() {
            _builder.AddAttribute( "(onOpenChange)", _config.GetValue( UiConst.OnOpenChange ) );
        }
    }
}
