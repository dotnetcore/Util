using System.Threading.Tasks;
using Util.Applications;
using Util.Datas.Sql;
using Util.Domains.Repositories;
using Util.Exceptions;
using Util.Maps;
using Util.Samples.Data;
using Util.Samples.Domain.Models;
using Util.Samples.Domain.Repositories;
using Util.Samples.Service.Abstractions.Systems;
using Util.Samples.Service.Dtos.Systems;
using Util.Samples.Service.Queries.Systems;

namespace Util.Samples.Service.Implements.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<Application, ApplicationDto, ApplicationQuery>, IApplicationService {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        /// <param name="sqlQuery">Sql查询对象</param>
        public ApplicationService( ISampleUnitOfWork unitOfWork, IApplicationRepository applicationRepository, ISqlQuery sqlQuery )
            : base( unitOfWork, applicationRepository ) {
            ApplicationRepository = applicationRepository;
            SqlQuery = sqlQuery;
        }

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IApplicationRepository ApplicationRepository { get; set; }
        /// <summary>
        /// Sql查询对象
        /// </summary>
        public ISqlQuery SqlQuery { get; }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ApplicationDto ToDto( Application entity ) {
            if( entity == null )
                return new ApplicationDto();
            return entity.MapTo<ApplicationDto>();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override Application ToEntity( ApplicationDto dto ) {
            if( dto == null )
                return new Application();
            return dto.MapTo( new Application( dto.Id.ToGuid() ) );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询参数</param>
        public override async Task<PagerList<ApplicationDto>> PagerQueryAsync( ApplicationQuery query ) {
            return await SqlQuery
                .Select<Application>( true )
                .From<Application>( "a" )
                .WhereIfNotEmpty<Application>( t => t.Code.Contains( query.Code ) )
                .WhereIfNotEmpty<Application>( t => t.Name.Contains( query.Name ) )
                .WhereIfNotEmpty<Application>( t => t.Comment.Contains( query.Comment ) )
                .OrIfNotEmpty<Application>( t => t.Code.Contains( query.Keyword ), t => t.Name.Contains( query.Keyword ) )
                .ToPagerListAsync<ApplicationDto>( query );
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected override async Task CreateBeforeAsync( Application entity ) {
            await base.CreateBeforeAsync( entity );
            if( await ApplicationRepository.ExistsAsync( t => t.Code == entity.Code ) )
                ThrowCodeRepeatException( entity.Code );
            if( await ApplicationRepository.ExistsAsync( t => t.Name == entity.Name ) )
                ThrowNameRepeatException( entity.Name );
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        private void ThrowCodeRepeatException( string code ) {
            throw new Warning( $"应用程序编码 {code} 已存在" );
        }

        /// <summary>
        /// 抛出名称重复异常
        /// </summary>
        private void ThrowNameRepeatException( string name ) {
            throw new Warning( $"应用程序名称 {name} 已存在" );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override async Task UpdateBeforeAsync( Application entity ) {
            await base.UpdateBeforeAsync( entity );
            if( await ApplicationRepository.ExistsAsync( t => t.Id != entity.Id && t.Code == entity.Code ) )
                ThrowCodeRepeatException( entity.Code );
            if( await ApplicationRepository.ExistsAsync( t => t.Id != entity.Id && t.Name == entity.Name ) )
                ThrowNameRepeatException( entity.Name );
        }
    }
}