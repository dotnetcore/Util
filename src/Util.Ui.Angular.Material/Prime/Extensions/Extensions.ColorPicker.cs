using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;

namespace Util.Ui.Prime.Extensions {
    /// <summary>
    /// 按钮扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 内联
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Inline<TComponent>( this TComponent component) where TComponent : IColorPicker {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Inline, true );
            } );
            return component;
        }
    }
}
