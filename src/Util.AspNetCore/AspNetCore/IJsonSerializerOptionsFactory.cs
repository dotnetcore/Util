namespace Util.AspNetCore; 

/// <summary>
/// Json序列化配置工厂
/// </summary>
public interface IJsonSerializerOptionsFactory : ISingletonDependency {
    /// <summary>
    /// 创建Json序列化配置
    /// </summary>
    JsonSerializerOptions CreateOptions();
}