using Util.Ui.Components.Internal;

namespace Util.Ui.Material.Tabs.Wrappers {
    /// <summary>
    /// 导航选项卡包装器
    /// </summary>
    public class TabNavWrapper : ITabNavWrapper {
        /// <summary>
        /// 导航选项卡
        /// </summary>
        private readonly TabNav _container;

        /// <summary>
        /// 初始化导航选项卡包装器
        /// </summary>
        /// <param name="tabs">导航选项卡</param>
        public TabNavWrapper( TabNav tabs ) {
            _container = tabs;
        }

        /// <summary>
        ///  渲染结束
        /// </summary>
        public void Dispose() {
            if( _container is IRenderEnd container )
                container.End();
        }

        /// <summary>
        /// 选项卡
        /// </summary>
        public ITabLink Tab() {
            return new TabLink();
        }
    }
}