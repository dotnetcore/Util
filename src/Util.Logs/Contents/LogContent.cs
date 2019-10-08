using System;
using System.Text;
using Util.Logs.Abstractions;

namespace Util.Logs.Contents {
    /// <summary>
    /// 日志内容
    /// </summary>
    public class LogContent : ILogContent, ICaption {
        /// <summary>
        /// 初始化日志内容
        /// </summary>
        public LogContent() {
            Params = new StringBuilder();
            Content = new StringBuilder();
            Sql = new StringBuilder();
            SqlParams = new StringBuilder();
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName { get; set; }
        /// <summary>
        /// 日志级别
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 日志标识
        /// </summary>
        public string LogId { get; set; }
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperationTime { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 线程号
        /// </summary>
        public string ThreadId { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 业务标识
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 租户
        /// </summary>
        public string Tenant { get; set; }
        /// <summary>
        /// 应用程序
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public StringBuilder Params { get; set; }
        /// <summary>
        /// 操作人标识
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作人角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public StringBuilder Content { get; set; }
        /// <summary>
        /// Sql语句
        /// </summary>
        public StringBuilder Sql { get; set; }
        /// <summary>
        /// Sql参数
        /// </summary>
        public StringBuilder SqlParams { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; set; }
    }
}
