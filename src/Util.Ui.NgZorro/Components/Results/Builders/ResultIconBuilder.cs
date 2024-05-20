using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Results.Builders; 

/// <summary>
/// 结果图标标签生成器
/// </summary>
public class ResultIconBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化结果图标标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public ResultIconBuilder( Config config ) : base( config,"div" ) {
        _config = config;
        base.Attribute( "nz-result-icon" );
    }
}