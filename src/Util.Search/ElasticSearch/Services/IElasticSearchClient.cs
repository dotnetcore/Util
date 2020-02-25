using Nest;

namespace Util.Search.ElasticSearch.Services {
    /// <summary>
    /// ElasticSearch客户端
    /// </summary>
    public interface IElasticSearchClient {
        /// <summary>
        /// 获取ElasticSearch Nest客户端
        /// </summary>
        ElasticClient GetClient();
    }
}
