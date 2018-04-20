using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 表单扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 禁用
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="disabled">禁用表达式</param>
        public static TComponent Disable<TComponent>( this TComponent component, string disabled ) where TComponent : IOption, IDisabled {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Disabled, disabled );
            } );
            return component;
        }

        /// <summary>
        /// 在循环中创建表单组件时使用，设置了ngModel，但无法设置固定的name，可以使用该属性创建控件，这样创建的控件独立于FormGroup
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Standalone<TComponent>( this TComponent component ) where TComponent : IOption, IDisabled {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Standalone, true );
            } );
            return component;
        }
    }
}
