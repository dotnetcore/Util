using System.Collections.Concurrent;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Caches;

namespace Util.Data.Sql.Tests.Samples {
    /// <summary>
    /// 测试列缓存
    /// </summary>
    public class TestColumnCache : ColumnCacheBase {
        /// <summary>
        /// 列名缓存
        /// </summary>
        private readonly ConcurrentDictionary<int, string> _cache;

        /// <summary>
        /// 初始化测试列缓存
        /// </summary>
        public TestColumnCache() : this( TestDialect.Instance ) {
        }

        /// <summary>
        /// 初始化测试列缓存
        /// </summary>
        public TestColumnCache( IDialect dialect ) : base( dialect ) {
            _cache = new ConcurrentDictionary<int, string>();
        }

        /// <summary>
        /// 测试列缓存实例
        /// </summary>
        public static readonly IColumnCache Instance = new TestColumnCache();

        /// <summary>
        /// 从缓存中获取处理后的列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        public override string GetSafeColumns( string columns ) {
            return _cache.GetOrAdd( columns.GetHashCode(), key => NormalizeColumns( columns ) );
        }

        /// <summary>
        /// 从缓存中获取处理后的列
        /// </summary>
        /// <param name="column">列</param>
        public override string GetSafeColumn( string column ) {
            return _cache.GetOrAdd( column.GetHashCode(), key => NormalizeColumn( column ) );
        }
    }
}
