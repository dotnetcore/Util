using System.Collections.Generic;
using System.Linq;

namespace Util.Datas.Queries {
    /// <summary>
    /// 排序生成器
    /// </summary>
    public class OrderByBuilder {
        /// <summary>
        /// 排序项列表
        /// </summary>
        private readonly List<OrderByItem> _items;

        /// <summary>
        /// 初始化排序生成器
        /// </summary>
        public OrderByBuilder() {
            _items = new List<OrderByItem>();
        }

        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="name">排序属性</param>
        /// <param name="desc">是否降序</param>
        public void Add( string name, bool desc = false ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return;
            _items.Add( new OrderByItem( name, desc ) );
        }

        /// <summary>
        /// 生成排序字符串
        /// </summary>
        public string Generate() {
            return _items.Select( t => t.Generate() ).ToList().Join();
        }
    }
}
