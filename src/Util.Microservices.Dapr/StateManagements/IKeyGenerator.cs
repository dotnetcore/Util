namespace Util.Microservices.Dapr.StateManagements; 

/// <summary>
/// 状态存储键生成器
/// </summary>
public interface IKeyGenerator : ISingletonDependency {
    /// <summary>
    /// 创建状态存储键
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="value">值</param>
    string CreateKey<TValue>( TValue value ) where TValue : IDataKey, IETag;
}