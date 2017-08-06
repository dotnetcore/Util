namespace Util.Domains.Repositories {
    /// <summary>
    /// 分页
    /// </summary>
    public interface IPager : IPagerBase {
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
