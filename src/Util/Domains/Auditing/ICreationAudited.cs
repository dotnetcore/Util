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
    /// <typeparam name="TKey">创建人编号类型</typeparam>
    public interface ICreationAudited<TKey> {
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        TKey CreatorId { get; set; }
    }
}
