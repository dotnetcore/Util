namespace Util.Microservices.Polly;

/// <summary>
/// 空弹性处理策略
/// </summary>
public class EmptyPolicy : IPolicy {
    /// <summary>
    /// 空弹性处理策略实例
    /// </summary>
    public static readonly IPolicy Instance = new EmptyPolicy();

    /// <inheritdoc />
    public IRetryPolicyHandler Retry() {
        return EmptyRetryPolicyHandler.Instance;
    }

    /// <inheritdoc />
    public IRetryPolicyHandler Retry( int count ) {
        return EmptyRetryPolicyHandler.Instance;
    }
}