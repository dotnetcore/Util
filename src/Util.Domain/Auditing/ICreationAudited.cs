using System;

namespace Util.Domain.Auditing {
    /// <summary>
    /// 创建操作审计
    /// </summary>
    public interface ICreationAudited : ICreationAudited<Guid?> {
    }

    /// <summary>
    /// 创建操作审计
    /// </summary>
    /// <typeparam name="TKey">创建人标识类型</typeparam>
    public interface ICreationAudited<TKey> {
        /// <summary>
        /// 创建人标识
        /// </summary>
        TKey CreatorId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreationTime { get; set; }
    }
}
