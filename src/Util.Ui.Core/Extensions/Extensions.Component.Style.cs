using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations.Styles;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 样式
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置为扁平风格
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="isPlain">是否启用扁平风格</param>
        public static TComponent Plain<TComponent>( this TComponent component, bool isPlain = true ) where TComponent : IComponent,IPlain {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.Attributes.SetAttribute( new TagHelperAttribute( UiConst.Plain, isPlain.SafeString() ) );
            } );
            return component;
        }
    }
}
