using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgAlain.Components.Sg.Builders;

/// <summary>
/// 简易栅格列标签生成器
/// </summary>
public class SgBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 初始化简易栅格列标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SgBuilder( Config config ) : base( config, "sg" ) {
        _config = config;
    }

    /// <summary>
    /// 配置列跨度
    /// </summary>
    public SgBuilder Span() {
        AttributeIfNotEmpty( "[col]", _config.GetValue( UiConst.Span ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Span();
    }
}