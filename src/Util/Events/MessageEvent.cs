using System.Text;
using Util.Helpers;

namespace Util.Events {
    /// <summary>
    /// 消息事件
    /// </summary>
    public class MessageEvent : Event, IMessageEvent {
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
            result.AppendLine( $"事件标识: {Id}" );
            result.AppendLine( $"事件时间:{Time.ToMillisecondString()}" );
            if( string.IsNullOrWhiteSpace( Name ) == false )
                result.AppendLine( $"消息名称:{Name}" );
            if( string.IsNullOrWhiteSpace( Callback ) == false )
                result.AppendLine( $"回调名称:{Callback}" );
            result.Append( $"事件数据：{Json.ToJson( Data )}" );
            return result.ToString();
        }
    }
}
