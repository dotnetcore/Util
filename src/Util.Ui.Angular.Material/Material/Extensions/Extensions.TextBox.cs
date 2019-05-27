using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 文本框扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置为密码框
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Password<TComponent>( this TComponent component ) where TComponent : ITextBox {
            var option = component as IOptionConfig;
            option?.Config<TextBoxConfig>( config => {
                config.Password();
            } );
            return component;
        }

        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        public static TComponent Number<TComponent>( this TComponent component ) where TComponent : ITextBox {
            var option = component as IOptionConfig;
            option?.Config<TextBoxConfig>( config => {
                config.Number();
            } );
            return component;
        }

        /// <summary>
        /// 电子邮件验证
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="message">电子邮件验证错误消息</param>
        public static TComponent Email<TComponent>( this TComponent component,string message = null ) where TComponent : ITextBox {
            var option = component as IOptionConfig;
            option?.Config<TextBoxConfig>( config => {
                config.Email();
                config.SetAttribute( UiConst.EmailMessage, message );
            } );
            return component;
        }

        /// <summary>
        /// 是否显示清除按钮
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="isShow">是否显示清除按钮</param>
        public static TComponent ShowClearButton<TComponent>( this TComponent component,bool isShow ) where TComponent : ITextBox {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.ShowClearButton, isShow );
            } );
            return component;
        }

        /// <summary>
        /// 转换为多行文本框
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="minRows">最小行数</param>
        /// <param name="maxRows">最大行数</param>
        public static TComponent ToTextArea<TComponent>( this TComponent component, int? minRows = null,int? maxRows = null ) where TComponent : ITextBox {
            var option = component as IOptionConfig;
            option?.Config<TextBoxConfig>( config => {
                config.IsTextArea = true;
                config.SetAttribute( UiConst.MinRows, minRows );
                config.SetAttribute( UiConst.MaxRows, maxRows );
            } );
            return component;
        }

        /// <summary>
        /// 转换为日期选择框
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="minDate">最小日期限制，范例：2000-1-1</param>
        /// <param name="maxDate">最大日期限制，范例：2000-1-1</param>
        public static TComponent ToDatePicker<TComponent>( this TComponent component, string minDate = null, string maxDate = null ) where TComponent : ITextBox {
            var option = component as IOptionConfig;
            option?.Config<TextBoxConfig>( config => {
                config.IsDatePicker = true;
                config.SetAttribute( MaterialConst.MinDate, minDate );
                config.SetAttribute( MaterialConst.MaxDate, maxDate );
            } );
            return component;
        }

        /// <summary>
        /// 转换为日期选择框
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="width">宽度</param>
        /// <param name="startView">起始视图</param>
        /// <param name="touchUi">触摸模式</param>
        public static TComponent ToDatePicker<TComponent>( this TComponent component, double width, DateView? startView = null,bool? touchUi = null ) where TComponent : ITextBox {
            var option = component as IOptionConfig;
            option?.Config<TextBoxConfig>( config => {
                config.IsDatePicker = true;
                config.SetAttribute( UiConst.Width, width );
                config.SetAttribute( MaterialConst.StartView, startView );
                config.SetAttribute( MaterialConst.TouchUi, touchUi );
            } );
            return component;
        }
    }
}
