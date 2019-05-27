using Util.Ui.Angular;
using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Enums;
using Util.Ui.Operations;
using Util.Ui.Operations.Forms;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 表单扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置占位提示符
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">占位提示文本</param>
        /// <param name="type">占位符浮动类型</param>
        public static TComponent Placeholder<TComponent>( this TComponent component, string text, FloatType? type ) where TComponent : IComponent, IPlaceholder {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Placeholder, text );
                config.SetAttribute( MaterialConst.FloatPlaceholder, type );
            } );
            return component;
        }

        /// <summary>
        /// 设置占位提示符绑定
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">占位提示文本</param>
        /// <param name="type">占位符浮动类型</param>
        public static TComponent BindPlaceholder<TComponent>( this TComponent component, string text, FloatType? type = null ) where TComponent : IComponent, IPlaceholder {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( AngularConst.BindPlaceholder, text );
                config.SetAttribute( MaterialConst.FloatPlaceholder, type );
            } );
            return component;
        }

        /// <summary>
        /// 设置提示,显示在控件下方
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">提示文本</param>
        /// <param name="right">显示到右侧</param>
        public static TComponent Hint<TComponent>( this TComponent component, string text, bool right = false ) where TComponent : IComponent, IHint {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                if( right ) {
                    config.SetAttribute( MaterialConst.EndHint, text );
                    return;
                }
                config.SetAttribute( MaterialConst.StartHint, text );
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

        /// <summary>
        /// 设置前缀
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        public static TComponent Prefix<TComponent>( this TComponent component, string text ) where TComponent : IComponent, IPrefix {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Prefix, text );
            } );
            return component;
        }

        /// <summary>
        /// 设置后缀
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        public static TComponent Suffix<TComponent>( this TComponent component, string text ) where TComponent : IComponent, IPrefix {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.SuffixText, text );
            } );
            return component;
        }

        /// <summary>
        /// 设置后缀
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="icon">FontAwesome图标</param>
        /// <param name="onClick">图标单击事件处理函数，范例：click()</param>
        public static TComponent Suffix<TComponent>( this TComponent component, FontAwesomeIcon icon, string onClick = null ) where TComponent : IComponent, IPrefix {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.SuffixFontAwesomeIcon, icon );
                config.SetAttribute( MaterialConst.OnSuffixIconClick, onClick );
            } );
            return component;
        }

        /// <summary>
        /// 设置后缀
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="icon">Material图标</param>
        /// <param name="onClick">图标单击事件处理函数，范例：click()</param>
        public static TComponent Suffix<TComponent>( this TComponent component, MaterialIcon icon, string onClick = null ) where TComponent : IComponent, IPrefix {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.SuffixMaterialIcon, icon );
                config.SetAttribute( MaterialConst.OnSuffixIconClick, onClick );
            } );
            return component;
        }

        /// <summary>
        /// 设置只读
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="readOnly">是否只读</param>
        public static TComponent ReadOnly<TComponent>( this TComponent component, bool readOnly = true ) where TComponent : IOption, IReadOnly {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.ReadOnly, readOnly );
            } );
            return component;
        }

        /// <summary>
        /// 设置只读
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="readOnly">只读表达式</param>
        public static TComponent ReadOnly<TComponent>( this TComponent component, string readOnly ) where TComponent : IComponent, IReadOnly {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.ReadOnly, readOnly );
            } );
            return component;
        }

        /// <summary>
        /// 设置标签
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        public static TComponent Label<TComponent>( this TComponent component, string text ) where TComponent : ILabel {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Label, text );
            } );
            return component;
        }

        /// <summary>
        /// 设置绑定标签
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        public static TComponent BindLabel<TComponent>( this TComponent component, string text ) where TComponent : ILabel {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( AngularConst.BindLabel, text );
            } );
            return component;
        }

        /// <summary>
        /// 设置标签
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        /// <param name="left">是否显示到左边</param>
        public static TComponent Label<TComponent>( this TComponent component, string text, bool? left ) where TComponent : ILabelPosition {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Label, text );
                if( left != null )
                    config.SetAttribute( UiConst.Position, left.SafeValue() ? XPosition.Left : XPosition.Right );
            } );
            return component;
        }
    }
}
