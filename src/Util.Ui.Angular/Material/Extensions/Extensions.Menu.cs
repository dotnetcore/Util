using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Menus;

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
        public static TComponent Overlap<TComponent>( this TComponent component, bool isOverlap = false ) where TComponent : IMenu {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Overlap, isOverlap );
            } );
            return component;
        }
    }
}
