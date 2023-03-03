using System.Collections.Generic;

namespace Util.Domain.Compare {
    /// <summary>
    /// 列表比较结果
    /// </summary>
    public class ListCompareResult<TEntity, TKey> where TEntity : IKey<TKey> {
        /// <summary>
        /// 初始化列表比较结果
        /// </summary>
        /// <param name="createList">创建列表</param>
        /// <param name="updateList">更新列表</param>
        /// <param name="deleteList">删除列表</param>
        public ListCompareResult( List<TEntity> createList, List<TEntity> updateList, List<TEntity> deleteList ) {
            CreateList = createList;
            UpdateList = updateList;
            DeleteList = deleteList;
        }

        /// <summary>
        /// 创建列表
        /// </summary>
        public List<TEntity> CreateList { get; }

        /// <summary>
        /// 更新列表
        /// </summary>
        public List<TEntity> UpdateList { get; }

        /// <summary>
        /// 删除列表
        /// </summary>
        public List<TEntity> DeleteList { get; }
    }
}
