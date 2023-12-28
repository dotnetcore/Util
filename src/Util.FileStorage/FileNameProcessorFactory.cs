using Util.Sessions;

namespace Util.FileStorage; 

/// <summary>
/// 文件名处理器工厂
/// </summary>
public class FileNameProcessorFactory : IFileNameProcessorFactory {
    /// <summary>
    /// 用户会话
    /// </summary>
    private readonly ISession _session;
    /// <summary>
    /// 文件名过滤器
    /// </summary>
    private readonly IFileNameFilter _filter;

    /// <summary>
    /// 初始化文件名处理器工厂
    /// </summary>
    /// <param name="session">用户会话</param>
    /// <param name="filter">文件名过滤器</param>
    public FileNameProcessorFactory( ISession session, IFileNameFilter filter ) {
        _session = session ?? NullSession.Instance;
        _filter = filter;
    }

    /// <inheritdoc />
    public IFileNameProcessor CreateProcessor( string policy ) {
        if ( policy.IsEmpty() )
            return new FileNameProcessor();
        if ( policy.ToLowerInvariant() == UserTimeFileNameProcessor.Policy )
            return new UserTimeFileNameProcessor( _session, _filter );
        throw new NotImplementedException( $"文件名处理策略 {policy} 未实现." );
    }
}