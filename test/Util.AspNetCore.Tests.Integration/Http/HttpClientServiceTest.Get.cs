using System.Collections.Generic;
using System.Threading.Tasks;
using Util.AspNetCore.Tests.Samples;
using Util.Http;
using Xunit;

namespace Util.AspNetCore.Tests.Http {
    /// <summary>
    /// Http客户端测试 - Get操作
    /// </summary>
    public partial class HttpClientServiceTest {

        #region 测试初始化

        /// <summary>
        /// Http客户端
        /// </summary>
        private readonly IHttpClient _client;

        /// <summary>
        /// 测试初始化
        /// </summary>
        /// <param name="client">Http客户端</param>
        public HttpClientServiceTest( IHttpClient client ) {
            _client = client;
        }

        #endregion

        #region 基础测试

        /// <summary>
        /// 测试调用Get方法
        /// </summary>
        [Fact]
        public async Task TestGet_1() {
            var result = await _client.Get( "/api/test1" ).GetResultAsync();
            Assert.Equal( "ok", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 传递id
        /// </summary>
        [Fact]
        public async Task TestGet_2() {
            var result = await _client.Get( "/api/test1/2" ).GetResultAsync();
            Assert.Equal( "ok:2", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 返回对象
        /// </summary>
        [Fact]
        public async Task TestGet_3() {
            CustomerQuery query = new CustomerQuery { Code = "a", Name = "b" };
            var result = await _client.Get<List<CustomerDto>>( "/api/test1/list", query ).GetResultAsync();
            Assert.Equal( 2, result.Count );
            Assert.Equal( "a", result[0].Code );
            Assert.Equal( "b", result[1].Name );
        }

        #endregion

        #region Header

        /// <summary>
        /// 测试调用Get方法 - 设置请求头
        /// </summary>
        [Fact]
        public async Task TestGet_Header_1() {
            var result = await _client.Get( "/api/test1/header" ).Header( "Authorization", "abc" ).GetResultAsync();
            Assert.Equal( "ok:abc", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 设置请求头 - 传入字典
        /// </summary>
        [Fact]
        public async Task TestGet_Header_2() {
            var headers = new Dictionary<string, string> { { "Authorization", "abc" } };
            var result = await _client.Get( "/api/test1/header" ).Header( headers ).GetResultAsync();
            Assert.Equal( "ok:abc", result );
        }

        #endregion

        #region QueryString

        /// <summary>
        /// 测试调用Get方法 - 发送query参数 - 硬编码
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_1() {
            var result = await _client.Get( "/api/test1/query?code=9&name=a" ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 发送query参数
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_2() {
            var result = await _client.Get( "/api/test1/query" ).QueryString( "code", "9" ).QueryString( "name", "a" ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 发送query参数 - 部分硬编码
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_3() {
            var result = await _client.Get( "/api/test1/query?code=9" ).QueryString( "name", "a" ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 发送query参数 - 传入字典
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_4() {
            var queryString = new Dictionary<string, string> { { "code", "9" }, { "name", "a" } };
            var result = await _client.Get( "/api/test1/query" ).QueryString( queryString ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 发送query参数 - 传入对象
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_5() {
            var query = new CustomerQuery { Code = "9", Name = "a" };
            var result = await _client.Get( "/api/test1/query" ).QueryString( query ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// 测试调用Get方法 - 发送query参数 - 使用Get重载方法传入参数
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_6() {
            var query = new CustomerQuery { Code = "9", Name = "a" };
            var result = await _client.Get( "/api/test1/query", query ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        #endregion
    }
}
