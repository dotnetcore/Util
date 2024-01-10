using Util.Helpers;

namespace Util.FileStorage; 

/// <summary>
/// 基于用户标识和时间的文件名处理器
/// </summary>
public class UserTimeFileNameProcessor : IFileNameProcessor {
    /// <summary>
    /// 策略名称
    /// </summary>
    public const string Policy = "USERTIME";
    /// <summary>
    /// 用户会话
    /// </summary>
    private readonly ISession _session;

    /// <summary>
    /// 初始化基于用户标识和时间的文件名处理器
    /// </summary>
    /// <param name="session">用户会话</param>
    public UserTimeFileNameProcessor( ISession session ) {
        _session = session ?? NullSession.Instance;
    }

    /// <inheritdoc />
    public ProcessedName Process( string fileName ) {
        if ( fileName.IsEmpty() )
            return new ProcessedName( null );
        var extension = Path.GetExtension( fileName );
        var name = $"{Id.Create()}{extension}";
        var result = Util.Helpers.Common.JoinPath( _session.UserId, $"{Time.Now:yyyy-MM-dd}", name );
        return new ProcessedName( result, fileName );
    }
}