using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.SideNavs.Builders;

namespace Util.Ui.Material.SideNavs.Renders {
    /// <summary>
    /// 侧边栏导航渲染器
    /// </summary>
    public class DrawerRender : SideNavRender {
        /// <summary>
        /// 初始化侧边栏导航渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DrawerRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DrawerBuilder();
            Config( builder );
            return builder;
        }
    }
}