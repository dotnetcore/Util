using System;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Select子句
    /// </summary>
    public interface ISelectClause : ISqlClause {
        /// <summary>
        /// 设置星号*列
        /// </summary>
        void Select();
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        void Select( string columns );
        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">列别名</param>
        void Select( ISqlBuilder builder, string alias );
        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">列别名</param>
        void Select( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendSql( string sql, bool raw );
        /// <summary>
        /// 添加子查询到Select子句
        /// </summary>
        ///  <param name="builder">Sql生成器</param>
        void AppendSql( ISqlBuilder builder );
        /// <summary>
        /// 添加子查询到Select子句
        /// </summary>
        ///  <param name="action">子查询操作</param>
        void AppendSql( Action<ISqlBuilder> action );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        ISelectClause Clone( SqlBuilderBase builder );
    }
}
