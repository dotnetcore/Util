using Util.Ui.Angular;
using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Operations.Navigation;
using Util.Ui.Operations.Styles;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 按钮扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 重置
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Reset<TComponent>( this TComponent component ) where TComponent : IButton {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Type, ButtonType.Reset );
            } );
            return component;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Submit<TComponent>( this TComponent component ) where TComponent : IButton {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Type, ButtonType.Submit );
            } );
            return component;
        }

        /// <summary>
        /// 关闭弹出层
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="result">返回结果</param>
        public static TComponent CloseDialog<TComponent>( this TComponent component,string result = "" ) where TComponent : IButton {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.CloseDialog, result );
            } );
            return component;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="style">样式</param>
        public static TComponent Style<TComponent>( this TComponent component, ButtonStyle style ) where TComponent : IButtonStyle {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Styles, style );
            } );
            return component;
        }

        /// <summary>
        /// 设置路由链接地址
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="routerLink">路由链接地址</param>
        public static TComponent Link<TComponent>( this TComponent component, string routerLink ) where TComponent : ILink {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                if( string.IsNullOrWhiteSpace( routerLink ) )
                    return;
                config.SetAttribute( UiConst.Link, routerLink );
            } );
            return component;
        }

        /// <summary>
        /// 设置路由链接地址,[routerLink]
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="routerLink">路由链接地址</param>
        public static TComponent BindLink<TComponent>( this TComponent component, string routerLink ) where TComponent : ILink {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                if( string.IsNullOrWhiteSpace( routerLink ) )
                    return;
                config.SetAttribute( AngularConst.BindLink, routerLink );
            } );
            return component;
        }
    }
}
