namespace Util; 

/// <summary>
/// Json配置
/// </summary>
public class JsonOptions {
    /// <summary>
    /// 初始化Json配置
    /// </summary>
    public JsonOptions() {
        IgnoreNullValues = true;
        IgnoreEmptyString = true;
        IgnoreCase = true;
        IgnoreInterface = true;
    }

    /// <summary>
    /// 是否移除双引号,默认值: false
    /// </summary>
    public bool RemoveQuotationMarks { get; set; }
    /// <summary>
    /// 是否将双引号转成单引号,默认值: false
    /// </summary>
    public bool ToSingleQuotes { get; set; }
    /// <summary>
    /// 是否忽略null值,默认值: true
    /// </summary>
    public bool IgnoreNullValues { get; set; }
    /// <summary>
    /// 是否忽略空字符串,默认值: true
    /// </summary>
    public bool IgnoreEmptyString { get; set; }
    /// <summary>
    /// 转换为Json时,属性名是否使用驼峰形式
    /// </summary>
    public bool ToCamelCase { get; set; }
    /// <summary>
    /// 反序列化时是否忽略大小写,默认值: true
    /// </summary>
    public bool IgnoreCase { get; set; }
    /// <summary>
    /// 反序列化接口实例时是否忽略接口,按实现类进行序列化,默认值: true
    /// </summary>
    public bool IgnoreInterface { get; set; }
}