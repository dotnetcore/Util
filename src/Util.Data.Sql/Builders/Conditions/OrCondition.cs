using System.Text;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// Or连接条件
    /// </summary>
    public class OrCondition : ISqlCondition {
        /// <summary>
        /// Sql条件1
        /// </summary>
        private readonly ISqlCondition _condition1;
        /// <summary>
        /// Sql条件2
        /// </summary>
        private readonly ISqlCondition _condition2;

        /// <summary>
        /// 初始化Or连接条件
        /// </summary>
        /// <param name="condition1">Sql条件1</param>
        /// <param name="condition2">Sql条件2</param>
        public OrCondition( ISqlCondition condition1, ISqlCondition condition2 = null ) {
            _condition1 = condition1;
            _condition2 = condition2;
            if ( condition1 != null && condition1 == NullCondition.Instance )
                _condition1 = null;
            if( condition2 != null && condition2 == NullCondition.Instance )
                _condition2 = null;
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            if( _condition1 == null && _condition2 == null )
                return;
            if ( _condition1 != null && _condition2 != null ) {
                AppendAllCondition( builder );
                return;
            }
            AppendCondition( builder, _condition1 );
            AppendCondition( builder, _condition2 );
        }

        /// <summary>
        /// 连接两个条件
        /// </summary>
        private void AppendAllCondition( StringBuilder builder ) {
            if( builder.Length == 0 ) {
                Or( builder );
                return;
            }
            builder.Append( " And " );
            Or( builder );
        }

        /// <summary>
        /// 或操作
        /// </summary>
        private void Or( StringBuilder builder ) {
            builder.Append( "(" );
            _condition1.AppendTo( builder );
            builder.Append( " Or " );
            _condition2.AppendTo( builder );
            builder.Append( ")" );
        }

        /// <summary>
        /// 连接1个条件
        /// </summary>
        private void AppendCondition( StringBuilder builder,ISqlCondition condition ) {
            if ( condition == null )
                return;
            if( builder.Length == 0 ) {
                condition.AppendTo( builder );
                return;
            }
            builder.Insert( 0, '(' );
            builder.Append( " Or " );
            condition.AppendTo( builder );
            builder.Append( ")" );
        }
    }
}