namespace Util.Microservices.Dapr.StateManagements;

/// <summary>
/// Dapr状态管理
/// </summary>
public class DaprStateManager<T> : DaprStateManagerBase<IStateManager<T>>, IStateManager<T> {
    /// <summary>
    /// 初始化Dapr状态管理
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="loggerFactory">日志工厂</param>
    /// <param name="keyGenerator">状态存储键生成器</param>
    public DaprStateManager( DaprClient client, IOptions<DaprOptions> options, ILoggerFactory loggerFactory, IKeyGenerator keyGenerator )
        : base( client, options, loggerFactory, keyGenerator ) {
    }

    /// <inheritdoc />
    public IStateManager<T> OrderBy( Expression<Func<T, object>> expression ) {
        Sort.OrderBy( expression );
        return this;
    }

    /// <inheritdoc />
    public IStateManager<T> OrderByDescending( Expression<Func<T, object>> expression ) {
        Sort.OrderByDescending( expression );
        return this;
    }

    /// <inheritdoc />
    public IStateManager<T> Equal( Expression<Func<T, object>> expression, object value ) {
        Filter.Equal( expression, value );
        return this;
    }

    /// <inheritdoc />
    public IStateManager<T> In( Expression<Func<T, object>> expression, IEnumerable<object> values ) {
        Filter.In( expression, values );
        return this;
    }

    /// <inheritdoc />
    public IStateManager<T> In( Expression<Func<T, object>> expression, params object[] values ) {
        Filter.In( expression, values );
        return this;
    }
}