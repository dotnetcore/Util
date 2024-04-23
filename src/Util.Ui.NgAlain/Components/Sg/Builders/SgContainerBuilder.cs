using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgAlain.Components.Sg.Builders;

/// <summary>
/// 简易栅格容器标签生成器
/// </summary>
public class SgContainerBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 初始化简易栅格容器标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SgContainerBuilder( Config config ) : base( config, "div" ) {
        _config = config;
        base.Attribute( "sg-container" );
    }

    /// <summary>
    /// 配置间距
    /// </summary>
    public SgContainerBuilder Gutter() {
        AttributeIfNotEmpty( "[gutter]", _config.GetValue( UiConst.Gutter ) );
        return this;
    }

    /// <summary>
    /// 配置列数
    /// </summary>
    public SgContainerBuilder Column() {
        AttributeIfNotEmpty( "[col]", _config.GetValue( UiConst.Column ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Gutter().Column();
    }
}