using Util.Data.Sql.Builders.Caches;

namespace Util.Data.Dapper.Sql.Builders; 

/// <summary>
/// Oracle列缓存
/// </summary>
public class OracleColumnCache : ColumnCacheBase {
    /// <summary>
    /// 列名缓存
    /// </summary>
    private readonly ConcurrentDictionary<int, string> _cache;

    /// <summary>
    /// 封闭构造方法
    /// </summary>
    private OracleColumnCache() : base( OracleDialect.Instance ) {
        _cache = new ConcurrentDictionary<int, string>();
    }

    /// <summary>
    /// Oracle列缓存实例
    /// </summary>
    public static readonly IColumnCache Instance = new OracleColumnCache();

    /// <inheritdoc />
    public override string GetSafeColumns( string columns ) {
        return _cache.GetOrAdd( columns.GetHashCode(), key => NormalizeColumns( columns ) );
    }

    /// <inheritdoc />
    public override string GetSafeColumn( string column ) {
        return _cache.GetOrAdd( column.GetHashCode(), key => NormalizeColumn( column ) );
    }
}