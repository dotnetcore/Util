using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// 空查询条件
    /// </summary>
    public class NullCondition : ICondition {
        /// <summary>
        /// 封闭构造方法
        /// </summary>
        private NullCondition() {
        }

        /// <summary>
        /// 空查询条件实例
        /// </summary>
        public static readonly NullCondition Instance = new NullCondition();

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public string GetCondition() {
            return null;
        }
    }
}