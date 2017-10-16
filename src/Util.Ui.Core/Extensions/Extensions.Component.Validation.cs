using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations.Forms.Validations;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 验证
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 必填项
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="message">错误消息</param>
        public static TComponent Required<TComponent>( this TComponent component, string message = "" ) where TComponent : IComponent, IRequired {
            if( !( component is IOptionConfig option ) )
                return component;
            option.Config<Config>( config => {
                config.Required = true;
                config.RequiredMessage = message;
            } );
            return component;
        }

        /// <summary>
        /// 最小长度
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="minLength">最小长度</param>
        /// <param name="message">错误消息</param>
        public static TComponent MinLength<TComponent>( this TComponent component, int minLength, string message = "" ) where TComponent : IComponent, IMinLength {
            if( !( component is IOptionConfig option ) )
                return component;
            option.Config<Config>( config => {
                config.MinLength = minLength;
                config.MinLengthMessage = message;
            } );
            return component;
        }
    }
}
