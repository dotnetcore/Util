namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// Sql生成器操作项
    /// </summary>
    public class BuilderItem {
        /// <summary>
        /// 初始化Sql生成器操作项
        /// </summary>
        /// <param name="name">操作名称</param>
        /// <param name="builder">Sql生成器</param>
        public BuilderItem( string name, ISqlBuilder builder ) {
            Name = name;
            Builder = builder;
        }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Sql生成器
        /// </summary>
        public ISqlBuilder Builder { get; }
    }
}
