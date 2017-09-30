namespace Util.Events.Cap {
    /// <summary>
    /// Cap事件
    /// </summary>
    public interface ICapEvent : IEvent {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        object Content { get; set; }
        /// <summary>
        /// 回调
        /// </summary>
        string Callback { get; set; }
    }
}
