using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgAlain.Components.FooterToolbars.Builders;

/// <summary>
/// 底部工具栏生成器
/// </summary>
public class FooterToolbarBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 初始化底部工具栏生成器
    /// </summary>
    /// <param name="config">配置</param>
    public FooterToolbarBuilder( Config config ) : base( config, "footer-toolbar" ) {
        _config = config;
    }

    /// <summary>
    /// 配置错误收集
    /// </summary>
    public FooterToolbarBuilder ErrorCollect() {
        AttributeIfNotEmpty( "[errorCollect]", _config.GetValue( UiConst.ErrorCollect ) );
        return this;
    }

    /// <summary>
    /// 配置额外信息
    /// </summary>
    public FooterToolbarBuilder Extra() {
        AttributeIfNotEmpty( "extra", _config.GetValue( UiConst.Extra ) );
        AttributeIfNotEmpty( "[extra]", _config.GetValue( AngularConst.BindExtra ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        ErrorCollect().Extra();
    }
}