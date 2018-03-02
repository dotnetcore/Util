using Util.Ui.Builders;

namespace Util.Ui.Material.Tabs.Builders {
    /// <summary>
    /// Material导航选项卡生成器
    /// </summary>
    public class TabNavBuilder : TagBuilder {
        /// <summary>
        /// 初始化导航选项卡生成器
        /// </summary>
        public TabNavBuilder() : base( "nav" ) {
            AddAttribute( "mat-tab-nav-bar" );
        }
    }
}