namespace Util.Caching; 

/// <summary>
/// 空缓存
/// </summary>
public class NullCache : ILocalCache {
    /// <summary>
    /// 缓存空实例
    /// </summary>
    public static readonly ILocalCache Instance = new NullCache();

    /// <inheritdoc />
    public bool Exists( CacheKey key ) {
        return false;
    }

    /// <inheritdoc />
    public bool Exists( string key ) {
        return false;
    }

    /// <inheritdoc />
    public Task<bool> ExistsAsync( CacheKey key, CancellationToken cancellationToken = default ) {
        return Task.FromResult( false );
    }

    /// <inheritdoc />
    public Task<bool> ExistsAsync( string key, CancellationToken cancellationToken = default ) {
        return Task.FromResult( false );
    }

    /// <inheritdoc />
    public T Get<T>( CacheKey key ) {
        return default;
    }

    /// <inheritdoc />
    public T Get<T>( string key ) {
        return default;
    }

    /// <inheritdoc />
    public List<T> Get<T>( IEnumerable<CacheKey> keys ) {
        return new List<T>();
    }

    /// <inheritdoc />
    public List<T> Get<T>( IEnumerable<string> keys ) {
        return new List<T>();
    }

    /// <inheritdoc />
    public T Get<T>( CacheKey key, Func<T> action, CacheOptions options = null ) {
        return action == null ? default : action();
    }

    /// <inheritdoc />
    public T Get<T>( string key, Func<T> action, CacheOptions options = null ) {
        return action == null ? default : action();
    }

    /// <inheritdoc />
    public Task<object> GetAsync( string key, Type type, CancellationToken cancellationToken = default ) {
        return null;
    }

    /// <inheritdoc />
    public async Task<T> GetAsync<T>( CacheKey key, CancellationToken cancellationToken = default ) {
        await Task.CompletedTask;
        return default;
    }

    /// <inheritdoc />
    public async Task<T> GetAsync<T>( string key, CancellationToken cancellationToken = default ) {
        await Task.CompletedTask;
        return default;
    }

    /// <inheritdoc />
    public async Task<List<T>> GetAsync<T>( IEnumerable<CacheKey> keys, CancellationToken cancellationToken = default ) {
        await Task.CompletedTask;
        return new List<T>();
    }

    /// <inheritdoc />
    public async Task<List<T>> GetAsync<T>( IEnumerable<string> keys, CancellationToken cancellationToken = default ) {
        await Task.CompletedTask;
        return new List<T>();
    }

    /// <inheritdoc />
    public async Task<T> GetAsync<T>( CacheKey key, Func<Task<T>> action, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return action == null ? default : await action();
    }

    /// <inheritdoc />
    public async Task<T> GetAsync<T>( string key, Func<Task<T>> action, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return action == null ? default : await action();
    }

    /// <inheritdoc />
    public List<T> GetByPrefix<T>( string prefix ) {
        return new List<T>();
    }

    /// <inheritdoc />
    public async Task<List<T>> GetByPrefixAsync<T>( string prefix, CancellationToken cancellationToken = default ) {
        await Task.CompletedTask;
        return new List<T>();
    }

    /// <inheritdoc />
    public bool TrySet<T>( CacheKey key, T value, CacheOptions options = null ) {
        return false;
    }

    /// <inheritdoc />
    public bool TrySet<T>( string key, T value, CacheOptions options = null ) {
        return false;
    }

    /// <inheritdoc />
    public Task<bool> TrySetAsync<T>( CacheKey key, T value, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return Task.FromResult( false );
    }

    /// <inheritdoc />
    public Task<bool> TrySetAsync<T>( string key, T value, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return Task.FromResult( false );
    }

    /// <inheritdoc />
    public void Set<T>( CacheKey key, T value, CacheOptions options = null ) {
    }

    /// <inheritdoc />
    public void Set<T>( string key, T value, CacheOptions options = null ) {
    }

    /// <inheritdoc />
    public void Set<T>( IDictionary<CacheKey, T> items, CacheOptions options = null ) {
    }

    /// <inheritdoc />
    public void Set<T>( IDictionary<string, T> items, CacheOptions options = null ) {
    }

    /// <inheritdoc />
    public Task SetAsync<T>( CacheKey key, T value, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task SetAsync<T>( string key, T value, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task SetAsync<T>( IDictionary<CacheKey, T> items, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task SetAsync<T>( IDictionary<string, T> items, CacheOptions options = null, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public void Remove( CacheKey key ) {
    }

    /// <inheritdoc />
    public void Remove( string key ) {
    }

    /// <inheritdoc />
    public void Remove( IEnumerable<CacheKey> keys ) {
    }

    /// <inheritdoc />
    public void Remove( IEnumerable<string> keys ) {
    }

    /// <inheritdoc />
    public Task RemoveAsync( CacheKey key, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task RemoveAsync( string key, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task RemoveAsync( IEnumerable<CacheKey> keys, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task RemoveAsync( IEnumerable<string> keys, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public void RemoveByPrefix( string prefix ) {
    }

    /// <inheritdoc />
    public Task RemoveByPrefixAsync( string prefix, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public void RemoveByPattern( string pattern ) {
    }

    /// <inheritdoc />
    public Task RemoveByPatternAsync( string pattern, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public void Clear() {
    }

    /// <inheritdoc />
    public Task ClearAsync( CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }
}