using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace Util.Search.ElasticSearch {
    /// <summary>
    /// ElasticSearch索引扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 检测索引别名是否存在
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="alias">别名</param>
        public static async Task<bool> AliasExistsAsync( this IElasticSearch source, string alias ) {
            source.CheckNull( nameof( source ) );
            if ( alias.IsEmpty() )
                return false;
            var result = await source.GetClient().Indices.AliasExistsAsync( alias );
            return result.Exists;
        }

        /// <summary>
        /// 获取索引名称列表
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="alias">别名</param>
        public static async Task<List<string>> GetIndexesByAliasAsync( this IElasticSearch source, string alias ) {
            source.CheckNull( nameof( source ) );
            if ( alias.IsEmpty() )
                return new List<string>();
            var result = await source.GetClient().GetIndicesPointingToAliasAsync( alias );
            return result.ToList();
        }

        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="index">索引名称，注意：必须小写</param>
        /// <param name="alias">别名名称，注意：必须小写</param>
        /// <param name="selector">映射操作</param>
        public static async Task<CreateIndexResponse> CreateIndexAsync( this IElasticSearch source, string index, string alias = null,
            Func<CreateIndexDescriptor, ICreateIndexRequest> selector = null ) {
            source.CheckNull( nameof( source ) );
            var client = source.GetClient();
            var result = await client.Indices.CreateAsync( index, selector );
            if ( alias.IsEmpty() == false )
                await client.Indices.PutAliasAsync( index, alias );
            return result;
        }

        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="source">服务</param>
        public static async Task<DeleteIndexResponse> DeleteIndexAsync<TDocument>( this IElasticSearch source ) where TDocument : class {
            var index = GetIndex<TDocument>();
            return await DeleteIndexAsync( source, index );
        }

        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="index">索引名称，注意：必须小写</param>
        public static async Task<DeleteIndexResponse> DeleteIndexAsync( this IElasticSearch source, string index ) {
            source.CheckNull( nameof( source ) );
            return await source.GetClient().Indices.DeleteAsync( index );
        }

        /// <summary>
        /// 通过别名删除索引集合
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="alias">别名</param>
        public static async Task DeleteIndexesByAliasAsync( this IElasticSearch source, string alias ) {
            source.CheckNull( nameof( source ) );
            if ( alias.IsEmpty() )
                return;
            var indexes = await GetIndexesByAliasAsync( source, alias );
            foreach ( var index in indexes )
                await DeleteIndexAsync( source, index );
        }

        /// <summary>
        /// 删除全部索引
        /// </summary>
        /// <param name="source">服务</param>
        public static async Task<DeleteIndexResponse> DeleteAllIndexAsync( this IElasticSearch source ) {
            return await DeleteIndexAsync( source, "_all" );
        }

        /// <summary>
        /// 添加索引列表到别名
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="alias">别名</param>
        /// <param name="indexes">索引名称列表</param>
        public static async Task AddIndexesToAliasAsync( this IElasticSearch source, string alias, params string[] indexes ) {
            source.CheckNull( nameof( source ) );
            if ( alias.IsEmpty() )
                return;
            foreach ( var index in indexes )
                await source.GetClient().Indices.PutAliasAsync( index, alias );
        }

        /// <summary>
        /// 从别名中移除索引列表
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="alias">别名</param>
        /// <param name="indexes">索引名称列表</param>
        public static async Task RemoveIndexesFromAliasAsync( this IElasticSearch source, string alias, params string[] indexes ) {
            source.CheckNull( nameof( source ) );
            if ( alias.IsEmpty() )
                return;
            foreach ( var index in indexes ) 
                await source.GetClient().Indices.DeleteAliasAsync( index, alias );
        }
    }
}
