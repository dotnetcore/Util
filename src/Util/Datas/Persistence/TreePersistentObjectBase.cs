using System;
using Util.Domains.Trees;

namespace Util.Datas.Persistence {
    /// <summary>
    /// 树型持久化对象
    /// </summary>
    public abstract class TreePersistentObjectBase : TreePersistentObjectBase<Guid, Guid?> {
    }

    /// <summary>
    /// 树型持久化对象
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreePersistentObjectBase<TKey, TParentId> : PersistentObjectBase<TKey>, IParentId<TParentId>, IPath, IEnabled, ISortId {
        /// <summary>
        /// 父标识
        /// </summary>
        public TParentId ParentId { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Path { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SortId { get; set; }
    }
}
