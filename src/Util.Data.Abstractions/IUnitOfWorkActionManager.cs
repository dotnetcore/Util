using Util.Dependency;

namespace Util.Data; 

/// <summary>
/// 工作单元操作管理器,用于将操作延迟到工作单元提交后执行
/// </summary>
public interface IUnitOfWorkActionManager : IScopeDependency {
    /// <summary>
    /// 注册操作
    /// </summary>
    /// <param name="action">操作</param>
    void Register( Func<Task> action );
    /// <summary>
    /// 执行操作
    /// </summary>
    Task ExecuteAsync();
}