using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Commons.Internal;
using Util.Ui.Material.Forms.Configs;

namespace Util.Ui.Material.Forms.Resolvers {
    /// <summary>
    /// 单选框表达式解析器
    /// </summary>
    public class RadioExpressionResolver {
        /// <summary>
        /// 初始化单选框表达式解析器
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="config">配置</param>
        private RadioExpressionResolver( ModelExpression expression, SelectConfig config ) {
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
            new RadioExpressionResolver( expression, config ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            _config.SetAttribute( UiConst.Name, Util.Helpers.String.FirstLowerCase( _expression.Name ) );
            _config.SetAttribute( UiConst.Label, Reflection.GetDisplayNameOrDescription( _memberInfo ) );
            Helper.InitModel( _config, _expression );
            Helper.InitRequired( _config, _expression );
            InitType();
        }

        /// <summary>
        /// 根据类型初始化
        /// </summary>
        private void InitType() {
            if( Reflection.IsBool( _memberInfo ) )
                _config.AddBool();
            else if( Reflection.IsEnum( _memberInfo ) )
                _config.AddEnum( _expression.Metadata.ModelType );
        }
    }
}
