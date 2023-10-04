namespace Util.Localization.Store;

/// <summary>
/// 本地化资源存储器
/// </summary>
public interface ILocalizedStore {
    /// <summary>
    /// 获取本地化资源值,未查找到资源返回null
    /// </summary>
    /// <param name="culture">区域文化,范例: zh-CN</param>
    /// <param name="type">资源类型</param>
    /// <param name="name">资源名称</param>
    string GetValue( string culture, string type, string name );
    /// <summary>
    /// 获取区域文化列表
    /// </summary>
    IList<string> GetCultures();
    /// <summary>
    /// 获取资源类型列表
    /// </summary>
    IList<string> GetTypes();
    /// <summary>
    /// 获取本地化资源集合
    /// </summary>
    /// <param name="culture">区域文化,范例: zh-CN</param>
    /// <param name="type">资源类型</param>
    IDictionary<string, string> GetResources( string culture, string type );
}