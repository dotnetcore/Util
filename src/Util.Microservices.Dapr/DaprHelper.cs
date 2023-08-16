namespace Util.Microservices.Dapr; 

/// <summary>
/// Dapr辅助操作
/// </summary>
public static class DaprHelper {
    /// <summary>
    /// 应用标识环境变量
    /// </summary>
    public const string DaprAppId = "Dapr_AppId";

    /// <summary>
    /// 设置应用标识环境变量
    /// </summary>
    /// <param name="appId">应用标识</param>
    public static void SetAppId( string appId ) {
        Environment.SetEnvironmentVariable( DaprAppId, appId );
    }

    /// <summary>
    /// 获取应用标识环境变量
    /// </summary>
    public static string GetAppId() {
        return Environment.GetEnvironmentVariable( DaprAppId );
    }
}