using System.Text;

namespace Util.Events.Messages {
    /// <summary>
    /// 消息事件
    /// </summary>
    public class MessageEvent : Event, IMessageEvent {
        /// <summary>
        /// 事件数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 发送目标
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 回调
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// 输出日志
        /// </summary>
        public override string ToString() {
            StringBuilder result = new StringBuilder();
            result.AppendLine( $"事件标识: {Id}" );
            result.AppendLine( $"事件时间:{Time.ToMillisecondString()}" );
            if( string.IsNullOrWhiteSpace( Target ) == false )
                result.AppendLine( $"发送目标:{Target}" );
            if( string.IsNullOrWhiteSpace( Callback ) == false )
                result.AppendLine( $"回调:{Callback}" );
            result.Append( $"事件数据：{Util.Helpers.Json.ToJson( Data )}" );
            return result.ToString();
        }
    }
}
