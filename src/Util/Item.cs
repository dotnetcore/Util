using System;

namespace Util {
    /// <summary>
    /// 列表项
    /// </summary>
    public class Item : IComparable<Item> {
        /// <summary>
        /// 初始化列表项
        /// </summary>
        public Item() {
        }

        /// <summary>
        /// 初始化列表项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        public Item( string text, string value )
            : this( text, value, 0 ) {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <param name="sortId">排序号</param>
        public Item( string text, string value, int sortId ) {
            Text = text;
            Value = value;
            SortId = sortId;
        }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="other">其它列表项</param>
        public int CompareTo( Item other ) {
            return string.Compare( Text, other.Text, StringComparison.CurrentCulture );
        }
    }
}
