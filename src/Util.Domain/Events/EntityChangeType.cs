namespace Util.Domain.Events {
    /// <summary>
    /// 实体变更类型
    /// </summary>
    public enum EntityChangeType {
        /// <summary>
        /// 新增
        /// </summary>
        Created,
        /// <summary>
        /// 修改
        /// </summary>
        Updated,
        /// <summary>
        /// 删除
        /// </summary>
        Deleted
    }
}
