using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Trees;

namespace Util.Ui.Data {
    /// <summary>
    /// 树形参数
    /// </summary>
    /// <typeparam name="TNode">树形参数类型</typeparam>
    public class TreeDto<TNode> : TreeDto where TNode : TreeDto<TNode> {
        /// <summary>
        /// 初始化树形参数
        /// </summary>
        public TreeDto() {
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
    public class TreeDto : TreeDtoBase {
        /// <summary>
        /// 标签文本
        /// </summary>
        public virtual string Text { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Display( Name = "图标" )]
        public virtual string Icon { get; set; }
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
    }
}
