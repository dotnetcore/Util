using System;
using System.Linq.Expressions;
using System.Reflection;
using Util.Helpers;
using Util.Ui.Angular.Internal;
using Util.Ui.Material.Extensions;

namespace Util.Ui.Material.Forms.Models {
    /// <summary>
    /// 模型下拉列表
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class ModelSelect<TModel, TProperty> : Select {
        /// <summary>
        /// 初始化模型下拉列表
        /// </summary>
        /// <param name="expression">属性表达式</param>
        public ModelSelect( Expression<Func<TModel, TProperty>> expression ) {
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
            InitType();
        }

        /// <summary>
        /// 根据类型初始化
        /// </summary>
        private void InitType() {
            if( Reflection.IsBool( _memberInfo ) )
                this.Bool();
            else if( Reflection.IsEnum( _memberInfo ) )
                Enum<TProperty>();
        }
    }
}
