using Microsoft.AspNetCore.Mvc;
using Util.Security;

namespace Util.AspNetCore.Tests.Controllers;

/// <summary>
/// 测试Api控制器5 - 用于测试授权
/// </summary>
[ApiController]
[Route( "api/[controller]" )]
public class Test5Controller : ControllerBase {
    /// <summary>
    /// 操作1
    /// </summary>
    [HttpGet( "1" )]
    [Acl]
    public string Get() {
        return "ok";
    }
}