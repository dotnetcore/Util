using String = Util.Helpers.String;

namespace Util;

/// <summary>
/// 字符串扩展
/// </summary>
public static class StringExtensions {
    /// <summary>
    /// 移除起始字符串
    /// </summary>
    /// <param name="value">值</param>
    /// <param name="start">要移除的值</param>
    /// <param name="ignoreCase">是否忽略大小写,默认值: true</param>
    public static string RemoveStart( this string value, string start, bool ignoreCase = true ) {
        return String.RemoveStart( value, start, ignoreCase );
    }

    /// <summary>
    /// 移除末尾字符串
    /// </summary>
    /// <param name="value">值</param>
    /// <param name="end">要移除的值</param>
    /// <param name="ignoreCase">是否忽略大小写,默认值: true</param>
    public static string RemoveEnd( this string value, string end, bool ignoreCase = true ) {
        return String.RemoveEnd( value, end, ignoreCase );
    }

    /// <summary>
    /// 移除起始字符串
    /// </summary>
    /// <param name="value">值</param>
    /// <param name="start">要移除的值</param>
    public static StringBuilder RemoveStart( this StringBuilder value, string start ) {
        return String.RemoveStart( value, start );
    }

    /// <summary>
    /// 移除末尾字符串
    /// </summary>
    /// <param name="value">值</param>
    /// <param name="end">要移除的值</param>
    public static StringBuilder RemoveEnd( this StringBuilder value, string end ) {
        return String.RemoveEnd( value, end );
    }

    /// <summary>
    /// 移除起始字符串
    /// </summary>
    /// <param name="writer">字符串写入器</param>
    /// <param name="start">要移除的值</param>
    public static StringWriter RemoveStart( this StringWriter writer, string start ) {
        if ( writer == null )
            return null;
        var builder = writer.GetStringBuilder();
        builder.RemoveStart( start );
        return writer;
    }

    /// <summary>
    /// 移除末尾字符串
    /// </summary>
    /// <param name="writer">字符串写入器</param>
    /// <param name="end">要移除的值</param>
    public static StringWriter RemoveEnd( this StringWriter writer, string end ) {
        if ( writer == null )
            return null;
        var builder = writer.GetStringBuilder();
        builder.RemoveEnd( end );
        return writer;
    }
}