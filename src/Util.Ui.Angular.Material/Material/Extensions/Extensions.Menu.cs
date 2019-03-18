using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Buttons;
using Util.Ui.Material.Buttons.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Menus;
using Util.Ui.Material.Menus.Configs;
using Util.Ui.Material.Menus.Datas;
using Util.Ui.Operations.Navigation;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 菜单扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置菜单位置
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="xPosition">X轴位置</param>
        /// <param name="yPosition">Y轴位置</param>
        public static TComponent Position<TComponent>( this TComponent component, XPosition? xPosition, YPosition? yPosition = null ) where TComponent : IMenu {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.XPosition, xPosition );
                config.SetAttribute( UiConst.YPosition, yPosition );
            } );
            return component;
        }

        /// <summary>
        /// 设置弹出菜单是否与触发按钮重叠
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="isOverlap">是否重叠,false代表不重叠</param>
        public static TComponent Overlap<TComponent>( this TComponent component, bool? isOverlap = false ) where TComponent : IMenu {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Overlap, isOverlap );
            } );
            return component;
        }

        /// <summary>
        /// 设置菜单数据
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="data">菜单数据</param>
        public static TComponent Data<TComponent>( this TComponent component, MenuData data ) where TComponent : IMenu {
            var option = component as IOptionConfig;
            option?.Config<MenuConfig>( config => {
                config.Data = data;
            } );
            return component.Id( data.Id ).Position( data.XPosition, data.YPosition ).Overlap( data.Overlap );
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="nodes">菜单节点集合</param>
        public static TComponent Menu<TComponent>( this TComponent component, MenuNodeCollection nodes ) where TComponent : IButton {
            var option = component as IOptionConfig;
            option?.Config<ButtonConfig>( config => {
                config.Data = nodes.ToMenuDatas();
            } );
            return component.Menu( nodes.RootId );
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="menuId">菜单标识</param>
        public static TComponent Menu<TComponent>( this TComponent component, string menuId ) where TComponent : IMenuId {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.MenuId, menuId );
            } );
            return component;
        }
    }
}
