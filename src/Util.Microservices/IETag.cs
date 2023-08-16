namespace Util.Microservices;

/// <summary>
/// 乐观锁
/// </summary>
public interface IETag {
    /// <summary>
    /// 并发标记
    /// </summary>
    string ETag { get; set; }
}