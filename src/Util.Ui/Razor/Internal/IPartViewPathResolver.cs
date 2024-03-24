namespace Util.Ui.Razor.Internal;

/// <summary>
/// 分部视图路径解析器
/// </summary>
public interface IPartViewPathResolver {
    /// <summary>
    /// 从视图文件内容解析分部视图路径
    /// </summary>
    /// <param name="path">视图路径</param>
    /// <param name="content">视图文件内容</param>
    List<string> Resolve( string path, string content );
}