namespace Util.Microservices.Dapr.WebApiSample.Controllers;

/// <summary>
/// 测试1控制器 - 用于测试使用HttpClient获取字符串结果
/// </summary>
[ApiController]
[Route("Test1")]
public class Test1Controller : ControllerBase {
    /// <summary>
    /// HttpGet访问,返回字符串
    /// </summary>
    [HttpGet]
    public string Get_1() {
        return "ok";
    }

    /// <summary>
    /// HttpGet访问,传入参数
    /// </summary>
    [HttpGet( "{id}" )]
    public string Get_2( string id ) {
        return $"id:{id}";
    }
}