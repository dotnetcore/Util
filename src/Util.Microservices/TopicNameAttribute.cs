namespace Util.Microservices;

/// <summary>
/// 事件主题名称
/// </summary>
public class TopicNameAttribute : Attribute {
    /// <summary>
    /// 事件主题名称
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 初始化事件主题名称
    /// </summary>
    /// <param name="name">事件主题名称</param>
    public TopicNameAttribute( string name ) {
        Name = name;
    }

    /// <summary>
    /// 获取事件主题名称
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public static string GetName<T>() {
        return GetName( typeof( T ) );
    }

    /// <summary>
    /// 获取事件主题名称
    /// </summary>
    /// <param name="type">类型</param>
    public static string GetName( Type type ) {
        if ( type == null )
            return null;
        var attribute = type.GetCustomAttribute<TopicNameAttribute>();
        return attribute == null || attribute.Name.IsEmpty() ? type.Name : attribute.Name;
    }
}