using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Containers.Builders; 

/// <summary>
/// router-outlet标签生成器
/// </summary>
public class RouterOutletBuilder : AngularTagBuilder {
    /// <summary>
    /// 初始化router-outlet标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public RouterOutletBuilder( Config config ) : base( config, "router-outlet" ) {
    }
}