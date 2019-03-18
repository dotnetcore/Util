using System;
using System.Linq.Expressions;
using System.Reflection;
using Util.Helpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Angular.Internal;

namespace Util.Ui.Material.Forms.Models {
    /// <summary>
    /// 模型文本框
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class ModelTextBox<TModel, TProperty> : TextBox {
        /// <summary>
        /// 初始化模型文本框
        /// </summary>
        /// <param name="expression">属性表达式</param>
        public ModelTextBox( Expression<Func<TModel, TProperty>> expression ) {
            if( expression == null )
                return;
            _expression = expression;
            _memberInfo = Lambda.GetMember( _expression );
            _config = (TextBoxConfig)OptionConfig;
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
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            Helper.Init( _config, _expression, _memberInfo );
            Helper.InitDataType( _config, _memberInfo );
            Helper.InitValidation( _config, _memberInfo );
        }
    }
}