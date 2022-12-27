using System;
using System.Text;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Core;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Select子句
    /// </summary>
    public class SelectClause : ClauseBase, ISelectClause {

        #region 字段

        /// <summary>
        /// Select子句结果
        /// </summary>
        protected readonly StringBuilder Result;
        /// <summary>
        /// 列缓存
        /// </summary>
        protected readonly IColumnCache ColumnCache;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Select子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">Select子句结果</param>
        public SelectClause( SqlBuilderBase sqlBuilder, StringBuilder result = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
            ColumnCache = sqlBuilder.ColumnCache;
        }

        #endregion

        #region Select(设置列名)

        /// <inheritdoc />
        public void Select() {
            Result.Clear();
            Result.Append( "*" );
        }

        /// <inheritdoc />
        public void Select( string columns ) {
            if ( columns.IsEmpty() )
                return;
            if ( columns == "*" ) {
                Select();
                return;
            }
            AppendColumns( ColumnCache.GetSafeColumns( columns ) );
        }

        /// <summary>
        /// 添加列
        /// </summary>
        protected void AppendColumns( string columns ) {
            if( Result.Length > 0 ) 
                Result.RemoveEnd( "," ).Append( "," );
            Result.Append( columns );
        }

        /// <inheritdoc />
        public void Select( ISqlBuilder builder, string alias ) {
            if( builder == null )
                return;
            if( Result.Length > 0 )
                Result.Append( "," );
            var item = new SqlBuilderItem( Dialect, builder, alias );
            item.AppendTo( Result );
        }

        /// <inheritdoc />
        public void Select( Action<ISqlBuilder> action, string alias ) {
            if( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            Select( builder, alias );
        }

        #endregion

        #region AppendSql(添加到Select子句)

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

        /// <inheritdoc />
        public void AppendSql( ISqlBuilder builder ) {
            if( builder == null )
                return;
            builder.AppendTo( Result );
        }

        /// <inheritdoc />
        public void AppendSql( Action<ISqlBuilder> action ) {
            if( action == null )
                return;
            var builder = SqlBuilder.New();
            action( builder );
            AppendSql( builder );
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
            if ( Validate() == false )
                return;
            builder.Append( "Select " );
            builder.Append( Result );
        }

        #endregion

        #region Clear(清理)

        /// <inheritdoc />
        public void Clear() {
            Result.Clear();
        }

        #endregion

        #region Clone(复制Select子句)

        /// <inheritdoc />
        public virtual ISelectClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            return new SelectClause( builder, result );
        }

        #endregion
    }
}
