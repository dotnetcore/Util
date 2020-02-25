using Nest;

namespace Util.Search.ElasticSearch.Services {
    /// <summary>
    /// 搜索条件
    /// </summary>
    public interface ICondition {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        QueryContainer GetCondition();
    }
}
