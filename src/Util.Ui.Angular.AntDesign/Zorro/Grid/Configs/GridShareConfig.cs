namespace Util.Ui.Zorro.Grid.Configs {
    /// <summary>
    /// 栅格共享配置
    /// </summary>
    public class GridShareConfig {
        /// <summary>
        /// 间隔
        /// </summary>
        public string Gutter { get; set; }
        /// <summary>
        /// 显示标签
        /// </summary>
        public bool ShowLabel { get; set; }
        /// <summary>
        /// 标签跨度
        /// </summary>
        public string LabelSpan { get; set; }
        /// <summary>
        /// 控件跨度
        /// </summary>
        public string ControlSpan { get; set; }
        /// <summary>
        /// 列跨度
        /// </summary>
        public string ColumnSpan { get; set; }
        /// <summary>
        /// 表单项是否开启浮动布局
        /// </summary>
        public bool FormItemFlex { get; set; }
        /// <summary>
        /// 自动创建栅格列
        /// </summary>
        public bool AutoCreateColumn { get; set; }
    }
}
