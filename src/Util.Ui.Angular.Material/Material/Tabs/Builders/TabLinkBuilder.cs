using Util.Helpers;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Material.Tabs.Builders {
    /// <summary>
    /// Material链接选项卡生成器
    /// </summary>
    public class TabLinkBuilder : TagBuilder {
        /// <summary>
        /// 初始化链接选项卡生成器
        /// </summary>
        public TabLinkBuilder() : base( "a" ) {
            AddAttribute( "mat-tab-link" ).AddAttribute( "routerLinkActive" );
        }

        /// <summary>
        /// 配置路由链接
        /// </summary>
        /// <param name="config">配置</param>
        public void ConfigRouterLink( IConfig config ) {
            var id = config.GetValue( UiConst.Id );
            if( string.IsNullOrWhiteSpace( id ) )
                id = $"{Id.Guid()}";
            id = $"m_{id}";
            AddAttribute( $"#{id}", "routerLinkActive" );
            AddAttribute( "[active]", $"{id}.isActive" );
        }
    }
}