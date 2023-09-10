namespace Util; 

/// <summary>
/// 字典操作扩展
/// </summary>
public static class DictionaryExtensions {
    /// <summary>
    /// 获取值
    /// </summary>
    /// <param name="source">字典数据</param>
    /// <param name="key">键</param>
    public static TValue GetValue<TKey, TValue>( this IDictionary<TKey, TValue> source, TKey key ) {
        if ( source == null )
            return default;
        return source.TryGetValue( key, out var obj ) ? obj : default;
    }
}