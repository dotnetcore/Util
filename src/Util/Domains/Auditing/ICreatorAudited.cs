using System;

namespace Util.Domains.Auditing {
    /// <summary>
    /// 创建人操作审计
    /// </summary>
    public interface ICreatorAudited : ICreatorAudited<Guid?> {
    }

    /// <summary>
    /// 创建人操作审计
    /// </summary>
    /// <typeparam name="TKey">创建人标识类型</typeparam>
    public interface ICreatorAudited<TKey> : ICreationAudited<TKey>, ICreator {
    }
}
