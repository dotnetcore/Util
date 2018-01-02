using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Util.Helpers;
using Util.Ui.Extensions;
using Util.Ui.Internal;
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
            InitModel();
            InitPlaceholder();
            InitType();
            InitRequired();
        }

        /// <summary>
        /// 初始化模型绑定
        /// </summary>
        private void InitModel() {
            var model = Helper.GetModel( _expression );
            if ( string.IsNullOrWhiteSpace( model ) )
                return;
            this.Model( model );
        }

        /// <summary>
        /// 初始化占位提示符
        /// </summary>
        private void InitPlaceholder() {
            this.Placeholder( Reflection.GetDisplayNameOrDescription( _memberInfo ) );
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

        /// <summary>
        /// 初始化必填项验证
        /// </summary>
        private void InitRequired() {
            var attribute = Lambda.GetAttribute<RequiredAttribute>( _expression );
            if( attribute != null )
                this.Required( attribute.ErrorMessage );
        }
    }
}
