using System;
using System.Text;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Conditions;
using Util.Data.Sql.Builders.Core;
using Util.Helpers;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Join子句
    /// </summary>
    public class JoinClause : ClauseBase, IJoinClause {

        #region 常量

        /// <summary>
        /// Join关键字
        /// </summary>
        private const string JoinKey = "Join";
        /// <summary>
        /// Left Join关键字
        /// </summary>
        private const string LeftJoinKey = "Left Join";
        /// <summary>
        /// Right Join关键字
        /// </summary>
        private const string RightJoinKey = "Right Join";

        #endregion

        #region 字段

        /// <summary>
        /// Join子句结果
        /// </summary>
        protected readonly StringBuilder Result;
        /// <summary>
        /// 连接条件
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
        /// 初始化Join子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">Join子句结果</param>
        /// <param name="condition">连接条件</param>
        public JoinClause( SqlBuilderBase sqlBuilder, StringBuilder result = null, StringBuilder condition = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
            Condition = condition ?? new StringBuilder();
            ColumnCache = sqlBuilder.ColumnCache;
            ConditionFactory = sqlBuilder.ConditionFactory;
        }

        #endregion

        #region Join(内连接)

        /// <inheritdoc />
        public void Join( string table ) {
            Join( JoinKey, table );
        }

        /// <summary>
        /// 表连接
        /// </summary>
        private void Join( string joinType, string table ) {
            AppendOn();
            AppendJoin( joinType, table );
        }

        /// <summary>
        /// 添加On条件
        /// </summary>
        private void AppendOn() {
            if( Condition.Length == 0 )
                return;
            Result.Append( " On " );
            Result.Append( Condition );
            Result.AppendLine( " " );
            Condition.Clear();
        }

        /// <summary>
        /// 添加Join
        /// </summary>
        private void AppendJoin( string joinType, string table ) {
            Result.AppendFormat( "{0} ", joinType );
            var item = CreateTableItem( table );
            item.AppendTo( Result );
        }

        /// <summary>
        /// 创建表项
        /// </summary>
        /// <param name="table">表名</param>
        protected virtual TableItem CreateTableItem( string table ) {
            return new( Dialect, table );
        }

        /// <inheritdoc />
        public void Join( ISqlBuilder builder, string alias ) {
            Join( JoinKey, builder, alias );
        }

        /// <summary>
        /// 表连接
        /// </summary>
        private void Join( string joinType, ISqlBuilder builder, string alias ) {
            if( builder == null )
                return;
            AppendOn();
            Result.AppendFormat( "{0} ", joinType );
            var item = new SqlBuilderItem( Dialect, builder, alias );
            item.AppendTo( Result );
        }

        /// <inheritdoc />
        public void Join( Action<ISqlBuilder> action, string alias ) {
            if( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            Join( builder, alias );
        }

        #endregion

        #region LeftJoin(左外连接)

        /// <inheritdoc />
        public void LeftJoin( string table ) {
            Join( LeftJoinKey, table );
        }

        /// <inheritdoc />
        public void LeftJoin( ISqlBuilder builder, string alias ) {
            Join( LeftJoinKey, builder, alias );
        }

        /// <inheritdoc />
        public void LeftJoin( Action<ISqlBuilder> action, string alias ) {
            if( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            LeftJoin( builder, alias );
        }

        #endregion

        #region RightJoin(右外连接)

        /// <inheritdoc />
        public void RightJoin( string table ) {
            Join( RightJoinKey, table );
        }

        /// <inheritdoc />
        public void RightJoin( ISqlBuilder builder, string alias ) {
            Join( RightJoinKey, builder, alias );
        }

        /// <inheritdoc />
        public void RightJoin( Action<ISqlBuilder> action, string alias ) {
            if( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            RightJoin( builder, alias );
        }

        #endregion

        #region On(设置连接条件)

        /// <inheritdoc />
        public void On( string column, object value, Operator @operator = Operator.Equal, bool isParameterization = false ) {
            column = ColumnCache.GetSafeColumn( column );
            value = GetValue( value, isParameterization );
            var condition = ConditionFactory.Create( column, value, @operator, isParameterization );
            On( condition );
        }

        /// <summary>
        /// 获取值,非参数化字符串值被认为是列名,将进行规范化处理
        /// </summary>
        private object GetValue( object value, bool isParameterization ) {
            if( value == null )
                return null;
            if( isParameterization )
                return value;
            if( value.GetType() != typeof( string ) )
                return value;
            return ColumnCache.GetSafeColumn( value.ToString() );
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="condition">连接条件</param>
        public void On( ISqlCondition condition ) {
            if( condition == null )
                return;
            new AndCondition( condition ).AppendTo( Condition );
        }

        #endregion

        #region AppendJoin(添加到内连接子句)

        /// <inheritdoc />
        public void AppendJoin( string sql, bool raw ) {
            AppendSql( JoinKey, sql, raw );
        }

        /// <summary>
        /// 添加到连接子句
        /// </summary>
        private void AppendSql( string joinType, string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            AppendOn();
            Result.AppendFormat( "{0} ", joinType );
            if( raw ) {
                Result.Append( sql );
                return;
            }
            Result.Append( ReplaceRawSql( sql ) );
        }

        #endregion

        #region AppendLeftJoin(添加到左外连接子句)

        /// <inheritdoc />
        public void AppendLeftJoin( string sql, bool raw ) {
            AppendSql( LeftJoinKey, sql, raw );
        }

        #endregion

        #region AppendRightJoin(添加到右外连接子句)

        /// <inheritdoc />
        public void AppendRightJoin( string sql, bool raw ) {
            AppendSql( RightJoinKey, sql, raw );
        }

        #endregion

        #region AppendOn(添加到On子句)

        /// <inheritdoc />
        public void AppendOn( string sql, bool raw ) {
            if( raw ) {
                On( new SqlCondition( sql ) );
                return;
            }
            On( new SqlCondition( ReplaceRawSql( sql ) ) );
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
            AppendOn();
            builder.Append( Result );
            builder.RemoveEnd( $" {Common.Line}" );
        }

        #endregion

        #region Clear(清理)

        /// <inheritdoc />
        public void Clear() {
            Result.Clear();
            Condition.Clear();
        }

        #endregion

        #region Clone(复制Join子句)

        /// <inheritdoc />
        public virtual IJoinClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            var condition = new StringBuilder();
            condition.Append( Condition );
            return new JoinClause( builder, result, condition );
        }

        #endregion
    }
}
