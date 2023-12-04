using System;
using Util.Dependency;

namespace Util.FileStorage.Samples;

/// <summary>
/// 文件名处理器测试工厂
/// </summary>
[Ioc(9)]
public class TestFileNameProcessorFactory : IFileNameProcessorFactory {
    /// <inheritdoc />
    public IFileNameProcessor CreateProcessor( string policy ) {
        if ( policy.IsEmpty() )
            return new FileNameProcessor();
        if ( policy.ToLowerInvariant() == "test" )
            return new TestFileNameProcessor();
        throw new NotImplementedException( $"文件名处理策略 {policy} 未实现." );
    }
}