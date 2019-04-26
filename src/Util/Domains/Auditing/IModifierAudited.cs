using System;

namespace Util.Domains.Auditing {
    /// <summary>
    /// 修改人操作审计
    /// </summary>
    public interface IModifierAudited : IModifierAudited<Guid?> {
    }

    /// <summary>
    /// 修改人操作审计
    /// </summary>
    /// <typeparam name="TKey">最后修改人标识类型</typeparam>
    public interface IModifierAudited<TKey> : IModificationAudited<TKey>, IModifier {
    }
}
