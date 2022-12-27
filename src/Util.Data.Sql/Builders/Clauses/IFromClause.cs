using System;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// From子句
    /// </summary>
    public interface IFromClause : ISqlClause {
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        void From( string table );
        /// <summary>
        /// 设置子查询表
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        void From( ISqlBuilder builder, string alias );
        /// <summary>
        /// 设置子查询表
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        void From( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendSql( string sql, bool raw );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制From子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IFromClause Clone( SqlBuilderBase builder );
    }
}
