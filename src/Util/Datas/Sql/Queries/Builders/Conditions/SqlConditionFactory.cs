using System;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// Sql查询条件工厂
    /// </summary>
    public static class SqlConditionFactory {
        /// <summary>
        /// 创建Sql查询条件
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <param name="operator">操作符</param>
        public static ICondition Create( string left, string right, Operator @operator ) {
            switch( @operator ) {
                case Operator.Equal:
                    if( right == null )
                        return new IsNullCondition( left );
                    return new EqualCondition( left, right );
                case Operator.NotEqual:
                    if( right == null )
                        return new IsNotNullCondition( left );
                    return new NotEqualCondition( left, right );
                case Operator.Greater:
                    return new GreaterCondition( left, right );
                case Operator.Less:
                    return new LessCondition( left, right );
                case Operator.GreaterEqual:
                    return new GreaterEqualCondition( left, right );
                case Operator.LessEqual:
                    return new LessEqualCondition( left, right );
                case Operator.Contains:
                    return new LikeCondition( left, right );
                case Operator.Starts:
                    return new LikeCondition( left, right );
                case Operator.Ends:
                    return new LikeCondition( left, right );
            }
            throw new NotImplementedException( $"运算符 {@operator.Description()} 未实现" );
        }
    }
}
