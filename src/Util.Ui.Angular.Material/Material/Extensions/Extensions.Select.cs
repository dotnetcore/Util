using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations.Datas;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 下拉列表扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 显示模板，值用{0}表示，范例：当前选中：{0} ,显示为 当前选中：1,2,3
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="template">模板</param>
        public static TComponent Template<TComponent>( this TComponent component, string template ) where TComponent : ISelect {
            var option = component as IOptionConfig;
            option?.Config<SelectConfig>( config => {
                config.SetAttribute( UiConst.Template, template );
            } );
            return component;
        }

        /// <summary>
        /// 添加项
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <param name="group">组</param>
        public static TComponent Add<TComponent>( this TComponent component, string text, object value,string group = null ) where TComponent : IItem {
            var option = component as IOptionConfig;
            option?.Config<SelectConfig>( config => {
                config.AddItems( new Item( text, value, null, group ) );
            } );
            return component;
        }

        /// <summary>
        /// 添加项
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="items">列表项集合</param>
        public static TComponent Add<TComponent>( this TComponent component, params Item[] items ) where TComponent : IItem {
            var option = component as IOptionConfig;
            option?.Config<SelectConfig>( config => {
                if ( items == null )
                    return;
                config.AddItems( items );
            } );
            return component;
        }

        /// <summary>
        /// 绑定bool
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Bool<TComponent>( this TComponent component ) where TComponent : IItem {
            return component.Add( "是", true ).Add( "否", false );
        }
    }
}
