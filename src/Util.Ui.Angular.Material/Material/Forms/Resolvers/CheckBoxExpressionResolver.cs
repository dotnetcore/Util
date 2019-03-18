using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Internal;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.Material.Forms.Resolvers {
    /// <summary>
    /// 复选框表达式解析器
    /// </summary>
    public class CheckBoxExpressionResolver {
        /// <summary>
        /// 初始化复选框表达式解析器
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        private CheckBoxExpressionResolver( ModelExpression expression, Config config ) {
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
        private readonly Config _config;

        /// <summary>
        /// 成员
        /// </summary>
        private readonly MemberInfo _memberInfo;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        public static void Init( ModelExpression expression, Config config ) {
            new CheckBoxExpressionResolver( expression, config ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            Helper.Init( _config, _expression, _memberInfo );
        }
    }
}
