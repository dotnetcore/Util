namespace Util.Domain.Auditing;

/// <summary>
/// 修改时间审计
/// </summary>
public interface ILastModificationTime {
    /// <summary>
    /// 最后修改时间
    /// </summary>
    DateTime? LastModificationTime { get; set; }
}