using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Operations.Styles;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 样式扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="color">颜色</param>
        public static TComponent Color<TComponent>( this TComponent component,Color color ) where TComponent : IOption, IColor {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Color, color.ToString().ToLower() );
            } );
            return component;
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="color">颜色</param>
        public static TComponent BackgroundColor<TComponent>( this TComponent component, Color color ) where TComponent : IOption, IBackgroundColor {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.BackgroundColor, color.ToString().ToLower() );
            } );
            return component;
        }
    }
}
