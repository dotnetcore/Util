using System;
using Util.Ui.Material.Buttons;
using Util.Ui.Material.Forms;
using Util.Ui.Services;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 文本框
        /// </summary>
        /// <param name="service">组件服务</param>
        public static Util.Ui.Components.ITextBox TextBox( this IUiService service ) {
            return new TextBox();
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="service">组件服务</param>
        /// <param name="text">文本</param>
        public static IButton Button( this IUiService service,string text ) {
            return new Button().Text( text );
        }

        /// <summary>
        /// 表单
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IForm Form( this IUiService service ) {
            if( !( service is IContext context ))
                throw new NotImplementedException( "组件服务必须实现Util.Ui.Services.IContext" );
            return new Form( context.Helper.ViewContext.Writer, context.Encoder );
        }
    }
}
