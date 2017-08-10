namespace Util.Datas.Queries {
    /// <summary>
    /// 排序项
    /// </summary>
    public class OrderByItem {
        /// <summary>
        /// 初始化排序项
        /// </summary>
        /// <param name="name">排序属性</param>
        /// <param name="desc">是否降序</param>
        public OrderByItem( string name, bool desc ) {
            Name = name;
            Desc = desc;
        }

        /// <summary>
        /// 排序属性
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 是否降序
        /// </summary>
        public bool Desc { get; }

        /// <summary>
        /// 创建排序字符串
        /// </summary>
        public string Generate() {
            if( Desc )
                return $"{Name} desc";
            return Name;
        }
    }
}
