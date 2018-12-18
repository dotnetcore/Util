using Util.Datas.Sql.Queries.Builders.Core;

namespace Util.Datas.Sql.Queries.Builders.Abstractions {
    /// <summary>
    /// Sql过滤器
    /// </summary>
    public interface ISqlFilter {
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="context">Sql查询执行上下文</param>
        void Filter( SqlQueryContext context );
    }
}
