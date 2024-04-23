using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Segments.Builders;

/// <summary>
/// 分段控制器标签生成器
/// </summary>
public class SegmentedBuilder : FormControlBuilderBase<SegmentedBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 标识
    /// </summary>
    private string _id;

    /// <summary>
    /// 初始化分段控制器标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SegmentedBuilder( Config config ) : base( config, "nz-segmented" ) {
        _config = config;
    }

    /// <summary>
    /// 扩展标识
    /// </summary>
    protected string ExtendId => $"x_{GetId()}";

    /// <summary>
    /// 获取标识
    /// </summary>
    private string GetId() {
        if ( _id.IsEmpty() == false )
            return _id;
        _id = _config.GetValue( UiConst.Id );
        if ( _id.IsEmpty() )
            _id = Util.Helpers.Id.Create();
        return _id;
    }

    /// <summary>
    /// 配置将宽度调整为父元素宽度
    /// </summary>
    public SegmentedBuilder Block() {
        AttributeIfNotEmpty( "[nzBlock]", _config.GetValue( UiConst.Block ) );
        return this;
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public SegmentedBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置选择框大小
    /// </summary>
    public SegmentedBuilder Size() {
        AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置选项列表
    /// </summary>
    public SegmentedBuilder Options() {
        AttributeIfNotEmpty( "[nzOptions]", _config.GetValue( UiConst.Options ) );
        return this;
    }

    /// <summary>
    /// 配置自动加载
    /// </summary>
    private SegmentedBuilder AutoLoad() {
        AttributeIfNotEmpty( "[autoLoad]", _config.GetValue( UiConst.AutoLoad ) );
        return this;
    }

    /// <summary>
    /// 配置查询参数
    /// </summary>
    private SegmentedBuilder QueryParam() {
        AttributeIfNotEmpty( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
        return this;
    }

    /// <summary>
    /// 配置Api地址
    /// </summary>
    private SegmentedBuilder Url() {
        AttributeIfNotEmpty( "url", _config.GetValue( UiConst.Url ) );
        AttributeIfNotEmpty( "[url]", _config.GetValue( AngularConst.BindUrl ) );
        return this;
    }

    /// <summary>
    /// 配置数据源
    /// </summary>
    private SegmentedBuilder Data() {
        AttributeIfNotEmpty( "[data]", _config.GetValue( UiConst.Data ) );
        return this;
    }

    /// <summary>
    /// 配置值绑定
    /// </summary>
    private SegmentedBuilder Value() {
        AttributeIfNotEmpty( "[(value)]", _config.GetValue( UiConst.Value ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public SegmentedBuilder Events() {
        AttributeIfNotEmpty( "(valueChange)", _config.GetValue( UiConst.OnValueChange ) );
        AttributeIfNotEmpty( "(onLoad)", _config.GetValue( UiConst.OnLoad ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        ConfigForm().Name()
            .Block().Disabled().Size()
            .Options().AutoLoad().QueryParam()
            .Url().Data().Value()
            .Events();
        EnableExtend();
    }

    /// <summary>
    /// 启用扩展
    /// </summary>
    public SegmentedBuilder EnableExtend() {
        if ( IsEnableExtend() == false )
            return this;
        Attribute( $"#{ExtendId}", "xSegmentedExtend" );
        Attribute( "x-segmented-extend" );
        Attribute( "[nzOptions]", $"{ExtendId}.options" );
        Attribute( "[(ngModel)]", $"{ExtendId}.index", true );
        Attribute( "(nzValueChange)", $"{ExtendId}.handleValueChange($event)" );
        return this;
    }

    /// <summary>
    /// 是否启用基础扩展
    /// </summary>
    public bool IsEnableExtend() {
        if ( GetEnableExtend() == false ) {
            return false;
        }
        return GetEnableExtend() == true ||
               GetUrl().IsEmpty() == false ||
               GetBindUrl().IsEmpty() == false ||
               GetData().IsEmpty() == false;
    }

    /// <summary>
    /// 获取启用扩展属性
    /// </summary>
    private bool? GetEnableExtend() {
        return _config.GetValue<bool?>( UiConst.EnableExtend );
    }

    /// <summary>
    /// 获取地址
    /// </summary>
    private string GetUrl() {
        return _config.GetValue( UiConst.Url );
    }

    /// <summary>
    /// 获取地址
    /// </summary>
    private string GetBindUrl() {
        return _config.GetValue( AngularConst.BindUrl );
    }

    /// <summary>
    /// 获取数据源
    /// </summary>
    private string GetData() {
        return _config.GetValue( UiConst.Data );
    }
}