using System;
using Microsoft.Extensions.Configuration;

namespace Util.Search.ElasticSearch.Configs {
    /// <summary>
    /// 搜索配置提供器
    /// </summary>
    public class DefaultConfigProvider : IConfigProvider {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 初始化搜索配置提供器
        /// </summary>
        /// <param name="configuration">配置</param>
        public DefaultConfigProvider( IConfiguration configuration ) {
            _configuration = configuration ?? throw new ArgumentNullException( nameof( configuration ) );
        }

        /// <summary>
        /// 获取搜索配置
        /// </summary>
        public SearchConfig GetConfig() {
            var result = new SearchConfig {
                ConnectionString = _configuration["ElasticSearch:ConnectionString"]
            };
            return result;
        }
    }
}
