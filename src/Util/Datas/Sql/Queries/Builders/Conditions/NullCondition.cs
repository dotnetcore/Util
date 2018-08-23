namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// 空查询条件
    /// </summary>
    public class NullCondition : ICondition {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return null;
        }
    }
}