using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 复选框扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置不确定样式
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="expression">表达式</param>
        public static TComponent Indeterminate<TComponent>( this TComponent component, string expression ) where TComponent : ICheckBox {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Indeterminate, expression );
            } );
            return component;
        }
    }
}
