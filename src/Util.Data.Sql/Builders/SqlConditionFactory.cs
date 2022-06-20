using System;
using Util.Data.Queries;
using Util.Data.Sql.Builders.Conditions;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql条件工厂
    /// </summary>
    public class SqlConditionFactory : IConditionFactory {
        /// <summary>
        /// Sql参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;

        /// <summary>
        /// 初始化Sql条件工厂
        /// </summary>
        /// <param name="parameterManager">Sql参数管理器</param>
        public SqlConditionFactory( IParameterManager parameterManager ) {
            _parameterManager = parameterManager ?? throw new ArgumentNullException( nameof( parameterManager ) );
        }

        /// <inheritdoc />
        public virtual ISqlCondition Create( string column, object value, Operator @operator, bool isParameterization = true ) {
            if( IsInCondition( @operator, value ) )
                return new InCondition( _parameterManager, column, value, isParameterization );
            if( IsNotInCondition( @operator, value ) )
                return new NotInCondition( _parameterManager, column, value, isParameterization );
            switch( @operator ) {
                case Operator.Equal:
                    return new EqualCondition( _parameterManager, column, value, isParameterization );
                case Operator.NotEqual:
                    return new NotEqualCondition( _parameterManager, column, value, isParameterization );
                case Operator.Greater:
                    return new GreaterCondition( _parameterManager, column, value, isParameterization );
                case Operator.GreaterEqual:
                    return new GreaterEqualCondition( _parameterManager, column, value, isParameterization );
                case Operator.Less:
                    return new LessCondition( _parameterManager, column, value, isParameterization );
                case Operator.LessEqual:
                    return new LessEqualCondition( _parameterManager, column, value, isParameterization );
                case Operator.Contains:
                    return new ContainsCondition( _parameterManager, column, value, isParameterization );
                case Operator.Starts:
                    return new StartsCondition( _parameterManager, column, value, isParameterization );
                case Operator.Ends:
                    return new EndsCondition( _parameterManager, column, value, isParameterization );
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 是否In条件
        /// </summary>
        private bool IsInCondition( Operator @operator, object value ) {
            if( @operator == Operator.In )
                return true;
            return false;
        }

        /// <summary>
        /// 是否Not In条件
        /// </summary>
        private bool IsNotInCondition( Operator @operator, object value ) {
            if( @operator == Operator.NotIn )
                return true;
            return false;
        }

        /// <inheritdoc />
        public virtual ISqlCondition Create( string column, object minValue, object maxValue, Boundary boundary, bool isParameterization = true ) {
            return new SegmentCondition( _parameterManager, column, minValue, maxValue, boundary, isParameterization );
        }
    }
}
