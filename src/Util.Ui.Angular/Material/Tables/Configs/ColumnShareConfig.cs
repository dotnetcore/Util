namespace Util.Ui.Material.Tables.Configs {
    /// <summary>
    /// 列共享配置
    /// </summary>
    public class ColumnShareConfig {
        /// <summary>
        /// 初始化列共享配置
        /// </summary>
        public ColumnShareConfig() {
            AutoCreateHeaderCell = true;
            AutoCreateCell = true;
        }

        /// <summary>
        /// 是否自动创建列头
        /// </summary>
        public bool AutoCreateHeaderCell { get; set; }

        /// <summary>
        /// 是否自动创建单元格
        /// </summary>
        public bool AutoCreateCell { get; set; }
    }
}
