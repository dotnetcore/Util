using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Calendars.Builders {
    /// <summary>
    /// 日历标签生成器
    /// </summary>
    public class CalendarBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化日历标签生成器
        /// </summary>
        public CalendarBuilder( Config config ) : base( config, "nz-calendar" ) {
            _config = config;
        }

        /// <summary>
        /// 配置显示模式
        /// </summary>
        public CalendarBuilder Mode() {
            AttributeIfNotEmpty( "nzMode", _config.GetValue<CalendarMode?>( UiConst.Mode )?.Description() );
            AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
            AttributeIfNotEmpty( "[(nzMode)]", _config.GetValue( AngularConst.BindonMode ) );
            return this;
        }

        /// <summary>
        /// 配置是否全屏显示
        /// </summary>
        public CalendarBuilder Fullscreen() {
            AttributeIfNotEmpty( "[nzFullscreen]", _config.GetBoolValue( UiConst.Fullscreen ) );
            AttributeIfNotEmpty( "[nzFullscreen]", _config.GetValue( AngularConst.BindFullscreen ) );
            return this;
        }

        /// <summary>
        /// 配置自定义渲染日期单元格模板
        /// </summary>
        public CalendarBuilder DateCell() {
            AttributeIfNotEmpty( "[nzDateCell]", _config.GetValue( UiConst.DateCell ) );
            AttributeIfNotEmpty( "[nzDateFullCell]", _config.GetValue( UiConst.DateFullCell ) );
            return this;
        }

        /// <summary>
        /// 配置自定义渲染月单元格模板
        /// </summary>
        public CalendarBuilder MonthCell() {
            AttributeIfNotEmpty( "[nzMonthCell]", _config.GetValue( UiConst.MonthCell ) );
            AttributeIfNotEmpty( "[nzMonthFullCell]", _config.GetValue( UiConst.MonthFullCell ) );
            return this;
        }

        /// <summary>
        /// 配置不可选择日期函数
        /// </summary>
        public CalendarBuilder DisabledDate() {
            AttributeIfNotEmpty( "[nzDisabledDate]", _config.GetValue( UiConst.DisabledDate ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CalendarBuilder Events() {
            AttributeIfNotEmpty( "(nzPanelChange)", _config.GetValue( UiConst.OnPanelChange ) );
            AttributeIfNotEmpty( "(nzSelectChange)", _config.GetValue( UiConst.OnSelectChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            this.NgModel( _config );
            Mode().Fullscreen().DateCell().MonthCell().DisabledDate().Events();
        }
    }
}