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
        /// 测试添加实体 - 自动清除字符串两端空白
        /// </summary>
        [Fact]
        public async Task TestAddAsync() {
            //添加实体
            var entity = TagFakeService.GetTag();
            entity.Init();
            entity.Name = "                         a                                ";
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.True( result != null );
            Assert.Equal( "a",result.Name );
        }
    }
}