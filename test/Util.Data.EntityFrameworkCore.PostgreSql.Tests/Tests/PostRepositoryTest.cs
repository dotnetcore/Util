using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Data.EntityFrameworkCore.Fakes;
using Util.Data.EntityFrameworkCore.Infrastructure;
using Util.Data.EntityFrameworkCore.Repositories;
using Util.Data.EntityFrameworkCore.UnitOfWorks;
using Xunit;

namespace Util.Data.EntityFrameworkCore.Tests {
    /// <summary>
    /// 贴子仓储测试
    /// 说明:
    /// 1. 测试多对多
    /// </summary>
    public class PostRepositoryTest : TestBase {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IPostRepository _repository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PostRepositoryTest(IPostRepository repository, IPgSqlUnitOfWork unitOfWork ) : base(unitOfWork){
            _repository = repository;
        }

        /// <summary>
        /// 测试添加实体
        /// </summary>
        [Fact]
        public async Task TestAddAsync() {
            //添加实体
            var post = PostFakeService.GetPost();
            post.Init();
            var tag1 = TagFakeService.GetTag();
            tag1.Init();
            post.Tags.Add( tag1 );

            var tag2 = TagFakeService.GetTag();
            tag2.Init();
            post.Tags.Add( tag2 );

            await _repository.AddAsync( post );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.SingleAsync( t => t.Id == post.Id, queryable => queryable.Include( t => t.Tags ) );
            Assert.NotNull( result );
            Assert.Equal( 2,result.Tags.Count );
        }
    }
}