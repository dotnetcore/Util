namespace Util.Caching {
    /// <summary>
    /// 缓存键扩展
    /// </summary>
    public static class CacheKeyExtensions {
        /// <summary>
        /// 验证缓存键
        /// </summary>
        /// <param name="cacheKey">缓存键</param>
        public static void Validate( this CacheKey cacheKey ) {
            cacheKey.CheckNull( nameof( cacheKey ) );
            cacheKey.Key.CheckNull( nameof( cacheKey.Key ) );
        }

        /// <summary>
        /// 获取缓存键前缀
        /// </summary>
        /// <param name="cacheKey">缓存键</param>
        public static string GetPrefix( this CacheKey cacheKey ) {
            if ( cacheKey == null )
                return null;
            if ( cacheKey.Prefix.IsEmpty() )
                return null;
            return cacheKey.Prefix;
        }
    }
}
