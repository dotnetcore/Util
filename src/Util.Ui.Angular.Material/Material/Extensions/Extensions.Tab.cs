using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Tabs;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 选项卡扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置为动态高度
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent DynamicHeight<TComponent>( this TComponent component ) where TComponent : ITabGroup {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.DynamicHeight, true );
            } );
            return component;
        }

        /// <summary>
        /// 拉伸选项卡
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Stretch<TComponent>( this TComponent component ) where TComponent : ITabGroup {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Stretch, true );
            } );
            return component;
        }

        /// <summary>
        /// 选中指定索引的选项卡
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="expression">索引表达式</param>
        public static TComponent Select<TComponent>( this TComponent component, string expression ) where TComponent : ITabGroup {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.SelectedIndex, expression );
            } );
            return component;
        }

        /// <summary>
        /// 设置选项卡位置
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="position">选项卡位置</param>
        public static TComponent HeaderPosition<TComponent>( this TComponent component, YPosition position ) where TComponent : ITabGroup {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.HeaderPosition, position );
            } );
            return component;
        }

        /// <summary>
        /// 延迟加载
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent LazyLoad<TComponent>( this TComponent component ) where TComponent : ITab {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.LazyLoad, true );
            } );
            return component;
        }
    }
}
