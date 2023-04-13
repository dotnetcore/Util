using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Util.Helpers;
using Util.Http;
using Util.Tests.Infrastructure;
using Xunit;

namespace Util.Applications.Locks {
    /// <summary>
    /// 请求锁过滤器测试
    /// </summary>
    public class LockAttributeTest : ControllerTestBase {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public LockAttributeTest( IHttpClient client, IHttpContextAccessor accessor ) : base(client, accessor ) {
        }

        /// <summary>
        /// 测试未设置防重复过滤器
        /// </summary>
        [Fact]
        public async Task Test_1() {
            var url = "/api/lock/nolock";
            var bag = new ConcurrentBag<WebApiResult<string>>();
            await Thread.ParallelForAync( async () => {
                var result = await GetAsync<string>( url );
                bag.Add( result );
            }, 20 );
            Assert.Equal( 20, bag.ToList().FindAll( t => t.Data == "ok" ).Count );
        }

        /// <summary>
        /// 测试设置防重复过滤器 - 全局锁 - 同一时刻只有一个用户成功执行
        /// </summary>
        [Fact]
        public async Task Test_2() {
            var url = "/api/lock/GlobalLock";
            var bag = new ConcurrentBag<WebApiResult<string>>();
            await Thread.ParallelForAync( async () => {
                var result = await GetAsync<string>( url );
                bag.Add( result );
            }, 20 );
            Assert.Single( bag.ToList().FindAll( t => t.Data == "ok" ));
        }

        /// <summary>
        /// 测试设置防重复过滤器 - 用户锁 - 模拟10个用户,每个用户发送5个请求,结果是每个用户只成功执行一次
        /// </summary>
        [Fact]
        public async Task Test_3() {
            var url = "/api/lock/UserLock";
            var bag = new ConcurrentBag<WebApiResult<string>>();
            await Thread.ParallelForAync( async () => {
                var userId = Id.Create();
                await Thread.ParallelForAync( async () => {
                    var result = await Client.Get<WebApiResult<string>>( url ).Header( "user-id",userId ).GetResultAsync();
                    bag.Add( result );
                }, 5 );
            }, 10 );
            Assert.Equal( 10, bag.ToList().FindAll( t => t.Data == "ok" ).Count );
        }
    }
}
