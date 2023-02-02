using System.ComponentModel.DataAnnotations;
using Util.Data.Queries;

namespace Util.Data.Trees {
    /// <summary>
    /// 树形查询参数
    /// </summary>
    public class TreeQueryParameter : QueryParameter, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形查询参数
        /// </summary>
        protected TreeQueryParameter() {
            Order = "SortId";
        }

        /// <summary>
        /// 父标识
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int? Level { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "util.enabled" )]
        public bool? Enabled { get; set; }
    }
}
