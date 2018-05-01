namespace Util.Domains.Trees {
    /// <summary>
    /// 树型父标识
    /// </summary>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public interface IParentId<TParentId> {
        /// <summary>
        /// 父标识
        /// </summary>
        TParentId ParentId { get; set; }
    }
}