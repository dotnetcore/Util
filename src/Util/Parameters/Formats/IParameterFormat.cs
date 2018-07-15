namespace Util.Parameters.Formats {
    /// <summary>
    /// 参数格式化器
    /// </summary>
    public interface IParameterFormat {
        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        string Format( string key, object value );
        /// <summary>
        /// 连接参数
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        string Join( string left, string right );
    }
}
