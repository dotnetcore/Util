namespace Util.Events.Messages {
    /// <summary>
    /// 消息事件
    /// </summary>
    public interface IMessageEvent : IEvent {
        /// <summary>
        /// 事件数据
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// 发送目标
        /// </summary>
        string Target { get; set; }

        /// <summary>
        /// 回调
        /// </summary>
        string Callback { get; set; }
    }
}
