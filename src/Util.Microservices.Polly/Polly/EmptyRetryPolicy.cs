namespace Util.Microservices.Polly;

/// <summary>
/// 空重试处理策略
/// </summary>
public class EmptyRetryPolicy : IRetryPolicy {
    /// <summary>
    /// 空重试处理策略实例
    /// </summary>
    public static readonly IRetryPolicy Instance = new EmptyRetryPolicy();

    /// <inheritdoc />
    public IRetryPolicy Forever() {
        return this;
    }

    /// <inheritdoc />
    public IRetryPolicy Wait() {
        return this;
    }

    /// <inheritdoc />
    public IRetryPolicy Wait( Func<int, TimeSpan> sleepDurationProvider ) {
        return this;
    }

    /// <inheritdoc />
    public IRetryPolicy OnRetry( Action<Exception, int> action ) {
        return this;
    }

    /// <inheritdoc />
    public void Execute( Action action ) {
        action?.Invoke();
    }

    /// <inheritdoc />
    public async Task ExecuteAsync( Func<Task> action ) {
        if ( action == null )
            return;
        await action();
    }
}

/// <summary>
/// 空重试处理策略
/// </summary>
public class EmptyRetryPolicy<TResult> : IRetryPolicy<TResult> {
    /// <summary>
    /// 空重试处理策略实例
    /// </summary>
    public static readonly IRetryPolicy<TResult> Instance = new EmptyRetryPolicy<TResult>();

    /// <inheritdoc />
    public IRetryPolicy<TResult> Forever() {
        return this;
    }

    /// <inheritdoc />
    public IRetryPolicy<TResult> Wait() {
        return this;
    }

    /// <inheritdoc />
    public IRetryPolicy<TResult> Wait( Func<int, TimeSpan> sleepDurationProvider ) {
        return this;
    }

    /// <inheritdoc />
    public IRetryPolicy<TResult> OnRetry( Action<DelegateResult<TResult>, int> action ) {
        return this;
    }

    /// <inheritdoc />
    public TResult Execute( Func<TResult> action ) {
        return action == null ? default : action();
    }

    /// <inheritdoc />
    public async Task<TResult> ExecuteAsync( Func<Task<TResult>> action ) {
        return action == null ? default : await action();
    }
}