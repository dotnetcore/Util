using Util.Ui.Components;
using Util.Ui.Configs;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 文本框扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置为密码框
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Password<TComponent>( this TComponent component ) where TComponent : ITextBox {
            component.Config<Config>( config => {
                config.Type = "password";
            } );
            return component;
        }

        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Number<TComponent>( this TComponent component ) where TComponent : ITextBox {
            component.Config<Config>( config => {
                config.Type = "number";
            } );
            return component;
        }
    }
}
