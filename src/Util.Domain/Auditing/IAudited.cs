namespace Util.Domain.Auditing {
    /// <summary>
    /// 操作审计
    /// </summary>
    public interface IAudited : ICreationAudited, IModificationAudited {
    }

    /// <summary>
    /// 操作审计
    /// </summary>
    /// <typeparam name="TKey">操作人编号类型</typeparam>
    public interface IAudited<TKey> : ICreationAudited<TKey>, IModificationAudited<TKey> {
    }
}
