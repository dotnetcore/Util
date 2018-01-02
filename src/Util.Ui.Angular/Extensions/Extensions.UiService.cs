using System;
using Util.Ui.Components;
using Util.Ui.Material.Buttons;
using Util.Ui.Material.Forms;
using Util.Ui.Material.Icons;
using Util.Ui.Material.Services;
using Util.Ui.Services;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 图标
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IIcon Icon<TModel>( this IUiService<TModel> service ) {
            return new Icon();
        }

        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ISelect Select<TModel>( this IUiService<TModel> service ) {
            return new Select();
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="service">组件服务</param>
        /// <param name="text">文本</param>
        public static Util.Ui.Material.Buttons.IButton Button<TModel>( this IUiService<TModel> service, string text ) {
            return new Button().Text( text );
        }

        /// <summary>
        /// 文本框
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ITextBox TextBox<TModel>( this IUiService<TModel> service ) {
            return new TextBox();
        }

        /// <summary>
        /// 表单
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IForm Form<TModel>( this IUiService<TModel> service ) {
            if( !( service is IContext<TModel> context ) )
                throw new NotImplementedException( "组件服务必须实现Util.Ui.Services.IContext" );
            return new Form( context.Helper.ViewContext.Writer, context.Encoder );
        }
    }
}
