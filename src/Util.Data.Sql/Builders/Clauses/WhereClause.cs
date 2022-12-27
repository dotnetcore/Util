using System;
using System.Text;
using Util.Data.Queries;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Conditions;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Where子句
    /// </summary>
    public class WhereClause : ClauseBase,IWhereClause {

        #region 字段

        /// <summary>
        /// Where子句结果
        /// </summary>
        protected readonly StringBuilder Result;
        /// <summary>
        /// 列缓存
        /// </summary>
        protected readonly IColumnCache ColumnCache;
        /// <summary>
        /// Sql条件工厂
        /// </summary>
        protected readonly IConditionFactory ConditionFactory;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Where子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">Where子句结果</param>
        public WhereClause( SqlBuilderBase sqlBuilder, StringBuilder result = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
            ColumnCache = sqlBuilder.ColumnCache;
            ConditionFactory = sqlBuilder.ConditionFactory;
        }

        #endregion

        #region And

        /// <inheritdoc />
        public void And( ISqlCondition condition ) {
            new AndCondition( condition ).AppendTo( Result );
        }

        #endregion

        #region Or

        /// <inheritdoc />
        public void Or( ISqlCondition condition ) {
            new OrCondition( condition ).AppendTo( Result );
        }

        #endregion

        #region Where

        /// <inheritdoc />
        public void Where( string column, object value, Operator @operator ) {
            column = ColumnCache.GetSafeColumn( column );
            And( ConditionFactory.Create( column, value, @operator ) );
        }

        /// <inheritdoc />
        public void Where( string column, ISqlBuilder builder, Operator @operator ) {
            if( builder == null )
                return;
            Where( column, (object)builder, @operator );
        }

        /// <inheritdoc />
        public void Where( string column, Action<ISqlBuilder> action, Operator @operator ) {
            if( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            Where( column, builder, @operator );
        }

        #endregion

        #region IsNull

        /// <inheritdoc />
        public void IsNull( string column ) {
            Where( column, (object)null, Operator.Equal );
        }

        #endregion

        #region IsNotNull

        /// <inheritdoc />
        public void IsNotNull( string column ) {
            Where( column, (object)null, Operator.NotEqual );
        }

        #endregion

        #region IsEmpty

        /// <inheritdoc />
        public void IsEmpty( string column ) {
            column = ColumnCache.GetSafeColumn( column );
            var nullCondition = ConditionFactory.Create( column, null, Operator.Equal );
            var emptyCondition = ConditionFactory.Create( column, "''", Operator.Equal, false );
            And( new OrCondition( nullCondition, emptyCondition ) );
        }

        #endregion

        #region IsNotEmpty

        /// <inheritdoc />
        public void IsNotEmpty( string column ) {
            column = ColumnCache.GetSafeColumn( column );
            var notNullCondition = ConditionFactory.Create( column, null, Operator.NotEqual );
            var notEmptyCondition = ConditionFactory.Create( column, "''", Operator.NotEqual, false );
            And( new AndCondition( notNullCondition, notEmptyCondition ) );
        }

        #endregion

        #region Between

        /// <inheritdoc />
        public void Between( string column, int? min, int? max, Boundary boundary ) {
            column = ColumnCache.GetSafeColumn( column );
            if( min > max ) {
                And( ConditionFactory.Create( column, max, min, boundary ) );
                return;
            }
            And( ConditionFactory.Create( column, min, max, boundary ) );
        }

        /// <inheritdoc />
        public void Between( string column, double? min, double? max, Boundary boundary ) {
            column = ColumnCache.GetSafeColumn( column );
            if( min > max ) {
                And( ConditionFactory.Create( column, max, min, boundary ) );
                return;
            }
            And( ConditionFactory.Create( column, min, max, boundary ) );
        }

        /// <inheritdoc />
        public void Between( string column, decimal? min, decimal? max, Boundary boundary ) {
            column = ColumnCache.GetSafeColumn( column );
            if( min > max ) {
                And( ConditionFactory.Create( column, max, min, boundary ) );
                return;
            }
            And( ConditionFactory.Create( column, min, max, boundary ) );
        }

        /// <inheritdoc />
        public void Between( string column, DateTime? min, DateTime? max, bool includeTime, Boundary? boundary ) {
            column = ColumnCache.GetSafeColumn( column );
            And( ConditionFactory.Create( column, GetMin( min, max, includeTime ), GetMax( min, max, includeTime ), GetBoundary( boundary, includeTime ) ) );
        }

        /// <summary>
        /// 获取最小日期
        /// </summary>
        private DateTime? GetMin( DateTime? min, DateTime? max, bool includeTime ) {
            if( min == null )
                return null;
            DateTime? result = min;
            if( min > max )
                result = max;
            if( includeTime )
                return result;
            return result.SafeValue().Date;
        }

        /// <summary>
        /// 获取最大日期
        /// </summary>
        private DateTime? GetMax( DateTime? min, DateTime? max, bool includeTime ) {
            if( max == null )
                return null;
            DateTime? result = max;
            if( min > max )
                result = min;
            if( includeTime )
                return result;
            return result.SafeValue().Date.AddDays( 1 );
        }

        /// <summary>
        /// 获取日期范围查询条件边界
        /// </summary>
        private Boundary GetBoundary( Boundary? boundary, bool includeTime ) {
            if( boundary != null )
                return boundary.SafeValue();
            if( includeTime )
                return Boundary.Both;
            return Boundary.Left;
        }

        #endregion

        #region Exists

        /// <inheritdoc />
        public void Exists( ISqlBuilder builder ) {
            if ( builder == null )
                return;
            And( new ExistsCondition( builder ) );
        }

        /// <inheritdoc />
        public void Exists( Action<ISqlBuilder> action ) {
            if ( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            Exists( builder );
        }

        #endregion

        #region NotExists

        /// <inheritdoc />
        public void NotExists( ISqlBuilder builder ) {
            if ( builder == null )
                return;
            And( new NotExistsCondition( builder ) );
        }

        /// <inheritdoc />
        public void NotExists( Action<ISqlBuilder> action ) {
            if ( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            NotExists( builder );
        }

        #endregion

        #region AppendSql

        /// <inheritdoc />
        public void AppendSql( string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            if( raw ) {
                And( new SqlCondition( sql ) );
                return;
            }
            And( new SqlCondition( ReplaceRawSql( sql ) ) );
        }

        #endregion

        #region Validate

        /// <inheritdoc />
        public bool Validate() {
            return Result.Length > 0;
        }

        #endregion

        #region AppendTo

        /// <inheritdoc />
        public void AppendTo( StringBuilder builder ) {
            builder.CheckNull( nameof(builder) );
            if( Validate() == false )
                return;
            builder.Append( "Where " );
            builder.Append( Result );
        }

        #endregion

        #region Clear

        /// <inheritdoc />
        public void Clear() {
            Result.Clear();
        }

        #endregion

        #region Clone

        /// <inheritdoc />
        public virtual IWhereClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            return new WhereClause( builder, result );
        }

        #endregion
    }
}

