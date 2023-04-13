namespace Util.Generators.Configuration {
    /// <summary>
    /// 消息配置项
    /// </summary>
    public class MessageOptions {
        /// <summary>
        /// 必填项消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// 最大长度消息
        /// </summary>
        public string MaxLengthMessage { get; set; }

        /// <summary>
        /// 复制
        /// </summary>
        public MessageOptions Clone() {
            return new() {
                RequiredMessage = RequiredMessage,
                MaxLengthMessage = MaxLengthMessage
            };
        }
    }
}
