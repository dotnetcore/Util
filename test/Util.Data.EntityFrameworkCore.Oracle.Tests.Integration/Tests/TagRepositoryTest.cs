using System.Threading.Tasks;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;
using Xunit;

namespace Util.Data.EntityFrameworkCore.Tests {
    /// <summary>
    /// 标签仓储测试
    /// </summary>
    public class TagRepositoryTest : TestBase {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly ITagRepository _repository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TagRepositoryTest( ITagRepository repository, ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
            _repository = repository;
        }

        /// <summary>
        /// 测试添加实体
        /// </summary>
        [Fact]
        public async Task TestAddAsync() {
            //添加实体
            var entity = TagFakeService.GetTag();
            entity.Init();
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            Assert.True( await _repository.ExistsAsync( t => t.Id == entity.Id ) );
        }
    }
}