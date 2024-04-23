using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Typographies.Builders; 

/// <summary>
/// div生成器
/// </summary>
public class DivBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化div生成器
    /// </summary>
    /// <param name="config">配置</param>
    public DivBuilder( Config config ) : base( config, "div" ) {
        _config = config;
    }
}