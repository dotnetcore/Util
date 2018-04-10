using System.Collections.Generic;
using Newtonsoft.Json;

namespace Util.Ui.Prime.Datas {
    /// <summary>
    /// 树节点
    /// </summary>
    /// <typeparam name="TData">数据类型</typeparam>
    public class PrimeTreeNode<TData> {
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty( "data" )]
        public TData Data { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        [JsonProperty( "children" )]
        public IEnumerable<PrimeTreeNode<TData>> Children { get; set; }
    }
}
