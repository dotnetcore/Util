using System;
using System.Text;
using Util.Events.Properties;
using Util.Helpers;

namespace Util.Events {
    /// <summary>
    /// 消息事件
    /// </summary>
    public class MessageEvent : Event, IMessageEvent {
        /// <summary>
        /// 初始化消息事件
        /// </summary>
        public MessageEvent() {
            Id = Util.Helpers.Id.Create();
            Time = DateTime.Now;
        }

        /// <summary>
        /// 事件标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 事件发生时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 消息名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 事件数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 回调名称
        /// </summary>
        public string Callback { get; set; }
        /// <summary>
        /// 是否立即发送消息
        /// </summary>
        public bool Send { get; set; }

        /// <summary>
        /// 输出日志
        /// </summary>
        public override string ToString() {
            var result = new StringBuilder();
            result.Append( $"{EventBusResource.EventId}: {Id}," );
            result.Append( $"{EventBusResource.EventTime}:{Time.ToMillisecondString()}," );
            if( string.IsNullOrWhiteSpace( Name ) == false )
                result.Append( $"{EventBusResource.MessageName}:{Name}," );
            if( string.IsNullOrWhiteSpace( Callback ) == false )
                result.Append( $"{EventBusResource.Callback}:{Callback}" );
            result.Append( $"{EventBusResource.EventData}：{Json.ToJson( Data )}" );
            return result.ToString();
        }
    }
}
