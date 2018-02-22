using Util.Ui.Builders;

namespace Util.Ui.Material.Tabs.Builders {
    /// <summary>
    /// Material导航选项卡生成器
    /// </summary>
    public class TabNavigationBuilder : TagBuilder {
        /// <summary>
        /// 初始化导航选项卡生成器
        /// </summary>
        public TabNavigationBuilder() : base( "nav" ) {
            AddAttribute( "mat-tab-nav-bar" );
        }
    }
}