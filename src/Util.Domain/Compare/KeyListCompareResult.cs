using System.Collections.Generic;

namespace Util.Domain.Compare {
    /// <summary>
    /// 键列表比较结果
    /// </summary>
    public class KeyListCompareResult<TKey> {
        /// <summary>
        /// 初始化键列表比较结果
        /// </summary>
        /// <param name="createList">创建列表</param>
        /// <param name="updateList">更新列表</param>
        /// <param name="deleteList">删除列表</param>
        public KeyListCompareResult( List<TKey> createList, List<TKey> updateList, List<TKey> deleteList ) {
            CreateList = createList;
            UpdateList = updateList;
            DeleteList = deleteList;
        }

        /// <summary>
        /// 创建列表
        /// </summary>
        public List<TKey> CreateList { get; }

        /// <summary>
        /// 更新列表
        /// </summary>
        public List<TKey> UpdateList { get; }

        /// <summary>
        /// 删除列表
        /// </summary>
        public List<TKey> DeleteList { get; }
    }
}
