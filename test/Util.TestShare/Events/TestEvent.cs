using System;
using Util.Events;

namespace Util.Tests.Events; 

/// <summary>
/// 测试事件
/// </summary>
public class TestEvent : IEvent {
    public Guid Id { get; set; }
    public string Name { get; set; }
}

/// <summary>
/// 测试事件2
/// </summary>
public class TestEvent2 : IEvent {
    public Guid Id { get; set; }
    public string Name { get; set; }
}

/// <summary>
/// 测试事件3 - 集成事件
/// </summary>
public record TestEvent3( Guid Id, string Name ) : IntegrationEvent {
}