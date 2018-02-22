using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Operations;
using Util.Ui.Operations.Effects;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 图标
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 图标
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="icon">Font Awesome图标</param>
        public static TComponent Icon<TComponent>( this TComponent component, FontAwesomeIcon? icon ) where TComponent : IOption, ISetIcon {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                if ( icon == null )
                    return;
                config.SetAttribute( UiConst.FontAwesomeIcon, icon );
            } );
            return component;
        }

        /// <summary>
        /// 图标
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="icon">Material图标</param>
        public static TComponent Icon<TComponent>( this TComponent component, MaterialIcon? icon ) where TComponent : IOption, ISetIcon {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                if( icon == null )
                    return;
                config.SetAttribute( UiConst.MaterialIcon, icon );
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
                config.SetAttribute( UiConst.Size, size );
            } );
            return component;
        }

        /// <summary>
        /// 持续旋转
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

        /// <summary>
        /// 旋转
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="type">旋转类型</param>
        public static TComponent Rotate<TComponent>( this TComponent component, RotateType type ) where TComponent : IIcon {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Rotate, type );
            } );
            return component;
        }

        /// <summary>
        /// 子图标
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="childIcon">子图标</param>
        /// <param name="class">子图标class</param>
        public static TComponent Child<TComponent>( this TComponent component, FontAwesomeIcon childIcon,string @class = null ) where TComponent : IIcon {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Child, childIcon.ToString() );
                if( string.IsNullOrWhiteSpace( @class ) == false )
                    config.SetAttribute( UiConst.ChildClass, @class );
            } );
            return component;
        }
    }
}
