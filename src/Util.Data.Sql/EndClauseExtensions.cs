using Util.Data.Queries;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// 结束子句操作扩展
    /// </summary>
    public static class EndClauseExtensions {

        #region Skip(设置跳过行数)

        /// <summary>
        /// 设置跳过行数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="count">跳过的行数</param>
        public static T Skip<T>( this T source, int count ) where T : IEnd {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.EndClause.Skip( count );
            return source;
        }

        #endregion

        #region Take(设置获取行数)

        /// <summary>
        /// 设置获取行数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="count">获取的行数</param>
        public static T Take<T>( this T source, int count ) where T : IEnd {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.EndClause.Take( count );
            return source;
        }

        #endregion

        #region Page(设置分页)

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="page">分页参数</param>
        public static T Page<T>( this T source, IPage page ) where T : IEnd {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.EndClause.Page( page );
            return source;
        }

        #endregion

        #region AppendEnd(添加到Sql结束位置)

        /// <summary>
        /// 添加到Sql结束位置
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendEnd<T>( this T source, string sql, bool raw = false ) where T : IEnd {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.EndClause.AppendSql( sql, raw );
            return source;
        }

        #endregion

        #region ClearPage(清理分页)

        /// <summary>
        /// 清理分页
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearPage<T>( this T source ) where T : IEnd {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.EndClause.ClearPage();
            return source;
        }

        #endregion

        #region ClearEnd(清理结束子句)

        /// <summary>
        /// 清理Sql结束子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearEnd<T>( this T source ) where T : IEnd {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.EndClause.Clear();
            return source;
        }

        #endregion
    }
}
