namespace Util.Microservices; 

/// <summary>
/// 发布订阅名称
/// </summary>
public class PubsubNameAttribute : Attribute {
    /// <summary>
    /// 发布订阅名称
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 初始化发布订阅名称
    /// </summary>
    /// <param name="name">发布订阅名称</param>
    public PubsubNameAttribute( string name ) {
        Name = name;
    }

    /// <summary>
    /// 获取发布订阅名称,未设置则返回默认值: pubsub
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public static string GetName<T>() {
        return GetName( typeof( T ) );
    }

    /// <summary>
    /// 获取发布订阅名称
    /// </summary>
    /// <param name="type">类型</param>
    public static string GetName( Type type ) {
        if ( type == null )
            return null;
        var attribute = type.GetCustomAttribute<PubsubNameAttribute>();
        return attribute == null || attribute.Name.IsEmpty() ? "pubsub" : attribute.Name;
    }
}