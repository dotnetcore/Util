using System;
using System.Linq.Expressions;
using Util.Domains.Repositories;

namespace Util.Datas.Sql.Queries.Builders.Abstractions {
    /// <summary>
    /// 排序子句
    /// </summary>
    public interface IOrderByClause {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="order">排序列表</param>
        /// <param name="tableAlias">表别名</param>
        void OrderBy( string order, string tableAlias = null );
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">排序列</param>
        /// <param name="desc">是否倒排</param>
        void OrderBy<TEntity>( Expression<Func<TEntity, object>> column, bool desc = false );
        /// <summary>
        /// 添加到OrderBy子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendSql( string sql );
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="pager">分页</param>
        void Validate( IPager pager );
        /// <summary>
        /// 获取Sql
        /// </summary>
        string ToSql();
    }
}
