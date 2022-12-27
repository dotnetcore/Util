using System.Text;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// Sql不相等查询条件
    /// </summary>
    public class NotEqualCondition : SqlConditionBase {
        /// <summary>
        /// 初始化Sql不相等查询条件
        /// </summary>
        public NotEqualCondition( IParameterManager parameterManager, string column, object value, bool isParameterization )
            : base( parameterManager, column, value, isParameterization ) {
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public override void AppendTo( StringBuilder builder ) {
            if( Value == null ) {
                new IsNotNullCondition( Column ).AppendTo( builder );
                return;
            }
            base.AppendTo( builder );
        }

        /// <summary>
        /// 添加Sql条件
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        protected override void AppendCondition( StringBuilder builder, string column, object value ) {
            builder.AppendFormat( "{0}<>{1}", column, value );
        }

        /// <summary>
        /// 添加Sql生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        /// <param name="column">列名</param>
        /// <param name="sqlBuilder">Sql生成器</param>
        protected override void AppendSqlBuilder( StringBuilder builder, string column, ISqlBuilder sqlBuilder ) {
            builder.AppendFormat( "{0}<>", column );
            builder.Append( "(" );
            sqlBuilder.AppendTo( builder );
            builder.Append( ")" );
        }
    }
}