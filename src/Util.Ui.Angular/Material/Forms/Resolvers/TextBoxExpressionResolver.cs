using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Commons.Internal;
using Util.Ui.Material.Forms.Configs;

namespace Util.Ui.Material.Forms.Resolvers {
    /// <summary>
    /// 文本框表达式解析器
    /// </summary>
    public class TextBoxExpressionResolver {
        /// <summary>
        /// 初始化文本框表达式解析器
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        private TextBoxExpressionResolver( ModelExpression expression, TextBoxConfig config ) {
            if( expression == null || config == null )
                return;
            _expression = expression;
            _config = config;
            _memberInfo = expression.GetMemberInfo();
        }

        /// <summary>
        /// 属性表达式
        /// </summary>
        private readonly ModelExpression _expression;

        /// <summary>
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 成员
        /// </summary>
        private readonly MemberInfo _memberInfo;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        public static void Init( ModelExpression expression, TextBoxConfig config ) {
            new TextBoxExpressionResolver( expression, config ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            Helper.InitConfig( _config, _expression, _memberInfo );
            InitType();
            InitValidation();
        }

        /// <summary>
        /// 根据类型初始化
        /// </summary>
        private void InitType() {
            if( Reflection.IsNumber( _memberInfo ) )
                _config.SetAttribute( UiConst.Type, "number" );
        }

        /// <summary>
        /// 初始化验证
        /// </summary>
        private void InitValidation() {
            InitStringLength();
            InitEmail();
        }

        /// <summary>
        /// 初始化字符串长度验证
        /// </summary>
        private void InitStringLength() {
            var attribute = _expression.GetValidationAttribute<StringLengthAttribute>();
            if( attribute == null )
                return;
            if( attribute.MinimumLength > 0 )
                _config.SetAttribute( UiConst.MinLength, attribute.MinimumLength );
            if( attribute.MaximumLength > 0 )
                _config.SetAttribute( UiConst.MaxLength, attribute.MaximumLength );
        }

        /// <summary>
        /// 初始化电子邮件验证
        /// </summary>
        private void InitEmail() {
            var attribute = _expression.GetValidationAttribute<EmailAddressAttribute>();
            if( attribute == null )
                return;
            _config.SetAttribute( UiConst.Type, "email" );
            if ( attribute.ErrorMessage.Contains( "field is not a valid e-mail address" ) )
                return;
            _config.SetAttribute( UiConst.EmailMessage, attribute.ErrorMessage );
        }
    }
}
