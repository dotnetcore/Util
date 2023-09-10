using Util.Data.Queries;

namespace Util.Microservices;

/// <summary>
/// 状态管理
/// </summary>
public interface IStateManagerBase<out TStateManager> : ITransientDependency where TStateManager : IStateManagerBase<TStateManager> {
    /// <summary>
    /// 设置状态组件名称
    /// </summary>
    /// <param name="storeName">状态组件名称</param>
    TStateManager StoreName( string storeName );
    /// <summary>
    /// 清理
    /// </summary>
    TStateManager Clear();
    /// <summary>
    /// 开始事务
    /// </summary>
    TStateManager BeginTransaction();
    /// <summary>
    /// 设置Json序列化配置
    /// </summary>
    /// <param name="options">Json序列化配置</param>
    TStateManager JsonSerializerOptions( JsonSerializerOptions options );
    /// <summary>
    /// 设置元数据
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    TStateManager Metadata( string key, string value );
    /// <summary>
    /// 设置元数据
    /// </summary>
    /// <param name="metadata">元数据键值对集合</param>
    TStateManager Metadata( IDictionary<string, string> metadata );
    /// <summary>
    /// 移除元数据
    /// </summary>
    /// <param name="key">键</param>
    TStateManager RemoveMetadata( string key );
    /// <summary>
    /// 设置内容类型: contentType
    /// </summary>
    /// <param name="type">内容类型</param>
    TStateManager ContentType( string type );
    /// <summary>
    /// 添加分页大小
    /// </summary>
    /// <param name="pageSize">分页大小</param>
    TStateManager Limit( int pageSize );
    /// <summary>
    /// 添加迭代令牌,即分页跳过行数
    /// </summary>
    /// <param name="token">迭代令牌,即分页跳过行数</param>
    TStateManager Token( int token );
    /// <summary>
    /// 添加排序条件
    /// </summary>
    /// <param name="orderBy">排序条件,范例: a,b desc</param>
    TStateManager OrderBy( string orderBy );
    /// <summary>
    /// 设置相等条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="value">属性值</param>
    TStateManager Equal( string property, object value );
    /// <summary>
    /// 根据规则添加相等查询条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="value">属性值</param>
    /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
    TStateManager EqualIf( string property, object value, bool condition );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="values">属性值</param>
    TStateManager In( string property, IEnumerable<object> values );
    /// <summary>
    /// 设置In条件
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="values">属性值</param>
    TStateManager In( string property, params object[] values );
    /// <summary>
    /// 设置And连接条件
    /// </summary>
    /// <param name="conditions">属性名</param>
    TStateManager And( params IStateCondition[] conditions );
    /// <summary>
    /// 设置Or连接条件
    /// </summary>
    /// <param name="conditions">属性名</param>
    TStateManager Or( params IStateCondition[] conditions );
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
    /// 通过标识删除数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="id">标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task RemoveByIdAsync<TValue>( string id, CancellationToken cancellationToken = default ) where TValue : IDataKey;
    /// <summary>
    /// 保存数据,返回存储键名
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="value">值</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <param name="key">键名</param>
    Task<string> SaveAsync<TValue>( TValue value, CancellationToken cancellationToken = default, string key = null ) where TValue : IDataKey, IETag;
    /// <summary>
    /// 批量保存数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="values">值</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task SaveAsync<TValue>( IEnumerable<TValue> values, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag;
    /// <summary>
    /// 提交事务
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task CommitAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 通过标识获取存储键
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="id">标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<string> GetKeyByIdAsync<TValue>( string id, CancellationToken cancellationToken = default ) where TValue : IDataKey;
    /// <summary>
    /// 获取数据和并发标记
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="key">键名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<(TValue value, string etag)> GetStateAndETagAsync<TValue>( string key, CancellationToken cancellationToken = default );
    /// <summary>
    /// 通过键名获取数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="key">键名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TValue> GetAsync<TValue>( string key, CancellationToken cancellationToken = default );
    /// <summary>
    /// 通过键名获取数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="keys">键列表</param>
    /// <param name="parallelism">并行度</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IList<TValue>> GetAsync<TValue>( IReadOnlyList<string> keys, int? parallelism = 0, CancellationToken cancellationToken = default );
    /// <summary>
    /// 通过标识获取数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="id">标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TValue> GetByIdAsync<TValue>( string id, CancellationToken cancellationToken = default ) where TValue : IDataKey;
    /// <summary>
    /// 获取指定类型的单条数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="cancellationToken">取消令牌</param>
    Task<TValue> SingleAsync<TValue>( CancellationToken cancellationToken = default ) where TValue : IDataKey;
    /// <summary>
    /// 获取指定类型的全部数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IList<TValue>> GetAllAsync<TValue>( CancellationToken cancellationToken = default );
    /// <summary>
    /// 查询
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IList<TValue>> QueryAsync<TValue>( CancellationToken cancellationToken = default );
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="page">分页参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<PageList<TValue>> PageQueryAsync<TValue>( IPage page, CancellationToken cancellationToken = default );
}