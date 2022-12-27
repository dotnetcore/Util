using System;
using System.Text;
using Util.Data.Sql.Builders.Core;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// From子句
    /// </summary>
    public class FromClause : ClauseBase, IFromClause {

        #region 字段

        /// <summary>
        /// From子句结果
        /// </summary>
        protected readonly StringBuilder Result;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化From子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">From子句结果</param>
        public FromClause( SqlBuilderBase sqlBuilder, StringBuilder result = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
        }

        #endregion

        #region From(设置表)

        /// <inheritdoc />
        public void From( string table ) {
            if ( table.IsEmpty() )
                return;
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
        public void From( ISqlBuilder builder, string alias ) {
            if( builder == null )
                return;
            var item = new SqlBuilderItem( Dialect, builder, alias );
            item.AppendTo( Result );
        }

        /// <inheritdoc />
        public void From( Action<ISqlBuilder> action, string alias ) {
            if( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            From( builder, alias );
        }

        #endregion

        #region AppendSql(添加到From子句)

        /// <inheritdoc />
        public void AppendSql( string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            if( raw ) {
                Result.Append( sql );
                return;
            }
            Result.Append( ReplaceRawSql( sql ) );
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
            builder.Append( "From " );
            builder.Append( Result );
        }

        #endregion

        #region Clear(清理)

        /// <inheritdoc />
        public void Clear() {
            Result.Clear();
        }

        #endregion

        #region Clone(复制From子句)

        /// <inheritdoc />
        public virtual IFromClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            return new FromClause( builder, result );
        }

        #endregion
    }
}
