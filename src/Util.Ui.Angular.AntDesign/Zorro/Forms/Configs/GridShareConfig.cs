namespace Util.Ui.Zorro.Forms.Configs {
    /// <summary>
    /// 栅格共享配置
    /// </summary>
    public class GridShareConfig {
        /// <summary>
        /// 栅格共享配置键
        /// </summary>
        public const string Key = "GridShareConfig";
        /// <summary>
        /// 标签跨度
        /// </summary>
        public string LabelSpan { get; set; }
        /// <summary>
        /// 控件跨度
        /// </summary>
        public string ControlSpan { get; set; }
        /// <summary>
        /// 间隔
        /// </summary>
        public string Gutter { get; set; }
    }
}
