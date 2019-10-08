using System.IO;
using Util.Ui.Components;
using Util.Ui.Material.Tabs.Renders;
using Util.Ui.Material.Tabs.Wrappers;
using Util.Ui.Renders;

namespace Util.Ui.Material.Tabs {
    /// <summary>
    /// 选项卡组
    /// </summary>
    public class TabGroup : ContainerBase<ITabGroupWrapper>, ITabGroup {
        /// <summary>
        /// 初始化选项卡组
        /// </summary>
        /// <param name="writer">流写入器</param>
        public TabGroup( TextWriter writer ) : base( writer ) {
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TabGroupRender( OptionConfig );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override ITabGroupWrapper GetWrapper() {
            return new TabGroupWrapper( this );
        }
    }
}