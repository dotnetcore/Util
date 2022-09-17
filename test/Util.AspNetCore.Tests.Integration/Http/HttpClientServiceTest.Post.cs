using System.Collections.Generic;
using System.Threading.Tasks;
using Util.AspNetCore.Tests.Samples;
using Xunit;

namespace Util.AspNetCore.Tests.Http {
    /// <summary>
    /// Http客户端测试 - Post操作
    /// </summary>
    public partial class HttpClientServiceTest {
        /// <summary>
        /// 测试Post调用 - 返回字符串结果
        /// </summary>
        [Fact]
        public async Task TestPost_1() {
            var dto = new CustomerDto { Code = "a" };
            var result = await _client.Post( "/api/test2/create", dto ).GetResultAsync();
            Assert.Equal( "ok:a", result );
        }

        /// <summary>
        /// 测试Post调用 - 返回泛型结果
        /// </summary>
        [Fact]
        public async Task TestPost_2() {
            var dto = new CustomerDto { Code = "a" };
            var result = await _client.Post<CustomerDto>( "/api/test2", dto ).GetResultAsync();
            Assert.Equal( "a", result.Code );
        }

        /// <summary>
        /// 测试Post调用 - 使用Content方法传递参数 - 键值对
        /// </summary>
        [Fact]
        public async Task TestPost_Content_1() {
            var result = await _client.Post( "/api/test2/create" ).Content( "code","a" ).GetResultAsync();
            Assert.Equal( "ok:a", result );
        }

        /// <summary>
        /// 测试Post调用 - 使用Content方法传递参数 - 字典
        /// </summary>
        [Fact]
        public async Task TestPost_Content_2() {
            var dic = new Dictionary<string, string> { { "code", "a" } };
            var result = await _client.Post( "/api/test2/create" ).Content( dic ).GetResultAsync();
            Assert.Equal( "ok:a", result );
        }

        /// <summary>
        /// 测试Post调用 - 使用Content方法传递参数 - 对象
        /// </summary>
        [Fact]
        public async Task TestPost_Content_3() {
            var dto = new CustomerDto { Code = "a" };
            var result = await _client.Post( "/api/test2/create" ).Content( dto ).GetResultAsync();
            Assert.Equal( "ok:a", result );
        }
    }
}
