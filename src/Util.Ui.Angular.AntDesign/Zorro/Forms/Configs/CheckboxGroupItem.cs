using Newtonsoft.Json;

namespace Util.Ui.Zorro.Forms.Configs {
    /// <summary>
    /// 复选框组列表项
    /// </summary>
    public class CheckboxGroupItem {
        /// <summary>
        /// 初始化复选框组列表项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        public CheckboxGroupItem( string text, object value ) {
            Label = text;
            Value = value;
        }

        /// <summary>
        /// 文本
        /// </summary>
        [JsonProperty( "label", NullValueHandling = NullValueHandling.Ignore )]
        public string Label { get; }

        /// <summary>
        /// 值
        /// </summary>
        [JsonProperty( "value", NullValueHandling = NullValueHandling.Ignore )]
        public object Value { get; }
    }
}
