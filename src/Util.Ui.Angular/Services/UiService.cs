using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Ui.CkEditor;
using Util.Ui.CkEditor.Models;
using Util.Ui.Components;
using Util.Ui.Material.Forms.Models;
using Util.Ui.Prime.ColorPickers.Models;

namespace Util.Ui.Services {
    /// <summary>
    /// 组件服务
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    public class UiService<TModel> : UiServiceBase<TModel>, IUiService<TModel> {
        /// <summary>
        /// 初始化组件服务
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        public UiService( IHtmlHelper<TModel> helper ) : base( helper ) {
        }

        /// <summary>
        /// 单选框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public IRadio Radio<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelRadio<TModel, TProperty>( expression );
        }

        /// <summary>
        /// 复选框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ICheckBox CheckBox<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelCheckBox<TModel, TProperty>( expression );
        }

        /// <summary>
        /// 滑动开关
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ISlideToggle SlideToggle<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelSlideToggle<TModel, TProperty>( expression );
        }

        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ISelect Select<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelSelect<TModel, TProperty>( expression );
        }

        /// <summary>
        /// 文本框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ITextBox TextBox<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelTextBox<TModel, TProperty>( expression );
        }

        /// <summary>
        /// 颜色选择器
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public IColorPicker ColorPicker<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelColorPicker<TModel, TProperty>( expression );
        }

        /// <summary>
        /// 富文本框编辑器
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public IEditor Editor<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelEditor<TModel, TProperty>( expression );
        }
    }
}
