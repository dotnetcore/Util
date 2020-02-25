using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Datas.Queries;
using Util.Search.ElasticSearch.Services;

namespace Util.Search.ElasticSearch {
    /// <summary>
    /// ElasticSearch搜索扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取全部数据，说明：最多返回10000条
        /// </summary>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <param name="source">服务</param>
        /// <param name="index">索引名称，注意：必须小写</param>
        public static async Task<List<TResult>> GetAllAsync<TResult>( this IElasticSearch source, string index = null ) where TResult : class {
            source.CheckNull( nameof( source ) );
            index = GetIndex<TResult>( index );
            var result = await source.GetClient().SearchAsync<TResult>( s => s.Index( index ).Size( 10000 ).Query( q => q.MatchAll() ) );
            return result.Documents.ToList();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <param name="source">服务</param>
        /// <param name="query">查询参数</param>
        public static Search<TResult> Search<TResult>( this IElasticSearch source, IQueryParameter query ) where TResult : class {
            source.CheckNull( nameof( source ) );
            query.CheckNull( nameof( query ) );
            return new Search<TResult>( source, query );
        }
    }
}
