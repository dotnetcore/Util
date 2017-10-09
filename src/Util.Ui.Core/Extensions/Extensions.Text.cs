using System;
using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Operations;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 文本操作
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置文本
        /// </summary>
        /// <typeparam name="TComponent">标题组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">标题文本</param>
        public static TComponent Text<TComponent>( this TComponent component, string text ) where TComponent : IComponent, IText {
            component.CheckNull( nameof( component ) );
            component.Config<IConfig>( config => {
                config.Text = text;
            } );
            return component;
        }
    }
}
