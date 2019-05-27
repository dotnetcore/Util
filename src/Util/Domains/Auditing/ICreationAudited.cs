using System;

namespace Util.Domains.Auditing {
    /// <summary>
    /// 创建操作审计
    /// </summary>
    public interface ICreationAudited : ICreationAudited<Guid?> {
    }

    /// <summary>
    /// 创建操作审计
    /// </summary>
    /// <typeparam name="TKey">创建人标识类型</typeparam>
    public interface ICreationAudited<TKey> : ICreationTime {
        /// <summary>
        /// 创建人标识
        /// </summary>
        TKey CreatorId { get; set; }
    }
}
