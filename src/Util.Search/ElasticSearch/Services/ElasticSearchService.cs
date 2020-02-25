using System;
using Nest;
using Util.Search.ElasticSearch.Configs;

namespace Util.Search.ElasticSearch.Services {
    /// <summary>
    /// ElasticSearch服务
    /// </summary>
    public class ElasticSearchService : IElasticSearchClient, IElasticSearch {
        /// <summary>
        /// 搜索配置
        /// </summary>
        private readonly SearchConfig _config;
        /// <summary>
        /// ElasticSearch客户端
        /// </summary>
        private ElasticClient _client;

        /// <summary>
        /// 初始化ElasticSearch服务
        /// </summary>
        /// <param name="configProvider">搜索配置提供器</param>
        public ElasticSearchService( IConfigProvider configProvider ) {
            configProvider.CheckNull( nameof( configProvider ) );
            _config = configProvider.GetConfig();
        }

        /// <summary>
        /// 获取ElasticSearch Nest客户端
        /// </summary>
        public ElasticClient GetClient() {
            if ( _client != null )
                return _client;
            var settings = GetSettings();
            _client = new ElasticClient( settings );
            return _client;
        }

        /// <summary>
        /// 获取连接配置
        /// </summary>
        private ConnectionSettings GetSettings() {
            var uri = new Uri( _config.ConnectionString );
            return new ConnectionSettings( uri );
        }
    }
}
