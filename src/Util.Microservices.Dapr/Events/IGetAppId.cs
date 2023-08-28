namespace Util.Microservices.Dapr.Events; 

/// <summary>
/// 获取应用标识
/// </summary>
public interface IGetAppId : ISingletonDependency {
    /// <summary>
    /// 获取应用标识
    /// </summary>
    string GetAppId();
}