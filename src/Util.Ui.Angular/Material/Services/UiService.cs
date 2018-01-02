using System;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Ui.Components;
using Util.Ui.Material.Forms.Models;
using Util.Ui.Services;

namespace Util.Ui.Material.Services {
    /// <summary>
    /// 组件服务
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    public class UiService<TModel> : UiServiceBase<TModel>, IUiService<TModel> {
        /// <summary>
        /// 初始化组件服务
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="encoder">Html编码</param>
        public UiService( IHtmlHelper<TModel> helper, HtmlEncoder encoder ) : base( helper, encoder ) {
        }

        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ISelect Select<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelSelect<TModel, TProperty>( expression );
        }
    }
}
