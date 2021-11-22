using Util.Data.Queries;

namespace Util.Data.Trees {
    /// <summary>
    /// 树形查询参数
    /// </summary>
    public interface ITreeQueryParameter : IPage {
        /// <summary>
        /// 父标识
        /// </summary>
        string ParentId { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        int? Level { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        bool? Enabled { get; set; }
    }
}
