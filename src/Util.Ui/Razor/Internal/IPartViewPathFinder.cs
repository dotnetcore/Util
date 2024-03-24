namespace Util.Ui.Razor.Internal;

/// <summary>
/// 分部视图路径查找器
/// </summary>
public interface IPartViewPathFinder {
    /// <summary>
    /// 查找分部视图的路径
    /// </summary>
    /// <param name="viewPath">主视图路径</param>
    /// <param name="partViewName">分部视图名称, partial 标签的 name 属性</param>
    string Find( string viewPath, string partViewName );
}