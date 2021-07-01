using System;
using System.Text.Json.Serialization;

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
        public Item( string text, object value, int? sortId = null, string group = null, bool? disabled = null ) {
            Text = text;
            Value = value;
            SortId = sortId;
            Group = group;
            Disabled = disabled;
        }

        /// <summary>
        /// 文本
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; }

        /// <summary>
        /// 值
        /// </summary>
        [JsonPropertyName("value")]
        public object Value { get; }

        /// <summary>
        /// 排序号
        /// </summary>
        [JsonPropertyName("sortId")]
        public int? SortId { get; }

        /// <summary>
        /// 组
        /// </summary>
        [JsonPropertyName("group")]
        public string Group { get; }

        /// <summary>
        /// 禁用
        /// </summary>
        [JsonPropertyName("disabled")]
        public bool? Disabled { get; }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="other">其它列表项</param>
        public int CompareTo( Item other ) {
            return string.Compare( Text, other.Text, StringComparison.CurrentCulture );
        }
    }
}
