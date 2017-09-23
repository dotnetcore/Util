using Util.Applications;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Maps;

namespace Util.Tests.Samples {
    /// <summary>
    /// 数据传输对象样例
    /// </summary>
    public class DtoSample : DtoBase {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 查询服务样例
    /// </summary>
    public class QueryServiceSample : QueryServiceBase<EntitySample, DtoSample, QueryParameterSample> {
        public QueryServiceSample( IRepositorySample repository ) : base( repository ) {
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override DtoSample ToDto( EntitySample entity ) {
            return entity.MapTo<DtoSample>();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override EntitySample ToEntity( DtoSample dto ) {
            return dto.MapTo( new EntitySample( dto.Id.ToGuid() ) );
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="parameter">查询参数</param>
        protected override IQueryBase<EntitySample> CreateQuery( QueryParameterSample parameter ) {
            return new Query<EntitySample>( parameter ).WhereIfNotEmpty( t => t.Name == parameter.Name );
        }

        /// <summary>
        /// 查询时是否跟踪对象
        /// </summary>
        protected override bool IsTracking => true;
    }
}
