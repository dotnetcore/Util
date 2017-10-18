using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations;
using Util.Ui.Operations.Forms;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public static TComponent Attribute<TComponent>( this TComponent component, string name, string value ) where TComponent : IOption {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.OtherAttributes.Add( name, value );
            } );
            return component;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="value">属性值</param>
        public static TComponent Attribute<TComponent>( this TComponent component, string value ) where TComponent : IOption {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.OtherAttributes.Add( value, null );
            } );
            return component;
        }

        /// <summary>
        /// 设置标识
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="id">组件标识</param>
        public static TComponent Id<TComponent>( this TComponent component, string id ) where TComponent : IOption {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.Attributes.Add( Const.Id,id );
            } );
            return component;
        }

        /// <summary>
        /// 设置名称
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="name">组件名称</param>
        public static TComponent Name<TComponent>( this TComponent component, string name ) where TComponent : IOption, IName {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.Name = name;
            } );
            return component;
        }

        /// <summary>
        /// 设置文本
        /// </summary>
        /// <typeparam name="TComponent">标题组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">标题文本</param>
        public static TComponent Text<TComponent>( this TComponent component, string text ) where TComponent : IComponent, IText {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( Const.Text, text );
            } );
            return component;
        }

        /// <summary>
        /// 设置占位符
        /// </summary>
        /// <typeparam name="TComponent">标题组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        public static TComponent Placeholder<TComponent>( this TComponent component, string text ) where TComponent : IComponent, IPlaceholder {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.Placeholder = text;
            } );
            return component;
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="TComponent">标题组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="value">值</param>
        public static TComponent Value<TComponent>( this TComponent component, string value ) where TComponent : IComponent, IValue {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.Value = value;
            } );
            return component;
        }
    }
}
