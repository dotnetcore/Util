using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Drawers.Builders;

/// <summary>
/// 抽屉内容标签生成器
/// </summary>
public class DrawerContentBuilder : AngularTagBuilder {
    /// <summary>
    /// 初始化抽屉内容标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public DrawerContentBuilder( Config config ) : base( config, "ng-container" ) {
        base.Attribute( "*nzDrawerContent" );
    }
}