using System;

namespace Util.Datas.Queries.Trees {
    /// <summary>
    /// 树形查询参数
    /// </summary>
    public interface ITreeQueryParameter : ITreeQueryParameter<Guid?> {
    }

    /// <summary>
    /// 树形查询参数
    /// </summary>
    /// <typeparam name="TParentId">父编号类型</typeparam>
    public interface ITreeQueryParameter<TParentId> : IQueryParameter {
        /// <summary>
        /// 父标识
        /// </summary>
        TParentId ParentId { get; set; }
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
        /// <summary>
        /// 是否搜索
        /// </summary>
        bool IsSearch();
    }
}
