using Util.Ui.NgZorro.Components.Flex.Builders;

namespace Util.Ui.NgZorro.Components.Drawers.Builders; 

/// <summary>
/// 抽屉页脚标签生成器
/// </summary>
public class DrawerFooterBuilder : FlexBuilder {
    /// <summary>
    /// 初始化抽屉页脚标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public DrawerFooterBuilder( Config config ) : base( config ) {
        base.Attribute( "*xDrawerFooter" );
    }
}