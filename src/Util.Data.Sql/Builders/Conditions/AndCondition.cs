using System.Text;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// And连接条件
    /// </summary>
    public class AndCondition : ISqlCondition {
        /// <summary>
        /// Sql条件1
        /// </summary>
        private readonly ISqlCondition _condition1;
        /// <summary>
        /// Sql条件2
        /// </summary>
        private readonly ISqlCondition _condition2;

        /// <summary>
        /// 初始化And连接条件
        /// </summary>
        /// <param name="condition1">Sql条件1</param>
        /// <param name="condition2">Sql条件2</param>
        public AndCondition( ISqlCondition condition1, ISqlCondition condition2 = null ) {
            _condition1 = condition1;
            _condition2 = condition2;
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            if( _condition1 == null && _condition2 == null )
                return;
            And( builder, _condition1 );
            And( builder, _condition2 );
        }

        /// <summary>
        /// 与连接
        /// </summary>
        private void And( StringBuilder builder,ISqlCondition condition ) {
            if ( condition == null || condition == NullCondition.Instance )
                return;
            if ( builder.Length == 0 ) {
                condition.AppendTo( builder );
                return;
            }
            builder.Append( " And " );
            condition.AppendTo( builder );
        }
    }
}
