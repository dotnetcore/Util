using System;
using Util.Ui.Components;
using Util.Ui.Material.Buttons;
using Util.Ui.Material.Forms;
using Util.Ui.Material.Grids;
using Util.Ui.Material.Icons;
using Util.Ui.Material.Menus;
using Util.Ui.Material.Tabs;
using Util.Ui.Services;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 链接
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IAnchor A<TModel>( this IUiService<TModel> service ) {
            return new Anchor();
        }

        /// <summary>
        /// 图标
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IIcon Icon<TModel>( this IUiService<TModel> service ) {
            return new Icon();
        }

        /// <summary>
        /// 单选框
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IRadio Radio<TModel>( this IUiService<TModel> service ) {
            return new Radio();
        }

        /// <summary>
        /// 复选框
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ICheckBox CheckBox<TModel>( this IUiService<TModel> service ) {
            return new CheckBox();
        }

        /// <summary>
        /// 滑动开关
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ISlideToggle SlideToggle<TModel>( this IUiService<TModel> service ) {
            return new SlideToggle();
        }

        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ISelect Select<TModel>( this IUiService<TModel> service ) {
            return new Select();
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
                throw new NotSupportedException();
            return new Form( context.Helper.ViewContext.Writer );
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="service">组件服务</param>
        public static Material.Buttons.IButton Button<TModel>( this IUiService<TModel> service ) {
            if( !( service is IContext<TModel> context ) )
                throw new NotSupportedException();
            return new Button( context.Helper.ViewContext.Writer );
        }

        /// <summary>
        /// 菜单
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IMenu Menu<TModel>( this IUiService<TModel> service ) {
            if( !( service is IContext<TModel> context ) )
                throw new NotSupportedException();
            return new Menu( context.Helper.ViewContext.Writer );
        }

        /// <summary>
        /// 选项卡组
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ITabGroup Tabs<TModel>( this IUiService<TModel> service ) {
            if( !( service is IContext<TModel> context ) )
                throw new NotSupportedException();
            return new TabGroup( context.Helper.ViewContext.Writer );
        }

        /// <summary>
        /// 导航选项卡
        /// </summary>
        /// <param name="service">组件服务</param>
        public static ITabNavigation NavTabs<TModel>( this IUiService<TModel> service ) {
            if( !( service is IContext<TModel> context ) )
                throw new NotSupportedException();
            return new TabNavigation( context.Helper.ViewContext.Writer );
        }

        /// <summary>
        /// 栅格
        /// </summary>
        /// <param name="service">组件服务</param>
        public static IGrid<TModel> Grid<TModel>( this IUiService<TModel> service ) {
            if( !( service is IContext<TModel> context ) )
                throw new NotSupportedException();
            return new Grid<TModel>( context.Helper.ViewContext.Writer );
        }
    }
}
