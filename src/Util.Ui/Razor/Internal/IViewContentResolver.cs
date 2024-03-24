namespace Util.Ui.Razor.Internal;

/// <summary>
/// 视图内容解析器
/// </summary>
public interface IViewContentResolver {
    /// <summary>
    /// 解析视图文件内容
    /// </summary>
    /// <param name="path">视图路径</param>
    string Resolve( string path );
}