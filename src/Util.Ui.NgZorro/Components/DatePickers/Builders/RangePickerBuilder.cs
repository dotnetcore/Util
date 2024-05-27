using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;
using Config = Util.Ui.Configs.Config;

namespace Util.Ui.NgZorro.Components.DatePickers.Builders;

/// <summary>
/// 日期范围选择标签生成器
/// </summary>
public class RangePickerBuilder : FormControlBuilderBase<RangePickerBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 标识
    /// </summary>
    private string _id;

    /// <summary>
    /// 初始化日期范围选择标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public RangePickerBuilder( Config config ) : base( config, "nz-range-picker" ) {
        _config = config;
    }

    /// <summary>
    /// 配置输入框标识
    /// </summary>
    public RangePickerBuilder NzId() {
        AttributeIfNotEmpty( "nzId", _config.GetValue( UiConst.NzId ) );
        AttributeIfNotEmpty( "[nzId]", _config.GetValue( AngularConst.BindNzId ) );
        return this;
    }

    /// <summary>
    /// 配置允许清除
    /// </summary>
    public RangePickerBuilder AllowClear() {
        AttributeIfNotEmpty( "[nzAllowClear]", _config.GetValue( UiConst.AllowClear ) );
        return this;
    }

    /// <summary>
    /// 配置自动聚焦
    /// </summary>
    public RangePickerBuilder AutoFocus() {
        AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( UiConst.AutoFocus ) );
        return this;
    }

    /// <summary>
    /// 配置浮层是否应带有背景板
    /// </summary>
    public RangePickerBuilder Backdrop() {
        AttributeIfNotEmpty( "[nzBackdrop]", _config.GetValue( UiConst.Backdrop ) );
        return this;
    }

    /// <summary>
    /// 配置默认面板日期
    /// </summary>
    public RangePickerBuilder DefaultPickerValue() {
        AttributeIfNotEmpty( "nzDefaultPickerValue", _config.GetValue( UiConst.DefaultPickerValue ) );
        AttributeIfNotEmpty( "[nzDefaultPickerValue]", _config.GetValue( AngularConst.BindDefaultPickerValue ) );
        return this;
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public RangePickerBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置不可选择日期函数
    /// </summary>
    public RangePickerBuilder DisabledDate() {
        AttributeIfNotEmpty( "[nzDisabledDate]", _config.GetValue( UiConst.DisabledDate ) );
        return this;
    }

    /// <summary>
    /// 配置不可选择时间函数
    /// </summary>
    public RangePickerBuilder DisabledTime() {
        AttributeIfNotEmpty( "[nzDisabledTime]", _config.GetValue( UiConst.DisabledTime ) );
        return this;
    }

    /// <summary>
    /// 配置弹出日历样式类名
    /// </summary>
    public RangePickerBuilder DropdownClassName() {
        AttributeIfNotEmpty( "nzDropdownClassName", _config.GetValue( UiConst.DropdownClassName ) );
        AttributeIfNotEmpty( "[nzDropdownClassName]", _config.GetValue( AngularConst.BindDropdownClassName ) );
        return this;
    }

    /// <summary>
    /// 配置弹出日历样式
    /// </summary>
    public RangePickerBuilder PopupStyle() {
        AttributeIfNotEmpty( "[nzPopupStyle]", _config.GetValue( UiConst.PopupStyle ) );
        return this;
    }

    /// <summary>
    /// 配置日期格式
    /// </summary>
    public RangePickerBuilder Format() {
        AttributeIfNotEmpty( "nzFormat", _config.GetValue( UiConst.Format ) );
        AttributeIfNotEmpty( "[nzFormat]", _config.GetValue( AngularConst.BindFormat ) );
        return this;
    }

    /// <summary>
    /// 配置只读
    /// </summary>
    public RangePickerBuilder InputReadonly() {
        AttributeIfNotEmpty( "[nzInputReadOnly]", _config.GetValue( UiConst.InputReadonly ) );
        return this;
    }

    /// <summary>
    /// 配置国际化
    /// </summary>
    public RangePickerBuilder Locale() {
        AttributeIfNotEmpty( "[nzLocale]", _config.GetValue( UiConst.Locale ) );
        return this;
    }

    /// <summary>
    /// 配置模式
    /// </summary>
    public RangePickerBuilder Mode() {
        AttributeIfNotEmpty( "nzMode", _config.GetValue<DatePickerMode?>( UiConst.Mode )?.Description() );
        AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
        return this;
    }

    /// <summary>
    /// 配置占位提示
    /// </summary>
    public RangePickerBuilder Placeholder() {
        AttributeIfNotEmpty( "nzPlaceHolder", _config.GetValue( UiConst.Placeholder ) );
        AttributeIfNotEmpty( "[nzPlaceHolder]", _config.GetValue( AngularConst.BindPlaceholder ) );
        return this;
    }

    /// <summary>
    /// 配置额外页脚
    /// </summary>
    public RangePickerBuilder RenderExtraFooter() {
        AttributeIfNotEmpty( "nzRenderExtraFooter", _config.GetValue( UiConst.RenderExtraFooter ) );
        AttributeIfNotEmpty( "[nzRenderExtraFooter]", _config.GetValue( AngularConst.BindRenderExtraFooter ) );
        return this;
    }

    /// <summary>
    /// 配置自定义日期单元格内容
    /// </summary>
    public RangePickerBuilder DateRender() {
        AttributeIfNotEmpty( "[nzDateRender]", _config.GetValue( UiConst.DateRender ) );
        return this;
    }

    /// <summary>
    /// 配置输入框大小
    /// </summary>
    public RangePickerBuilder Size() {
        AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置后缀图标
    /// </summary>
    public RangePickerBuilder SuffixIcon() {
        AttributeIfNotEmpty( "nzSuffixIcon", _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon )?.Description() );
        AttributeIfNotEmpty( "[nzSuffixIcon]", _config.GetValue( AngularConst.BindSuffixIcon ) );
        return this;
    }

    /// <summary>
    /// 配置移除边框
    /// </summary>
    public RangePickerBuilder Borderless() {
        AttributeIfNotEmpty( "[nzBorderless]", _config.GetValue( UiConst.Borderless ) );
        return this;
    }

    /// <summary>
    /// 配置内联模式
    /// </summary>
    public RangePickerBuilder Inline() {
        AttributeIfNotEmpty( "[nzInline]", _config.GetValue( UiConst.Inline ) );
        return this;
    }

    /// <summary>
    /// 配置显示周数
    /// </summary>
    public RangePickerBuilder ShowWeekNumber() {
        AttributeIfNotEmpty( "[nzShowWeekNumber]", _config.GetValue( UiConst.ShowWeekNumber ) );
        return this;
    }

    /// <summary>
    /// 配置预设时间范围
    /// </summary>
    public RangePickerBuilder Ranges() {
        AttributeIfNotEmpty( "[nzRanges]", _config.GetValue( UiConst.Ranges ) );
        return this;
    }

    /// <summary>
    /// 配置分隔符
    /// </summary>
    public RangePickerBuilder Separator() {
        AttributeIfNotEmpty( "nzSeparator", _config.GetValue( UiConst.Separator ) );
        AttributeIfNotEmpty( "[nzSeparator]", _config.GetValue( AngularConst.BindSeparator ) );
        return this;
    }

    /// <summary>
    /// 配置显示时间选择
    /// </summary>
    public RangePickerBuilder ShowTime() {
        AttributeIfNotEmpty( "[nzShowTime]", _config.GetValue( UiConst.ShowTime ) );
        return this;
    }

    /// <summary>
    /// 配置校验状态
    /// </summary>
    public RangePickerBuilder Status() {
        AttributeIfNotEmpty( "nzStatus", _config.GetValue<FormControlStatus?>( UiConst.Status )?.Description() );
        AttributeIfNotEmpty( "[nzStatus]", _config.GetValue( AngularConst.BindStatus ) );
        return this;
    }

    /// <summary>
    /// 配置校验状态
    /// </summary>
    public RangePickerBuilder Placement() {
        AttributeIfNotEmpty( "nzPlacement", _config.GetValue<DatePickerPlacement?>( UiConst.Placement )?.Description() );
        AttributeIfNotEmpty( "[nzPlacement]", _config.GetValue( AngularConst.BindPlacement ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public RangePickerBuilder Events() {
        AttributeIfNotEmpty( "(nzOnOpenChange)", _config.GetValue( UiConst.OnOpenChange ) );
        AttributeIfNotEmpty( "(nzOnCalendarChange)", _config.GetValue( UiConst.OnCalendarChange ) );
        AttributeIfNotEmpty( "(nzOnOk)", _config.GetValue( UiConst.OnOk ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        ConfigForm().NzId().Name().AllowClear().AutoFocus()
            .Backdrop().DefaultPickerValue()
            .Disabled().DisabledDate().DisabledTime()
            .DropdownClassName().PopupStyle()
            .Format().InputReadonly().Locale().Mode()
            .Placeholder().RenderExtraFooter().DateRender()
            .Size().SuffixIcon().Borderless().Inline().ShowWeekNumber()
            .Ranges().Separator().ShowTime().Status().Placement()
            .Events();
        EnableExtend();
    }

    /// <summary>
    /// 启用扩展
    /// </summary>
    private void EnableExtend() {
        if ( IsEnableExtend() == false )
            return;
        Attribute( "x-range-picker-extend" );
        Attribute( $"#{ExtendId}", "xRangePickerExtend" );
        Attribute( "[(ngModel)]", $"{ExtendId}.rangeDates", true );
        BeginDate();
        EndDate();
    }

    /// <summary>
    /// 扩展标识
    /// </summary>
    private string ExtendId {
        get {
            if ( _id.IsEmpty() )
                _id = _config.GetValue( UiConst.Id );
            if ( _id.IsEmpty() )
                _id = Id.Create();
            return $"x_{_id}";
        }
    }

    /// <summary>
    /// 是否启用扩展
    /// </summary>
    private bool IsEnableExtend() {
        if ( _config.Contains( UiConst.BeginDate ) )
            return true;
        if ( _config.Contains( UiConst.EndDate ) )
            return true;
        return false;
    }

    /// <summary>
    /// 配置起始日期
    /// </summary>
    private void BeginDate() {
        AttributeIfNotEmpty( "[(beginDate)]", _config.GetValue( UiConst.BeginDate ) );
    }

    /// <summary>
    /// 配置结束日期
    /// </summary>
    private void EndDate() {
        AttributeIfNotEmpty( "[(endDate)]", _config.GetValue( UiConst.EndDate ) );
    }
}