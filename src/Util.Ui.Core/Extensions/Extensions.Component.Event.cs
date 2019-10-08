﻿using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations.Events;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 事件
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 单击事件处理函数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">单击事件处理函数，范例：handle()</param>
        public static TComponent OnClick<TComponent>( this TComponent component, string handler ) where TComponent : IOption, IOnClick {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnClick,handler );
            } );
            return component;
        }

        /// <summary>
        /// 变更事件处理函数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">变更事件处理函数，范例：handle()</param>
        public static TComponent OnChange<TComponent>( this TComponent component, string handler ) where TComponent : IOption, IOnChange {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnChange, handler );
            } );
            return component;
        }

        /// <summary>
        /// 获得焦点事件处理函数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">获得焦点事件处理函数，范例：handle()</param>
        public static TComponent OnFocus<TComponent>( this TComponent component, string handler ) where TComponent : IOption, IOnFocus {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnFocus, handler );
            } );
            return component;
        }

        /// <summary>
        /// 失去焦点事件处理函数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">失去焦点事件处理函数，范例：handle()</param>
        public static TComponent OnBlur<TComponent>( this TComponent component, string handler ) where TComponent : IOption, IOnBlur {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnBlur, handler );
            } );
            return component;
        }

        /// <summary>
        /// 键盘按键事件处理函数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">键盘按键事件处理函数，范例：handle()</param>
        public static TComponent OnKeyup<TComponent>( this TComponent component, string handler ) where TComponent : IOption, IOnKeyup {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnKeyup, handler );
            } );
            return component;
        }

        /// <summary>
        /// 键盘按下事件处理函数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">键盘按下事件处理函数，范例：handle()</param>
        public static TComponent OnKeydown<TComponent>( this TComponent component, string handler ) where TComponent : IOption, IOnKeydown {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnKeydown, handler );
            } );
            return component;
        }

        /// <summary>
        /// 提交事件处理函数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="handler">提交事件处理函数，范例：handle()</param>
        public static TComponent OnSubmit<TComponent>( this TComponent component, string handler ) where TComponent : IOption, IOnSubmit {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.OnSubmit, handler );
            } );
            return component;
        }
    }
}
