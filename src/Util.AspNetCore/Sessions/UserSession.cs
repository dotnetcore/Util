using Util.Helpers;

namespace Util.Sessions; 

/// <summary>
/// 用户会话
/// </summary>
public class UserSession : ISession {
    /// <summary>
    /// 空用户会话
    /// </summary>
    public static readonly ISession Null = NullSession.Instance;

    /// <summary>
    /// 用户会话实例
    /// </summary>
    public static readonly ISession Instance = new UserSession();

    /// <inheritdoc />
    public virtual IServiceProvider ServiceProvider => Web.ServiceProvider;

    /// <inheritdoc />
    public virtual bool IsAuthenticated => Web.Identity.IsAuthenticated;

    /// <inheritdoc />
    public virtual string UserId {
        get {
            var result = Web.Identity.GetValue( ClaimTypes.UserId );
            return result.IsEmpty() ? Web.Identity.GetValue( System.Security.Claims.ClaimTypes.NameIdentifier ) : result;
        }
    }

    /// <inheritdoc />
    public virtual string TenantId => Web.Identity.GetValue( ClaimTypes.TenantId );
}