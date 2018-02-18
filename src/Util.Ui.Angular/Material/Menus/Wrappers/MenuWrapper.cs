using System;
using Util.Ui.Components.Internal;

namespace Util.Ui.Material.Menus.Wrappers {
    /// <summary>
    /// 菜单包装器
    /// </summary>
    public class MenuWrapper : IMenuWrapper {
        /// <summary>
        /// 菜单
        /// </summary>
        private readonly IMenu _container;

        /// <summary>
        /// 初始化菜单包装器
        /// </summary>
        /// <param name="menu">菜单</param>
        public MenuWrapper( IMenu menu ) {
            _container = menu;
        }

        /// <summary>
        ///  渲染结束
        /// </summary>
        public void Dispose() {
            if( !( _container is IRenderEnd container ) )
                throw new NotImplementedException( "容器必须实现Util.Ui.Components.IRenderEnd" );
            container.End();
        }

        /// <summary>
        /// 菜单项
        /// </summary>
        public IMenuItem Item() {
            return new MenuItem();
        }
    }
}