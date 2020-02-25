using System.Collections.Generic;
using System.Threading.Tasks;
using Nest;
using Util.Applications.Dtos;

namespace Util.Search.ElasticSearch {
    /// <summary>
    /// ElasticSearch索引扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加文档
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="document">文档对象</param>
        /// <param name="index">索引名称，注意：必须小写</param>
        /// <param name="id">文档标识</param>
        public static async Task<IndexResponse> AddAsync<TDocument>( this IElasticSearch source, TDocument document, string index = null,string id = null ) where TDocument : class {
            source.CheckNull( nameof(source) );
            document.CheckNull( nameof( document ) );
            index = GetIndex<TDocument>( index );
            id = GetId( document,id );
            if( id.IsEmpty() )
                return await source.GetClient().IndexAsync( document, t => t.Index( index ) );
            return await source.GetClient().IndexAsync( document, t => t.Index( index ).Id( id ) );
        }

        /// <summary>
        /// 获取索引名
        /// </summary>
        public static string GetIndex<TDocument>( string index = null ) {
            if ( index.IsEmpty() == false )
                return index;
            return typeof(TDocument).Name.ToLower();
        }

        /// <summary>
        /// 获取标识
        /// </summary>
        private static string GetId<TDocument>( TDocument document, string id ) {
            if ( id.IsEmpty() == false )
                return id;
            if ( !( document is IKey entity ) )
                return null;
            return entity.Id;
        }

        /// <summary>
        /// 批量添加文档列表
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="documents">文档对象列表</param>
        /// <param name="index">索引名称，注意：必须小写</param>
        /// <param name="timeout">超时时间间隔，单位：毫秒，默认值：300000，即5分钟</param>
        public static async Task<BulkResponse> AddListAsync<TDocument>( this IElasticSearch source, IEnumerable<TDocument> documents,
            string index = null,double timeout = 300000 ) where TDocument : class {
            source.CheckNull( nameof( source ) );
            documents.CheckNull( nameof( documents ) );
            index = GetIndex<TDocument>( index );
            return await source.GetClient().BulkAsync( t => t.Index( index ).IndexMany( documents ).Timeout( timeout ) );
        }

        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="source">服务</param>
        /// <param name="id">文档标识</param>
        /// <param name="index">索引名称，注意：必须小写</param>
        public static async Task<DeleteResponse> DeleteAsync<TDocument>( this IElasticSearch source, string id, string index = null ) where TDocument : class {
            source.CheckNull( nameof( source ) );
            index = GetIndex<TDocument>( index );
            return await source.GetClient().DeleteAsync<TDocument>( id, t => t.Index( index ) );
        }
    }
}
