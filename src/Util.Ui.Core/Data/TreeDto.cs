using Util.Applications.Trees;

namespace Util.Ui.Data {
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
    }
}
