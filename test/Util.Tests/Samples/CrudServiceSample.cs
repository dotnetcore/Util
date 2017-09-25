using Util.Applications;
using Util.Applications.Aspects;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Maps;

namespace Util.Tests.Samples {
    /// <summary>
    /// 增删改查服务样例
    /// </summary>
    public interface ICrudServiceSample : ICrudService<DtoSample, QueryParameterSample> {
    }

    /// <summary>
    /// 增删改查服务样例
    /// </summary>
    public class CrudServiceSample : CrudServiceBase<EntitySample, DtoSample, QueryParameterSample> ,ICrudServiceSample {
        public CrudServiceSample( IRepositorySample repository ) : base( repository ) {
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
            return new Query<EntitySample>( parameter );
        }
    }
}
