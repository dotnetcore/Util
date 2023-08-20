namespace Util.Microservices.Dapr.StateManagements;

/// <summary>
/// 状态存储键生成器
/// </summary>
public class KeyGenerator : IKeyGenerator {
    /// <inheritdoc />
    public string CreateKey<TValue>( string id ) where TValue : IDataKey {
        return id.IsEmpty() ? null : $"{typeof( TValue ).Name!.Replace( ".", "_" )}_{id}";
    }
}