using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Operations.Effects;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 图标
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Font Awesome图标
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="icon">图标</param>
        public static TComponent FontAwesome<TComponent>( this TComponent component, FontAwesomeIcon icon ) where TComponent : IIcon {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.FontAwesomeIcon, icon.ToString() );
            } );
            return component;
        }

        /// <summary>
        /// Material图标
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="icon">Material图标</param>
        public static TComponent Material<TComponent>( this TComponent component, MaterialIcon icon ) where TComponent : IComponent, IIcon {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.MaterialIcon, icon.ToString() );
            } );
            return component;
        }

        /// <summary>
        /// 设置图标大小
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="size">图标大小</param>
        public static TComponent Size<TComponent>( this TComponent component, IconSize size ) where TComponent : IIcon {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.IconSize, size.ToString() );
            } );
            return component;
        }

        /// <summary>
        /// 旋转
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="isSpin">是否旋转</param>
        public static TComponent Spin<TComponent>( this TComponent component, bool isSpin = true ) where TComponent : IComponent,ISpin {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Spin, isSpin );
            } );
            return component;
        }
    }
}
