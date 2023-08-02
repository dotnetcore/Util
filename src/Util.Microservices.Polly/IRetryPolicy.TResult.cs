namespace Util.Microservices; 

/// <summary>
/// 重试处理策略
/// </summary>
public interface IRetryPolicy<TResult> {
    /// <summary>
    /// 持续重试
    /// </summary>
    IRetryPolicy<TResult> Forever();
    /// <summary>
    /// 重试等待
    /// </summary>
    IRetryPolicy<TResult> Wait();
    /// <summary>
    /// 重试等待
    /// </summary>
    /// <param name="sleepDurationProvider">重试等待时间提供函数</param>
    IRetryPolicy<TResult> Wait( Func<int, TimeSpan> sleepDurationProvider );
    /// <summary>
    /// 重试回调函数
    /// </summary>
    /// <param name="action">重试回调函数</param>
    IRetryPolicy<TResult> OnRetry( Action<DelegateResult<TResult>, int> action );
    /// <summary>
    /// 执行操作
    /// </summary>
    /// <param name="action">操作</param>
    TResult Execute( Func<TResult> action );
    /// <summary>
    /// 执行操作
    /// </summary>
    /// <param name="action">操作</param>
    Task<TResult> ExecuteAsync( Func<Task<TResult>> action );
}