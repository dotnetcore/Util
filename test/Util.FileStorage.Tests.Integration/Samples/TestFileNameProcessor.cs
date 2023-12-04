namespace Util.FileStorage.Samples; 

/// <summary>
/// 测试文件名处理器
/// </summary>
public class TestFileNameProcessor : IFileNameProcessor {
    /// <inheritdoc />
    public ProcessedName Process( string fileName ) {
        if( fileName == "2.png" )
            return new ProcessedName( "a.png", "2.png" );
        return new ProcessedName( fileName, fileName );
    }
}