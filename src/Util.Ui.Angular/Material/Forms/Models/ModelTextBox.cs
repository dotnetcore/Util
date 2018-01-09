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
            InitValidation();
        }

        /// <summary>
        /// 初始化模型绑定
        /// </summary>
        private void InitModel() {
            var model = Helper.GetModel( _expression );
            if( string.IsNullOrWhiteSpace( model ) )
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
            if ( Reflection.IsDate( _memberInfo ) )
                this.ToDatePicker();
            else if ( Reflection.IsNumber( _memberInfo ) )
                this.Number();
        }

        /// <summary>
        /// 初始化验证
        /// </summary>
        private void InitValidation() {
            InitRequired();
            InitStringLength();
            InitEmail();
        }

        /// <summary>
        /// 初始化必填项验证
        /// </summary>
        private void InitRequired() {
            var attribute = Lambda.GetAttribute<RequiredAttribute>( _expression );
            if( attribute != null )
                this.Required( attribute.ErrorMessage );
        }

        /// <summary>
        /// 初始化字符串长度验证
        /// </summary>
        private void InitStringLength() {
            var attribute = Lambda.GetAttribute<StringLengthAttribute>( _expression );
            if( attribute == null )
                return;
            if ( attribute.MinimumLength > 0 )
                this.MinLength( attribute.MinimumLength );
            if ( attribute.MaximumLength > 0 )
                this.MaxLength( attribute.MaximumLength );
        }

        /// <summary>
        /// 初始化电子邮件验证
        /// </summary>
        private void InitEmail() {
            var attribute = Lambda.GetAttribute<EmailAddressAttribute>( _expression );
            if ( attribute == null )
                return;
            if ( attribute.ErrorMessage.Contains( "field is not a valid e-mail address" ) ) {
                this.Email();
                return;
            }
            this.Email( attribute.ErrorMessage );
        }
    }
}