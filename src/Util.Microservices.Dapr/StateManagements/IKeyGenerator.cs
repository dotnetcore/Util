namespace Util.Microservices.Dapr.StateManagements; 

/// <summary>
/// 状态存储键生成器
/// </summary>
public interface IKeyGenerator : ISingletonDependency {
    /// <summary>
    /// 创建状态存储键
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="id">标识</param>
    string CreateKey<TValue>( string id ) where TValue : IDataKey;
}