using System.Linq;
using System.Text;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Core;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Order By子句
    /// </summary>
    public class OrderByClause : ClauseBase, IOrderByClause {

        #region 字段

        /// <summary>
        /// 子句结果
        /// </summary>
        protected readonly StringBuilder Result;
        /// <summary>
        /// 列缓存
        /// </summary>
        protected readonly IColumnCache ColumnCache;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化排序子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">Order By子句结果</param>
        public OrderByClause( SqlBuilderBase sqlBuilder, StringBuilder result = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
            ColumnCache = sqlBuilder.ColumnCache;
        }

        #endregion

        #region OrderBy(排序)

        /// <inheritdoc />
        public void OrderBy( string order ) {
            if( string.IsNullOrWhiteSpace( order ) )
                return;
            var items = order.Split( ',' ).Where( t => t.IsEmpty() == false );
            foreach( var item in items ) {
                var orderItem = new OrderByItem( item );
                Result.Append( ColumnCache.GetSafeColumn( orderItem.Column ) );
                if( orderItem.Desc )
                    Result.Append( " Desc" );
                Result.Append( "," );
            }
        }

        #endregion

        #region AppendSql(添加到排序子句)

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
            builder.Append( "Order By " );
            builder.Append( Result );
            builder.RemoveEnd( "," );
        }

        #endregion

        #region Clear(清理)

        /// <inheritdoc />
        public void Clear() {
            Result.Clear();
        }

        #endregion

        #region Clone(复制Order By子句)

        /// <inheritdoc />
        public virtual IOrderByClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            return new OrderByClause( builder, result );
        }

        #endregion
    }
}
