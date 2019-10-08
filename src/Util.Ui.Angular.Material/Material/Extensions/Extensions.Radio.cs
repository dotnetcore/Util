using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 单选框扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置标签
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="showLabel">是否显示标签</param>
        public static TComponent Label<TComponent>( this TComponent component, bool showLabel ) where TComponent : IRadio {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.ShowLabel, showLabel );
            } );
            return component;
        }

        /// <summary>
        /// 垂直布局
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Vertical<TComponent>( this TComponent component ) where TComponent : IRadio {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Vertical, true );
            } );
            return component;
        }
    }
}
