namespace Util.Ui.NgZorro.Components.Radios.Configs {
    /// <summary>
    /// 单选框组合共享配置
    /// </summary>
    public class RadioGroupShareConfig {
        /// <summary>
        /// 初始化单选框组合共享配置
        /// </summary>
        /// <param name="id">标识</param>
        public RadioGroupShareConfig( string id = null ) {
            Id = id.IsEmpty() ? Util.Helpers.Id.Create() : id;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// 扩展标识
        /// </summary>
        public string ExtendId => $"x_{Id}";

        /// <summary>
        /// 是否自动创建单选框组合
        /// </summary>
        public bool? IsAutoCreateRadioGroup { get; set; }

        /// <summary>
        /// 是否自动创建单选框
        /// </summary>
        public bool? IsAutoCreateRadio { get; set; }

        /// <summary>
        /// 单选框组合是否设置扩展属性
        /// </summary>
        public bool IsRadioGroupExtend { get; set; }

        /// <summary>
        /// 单选框是否设置扩展属性
        /// </summary>
        public bool IsRadioExtend { get; set; }
    }
}
