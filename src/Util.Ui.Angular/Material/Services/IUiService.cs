using System;
using System.Linq.Expressions;
using Util.Ui.Components;

namespace Util.Ui.Material.Services {
    /// <summary>
    /// 组件服务
    /// </summary>
    public interface IUiService<TModel> {
        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        ISelect Select<TProperty>( Expression<Func<TModel, TProperty>> expression );
        /// <summary>
        /// 文本框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        ITextBox TextBox<TProperty>( Expression<Func<TModel, TProperty>> expression );
    }
}
