namespace Util.Events {
    /// <summary>
    /// 消息事件
    /// </summary>
    public interface IMessageEvent : IEvent {
        /// <summary>
        /// 消息名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 事件数据
        /// </summary>
        object Data { get; set; }
        /// <summary>
        /// 回调名称
        /// </summary>
        string Callback { get; set; }
        /// <summary>
        /// 是否立即发送消息
        /// </summary>
        bool Send { get; set; }
    }
}
