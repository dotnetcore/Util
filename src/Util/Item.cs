using System;

namespace Util {
    /// <summary>
    /// 列表项
    /// </summary>
    public class Item : IComparable<Item> {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <param name="sortId">排序号</param>
        /// <param name="group">组</param>
        /// <param name="disabled">禁用</param>
        public Item( string text, string value, int sortId = 0,string group = "",bool disabled = false) {
            Text = text;
            Value = value;
            SortId = sortId;
            Group = group;
            Disabled = disabled;
        }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortId { get; }

        /// <summary>
        /// 组
        /// </summary>
        public string Group { get; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="other">其它列表项</param>
        public int CompareTo( Item other ) {
            return string.Compare( Text, other.Text, StringComparison.CurrentCulture );
        }
    }
}
