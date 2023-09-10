namespace Util.Data.EntityFrameworkCore.Filters; 

/// <summary>
/// 数据过滤器管理器
/// </summary>
public class FilterManager : IFilterManager {
    /// <summary>
    /// 同步锁
    /// </summary>
    private static readonly object Sync = new();
    /// <summary>
    /// 过滤器类型列表
    /// </summary>
    private static readonly List<Type> _filterTypes = new();
    /// <summary>
    /// 过滤器字典
    /// </summary>
    private readonly Dictionary<Type, IFilter> _filters = new();
    /// <summary>
    /// 服务提供器
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 初始化数据过滤器管理器
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    public FilterManager( IServiceProvider serviceProvider ) {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException( nameof(serviceProvider) );
    }

    /// <summary>
    /// 添加过滤器类型
    /// </summary>
    /// <typeparam name="TFilterType">过滤器类型</typeparam>
    public static void AddFilterType<TFilterType>() {
        var type = typeof( TFilterType );
        lock ( Sync ) {
            if( _filterTypes.Contains( type ) )
                return;
            _filterTypes.Add( type );
        }
    }

    /// <summary>
    /// 移除过滤器类型
    /// </summary>
    /// <typeparam name="TFilterType">过滤器类型</typeparam>
    public static void RemoveFilterType<TFilterType>() {
        var type = typeof( TFilterType );
        lock( Sync ) {
            if( _filterTypes.Contains( type ) ) 
                _filterTypes.Remove( type );
        }
    }

    /// <summary>
    /// 清空过滤器类型
    /// </summary>
    public static void ClearFilterTypes() {
        _filterTypes.Clear();
    }

    /// <inheritdoc />
    public void EnableFilter<TFilterType>() where TFilterType : class {
        var filter = GetFilter<TFilterType>();
        filter?.Enable();
    }

    /// <inheritdoc />
    public IDisposable DisableFilter<TFilterType>() where TFilterType : class {
        var filter = GetFilter<TFilterType>();
        return filter?.Disable();
    }

    /// <inheritdoc />
    public IFilter GetFilter<TFilterType>() where TFilterType : class {
        return GetFilter( typeof(TFilterType) );
    }

    /// <inheritdoc />
    public IFilter GetFilter( Type filterType ) {
        if( _filters.ContainsKey( filterType ) == false ) {
            var serviceType = typeof( IFilter<> ).MakeGenericType( filterType );
            var filter = _serviceProvider.GetService( serviceType );
            _filters.Add( filterType, (IFilter)filter );
        }
        return _filters[filterType];
    }

    /// <inheritdoc />
    public bool IsEntityEnabled<TEntity>() {
        foreach( var type in _filterTypes ) {
            var filter = GetFilter( type );
            if ( filter.IsEntityEnabled<TEntity>() )
                return true;
        }
        return false;
    }

    /// <inheritdoc />
    public bool IsEnabled<TFilterType>() where TFilterType : class {
        var filter = GetFilter<TFilterType>();
        if ( filter == null )
            return false;
        return filter.IsEnabled;
    }

    /// <inheritdoc />
    public Expression<Func<TEntity, bool>> GetExpression<TEntity>( object state ) where TEntity : class {
        Expression<Func<TEntity, bool>> expression = null;
        foreach ( var type in _filterTypes ) {
            var filter = GetFilter( type );
            if ( filter.IsEntityEnabled<TEntity>() )
                expression = expression.And( filter.GetExpression<TEntity>( state ) );
        }
        return expression;
    }
}