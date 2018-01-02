using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Operations.Forms;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 表单扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置占位符
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">占位提示文本</param>
        /// <param name="position">占位提示浮动位置</param>
        public static TComponent Placeholder<TComponent>( this TComponent component, string text,FloatPlaceholder? position ) where TComponent : IComponent, IPlaceholder {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Placeholder, text );
                if( position != null )
                    config.SetAttribute( MaterialConst.FloatPlaceholder,position.Description() );
            } );
            return component;
        }

        /// <summary>
        /// 启用重置项，重置项显示在列表的第一行，用于清空当前选择的值
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">重置项文本</param>
        public static TComponent EnableResetOption<TComponent>( this TComponent component, string text ) where TComponent : IComponent, IResetOption {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.EnableResetOption, true );
                config.SetAttribute( MaterialConst.ResetOptionText, text );
            } );
            return component;
        }

        /// <summary>
        /// 启用重置项，重置项显示在列表的第一行，用于清空当前选择的值
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="enabled">是否启用</param>
        public static TComponent EnableResetOption<TComponent>( this TComponent component, bool enabled ) where TComponent : IComponent, IResetOption {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.EnableResetOption, enabled );
            } );
            return component;
        }

        /// <summary>
        /// 启用多选
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Multiple<TComponent>( this TComponent component ) where TComponent : IComponent, IMultiple {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Multiple, true );
            } );
            return component;
        }
    }
}
