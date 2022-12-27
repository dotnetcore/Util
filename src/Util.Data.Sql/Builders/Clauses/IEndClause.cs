using Util.Data.Queries;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// 结束子句
    /// </summary>
    public interface IEndClause : ISqlClause {
        /// <summary>
        /// 设置跳过行数
        /// </summary>
        /// <param name="count">跳过的行数</param>
        void Skip( int count );
        /// <summary>
        /// 设置获取行数
        /// </summary>
        /// <param name="count">获取的行数</param>
        void Take( int count );
        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="page">分页参数</param>
        void Page( IPage page );
        /// <summary>
        /// 添加到结束位置
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendSql( string sql, bool raw );
        /// <summary>
        /// 清理分页
        /// </summary>
        void ClearPage();
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制结束子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IEndClause Clone( SqlBuilderBase builder );
    }
}
