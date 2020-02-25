namespace Util.Search.ElasticSearch.Configs {
    /// <summary>
    /// 搜索配置提供器
    /// </summary>
    public interface IConfigProvider {
        /// <summary>
        /// 获取搜索配置
        /// </summary>
        SearchConfig GetConfig();
    }
}
