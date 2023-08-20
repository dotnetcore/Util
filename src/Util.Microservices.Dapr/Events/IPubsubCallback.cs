namespace Util.Microservices.Dapr.Events; 

/// <summary>
/// 发布订阅回调操作
/// </summary>
public interface IPubsubCallback : ISingletonDependency {
    /// <summary>
    /// 发布前操作
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnPublishBefore( PubsubArgument argument, CancellationToken cancellationToken = default );
    /// <summary>
    /// 发布后操作
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnPublishAfter( PubsubArgument argument, CancellationToken cancellationToken = default );
}