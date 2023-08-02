using Util.Dependency;

namespace Util.Microservices; 

/// <summary>
/// 弹性处理策略
/// </summary>
public interface IPolicy : ITransientDependency {
    /// <summary>
    /// 重试
    /// </summary>
    IRetryPolicyHandler Retry();
    /// <summary>
    /// 重试
    /// </summary>
    /// <param name="count">重试次数</param>
    IRetryPolicyHandler Retry( int count );
}