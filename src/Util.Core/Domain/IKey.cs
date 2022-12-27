namespace Util.Domain {
    /// <summary>
    /// 标识
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public interface IKey<out TKey> {
        /// <summary>
        /// 标识
        /// </summary>
        TKey Id { get; }
    }
}
