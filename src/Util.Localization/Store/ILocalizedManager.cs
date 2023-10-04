namespace Util.Localization.Store;

/// <summary>
/// 本地化资源管理器
/// </summary>
public interface ILocalizedManager {
    /// <summary>
    /// 加载全部本地化资源
    /// </summary>
    void LoadAllResources();
    /// <summary>
    /// 加载全部本地化资源
    /// </summary>
    /// <param name="culture">区域文化,范例: zh-CN</param>
    void LoadAllResources( string culture );
    /// <summary>
    /// 加载全部本地化资源
    /// </summary>
    /// <param name="culture">区域文化,范例: zh-CN</param>
    /// <param name="type">资源类型</param>
    void LoadAllResources( string culture, string type );
    /// <summary>
    /// 加载指定类型的本地化资源
    /// </summary>
    /// <param name="type">资源类型</param>
    void LoadResourcesByType( string type );
}