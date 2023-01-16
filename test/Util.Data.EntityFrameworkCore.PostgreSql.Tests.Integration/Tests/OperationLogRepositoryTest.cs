using System.Threading.Tasks;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;
using Xunit;

namespace Util.Data.EntityFrameworkCore.Tests {
    /// <summary>
    /// 操作日志仓储测试
    /// 说明:
    /// 测试自增长long类型标识
    /// </summary>
    public class OperationLogRepositoryTest : TestBase {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IOperationLogRepository _repository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public OperationLogRepositoryTest( IOperationLogRepository operationLogRepository, ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
            _repository = operationLogRepository;
        }

        /// <summary>
        /// 测试添加实体
        /// </summary>
        [Fact]
        public async Task TestAdd() {
            //添加实体
            var entity = OperationLogFakeService.GetOperationLog();
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( entity.Id > 0 );
            Assert.True( await _repository.ExistsAsync( t => t.Id == entity.Id ) );
        }

        /// <summary>
        /// 测试通过标识移除实体 - 物理删除
        /// </summary>
        [Fact]
        public async Task TestRemove_Id() {
            //添加实体
            var entity = OperationLogFakeService.GetOperationLog();
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //移除实体
            await _repository.RemoveAsync( entity.Id );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Null( result );
        }
    }
}
