using System.Collections.Generic;
using System.Threading.Tasks;
using Util.AspNetCore.Tests.Samples;
using Util.Http;
using Xunit;

namespace Util.AspNetCore.Tests.Http {
    /// <summary>
    /// Http�ͻ��˲��� - Get����
    /// </summary>
    public partial class HttpClientServiceTest {

        #region ���Գ�ʼ��

        /// <summary>
        /// Http�ͻ���
        /// </summary>
        private readonly IHttpClient _client;

        /// <summary>
        /// ���Գ�ʼ��
        /// </summary>
        /// <param name="client">Http�ͻ���</param>
        public HttpClientServiceTest( IHttpClient client ) {
            _client = client;
        }

        #endregion

        #region ��������

        /// <summary>
        /// ���Ե���Get����
        /// </summary>
        [Fact]
        public async Task TestGet_1() {
            var result = await _client.Get( "/api/test1" ).GetResultAsync();
            Assert.Equal( "ok", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ����id
        /// </summary>
        [Fact]
        public async Task TestGet_2() {
            var result = await _client.Get( "/api/test1/2" ).GetResultAsync();
            Assert.Equal( "ok:2", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ���ض���
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
        /// ���Ե���Get���� - ��������ͷ
        /// </summary>
        [Fact]
        public async Task TestGet_Header_1() {
            var result = await _client.Get( "/api/test1/header" ).Header( "Authorization", "abc" ).GetResultAsync();
            Assert.Equal( "ok:abc", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ��������ͷ - �����ֵ�
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
        /// ���Ե���Get���� - ����query���� - Ӳ����
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_1() {
            var result = await _client.Get( "/api/test1/query?code=9&name=a" ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ����query����
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_2() {
            var result = await _client.Get( "/api/test1/query" ).QueryString( "code", "9" ).QueryString( "name", "a" ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ����query���� - ����Ӳ����
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_3() {
            var result = await _client.Get( "/api/test1/query?code=9" ).QueryString( "name", "a" ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ����query���� - �����ֵ�
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_4() {
            var queryString = new Dictionary<string, string> { { "code", "9" }, { "name", "a" } };
            var result = await _client.Get( "/api/test1/query" ).QueryString( queryString ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ����query���� - �������
        /// </summary>
        [Fact]
        public async Task TestGet_QueryString_5() {
            var query = new CustomerQuery { Code = "9", Name = "a" };
            var result = await _client.Get( "/api/test1/query" ).QueryString( query ).GetResultAsync();
            Assert.Equal( "code:9,name:a", result );
        }

        /// <summary>
        /// ���Ե���Get���� - ����query���� - ʹ��Get���ط����������
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
