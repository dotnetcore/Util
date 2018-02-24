using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.SideNavs.Builders;

namespace Util.Ui.Material.SideNavs.Renders {
    /// <summary>
    /// 侧边栏导航内容渲染器
    /// </summary>
    public class DrawerContentRender : SideNavContentRender {
        /// <summary>
        /// 初始化侧边栏导航内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DrawerContentRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DrawerContentBuilder();
            Config( builder );
            return builder;
        }
    }
}