namespace Util.Parameters.Formats {
    /// <summary>
    /// Url参数格式化器
    /// </summary>
    internal class UrlParameterFormat : ParameterFormatBase {
        /// <summary>
        /// Url参数格式化器实例
        /// </summary>
        public static readonly IParameterFormat Instance = new UrlParameterFormat();

        /// <summary>
        /// 格式化分割符
        /// </summary>
        protected override string FormatSeparator => "=";

        /// <summary>
        /// 连接符
        /// </summary>
        protected override string JoinSeparator => "&";
    }
}
