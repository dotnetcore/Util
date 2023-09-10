namespace Util.Data; 

/// <summary>
/// 连接字符串名称
/// </summary>
public class ConnectionStringNameAttribute : Attribute {
    /// <summary>
    /// 连接字符串名称
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 初始化连接字符串名称
    /// </summary>
    /// <param name="name">连接字符串名称</param>
    public ConnectionStringNameAttribute( string name ) {
        Name = name;
    }

    /// <summary>
    /// 获取连接字符串名称,如果未设置名称则返回类型名
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public static string GetName<T>() {
        return GetName( typeof( T ) );
    }

    /// <summary>
    /// 获取连接字符串名称,如果未设置名称则返回类型名
    /// </summary>
    /// <param name="type">类型</param>
    public static string GetName( Type type ) {
        if ( type == null )
            return null;
        var attribute = type.GetCustomAttribute<ConnectionStringNameAttribute>();
        return attribute == null || attribute.Name.IsEmpty() ? type.Name : attribute.Name;
    }
}