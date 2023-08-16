using Util.Exceptions;
using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.ServiceInvocations; 

/// <summary>
/// 服务调用测试 - Web Api接口测试 - 不进行解包
/// 说明: 请求项目 Util.Microservices.Dapr.WebApiSample
/// </summary>
public partial class ServiceInvocationTest {

    #region 测试无参数无返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test2Controller控制器Get方法 - 无参数,无返回值 - 成功
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_NotUnpack_1() {
        await _serviceInvocation.UnpackResult( false ).InvokeAsync( "/Test2" );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test2Controller控制器Get_Fail方法 - 无参数,无返回值 - 失败,抛出异常
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_NotUnpack_2() {
        await Assert.ThrowsAsync<Warning>( async () => {
            await _serviceInvocation.UnpackResult( false ).InvokeAsync( "/Test2/fail" );
        } );
    }

    #endregion

    #region 测试有参数无返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test2Controller控制器Post方法 - 有参数,无返回值 - Code参数为2,成功
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_NotUnpack_3() {
        var dto = new CustomerDto { Code = "2" };
        await _serviceInvocation.UnpackResult( false ).InvokeAsync( "/Test2", dto );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test2Controller控制器Post方法 - 有参数,无返回值 - Code参数为1,返回失败消息
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_NotUnpack_4() {
        await Assert.ThrowsAsync<Warning>( async () => {
            var dto = new CustomerDto { Code = "1" };
            await _serviceInvocation.UnpackResult( false ).InvokeAsync( "/Test2", dto );
        } );
    }

    #endregion

    #region 测试无参数有返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test2Controller控制器Get_Customer方法 - 无参数,有返回值
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_NotUnpack_5() {
        var result = await _serviceInvocation.UnpackResult( false ).InvokeAsync<CustomerDto>( "/Test2/customer" );
        Assert.Equal( "ok", result.Name );
    }

    #endregion

    #region 测试有参数有返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test2Controller控制器Query方法 - 有参数,有返回值
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_NotUnpack_6() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation.UnpackResult( false ).InvokeAsync<CustomerDto>( "/Test2/query", query );
        Assert.Equal( "ok", result.Name );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test2Controller控制器Query方法 - 有参数,有返回值 - 请求参数使用泛型
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_NotUnpack_7() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation.UnpackResult( false ).InvokeAsync<CustomerQuery, CustomerDto>( "/Test2/query", query );
        Assert.Equal( "ok", result.Name );
    }

    #endregion
}