namespace Util.Data.Sql.Builders.Caches {
    /// <summary>
    /// 列缓存
    /// </summary>
    public interface IColumnCache {
        /// <summary>
        /// 从缓存中获取处理后的列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        string GetSafeColumns( string columns );
        /// <summary>
        /// 从缓存中获取处理后的列
        /// </summary>
        /// <param name="column">列</param>
        string GetSafeColumn( string column );
    }
}
