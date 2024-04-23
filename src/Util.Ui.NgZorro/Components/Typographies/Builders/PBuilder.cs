using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Typographies.Builders; 

/// <summary>
/// p标签生成器
/// </summary>
public class PBuilder : AngularTagBuilder {
    /// <summary>
    /// 初始化p标签生成器
    /// </summary>
    public PBuilder( Config config ) : base( config,"p" ) {
    }
}