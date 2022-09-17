namespace Util.Ui.NgZorro {
    /// <summary>
    /// NgZorro配置
    /// </summary>
    public class NgZorroOptions {
        /// <summary>
        /// 表格分页总行数模板
        /// </summary>
        public string TableTotalTemplate { get; set; } = "{{ range[0] }}-{{ range[1] }} 共 {{ total }} 条";
    }
}
