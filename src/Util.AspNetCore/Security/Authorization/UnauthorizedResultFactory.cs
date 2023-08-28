using Util.Applications;

namespace Util.Security.Authorization;

/// <summary>
/// 未授权返回结果工厂
/// </summary>
public class UnauthorizedResultFactory : IUnauthorizedResultFactory {
    /// <inheritdoc />
    public virtual int HttpStatusCode => 200;

    /// <inheritdoc />
    public virtual object CreateResult( HttpContext context ) {
        return new { Code = StateCode.Unauthorized };
    }
}