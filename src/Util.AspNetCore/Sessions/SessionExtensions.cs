namespace Util.Sessions; 

/// <summary>
/// 用户会话扩展
/// </summary>
public static class SessionExtensions {
    /// <summary>
    /// 获取当前操作人标识
    /// </summary>
    /// <param name="session">用户会话</param>
    public static Guid GetUserId( this ISession session ) {
        return session.UserId.ToGuid();
    }

    /// <summary>
    /// 获取当前操作人标识
    /// </summary>
    /// <param name="session">用户会话</param>
    public static T GetUserId<T>( this ISession session ) {
        return Util.Helpers.Convert.To<T>( session.UserId );
    }
}