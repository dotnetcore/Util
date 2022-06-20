namespace Util.Data.Sql.Builders.Sets {
    /// <summary>
    /// Sql生成器集合项
    /// </summary>
    public class SqlBuilderSetItem {
        /// <summary>
        /// 初始化Sql生成器集合项
        /// </summary>
        /// <param name="operator">操作</param>
        /// <param name="builder">Sql生成器实例</param>
        public SqlBuilderSetItem( string @operator, ISqlBuilder builder ) {
            Operator = @operator;
            Builder = builder;
        }

        /// <summary>
        /// 操作
        /// </summary>
        public string Operator { get; }

        /// <summary>
        /// Sql生成器
        /// </summary>
        public ISqlBuilder Builder { get; }

        /// <summary>
        /// 复制Sql生成器集合项
        /// </summary>
        public SqlBuilderSetItem Clone() {
            return new SqlBuilderSetItem( Operator, Builder.Clone() );
        }
    }
}
