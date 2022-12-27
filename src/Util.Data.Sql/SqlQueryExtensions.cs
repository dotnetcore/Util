using System.Data;
using Util.Data.Sql.Database;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql查询对象操作扩展
    /// </summary>
    public static partial class SqlQueryExtensions {

        #region GetConnection(获取数据库连接)

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="source">源</param>
        public static IDbConnection GetConnection( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            if ( source is IConnectionManager manager )
                return manager.GetConnection();
            return null;
        }

        #endregion

        #region SetConnection(设置数据库连接)

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="connection">数据库连接</param>
        public static ISqlQuery SetConnection( this ISqlQuery source, IDbConnection connection ) {
            source.CheckNull( nameof( source ) );
            if( source is IConnectionManager manager )
                manager.SetConnection( connection );
            return source;
        }

        #endregion

        #region Clear(清理)

        /// <summary>
        /// 清理
        /// </summary>
        /// <param name="source">源</param>
        public static ISqlQuery Clear( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            source.SqlBuilder.Clear();
            return source;
        }

        #endregion

        #region NewSqlBuilder(创建一个新的Sql生成器)

        /// <summary>
        /// 创建一个新的Sql生成器
        /// </summary>
        /// <param name="source">源</param>
        public static ISqlBuilder NewSqlBuilder( this ISqlQuery source ) {
            source.CheckNull( nameof( source ) );
            return source.SqlBuilder.New();
        }

        #endregion
    }
}
