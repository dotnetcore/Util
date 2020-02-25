using System;
using Nest;
using Util.Search.ElasticSearch.Services;

namespace Util.Search.ElasticSearch {
    /// <summary>
    /// ElasticSearch客户端扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <param name="source">服务</param>
        public static ElasticClient GetClient<T>( this T source ) where T : IElasticSearch {
            if ( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if ( !( source is IElasticSearchClient client ) )
                throw new NotImplementedException();
            return client.GetClient();
        }
    }
}
