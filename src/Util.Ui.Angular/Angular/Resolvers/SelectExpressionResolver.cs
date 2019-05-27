using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Angular.Internal;
using Util.Ui.Extensions;

namespace Util.Ui.Angular.Resolvers {
    /// <summary>
    /// 下拉列表表达式解析器
    /// </summary>
    public class SelectExpressionResolver {
        /// <summary>
        /// 初始化下拉列表表达式解析器
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        private SelectExpressionResolver( ModelExpression expression, SelectConfig config ) {
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
        private readonly SelectConfig _config;

        /// <summary>
        /// 成员
        /// </summary>
        private readonly MemberInfo _memberInfo;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        public static void Init( ModelExpression expression, SelectConfig config ) {
            new SelectExpressionResolver( expression, config ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            Helper.Init( _config, _expression, _memberInfo );
            InitType();
        }

        /// <summary>
        /// 根据类型初始化
        /// </summary>
        private void InitType() {
            if ( Reflection.IsBool( _memberInfo ) )
                _config.AddBool();
            else if ( Reflection.IsEnum( _memberInfo ) )
                _config.AddEnum( _expression.Metadata.ModelType );
        }
    }
}
