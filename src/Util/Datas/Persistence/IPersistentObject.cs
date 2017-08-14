using Util.Domains;

namespace Util.Datas.Persistence {
    /// <summary>
    /// 持久化对象
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public interface IPersistentObject<TKey> : IVersion {
        /// <summary>
        /// 标识
        /// </summary>
        TKey Id { get; set; }
    }
}
