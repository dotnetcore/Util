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
        public bool IsGenerateHtml { get; set; }
        /// <summary>
        /// 表格分页总行数模板
        /// </summary>
        public string TableTotalTemplate { get; set; } = "{{ range[0] }}-{{ range[1] }} 共 {{ total }} 条";
    }
}
