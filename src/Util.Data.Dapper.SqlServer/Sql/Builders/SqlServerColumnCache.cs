using System.Collections.Concurrent;
using Util.Data.Sql.Builders.Caches;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql Server列缓存
    /// </summary>
    public class SqlServerColumnCache : ColumnCacheBase {
        /// <summary>
        /// 列名缓存
        /// </summary>
        private readonly ConcurrentDictionary<int, string> _cache;

        /// <summary>
        /// 封闭构造方法
        /// </summary>
        private SqlServerColumnCache() : base( SqlServerDialect.Instance ) {
            _cache = new ConcurrentDictionary<int, string>();
        }

        /// <summary>
        /// Sql Server列缓存实例
        /// </summary>
        public static readonly IColumnCache Instance = new SqlServerColumnCache();

        /// <inheritdoc />
        public override string GetSafeColumns( string columns ) {
            return _cache.GetOrAdd( columns.GetHashCode(), key => NormalizeColumns( columns ) );
        }

        /// <inheritdoc />
        public override string GetSafeColumn( string column ) {
            return _cache.GetOrAdd( column.GetHashCode(), key => NormalizeColumn( column ) );
        }
    }
}
