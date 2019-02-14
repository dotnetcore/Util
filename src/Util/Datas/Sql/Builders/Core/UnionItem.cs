namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 联合操作项
    /// </summary>
    public class UnionItem {
        /// <summary>
        /// 初始化联合操作项
        /// </summary>
        /// <param name="operation">操作</param>
        /// <param name="builder">Sql生成器</param>
        public UnionItem( string operation, ISqlBuilder builder ) {
            Operation = operation;
            Builder = builder;
        }

        /// <summary>
        /// 操作
        /// </summary>
        public string Operation { get; }

        /// <summary>
        /// Sql生成器
        /// </summary>
        public ISqlBuilder Builder { get; }
    }
}
