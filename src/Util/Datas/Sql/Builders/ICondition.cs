namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// Sql查询条件
    /// </summary>
    public interface ICondition {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        string GetCondition();
    }
}
