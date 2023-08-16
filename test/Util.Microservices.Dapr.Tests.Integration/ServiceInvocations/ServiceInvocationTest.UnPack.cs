using System.Collections.Generic;
using Util.Data;
using Util.Exceptions;
using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.ServiceInvocations;

/// <summary>
/// 服务调用测试 - Web Api接口测试 - 使用ServiceResult解包
/// 说明: 请求项目 Util.Microservices.Dapr.WebApiSample
/// </summary>
public partial class ServiceInvocationTest {

    #region 测试无参数无返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Get方法 - 无参数,无返回值 - 状态码为成功
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_1() {
        await _serviceInvocation.InvokeAsync( "/api/Test3" );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Get_Fail方法 - 无参数,无返回值 - 状态码为失败,抛出异常
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_2() {
        await Assert.ThrowsAsync<Warning>( async () => {
            await _serviceInvocation.InvokeAsync( "/api/Test3/fail" );
        } );
    }

    #endregion

    #region 测试有参数无返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Post方法 - 有参数,无返回值 - Code参数为2,返回成功
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_3() {
        var dto = new CustomerDto { Code = "2" };
        await _serviceInvocation.InvokeAsync( "/api/Test3", dto );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Post方法 - 有参数,无返回值 - Code参数为1,返回失败消息
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_4() {
        await Assert.ThrowsAsync<Warning>( async () => {
            var dto = new CustomerDto { Code = "1" };
            await _serviceInvocation.InvokeAsync( "/api/Test3", dto );
        } );
    }

    #endregion

    #region 测试无参数有返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Get_Customer方法 - 无参数,有返回值
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_5() {
        var result = await _serviceInvocation.InvokeAsync<CustomerDto>( "/api/Test3/customer" );
        Assert.Equal( "ok", result.Name );
    }

    #endregion

    #region 测试有参数有返回值的场景

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Query方法 - 有参数,有返回值
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_6() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation.InvokeAsync<CustomerDto>( "/api/Test3/query", query );
        Assert.Equal( "ok", result.Name );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Query方法 - 有参数,有返回值 - 请求参数使用泛型
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_7() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation.InvokeAsync<CustomerQuery, CustomerDto>( "/api/Test3/query", query );
        Assert.Equal( "ok", result.Name );
    }

    #endregion

    #region 请求地址处理

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Query方法 - 请求地址处理,Test3/query处理为 /api/Test3/query
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_8() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation.InvokeAsync<CustomerDto>( "Test3/query", query );
        Assert.Equal( "ok", result.Name );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Query2方法 - 请求地址以/开头,不进行处理
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_9() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation.InvokeAsync<CustomerDto>( "/query", query );
        Assert.Equal( "ok", result.Name );
    }

    #endregion

    #region 请求头处理

    /// <summary>
    /// 测试设置请求头
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_Header_1() {
        var query = new CustomerQuery();
        var result = await _serviceInvocation.Header( "CustomerName", "abc" ).InvokeAsync<CustomerDto>( "test3/query_header", query );
        Assert.Equal( "abc", result.Name );
    }

    /// <summary>
    /// 测试设置请求头集合
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_Header_2() {
        var query = new CustomerQuery();
        var result = await _serviceInvocation.Header( new Dictionary<string, string> {
            {"CustomerCode","a"},
            {"CustomerName","b"}
        } ).InvokeAsync<CustomerDto>( "test3/query_header", query );
        Assert.Equal( "a", result.Code );
        Assert.Equal( "b", result.Name );
    }

    /// <summary>
    /// 测试移除请求头
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_Header_3() {
        var query = new CustomerQuery();
        var result = await _serviceInvocation.Header( new Dictionary<string, string> {
            {"CustomerCode","a"},
            {"CustomerName","b"}
        } )
        .RemoveHeader( "CustomerCode" )
        .InvokeAsync<CustomerDto>( "test3/query_header", query );
        Assert.Null( result.Code );
        Assert.Equal( "b", result.Name );
    }

    /// <summary>
    /// 测试移除请求头
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_Header_4() {
        Util.Helpers.Web.HttpContextAccessor = new MockHttpContextAccessor();
        var query = new CustomerQuery();
        var result = await _serviceInvocation
            .ImportHeader( "test_1" )
            .InvokeAsync<CustomerDto>( "test3/query_header_import", query );
        Assert.Equal( "test_1", result.Code );
    }

    /// <summary>
    /// 测试导入内容头 - Content-Language
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_ImportHeader_1() {
        Util.Helpers.Web.HttpContextAccessor = new MockHttpContextAccessor();
        var query = new CustomerQuery();
        var result = await _serviceInvocation.ImportHeader( "Content-Language" )
            .InvokeAsync<CustomerDto>( "test3/query_header_import", query );
        Assert.Equal( "en", result.Name );
    }

    #endregion

    #region 测试事件处理

    /// <summary>
    /// 测试状态转换事件处理
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_OnState() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation
            .OnState( ( code ) => ServiceState.Fail )
            .OnFail( async ( request, response, ex ) => {
                query.Phone = "123";
                await Task.CompletedTask;
            } )
            .InvokeAsync<CustomerDto>( "Test3/query", query );
        Assert.Equal( "123", query.Phone );
    }

    /// <summary>
    /// 测试调用前事件处理 - 返回false,不执行
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_OnBefore() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation.OnBefore( request => false ).InvokeAsync<CustomerDto>( "Test3/query", query );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试转换结果事件处理
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_OnResult() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation
            .OnResult( async ( response,options,token ) => {
                var json = await response.Content.ReadAsStringAsync( token );
                var result = Json.ToObject<ServiceResult<CustomerDto>>( json, options );
                result.Data.Phone = "123";
                return result;
            } )
            .InvokeAsync<CustomerDto>( "Test3/query", query );
        Assert.NotNull( result );
        Assert.Equal( "ok", result.Name );
        Assert.Equal( "123", result.Phone );
    }

    /// <summary>
    /// 测试调用成功事件处理
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_OnSuccess() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation
            .OnSuccess<CustomerDto>( async ( request, response, result ) => {
                result.Phone = "123";
                await Task.CompletedTask;
            } )
            .InvokeAsync<CustomerDto>( "Test3/query", query );
        Assert.NotNull( result );
        Assert.Equal( "ok", result.Name );
        Assert.Equal( "123", result.Phone );
    }

    /// <summary>
    /// 测试失败事件处理
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_OnFail() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation
            .OnFail( async ( request, response, ex ) => {
                query.Phone = "123";
                await Task.CompletedTask;
            } )
            .InvokeAsync<CustomerDto>( "Test3/fail", query );
        Assert.Equal( "123", query.Phone );
    }

    /// <summary>
    /// 测试完成事件处理
    /// </summary>
    [Fact]
    public async Task TestInvokeAsync_Unpack_OnComplete() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _serviceInvocation
            .OnComplete( async ( request, response ) => {
                query.Phone = "123";
                await Task.CompletedTask;
            } )
            .InvokeAsync<PageList<CustomerDto>>( "Test3/page_query", query );
        Assert.NotNull( result );
        Assert.Equal( 50, result.Total );
        Assert.Equal( "ok", result.Data[0].Name );
        Assert.Equal( "123", query.Phone );
    }

    #endregion
}