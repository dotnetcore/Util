using System;
using System.Linq.Expressions;

namespace Util.Datas.Sql.Queries.Builders.Abstractions {
    /// <summary>
    /// Group By子句
    /// </summary>
    public interface IGroupByClause {
        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="group">分组字段</param>
        /// <param name="having">分组条件</param>
        void GroupBy( string group, string having = null );
        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">分组字段</param>
        /// <param name="having">分组条件</param>
        void GroupBy<TEntity>( Expression<Func<TEntity, object>> column, string having = null );
        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendSql( string sql );
        /// <summary>
        /// 获取Sql
        /// </summary>
        string ToSql();
    }
}
