using System;
using System.Linq.Expressions;

namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// Group By子句
    /// </summary>
    public interface IGroupByClause {
        /// <summary>
        /// 复制Group By子句
        /// </summary>
        /// <param name="register">实体别名注册器</param>
        IGroupByClause Clone( IEntityAliasRegister register );
        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="columns">分组字段</param>
        /// <param name="having">分组条件</param>
        void GroupBy( string columns, string having = null );
        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">分组字段</param>
        void GroupBy<TEntity>( params Expression<Func<TEntity, object>>[] columns );
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
        /// 是否分组
        /// </summary>
        bool IsGroup { get; }
        /// <summary>
        /// 分组列表
        /// </summary>
        string GroupColumns { get; }
        /// <summary>
        /// 获取Sql
        /// </summary>
        string ToSql();
    }
}
