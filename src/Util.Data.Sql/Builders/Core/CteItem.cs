namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// 公用表表达式CTE项
    /// </summary>
    public class CteItem {
        /// <summary>
        /// 初始化公用表表达式CTE项
        /// </summary>
        /// <param name="name">公用表表达式名称</param>
        /// <param name="builder">Sql生成器</param>
        public CteItem( string name, ISqlBuilder builder ) {
            Name = name;
            Builder = builder;
        }

        /// <summary>
        /// 公用表表达式名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Sql生成器
        /// </summary>
        public ISqlBuilder Builder { get; }

        /// <summary>
        /// 复制公用表表达式CTE项
        /// </summary>
        public CteItem Clone() {
            return new CteItem( Name, Builder.Clone() );
        }
    }
}
