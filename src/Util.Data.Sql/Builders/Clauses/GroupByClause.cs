using System.Text;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Conditions;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Group By子句
    /// </summary>
    public class GroupByClause : ClauseBase, IGroupByClause {

        #region 字段

        /// <summary>
        /// 子句结果
        /// </summary>
        protected readonly StringBuilder Result;
        /// <summary>
        /// 分组条件
        /// </summary>
        protected StringBuilder Condition;
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
        /// 初始化Group By子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">Group By子句结果</param>
        /// <param name="condition">分组条件</param>
        public GroupByClause( SqlBuilderBase sqlBuilder, StringBuilder result = null, StringBuilder condition = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
            Condition = condition ?? new StringBuilder();
            ColumnCache = sqlBuilder.ColumnCache;
            ConditionFactory = sqlBuilder.ConditionFactory;
        }

        #endregion

        #region GroupBy(添加分组列)

        /// <inheritdoc />
        public void GroupBy( string columns ) {
            if( string.IsNullOrWhiteSpace( columns ) )
                return;
            if( Result.Length > 0 )
                Result.Append( "," );
            Result.Append( ColumnCache.GetSafeColumns( columns ) );
        }

        #endregion

        #region Having(添加分组条件)

        /// <inheritdoc />
        public void Having( string expression, object value, Operator @operator = Operator.Equal, bool isParameterization = true ) {
            And( ConditionFactory.Create( expression, value, @operator, isParameterization ) );
        }

        /// <summary>
        /// And连接条件
        /// </summary>
        private void And( ISqlCondition condition ) {
            new AndCondition( condition ).AppendTo( Condition );
        }

        #endregion

        #region AppendGroupBy(添加到Group By子句)

        /// <inheritdoc />
        public void AppendGroupBy( string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            if( raw ) {
                Result.Append( sql );
                return;
            }
            Result.Append( ReplaceRawSql( sql ) );
        }

        #endregion

        #region AppendHaving(添加到Having子句)

        /// <inheritdoc />
        public void AppendHaving( string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            if( raw ) {
                And( new SqlCondition( sql ) );
                return;
            }
            And( new SqlCondition( ReplaceRawSql( sql ) ) );
        }

        #endregion

        #region Validate(验证)

        /// <inheritdoc />
        public bool Validate() {
            return Result.Length > 0;
        }

        #endregion

        #region AppendTo(添加到字符串生成器)

        /// <inheritdoc />
        public void AppendTo( StringBuilder builder ) {
            builder.CheckNull( nameof( builder ) );
            if( Validate() == false )
                return;
            builder.Append( "Group By " );
            builder.Append( Result );
            if( Condition.Length == 0 )
                return;
            builder.Append( " Having " );
            builder.Append( Condition );
        }

        #endregion

        #region Clear(清理)

        /// <inheritdoc />
        public void Clear() {
            Result.Clear();
            Condition.Clear();
        }

        #endregion

        #region Clone(复制Group By子句)

        /// <inheritdoc />
        public virtual IGroupByClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            var condition = new StringBuilder();
            condition.Append( Condition );
            return new GroupByClause( builder, result, condition );
        }

        #endregion
    }
}
