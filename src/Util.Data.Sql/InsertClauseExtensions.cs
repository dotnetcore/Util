using System;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// Insert子句操作扩展
    /// </summary>
    public static class InsertClauseExtensions {

        #region Insert(设置插入的表和列名集合)

        /// <summary>
        /// 设置插入的表和列名集合
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">列名集合</param>
        /// <param name="table">表名</param>
        public static T Insert<T>( this T source, string columns, string table = null ) where T : IInsert {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.InsertClause.Insert( columns,table );
            return source;
        }

        #endregion

        #region Values(设置插入的值集合)

        /// <summary>
        /// 设置Insert语句插入的参数值集合
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="values">参数值集合</param>
        public static T Values<T>( this T source, params object[] values ) where T : IInsert {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.InsertClause.Values( values );
            return source;
        }

        #endregion

        #region AppendInsert(添加到Insert子句)

        /// <summary>
        /// 添加到Insert子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendInsert<T>( this T source, string sql,bool raw = false ) where T : IFrom {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.InsertClause.AppendInsert( sql, raw );
            return source;
        }

        #endregion

        #region AppendValues(添加到Values子句)

        /// <summary>
        /// 添加到Values子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendValues<T>( this T source, string sql, bool raw = false ) where T : IFrom {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.InsertClause.AppendValues( sql, raw );
            return source;
        }

        #endregion

        #region ClearInsert(清空Insert子句)

        /// <summary>
        /// 清空Insert子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearInsert<T>( this T source ) where T : IFrom {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.InsertClause.Clear();
            return source;
        }

        #endregion
    }
}
