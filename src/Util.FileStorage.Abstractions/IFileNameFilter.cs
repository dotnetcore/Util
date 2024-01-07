namespace Util.FileStorage; 

/// <summary>
/// 文件名过滤器
/// </summary>
public interface IFileNameFilter : ISingletonDependency {
    /// <summary>
    /// 过滤文件名
    /// </summary>
    /// <param name="fileName">文件名</param>
    string Filter( string fileName );
}