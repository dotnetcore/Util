using System;
using System.Threading.Tasks;
using Util.Applications.Trees;
using Util.Tests.Dtos;
using Util.Tests.Models;
using Util.Tests.Queries;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.Services {
    /// <summary>
    /// 资源服务
    /// </summary>
    public class ResourceService : TreeServiceBase<Resource,ResourceDto,ResourceQuery>, IResourceService {
        /// <summary>
        /// 仓储
        /// </summary>
        private IResourceRepository _repository;

        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        public ResourceService( IServiceProvider serviceProvider,ITestUnitOfWork unitOfWork, IResourceRepository repository ) : base( serviceProvider,unitOfWork,repository ) {
            _repository = repository;
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected override async Task CreateBeforeAsync( Resource entity ) {
            entity.SortId = await _repository.GenerateSortIdAsync( entity.ParentId );
        }
    }
}