namespace Util.Ui;

/// <summary>
/// 模型名称
/// </summary>
public static class ModelName {
    /// <summary>
    /// 模型名称映射
    /// </summary>
    private static readonly AsyncLocal<Dictionary<Type, string>> _modelNames = new();

    /// <summary>
    /// 添加模型名称映射
    /// </summary>
    /// <typeparam name="T">模型类型</typeparam>
    /// <param name="name">模型名称</param>
    public static void Add<T>( string name ) {
        _modelNames.Value ??= new Dictionary<Type, string>();
        _modelNames.Value.Add( typeof( T ), name );
    }

    /// <summary>
    /// 获取模型名称
    /// </summary>
    /// <typeparam name="T">模型类型</typeparam>
    public static string Get<T>() {
        return Get( typeof( T ) );
    }

    /// <summary>
    /// 获取模型名称
    /// </summary>
    /// <param name="type">模型类型</param>
    public static string Get(Type type) {
        return _modelNames.Value?.GetValue( type );
    }
}