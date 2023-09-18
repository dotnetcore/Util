namespace Util.Tenants;

/// <summary>
/// 租户解析器集合
/// </summary>
public class TenantResolverCollection : IEnumerable<ITenantResolver> {
    /// <summary>
    /// 租户解析器列表
    /// </summary>
    private readonly Dictionary<string, ITenantResolver> _resolvers;

    /// <summary>
    /// 初始化租户解析器集合
    /// </summary>
    public TenantResolverCollection() {
        _resolvers = new Dictionary<string, ITenantResolver>();
    }

    /// <summary>
    /// 获取枚举器
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    /// <summary>
    /// 获取枚举器
    /// </summary>
    public IEnumerator<ITenantResolver> GetEnumerator() {
        return GetResolvers().GetEnumerator();
    }

    /// <summary>
    /// 获取租户解析器列表
    /// </summary>
    public List<ITenantResolver> GetResolvers() {
        return _resolvers
            .Select( t => t.Value )
            .OrderByDescending( t => t.Priority )
            .ToList();
    }

    /// <summary>
    /// 获取租户解析器列表
    /// </summary>
    public List<TResolver> GetResolvers<TResolver>() where TResolver : ITenantResolver {
        return _resolvers
            .Where( t => t.Value.GetType() == typeof( TResolver ) )
            .Select( t => (TResolver)t.Value )
            .OrderByDescending( t => t.Priority )
            .ToList();
    }

    /// <summary>
    /// 获取租户解析器
    /// </summary>
    /// <typeparam name="TResolver">租户解析器类型</typeparam>
    public TResolver GetResolver<TResolver>() where TResolver: ITenantResolver {
        var key = typeof( TResolver ).FullName;
        return GetResolver<TResolver>( key );
    }

    /// <summary>
    /// 获取租户解析器
    /// </summary>
    /// <typeparam name="TResolver">租户解析器类型</typeparam>
    /// <param name="key">租户解析器键名</param>
    public TResolver GetResolver<TResolver>( string key ) where TResolver : ITenantResolver {
        var result = _resolvers.FirstOrDefault( t => t.Key == key );
        if ( result.Value == null )
            return default;
        return (TResolver)result.Value;
    }

    /// <summary>
    /// 添加租户解析器
    /// </summary>
    /// <param name="resolver">租户解析器</param>
    public void Add( ITenantResolver resolver ) {
        if ( resolver == null )
            return;
        var key = resolver.GetType().FullName;
        Add( key, resolver );
    }

    /// <summary>
    /// 添加租户解析器
    /// </summary>
    /// <param name="key">租户解析器键名</param>
    /// <param name="resolver">租户解析器</param>
    public void Add( string key, ITenantResolver resolver ) {
        if ( key.IsEmpty() )
            return;
        if ( resolver == null )
            return;
        Remove( key );
        _resolvers.Add( key, resolver );
    }

    /// <summary>
    /// 添加租户解析器列表
    /// </summary>
    /// <param name="resolvers">租户解析器列表</param>
    public void Add( IList<ITenantResolver> resolvers ) {
        if ( resolvers == null )
            return;
        foreach ( var resolver in resolvers )
            Add( resolver );
    }

    /// <summary>
    /// 移除租户解析器
    /// </summary>
    /// <typeparam name="TResolver">租户解析器类型</typeparam>
    public void Remove<TResolver>() where TResolver : ITenantResolver {
        var key = typeof( TResolver ).FullName;
        Remove( key );
    }

    /// <summary>
    /// 移除租户解析器
    /// </summary>
    /// <param name="key">租户解析器键名</param>
    public void Remove( string key ) {
        if ( key.IsEmpty() )
            return;
        _resolvers.Remove( key );
    }

    /// <summary>
    /// 清空租户解析器
    /// </summary>
    public void Clear() {
        _resolvers.Clear();
    }
}