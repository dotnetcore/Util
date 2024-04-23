using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Enums;

namespace Util.Ui.NgAlain.Components.Sv.Builders;

/// <summary>
/// 查看值标签生成器
/// </summary>
public class SvValueBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 初始化查看值标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SvValueBuilder( Config config ) : base( config, "sv-value" ) {
        _config = config;
    }

    /// <summary>
    /// 配置前缀
    /// </summary>
    public SvValueBuilder Prefix() {
        AttributeIfNotEmpty( "prefix", _config.GetValue( UiConst.Prefix ) );
        AttributeIfNotEmpty( "[prefix]", _config.GetValue( AngularConst.BindPrefix ) );
        return this;
    }

    /// <summary>
    /// 配置单位
    /// </summary>
    public SvValueBuilder Unit() {
        AttributeIfNotEmpty( "unit", _config.GetValue( UiConst.Unit ) );
        AttributeIfNotEmpty( "[unit]", _config.GetValue( AngularConst.BindUnit ) );
        return this;
    }

    /// <summary>
    /// 配置文字提示
    /// </summary>
    public SvValueBuilder Tooltip() {
        AttributeIfNotEmpty( "tooltip", _config.GetValue( UiConst.Tooltip ) );
        AttributeIfNotEmpty( "[tooltip]", _config.GetValue( AngularConst.BindTooltip ) );
        return this;
    }

    /// <summary>
    /// 配置尺寸
    /// </summary>
    public SvValueBuilder Size() {
        AttributeIfNotEmpty( "size", _config.GetValue<SvValueSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[size]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Prefix().Unit().Tooltip().Size();
    }
}