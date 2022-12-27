namespace Util.Data.Queries {
    /// <summary>
    /// 分页
    /// </summary>
    public interface IPage {
        /// <summary>
        /// 页数，即第几页，从1开始
        /// </summary>
        int Page { get; set; }
        /// <summary>
        /// 每页显示行数
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        int Total { get; set; }
        /// <summary>
        /// 获取总页数
        /// </summary>
        int GetPageCount();
        /// <summary>
        /// 获取跳过的行数
        /// </summary>
        int GetSkipCount();
        /// <summary>
        /// 排序条件
        /// </summary>
        string Order { get; set; }
        /// <summary>
        /// 获取起始行数
        /// </summary>
        int GetStartNumber();
        /// <summary>
        /// 获取结束行数
        /// </summary>
        int GetEndNumber();
    }
}
