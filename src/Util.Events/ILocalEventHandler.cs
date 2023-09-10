namespace Util.Events; 

/// <summary>
/// 本地事件处理器
/// </summary>
public interface ILocalEventHandler : IEventHandler  {
    /// <summary>
    /// 序号
    /// </summary>
    int Order { get; }
}