namespace Util.FileStorage; 

/// <summary>
/// 文件扩展名检查器
/// </summary>
public interface IFileExtensionInspector : ISingletonDependency {
    /// <summary>
    /// 获取文件扩展名
    /// </summary>
    /// <param name="stream">文件流</param>
    string GetExtension( Stream stream );
    /// <summary>
    /// 是否图片文件
    /// </summary>
    /// <param name="stream">文件流</param>
    bool IsImage( Stream stream );
    /// <summary>
    /// 是否pdf文件
    /// </summary>
    /// <param name="stream">文件流</param>
    bool IsPdf( Stream stream );
    /// <summary>
    /// 是否Office文件
    /// </summary>
    /// <param name="stream">文件流</param>
    bool IsOffice( Stream stream );
    /// <summary>
    /// 是否视频文件
    /// </summary>
    /// <param name="stream">文件流</param>
    bool IsVideo( Stream stream );
}