using System.Threading.Tasks;
using Util.AspNetCore.Tests.Samples;
using Xunit;

namespace Util.AspNetCore.Tests.Http {
    /// <summary>
    /// Http�ͻ��˲��� - Delete����
    /// </summary>
    public partial class HttpClientServiceTest {
        /// <summary>
        /// ���Ե���Delete�������� - �����ַ������
        /// </summary>
        [Fact]
        public async Task TestDelete_1() {
            var result = await _client.Delete( "/api/test4/delete/1" ).GetResultAsync();
            Assert.Equal( "ok:1", result );
        }

        /// <summary>
        /// ���Ե���Put���� - ���ط��ͽ��
        /// </summary>
        [Fact]
        public async Task TestDelete_2() {
            var result = await _client.Delete<CustomerDto>( "/api/test4/1" ).GetResultAsync();
            Assert.Equal( "1", result.Code );
        }
    }
}
