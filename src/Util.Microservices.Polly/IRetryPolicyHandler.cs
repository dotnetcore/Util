namespace Util.Microservices;

/// <summary>
/// 重试策略处理器
/// </summary>
public interface IRetryPolicyHandler {
    /// <summary>
    /// 指定触发重试的结果处理条件
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    /// <param name="action">触发重试的结果处理条件</param>
    IRetryPolicy<TResult> HandleResult<TResult>( Func<TResult, bool> action );
    /// <summary>
    /// 指定触发重试的异常
    /// </summary>
    /// <typeparam name="TException">异常类型</typeparam>
    IRetryPolicy HandleException<TException>() where TException : Exception;
}