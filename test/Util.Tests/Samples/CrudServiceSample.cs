using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Datas.UnitOfWorks;
using Util.Domains.Repositories;
using Util.Maps;

namespace Util.Tests.Samples {
    /// <summary>
    /// 增删改查服务样例
    /// </summary>
    public interface ICrudServiceSample : ICrudService<DtoSample, QueryParameterSample> {
    }

    /// <summary>
    /// 工作单元样例
    /// </summary>
    public class UnitOfWorkSample : IUnitOfWork {
        public void Dispose() {
        }

        public int Commit() {
            return 1;
        }

        public Task<int> CommitAsync() {
            return Task.FromResult( 1 );
        }
    }

    /// <summary>
    /// 增删改查服务样例
    /// </summary>
    public class CrudServiceSample : CrudServiceBase<EntitySample, DtoSample, QueryParameterSample> ,ICrudServiceSample {
        public CrudServiceSample( IUnitOfWork unitOfWork, IRepositorySample repository ) : base( unitOfWork, repository ) {
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
