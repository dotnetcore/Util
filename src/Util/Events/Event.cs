using System;
using System.Text;

namespace Util.Events {
    /// <summary>
    /// 事件
    /// </summary>
    /// <typeparam name="TData">事件数据类型</typeparam>
    public class Event<TData> {
        /// <summary>
        /// 初始化事件
        /// </summary>
        public Event( TData data ) {
            Timestamp = DateTime.Now;
            Data = data;
        }

        /// <summary>
        /// 事件时间
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// 事件数据
        /// </summary>
        public TData Data { get; set; }

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
            result.AppendLine( $"事件时间:{Timestamp.ToMillisecondString()}" );
            if( string.IsNullOrWhiteSpace( Target ) == false )
                result.AppendLine( $"发送目标:{Target}" );
            if( string.IsNullOrWhiteSpace( Callback ) == false )
                result.AppendLine( $"回调:{Callback}" );
            result.Append( $"事件数据：{Util.Helpers.Json.ToJson( Data )}" );
            return result.ToString();
        }
    }

    /// <summary>
    /// 事件
    /// </summary>
    public static class Event {
        /// <summary>
        /// 创建事件
        /// </summary>
        /// <typeparam name="TData">事件数据类型</typeparam>
        /// <param name="data">事件数据</param>
        /// <param name="target">发送目标</param>
        /// <param name="callback">回调</param>
        public static Event<TData> Create<TData>( TData data, string target = null, string callback = null ) {
            return new Event<TData>( data ) { Target = target, Callback = callback };
        }
    }
}
