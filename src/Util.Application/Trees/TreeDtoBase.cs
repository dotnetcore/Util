using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形参数
    /// </summary>
    public abstract class TreeDtoBase<TNode> : TreeDtoBase,ITreeNode<TNode> where TNode : ITreeNode<TNode> {
        /// <summary>
        /// 初始化树形参数
        /// </summary>
        protected TreeDtoBase() {
            Children = new List<TNode>();
        }

        /// <summary>
        /// 子节点列表
        /// </summary>
        public List<TNode> Children { get; set; }
    }

    /// <summary>
    /// 树形参数
    /// </summary>
    public abstract class TreeDtoBase : DtoBase, ITreeNode {
        /// <summary>
        /// 父标识
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 父名称
        /// </summary>
        [Display( Name = "util.parentName" )]
        public string ParentName { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public int? Level { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "util.enabled" )]
        public bool? Enabled { get; set; } = true;
        /// <summary>
        /// 排序号
        /// </summary>
        [Display( Name = "util.sortId" )]
        public int? SortId { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [Display( Name = "util.expanded" )]
        public bool? Expanded { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Display( Name = "util.icon" )]
        public string Icon { get; set; }
        /// <summary>
        /// 是否禁用复选框
        /// </summary>
        public bool? DisableCheckbox { get; set; }
        /// <summary>
        /// 是否可选中
        /// </summary>
        public bool? Selectable { get; set; } = true;
        /// <summary>
        /// 复选框是否被勾选
        /// </summary>
        public bool? Checked { get; set; }
        /// <summary>
        /// 节点是否被选中
        /// </summary>
        public bool? Selected { get; set; }
        /// <summary>
        /// 是否叶节点
        /// </summary>
        public bool? Leaf { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool? Hide { get; set; }
        /// <summary>
        /// 获取树节点显示文本
        /// </summary>
        public abstract string GetText();
    }
}
