using System;

namespace Util.Domains.Auditing {
    /// <summary>
    /// 修改操作审计
    /// </summary>
    public interface IModificationAudited : IModificationAudited<Guid?> {
    }

    /// <summary>
    /// 修改操作审计
    /// </summary>
    /// <typeparam name="TKey">最后修改人编号类型</typeparam>
    public interface IModificationAudited<TKey> {
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        TKey LastModifierId { get; set; }
    }
}
