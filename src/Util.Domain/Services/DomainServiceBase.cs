using Util.Localization;
using Util.Logging;
using Util.Sessions;

namespace Util.Domain.Services; 

/// <summary>
/// 领域服务
/// </summary>
public abstract class DomainServiceBase : IDomainService {
    /// <summary>
    /// 初始化领域服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    protected DomainServiceBase( IServiceProvider serviceProvider ) {
        ServiceProvider = serviceProvider ?? throw new ArgumentNullException( nameof( serviceProvider ) );
        Session = serviceProvider.GetService<ISession>() ?? NullSession.Instance;
        var logFactory = serviceProvider.GetService<ILogFactory>();
        Log = logFactory?.CreateLog( GetType() ) ?? NullLog.Instance;
        L = serviceProvider.GetService<IStringLocalizer>() ?? NullStringLocalizer.Instance;
    }

    /// <summary>
    /// 服务提供器
    /// </summary>
    protected IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// 用户会话
    /// </summary>
    protected ISession Session { get; set; }

    /// <summary>
    /// 日志操作
    /// </summary>
    protected ILog Log { get; }

    /// <summary>
    /// 本地化字符串
    /// </summary>
    protected IStringLocalizer L { get; set; }
}