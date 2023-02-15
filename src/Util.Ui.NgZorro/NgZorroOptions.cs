namespace Util.Ui.NgZorro {
    /// <summary>
    /// NgZorro配置
    /// </summary>
    public class NgZorroOptions {
        /// <summary>
        /// Spa静态文件根路径,默认值: ClientApp/dist
        /// </summary>
        public string RootPath { get; set; } = "ClientApp/dist";
        /// <summary>
        /// 是否生成html
        /// </summary>
        internal bool IsGenerateHtml { get; set; }
        /// <summary>
        /// 是否启用默认项文本
        /// </summary>
        public bool EnableDefaultOptionText { get; set; }
        /// <summary>
        /// 是否启用多语言
        /// </summary>
        public bool EnableI18n { get; set; }
    }
}
