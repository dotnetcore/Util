using Util.Data.EntityFrameworkCore.Fakes;
using Util.Data.EntityFrameworkCore.Infrastructure;
using Util.Data.EntityFrameworkCore.Repositories;
using Util.Data.EntityFrameworkCore.UnitOfWorks;
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
        public OperationLogRepositoryTest( IOperationLogRepository repository, IPgSqlUnitOfWork unitOfWork ) :base(unitOfWork) {
            _repository = repository;
        }

        /// <summary>
        /// 测试添加实体
        /// </summary>
        [Fact]
        public void TestAdd() {
            //添加实体
            var entity = OperationLogFakeService.GetOperationLog();
            _repository.Add( entity );
            UnitOfWork.Commit();

            //验证
            Assert.True( entity.Id > 0 );
            Assert.True( _repository.Exists( t => t.Id == entity.Id ) );
        }

        /// <summary>
        /// 测试通过标识移除实体 - 物理删除
        /// </summary>
        [Fact]
        public void TestRemove_Id() {
            //添加实体
            var entity = OperationLogFakeService.GetOperationLog();
            _repository.Add( entity );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //移除实体
            _repository.Remove( entity.Id );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.FindById( entity.Id );
            Assert.Null( result );
        }
    }
}
