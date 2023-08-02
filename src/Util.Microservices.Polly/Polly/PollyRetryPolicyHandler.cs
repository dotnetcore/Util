namespace Util.Microservices.Polly;

/// <summary>
/// Polly重试策略处理器
/// </summary>
public class PollyRetryPolicyHandler : IRetryPolicyHandler {
    /// <summary>
    /// 重试次数
    /// </summary>
    private readonly int? _count;

    /// <summary>
    /// 初始化Polly重试策略处理器
    /// </summary>
    /// <param name="count">重试次数</param>
    public PollyRetryPolicyHandler( int? count = null ) {
        _count = count;
    }

    /// <inheritdoc />
    public IRetryPolicy<TResult> HandleResult<TResult>( Func<TResult, bool> action ) {
        return new PollyRetryPolicy<TResult>( Policy.HandleResult( action ), _count );
    }

    /// <inheritdoc />
    public IRetryPolicy HandleException<TException>() where TException : Exception {
        return new PollyRetryPolicy( Policy.Handle<TException>(), _count );
    }
}