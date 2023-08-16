namespace Util.Microservices.Dapr.StateManagements;

/// <summary>
/// 状态存储键生成器
/// </summary>
public class KeyGenerator : IKeyGenerator {
    /// <inheritdoc />
    public string CreateKey<TValue>( TValue value ) where TValue : IDataKey, IETag {
        return value == null ? null : $"{value.GetType().FullName!.Replace( ".", "_" )}_{value.Id}";
    }
}