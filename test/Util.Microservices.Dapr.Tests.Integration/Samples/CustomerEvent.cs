using System.Runtime.CompilerServices;
using Util.Events;

namespace Util.Microservices.Dapr.Tests.Samples;

/// <summary>
/// 客户事件
/// </summary>

public record CustomerEvent: IntegrationEvent {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Code">编码</param>
    /// <param name="Name">姓名</param>
    public CustomerEvent( string Code, string Name ) {
        this.EventId = "a";
        
    }
}