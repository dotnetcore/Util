namespace Util.Data;

/// <summary>
/// 连接字符串集合
/// </summary>
public class ConnectionStringCollection : Dictionary<string, string> {
    /// <summary>
    /// 默认连接字符串名称,值: Default
    /// </summary>
    public const string DefaultName = "Default";

    /// <summary>
    /// 默认连接字符串
    /// </summary>
    public string Default {
        get => this.GetValue( DefaultName );
        set => this[DefaultName] = value;
    }

    /// <summary>
    /// 获取连接字符串
    /// </summary>
    /// <param name="name">连接字符串名称</param>
    public string GetConnectionString( string name ) {
        return ContainsKey( name ) ? this.GetValue( name ) : Default;
    }
}