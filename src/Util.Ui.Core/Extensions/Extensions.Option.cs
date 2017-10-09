using System;
using Util.Ui.Components;
using Util.Ui.Configs;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 基础组件扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置标识
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="id">组件标识</param>
        public static TComponent Id<TComponent>( this TComponent component, string id ) where TComponent : IOption {
            component.CheckNull( nameof( component ) );
            component.Config<IConfig>( config => {
                config.Id = id;
            } );
            return component;
        }
    }
}
