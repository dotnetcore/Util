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
            Helper.InitConfig( _config, _expression, _memberInfo );
            InitType();
        }

        /// <summary>
        /// 根据类型初始化
        /// </summary>
        private void InitType() {
            if ( Reflection.IsBool( _memberInfo ) )
                InitBool();
            else if ( Reflection.IsEnum( _memberInfo ) )
                InitEnum();
        }

        /// <summary>
        /// 初始化布尔类型
        /// </summary>
        private void InitBool() {
            _config.AddItems( new Item( "是", true ) ).AddItems( new Item( "否", false ) );
        }

        /// <summary>
        /// 初始化枚举类型
        /// </summary>
        private void InitEnum() {
            _config.AddItems( Util.Helpers.Enum.GetItems( _expression.Metadata.ModelType ).ToArray() );
        }
    }
}
