﻿using System.Collections.Generic;

namespace Util.Ui.Data {
    /// <summary>
    /// Ng-Zorro树节点
    /// </summary>
    public class ZorroTreeNode {
        /// <summary>
        /// 标识
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 是否叶节点
        /// </summary>
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool Expanded { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 是否禁用复选框
        /// </summary>
        public bool DisableCheckbox { get; set; }
        /// <summary>
        /// 是否可选中
        /// </summary>
        public bool Selectable { get; set; } = true;
        /// <summary>
        /// 复选框是否被选中
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// 当前节点是否被选中
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// 子节点列表
        /// </summary>
        public List<ZorroTreeNode> Children { get; set; }
    }
}
