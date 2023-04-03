namespace Util {
    /// <summary>
    /// Json配置
    /// </summary>
    public class JsonOptions {
        /// <summary>
        /// 是否移除双引号,默认值: false
        /// </summary>
        public bool RemoveQuotationMarks { get; set; }
        /// <summary>
        /// 是否将双引号转成单引号,默认值: false
        /// </summary>
        public bool ToSingleQuotes { get; set; }
        /// <summary>
        /// 是否忽略null值,默认值: false
        /// </summary>
        public bool IgnoreNullValues { get; set; }
    }
}
