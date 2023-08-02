namespace Util.Microservices.Polly;

/// <summary>
/// Polly重试处理策略
/// </summary>
public class PollyRetryPolicy : IRetryPolicy {

    #region 字段

    /// <summary>
    /// Polly策略生成器
    /// </summary>
    private readonly PolicyBuilder _policyBuilder;
    /// <summary>
    /// 重试次数
    /// </summary>
    private readonly int? _count;
    /// <summary>
    /// 是否持续重试
    /// </summary>
    private bool _isForever;
    /// <summary>
    /// 是否等待
    /// </summary>
    private bool _isWait;
    /// <summary>
    /// 重试等待时间提供函数
    /// </summary>
    private Func<int, TimeSpan> _sleepDurationProvider;
    /// <summary>
    /// 重试回调函数
    /// </summary>
    private Action<Exception, int> _onRetry;

    #endregion

    #region 构造方法

    /// <summary>
    /// 初始化Polly重试处理策略
    /// </summary>
    /// <param name="policyBuilder">Polly策略生成器</param>
    /// <param name="count">重试次数</param>
    public PollyRetryPolicy( PolicyBuilder policyBuilder, int? count ) {
        _policyBuilder = policyBuilder ?? throw new ArgumentNullException( nameof( policyBuilder ) );
        _count = count;
        _isForever = false;
        _isWait = false;
    }

    #endregion

    #region Forever

    /// <inheritdoc />
    public IRetryPolicy Forever() {
        _isForever = true;
        return this;
    }

    #endregion

    #region Wait

    /// <inheritdoc />
    public IRetryPolicy Wait() {
        _isWait = true;
        return this;
    }

    /// <inheritdoc />
    public IRetryPolicy Wait( Func<int, TimeSpan> sleepDurationProvider ) {
        _isWait = true;
        _sleepDurationProvider = sleepDurationProvider;
        return this;
    }

    #endregion

    #region OnRetry

    /// <inheritdoc />
    public IRetryPolicy OnRetry( Action<Exception, int> action ) {
        _onRetry = action;
        return this;
    }

    #endregion

    #region Execute

    /// <inheritdoc />
    public void Execute( Action action ) {
        CreateRetryPolicy().Execute( action );
    }

    /// <summary>
    /// 创建重试策略
    /// </summary>
    private RetryPolicy CreateRetryPolicy() {
        if ( _isWait == false )
            return CreateRetryPolicyByNoWait();
        return CreateRetryPolicyByWait();
    }

    /// <summary>
    /// 创建重试策略 - 不等待
    /// </summary>
    private RetryPolicy CreateRetryPolicyByNoWait() {
        if ( _isForever )
            return _policyBuilder.RetryForever( OnRetry );
        return _policyBuilder.Retry( GetRetryCount(), OnRetry );
    }

    /// <summary>
    /// 重试处理函数
    /// </summary>
    private void OnRetry( Exception exception, int times ) {
        if ( _onRetry == null )
            return;
        _onRetry( exception, times );
    }

    /// <summary>
    /// 获取重试次数
    /// </summary>
    private int GetRetryCount() {
        return _count > 0 ? _count.SafeValue() : 1;
    }

    /// <summary>
    /// 创建重试策略 - 等待
    /// </summary>
    private RetryPolicy CreateRetryPolicyByWait() {
        if ( _isForever )
            return _policyBuilder.WaitAndRetryForever( GetSleepDurationProvider(), ( e, i, t ) => OnRetry( e, i ) );
        return _policyBuilder.WaitAndRetry( GetRetryCount(), GetSleepDurationProvider(), ( e, t, i, c ) => OnRetry( e, i ) );
    }

    /// <summary>
    /// 获取重试等待时间提供函数
    /// </summary>
    private Func<int, TimeSpan> GetSleepDurationProvider() {
        if ( _sleepDurationProvider == null )
            return retryAttempt => TimeSpan.FromSeconds( Math.Pow( 2, retryAttempt ) );
        return _sleepDurationProvider;
    }

    #endregion

    #region ExecuteAsync

    /// <inheritdoc />
    public Task ExecuteAsync( Func<Task> action ) {
        return CreateAsyncRetryPolicy().ExecuteAsync( action );
    }

    /// <summary>
    /// 创建异步重试策略
    /// </summary>
    private AsyncRetryPolicy CreateAsyncRetryPolicy() {
        if ( _isWait == false )
            return CreateAsyncRetryPolicyByNoWait();
        return CreateAsyncRetryPolicyByWait();
    }

    /// <summary>
    /// 创建异步重试策略 - 不等待
    /// </summary>
    private AsyncRetryPolicy CreateAsyncRetryPolicyByNoWait() {
        if ( _isForever )
            return _policyBuilder.RetryForeverAsync( OnRetry );
        return _policyBuilder.RetryAsync( GetRetryCount(), OnRetry );
    }

    /// <summary>
    /// 创建异步重试策略 - 等待
    /// </summary>
    private AsyncRetryPolicy CreateAsyncRetryPolicyByWait() {
        if ( _isForever )
            return _policyBuilder.WaitAndRetryForeverAsync( GetSleepDurationProvider(), ( e, i, t ) => OnRetry( e, i ) );
        return _policyBuilder.WaitAndRetryAsync( GetRetryCount(), GetSleepDurationProvider(), ( e, t, i, c ) => OnRetry( e, i ) );
    }

    #endregion
}