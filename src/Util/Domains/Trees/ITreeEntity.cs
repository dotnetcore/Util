using System.Collections.Generic;

namespace Util.Domains.Trees {
    /// <summary>
    /// 树型实体
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父编号类型</typeparam>
    public interface ITreeEntity<TEntity, TKey, TParentId> : IAggregateRoot<TEntity, TKey> where TEntity : ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 父对象
        /// </summary>
        TEntity Parent { get; set; }
        /// <summary>
        /// 父编号
        /// </summary>
        TParentId ParentId { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        int Level { get; }
        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; }
        /// <summary>
        /// 排序号
        /// </summary>
        int? SortId { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// 初始化路径
        /// </summary>
        void InitPath();
        /// <summary>
        /// 初始化路径
        /// </summary>
        /// <param name="parent">父节点</param>
        void InitPath( TEntity parent );
        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        /// <param name="excludeSelf">是否排除当前节点,默认排除自身</param>
        List<TKey> GetParentIdsFromPath( bool excludeSelf = true );
    }
}
