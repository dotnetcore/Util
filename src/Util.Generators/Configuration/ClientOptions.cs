namespace Util.Generators.Configuration {
    /// <summary>
    /// 客户端配置项
    /// </summary>
    public class ClientOptions {
        /// <summary>
        /// 客户端应用名称
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 项目端口号
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 复制
        /// </summary>
        public ClientOptions Clone() {
            return new() {
                AppName = AppName,
                Port = Port
            };
        }
    }
}
