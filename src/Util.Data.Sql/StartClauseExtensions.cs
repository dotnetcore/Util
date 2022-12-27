using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// 起始子句操作扩展
    /// </summary>
    public static class StartClauseExtensions {

        #region Cte(设置公用表表达式CTE)

        /// <summary>
        /// 设置公用表表达式CTE
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="name">公用表表达式名称</param>
        /// <param name="builder">Sql生成器</param>
        public static T Cte<T>( this T source, string name, ISqlBuilder builder ) where T : IStart {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.StartClause.Cte( name, builder );
            return source;
        }

        #endregion

        #region Append(添加到Sql起始位置)

        /// <summary>
        /// 添加到Sql起始位置,与AppendStart功能相同
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T Append<T>( this T source, string sql, bool raw = false ) where T : IStart {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.StartClause.Append( sql, raw );
            return source;
        }

        #endregion

        #region AppendLine(添加到Sql起始位置并换行)

        /// <summary>
        /// 添加到Sql起始位置并换行
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendLine<T>( this T source, string sql, bool raw = false ) where T : IStart {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.StartClause.AppendLine( sql, raw );
            return source;
        }

        #endregion

        #region AppendStart(添加到Sql起始位置)

        /// <summary>
        /// 添加到Sql起始位置
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendStart<T>( this T source, string sql, bool raw = false ) where T : IStart {
            return source.Append( sql, raw );
        }

        #endregion

        #region ClearCte(清理公用表表达式CTE)

        /// <summary>
        /// 清理公用表表达式CTE
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearCte<T>( this T source ) where T : IStart {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.StartClause.ClearCte();
            return source;
        }

        #endregion

        #region ClearStart(清理起始子句)

        /// <summary>
        /// 清理Sql起始子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearStart<T>( this T source ) where T : IStart {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.StartClause.Clear();
            return source;
        }

        #endregion
    }
}
