namespace Util.Caching {
    /// <summary>
    /// 缓存键
    /// </summary>
    public class CacheKey {
        /// <summary>
        /// 缓存键
        /// </summary>
        private string _key;

        /// <summary>
        /// 初始化缓存键
        /// </summary>
        public CacheKey() {
        }

        /// <summary>
        /// 初始化缓存键
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="parameters">缓存键参数</param>
        public CacheKey( string key,params object[] parameters) {
            _key = string.Format( key, parameters );
        }

        /// <summary>
        /// 缓存键
        /// </summary>
        public string Key {
            get => $"{Prefix}{_key}";
            set => _key = value;
        }

        /// <summary>
        /// 缓存键前缀
        /// </summary>
        public string Prefix { get; set; }
    }
}
