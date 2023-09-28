using System.Threading.Tasks;
using Util.Applications;
using Util.Http;
using Util.Microservices;
using Xunit;

namespace Util.AspNetCore.Tests.Authorization; 

/// <summary>
/// 授权访问测试
/// </summary>
public class AclTest {
    /// <summary>
    /// Http客户端
    /// </summary>
    private readonly IHttpClient _client;

    /// <summary>
    /// 测试初始化
    /// </summary>
    /// <param name="client">Http客户端</param>
    public AclTest( IHttpClient client ) {
        _client = client;
    }

    /// <summary>
    /// 测试未授权
    /// </summary>
    [Fact]
    public async Task Test() {
        var result = await _client.Get<ServiceResult<object>>( "/api/test5/1" ).GetResultAsync();
        Assert.Equal( StateCode.Unauthorized, result.Code );
    }
}