using Util.Ui.Components.Internal;

namespace Util.Ui.Material.Tabs.Wrappers {
    /// <summary>
    /// 选项卡组包装器
    /// </summary>
    public class TabGroupWrapper : ITabGroupWrapper {
        /// <summary>
        /// 选项卡组
        /// </summary>
        private readonly TabGroup _container;

        /// <summary>
        /// 初始化选项卡组包装器
        /// </summary>
        /// <param name="tabs">选项卡组</param>
        public TabGroupWrapper( TabGroup tabs ) {
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
        public ITab Tab() {
            return new Tab( _container.Writer );
        }
    }
}