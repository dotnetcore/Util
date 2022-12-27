using System.Text;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// Sql尾匹配查询条件
    /// </summary>
    public class EndsCondition : SqlConditionBase {
        /// <summary>
        /// 初始化Sql尾匹配查询条件
        /// </summary>
        public EndsCondition( IParameterManager parameterManager, string column, object value, bool isParameterization ) 
            : base( parameterManager, column, value, isParameterization ) {
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        protected override object GetValue() {
            return $"%{Value}";
        }

        /// <summary>
        /// 添加Sql条件
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        protected override void AppendCondition( StringBuilder builder, string column, object value ) {
            builder.AppendFormat( "{0} Like {1}", column, value );
        }

        /// <summary>
        /// 添加非参数化条件
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        protected override void AppendNonParameterizedCondition( StringBuilder builder ) {
            AppendCondition( builder, Column, $"'{GetValue()}'" );
        }
    }
}
