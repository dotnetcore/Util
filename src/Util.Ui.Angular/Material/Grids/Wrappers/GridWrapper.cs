using System;
using System.Linq.Expressions;
using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Forms.Models;
using Util.Ui.Material.Lists;

namespace Util.Ui.Material.Grids.Wrappers {
    /// <summary>
    /// 栅格包装器
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    public class GridWrapper<TModel> : IGridWrapper<TModel> {
        /// <summary>
        /// 栅格
        /// </summary>
        private readonly IGrid _container;
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化栅格包装器
        /// </summary>
        /// <param name="grid">栅格</param>
        /// <param name="config">栅格配置</param>
        public GridWrapper( IGrid grid,IConfig config ) {
            _container = grid;
            _config = config;
        }

        /// <summary>
        ///  渲染结束
        /// </summary>
        public void Dispose() {
            if( _container is IRenderEnd container )
                container.End();
        }

        /// <summary>
        /// 单选框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public IRadio Radio<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelRadio<TModel, TProperty>( expression, _config );
        }

        /// <summary>
        /// 复选框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ICheckBox CheckBox<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelCheckBox<TModel, TProperty>( expression, _config );
        }

        /// <summary>
        /// 滑动开关
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ISlideToggle SlideToggle<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelSlideToggle<TModel, TProperty>( expression, _config );
        }

        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ISelect Select<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelSelect<TModel, TProperty>( expression, _config );
        }

        /// <summary>
        /// 选择列表
        /// </summary>
        public ISelectList SelectList() {
            return new SelectList( _config );
        }

        /// <summary>
        /// 文本框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public ITextBox TextBox<TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return new ModelTextBox<TModel, TProperty>( expression, _config );
        }
    }
}