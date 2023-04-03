using System.Collections.Generic;
using Util.Applications.Dtos;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树节点
    /// </summary>
    public interface ITreeNode<TNode> : ITreeNode where TNode : ITreeNode<TNode> {
        /// <summary>
        /// 子节点列表
        /// </summary>
        List<TNode> Children { get; set; }
    }

    /// <summary>
    /// 树节点
    /// </summary>
    public interface ITreeNode : IDto {
        /// <summary>
        /// 父标识
        /// </summary>
        string ParentId { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        int? Level { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        bool? Expanded { get; set; }
        /// <summary>
        /// 复选框是否被勾选
        /// </summary>
        bool? Checked { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        int? SortId { get; set; }
        /// <summary>
        /// 是否叶节点
        /// </summary>
        bool? Leaf { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        bool? Hide { get; set; }
    }
}
