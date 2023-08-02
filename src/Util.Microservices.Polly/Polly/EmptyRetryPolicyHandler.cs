namespace Util.Microservices.Polly;

/// <summary>
/// 空重试策略处理器
/// </summary>
public class EmptyRetryPolicyHandler : IRetryPolicyHandler {
    /// <summary>
    /// 空重试策略处理器
    /// </summary>
    public static readonly IRetryPolicyHandler Instance = new EmptyRetryPolicyHandler();

    /// <inheritdoc />
    public IRetryPolicy<TResult> HandleResult<TResult>( Func<TResult, bool> action ) {
        return EmptyRetryPolicy<TResult>.Instance;
    }

    /// <inheritdoc />
    public IRetryPolicy HandleException<TException>() where TException : Exception {
        return EmptyRetryPolicy.Instance;
    }
}