using System;
using System.Linq.Expressions;

namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// Order By子句
    /// </summary>
    public interface IOrderByClause {
        /// <summary>
        /// 复制Order By子句
        /// </summary>
        /// <param name="register">实体别名注册器</param>
        IOrderByClause Clone( IEntityAliasRegister register );
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
        /// <param name="isPage">是否分页</param>
        void Validate( bool isPage );
        /// <summary>
        /// 获取Sql
        /// </summary>
        string ToSql();
    }
}
