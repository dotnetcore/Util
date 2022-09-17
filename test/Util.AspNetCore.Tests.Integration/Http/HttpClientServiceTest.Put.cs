using System.Threading.Tasks;
using Util.AspNetCore.Tests.Samples;
using Xunit;

namespace Util.AspNetCore.Tests.Http {
    /// <summary>
    /// Http�ͻ��˲��� - Put����
    /// </summary>
    public partial class HttpClientServiceTest {
        /// <summary>
        /// ���Ե���Put�������� - �����ַ������
        /// </summary>
        [Fact]
        public async Task TestPut_1() {
            var dto = new CustomerDto { Code = "a" };
            var result = await _client.Put( "/api/test3/update", dto ).GetResultAsync();
            Assert.Equal( "ok:a", result );
        }

        /// <summary>
        /// ���Ե���Put���� - ���ط��ͽ��
        /// </summary>
        [Fact]
        public async Task TestPut_2() {
            var date = "2022-09-02 19:26:32";
            var dto = new CustomerDto { Code = "a",Birthday = date.ToDateTime() };
            var result = await _client.Put<CustomerDto>( "/api/test3/2", dto ).GetResultAsync();
            Assert.Equal( "2", result?.Id );
            Assert.Equal( "a", result?.Code );
            Assert.Equal( date, result?.Birthday.ToDateTimeString() );
        }
    }
}
