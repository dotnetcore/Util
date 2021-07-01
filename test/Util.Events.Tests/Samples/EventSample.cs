namespace Util.Events.Tests.Samples {
    /// <summary>
    /// 本地事件样例
    /// </summary>
    public class EventSample : Event{
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }
    }

    /// <summary>
    /// 本地事件样例2
    /// </summary>
    public class EventSample2 : Event {
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }
    }

    /// <summary>
    /// 本地事件样例3
    /// </summary>
    public class EventSample3 : Event {
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }
    }
}
