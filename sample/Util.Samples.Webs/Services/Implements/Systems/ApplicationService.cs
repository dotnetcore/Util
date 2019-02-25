﻿using System.Threading.Tasks;
using Util.Domains.Repositories;
using Util.Applications;
using Util.Datas.Sql;
using Util.Events;
using Util.Exceptions;
using Util.Maps;
using Util.Samples.Webs.Datas;
using Util.Samples.Webs.Domains.Models;
using Util.Samples.Webs.Domains.Repositories;
using Util.Samples.Webs.Services.Abstractions.Systems;
using Util.Samples.Webs.Services.Dtos.Systems;
using Util.Samples.Webs.Services.Queries.Systems;
using Util.Security.Properties;

namespace Util.Samples.Webs.Services.Implements.Systems {
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
        /// <param name="eventBus">事件总线</param>
        public ApplicationService( ISampleUnitOfWork unitOfWork, IApplicationRepository applicationRepository, ISqlQuery sqlQuery, IEventBus eventBus )
            : base( unitOfWork, applicationRepository ) {
            ApplicationRepository = applicationRepository;
            SqlQuery = sqlQuery;
            EventBus = eventBus;
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
        /// 事件总线
        /// </summary>
        public IEventBus EventBus { get; }

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
                .Select<Application>( t => new object[] { t.Id, t.Code, t.Comment, t.Enabled, t.Name, t.RegisterEnabled, t.CreationTime }, true )
                .From<Application>( "a" )
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
            throw new Warning( string.Format( SecurityResource.DuplicateApplicationCode, code ) );
        }

        /// <summary>
        /// 抛出名称重复异常
        /// </summary>
        private void ThrowNameRepeatException( string name ) {
            throw new Warning( string.Format( SecurityResource.DuplicateApplicationName, name ) );
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