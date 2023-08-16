namespace Util.Microservices.Dapr.Events; 

/// <summary>
/// 发布订阅回调操作
/// </summary>
public interface IPubsubCallback : ISingletonDependency {
    /// <summary>
    /// 发布前操作
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    Task OnPublishBefore( PubsubArgument argument );
    /// <summary>
    /// 发布后操作
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    Task OnPublishAfter( PubsubArgument argument );
}