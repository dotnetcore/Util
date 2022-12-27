using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Core;
using Util.Helpers;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// 起始子句
    /// </summary>
    public class StartClause : ClauseBase, IStartClause {

        #region 字段

        /// <summary>
        /// 起始子句结果
        /// </summary>
        protected readonly StringBuilder Result;
        /// <summary>
        /// 公用表表达式CTE项集合
        /// </summary>
        protected List<CteItem> CteItems;
        /// <summary>
        /// 列缓存
        /// </summary>
        protected readonly IColumnCache ColumnCache;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化起始子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">起始子句结果</param>
        /// <param name="cteItems">公用表表达式CTE项集合</param>
        public StartClause( SqlBuilderBase sqlBuilder, StringBuilder result = null, List<CteItem> cteItems = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
            CteItems = cteItems ?? new List<CteItem>();
            ColumnCache = sqlBuilder.ColumnCache;
        }

        #endregion

        #region Cte(公用表表达式CTE)

        /// <summary>
        /// 公用表表达式CTE
        /// </summary>
        /// <param name="name">公用表表达式名称</param>
        /// <param name="builder">Sql生成器</param>
        public void Cte( string name, ISqlBuilder builder ) {
            if( name.IsEmpty() || builder == null )
                return;
            name = ColumnCache.GetSafeColumn( name );
            CteItems.Add( new CteItem( name, builder ) );
        }

        #endregion

        #region Append(添加到起始位置)

        /// <summary>
        /// 添加到起始位置
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        public void Append( string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            if( raw ) {
                Result.Append( sql );
                return;
            }
            Result.Append( ReplaceRawSql( sql ) );
        }

        #endregion

        #region AppendLine(添加到起始位置并换行)

        /// <summary>
        /// 添加到起始位置并换行
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        public void AppendLine( string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            if( raw ) {
                Result.AppendLine( sql );
                return;
            }
            Result.AppendLine( ReplaceRawSql( sql ) );
        }

        #endregion

        #region Validate(验证)

        /// <summary>
        /// 验证
        /// </summary>
        public bool Validate() {
            if( Result.Length > 0 )
                return true;
            if( CteItems.Count > 0 )
                return true;
            return false;
        }

        #endregion

        #region AppendTo(添加到字符串生成器)

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            builder.CheckNull( nameof( builder ) );
            if( Validate() == false )
                return;
            AppendCte( builder );
            builder.Append( Result );
        }

        #endregion

        #region AppendCte(添加公用表表达式CTE)

        /// <summary>
        /// 添加公用表表达式CTE
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        protected virtual void AppendCte( StringBuilder builder ) {
            if( CteItems.Count == 0 )
                return;
            builder.AppendFormat( "{0} ", GetCteKeyWord() );
            foreach( var item in CteItems ) {
                builder.Append( item.Name );
                builder.AppendLine( " " );
                builder.Append( "As (" );
                item.Builder.AppendTo( builder );
                builder.AppendLine( ")," );
            }
            builder.RemoveEnd( $",{Common.Line}" );
        }

        /// <summary>
        /// 获取CTE关键字
        /// </summary>
        protected virtual string GetCteKeyWord() {
            return "With";
        }

        #endregion

        #region ClearCte(清理公用表表达式CTE)

        /// <summary>
        /// 清理公用表表达式CTE
        /// </summary>
        public void ClearCte() {
            CteItems.Clear();
        }

        #endregion

        #region Clear(清理)

        /// <summary>
        /// 清理
        /// </summary>
        public void Clear() {
            Result.Clear();
            CteItems.Clear();
        }

        #endregion

        #region Clone(复制起始子句)

        /// <summary>
        /// 复制起始子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        public virtual IStartClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            return new StartClause( builder, result, CteItems.Select( t => t.Clone() ).ToList() );
        }

        #endregion
    }
}
