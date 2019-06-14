﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using Util.Helpers;
using Util.Ui.Angular.Internal;

namespace Util.Ui.ColorPickers.Models {
    /// <summary>
    /// 模型颜色选择器
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class ModelColorPicker<TModel, TProperty> : ColorPicker {
        /// <summary>
        /// 初始化模型颜色选择器
        /// </summary>
        /// <param name="expression">属性表达式</param>
        public ModelColorPicker( Expression<Func<TModel, TProperty>> expression ) {
            if( expression == null )
                return;
            _expression = expression;
            _memberInfo = Lambda.GetMember( _expression );
            Init();
        }

        /// <summary>
        /// 属性表达式
        /// </summary>
        private readonly Expression<Func<TModel, TProperty>> _expression;
        /// <summary>
        /// 成员
        /// </summary>
        private readonly MemberInfo _memberInfo;

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            Helper.Init( OptionConfig, _expression, _memberInfo );
        }
    }
}
