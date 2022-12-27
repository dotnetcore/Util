using System;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Sql子句基类
    /// </summary>
    public abstract class ClauseBase {
        /// <summary>
        /// Sql生成器
        /// </summary>
        protected readonly SqlBuilderBase SqlBuilder;
        /// <summary>
        /// Sql方言
        /// </summary>
        protected readonly IDialect Dialect;

        /// <summary>
        /// 初始化Sql子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        protected ClauseBase( SqlBuilderBase sqlBuilder ) {
            SqlBuilder = sqlBuilder ?? throw new ArgumentNullException( nameof( sqlBuilder ) );
            Dialect = SqlBuilder.Dialect;
        }

        /// <summary>
        /// 替换原始Sql,将[]替换为特定Sql转义符
        /// </summary>
        /// <param name="sql">原始Sql</param>
        protected string ReplaceRawSql( string sql ) {
            return Dialect.ReplaceSql( sql );
        }
    }
}
