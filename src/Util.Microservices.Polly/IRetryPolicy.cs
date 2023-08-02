namespace Util.Microservices; 

/// <summary>
/// 重试处理策略
/// </summary>
public interface IRetryPolicy {
    /// <summary>
    /// 持续重试
    /// </summary>
    IRetryPolicy Forever();
    /// <summary>
    /// 重试等待
    /// </summary>
    IRetryPolicy Wait();
    /// <summary>
    /// 重试等待
    /// </summary>
    /// <param name="sleepDurationProvider">重试等待时间提供函数</param>
    IRetryPolicy Wait( Func<int, TimeSpan> sleepDurationProvider );
    /// <summary>
    /// 重试回调函数
    /// </summary>
    /// <param name="action">重试回调函数</param>
    IRetryPolicy OnRetry( Action<Exception, int> action );
    /// <summary>
    /// 执行操作
    /// </summary>
    /// <param name="action">操作</param>
    void Execute( Action action );
    /// <summary>
    /// 执行操作
    /// </summary>
    /// <param name="action">操作</param>
    Task ExecuteAsync( Func<Task> action );
}