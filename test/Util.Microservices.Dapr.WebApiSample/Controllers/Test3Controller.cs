using Microsoft.AspNetCore.Authorization;
using Util.Applications.Controllers;
using Util.Data;
using Util.Exceptions;
using Util.Microservices.Dapr.WebApiSample.Dtos;

namespace Util.Microservices.Dapr.WebApiSample.Controllers;

/// <summary>
/// 测试3控制器 - 用于测试包装结果对象
/// </summary>
public class Test3Controller : WebApiControllerBase {
    /// <summary>
    /// 测试Get方法访问 - 无参数 - 无返回值 - 成功
    /// </summary>
    [HttpGet]
    public IActionResult Get() {
        return Success();
    }

    /// <summary>
    /// 测试Get方法访问 - 无参数 - 无返回值 - 失败
    /// </summary>
    [HttpGet("fail")]
    public IActionResult Get_Fail() {
        return Fail( "fail" );
    }

    /// <summary>
    /// 测试Post方法访问 - 有参数 - 无返回值
    /// </summary>
    [HttpPost]
    public IActionResult Post( CustomerDto dto ) {
        if ( dto.Code != "2" )
            throw new Warning( "id必须为2" );
        return Success();
    }

    /// <summary>
    /// 测试Get方法访问 - 无参数 - 有返回值
    /// </summary>
    [HttpGet( "customer" )]
    public IActionResult Get_Customer() {
        var dto = new CustomerDto {
            Name = "ok"
        };
        return Success( dto );
    }

    /// <summary>
    /// 测试Get方法访问 - 有参数 - 有返回值
    /// </summary>
    [HttpGet( "query" )]
    public IActionResult Query( [FromQuery] CustomerQuery query ) {
        var dto = new CustomerDto {
            Name = query.Name
        };
        return Success( dto );
    }

    /// <summary>
    /// 测试自定义地址
    /// </summary>
    [HttpGet( "/query" )]
    public IActionResult Query2( [FromQuery] CustomerQuery query ) {
        var dto = new CustomerDto {
            Name = query.Name
        };
        return Success( dto );
    }

    /// <summary>
    /// 测试需要身份认证
    /// </summary>
    [HttpGet( "query_authorize" )]
    [Authorize]
    public IActionResult Query_Authorize( [FromQuery] CustomerQuery query ) {
        var dto = new CustomerDto {
            Name = query.Name
        };
        return Success( dto );
    }

    /// <summary>
    /// 测试分页对象
    /// </summary>
    [HttpGet( "page_query" )]
    public IActionResult PageQuery( [FromQuery] CustomerQuery query ) {
        PageList<CustomerDto> result = new PageList<CustomerDto>();
        result.Total = 50;
        result.Data.Add( new CustomerDto {
            Name = query.Name
        } );
        return Success( result );
    }

    /// <summary>
    /// 测试添加请求头
    /// </summary>
    [HttpGet( "query_header" )]
    public IActionResult Query2_Header_1( [FromQuery] CustomerQuery query ) {
        var customerCode = Request.Headers["CustomerCode"].FirstOrDefault();
        var customerName =  Request.Headers["CustomerName"].FirstOrDefault();
        var test_1 = Request.Headers["test_1"].FirstOrDefault();
        var dto = new CustomerDto {
            Code = customerCode,
            Name = customerName
        };
        return Success( dto );
    }

    /// <summary>
    /// 测试导入请求头
    /// </summary>
    [HttpGet( "query_header_import" )]
    public IActionResult Query2_Header_2( [FromQuery] CustomerQuery query ) {
        var test_1 = Request.Headers["test_1"].FirstOrDefault();
        var contentLanguage = Request.Headers.ContentLanguage.FirstOrDefault();
        var dto = new CustomerDto {
            Code = test_1,
            Name = contentLanguage
        };
        return Success( dto );
    }
}