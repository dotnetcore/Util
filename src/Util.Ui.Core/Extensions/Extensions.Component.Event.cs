using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations.Events;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 事件
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 单击事件
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">单击事件处理函数，范例：fun()</param>
        public static TComponent OnClick<TComponent>( this TComponent component, string handler ) where TComponent : IComponent,IOnClick {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnClick,handler );
            } );
            return component;
        }
    }
}
