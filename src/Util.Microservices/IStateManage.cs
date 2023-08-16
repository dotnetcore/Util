using Util.Data;

namespace Util.Microservices;

/// <summary>
/// 状态管理
/// </summary>
public interface IStateManage : ITransientDependency {
    /// <summary>
    /// 设置状态组件名称
    /// </summary>
    /// <param name="storeName">状态组件名称</param>
    IStateManage StoreName( string storeName );
    /// <summary>
    /// 清理
    /// </summary>
    IStateManage Clear();
    /// <summary>
    /// 开始事务
    /// </summary>
    IStateManage BeginTransaction();
    /// <summary>
    /// 提交事务
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task CommitAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 设置Json序列化配置
    /// </summary>
    /// <param name="options">Json序列化配置</param>
    IStateManage JsonSerializerOptions( JsonSerializerOptions options );
    /// <summary>
    /// 获取数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="key">键名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TValue> GetStateAsync<TValue>( string key, CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取数据和并发标记
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="key">键名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<(TValue value, string etag)> GetStateAndETagAsync<TValue>( string key, CancellationToken cancellationToken = default );
    /// <summary>
    /// 添加数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="key">键名</param>
    /// <param name="value">值</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task AddAsync<TValue>( string key, TValue value, CancellationToken cancellationToken = default );
    /// <summary>
    /// 更新数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="key">键名</param>
    /// <param name="value">值</param>
    /// <param name="etag">并发标记</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<bool> UpdateAsync<TValue>( string key, TValue value, string etag, CancellationToken cancellationToken = default );
    /// <summary>
    /// 删除数据
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task RemoveAsync( string key, CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="key">键名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TValue> GetAsync<TValue>( string key, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag;
    /// <summary>
    /// 获取数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="keys">键列表</param>
    /// <param name="parallelism">并行度</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IList<TValue>> GetAsync<TValue>( IReadOnlyList<string> keys, int? parallelism = 0, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag;
    /// <summary>
    /// 保存数据,返回存储键名
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="value">值</param>
    /// <param name="key">键名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<string> SaveAsync<TValue>( TValue value, string key = null, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag;
}