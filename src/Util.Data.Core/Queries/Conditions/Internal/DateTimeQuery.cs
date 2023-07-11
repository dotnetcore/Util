namespace Util.Data.Queries.Conditions.Internal;

/// <summary>
/// 日期范围查询参数对象 - 使用该对象的目的是构建参数化条件
/// </summary>
internal class DateTimeQuery {
    /// <summary>
    /// 起始时间
    /// </summary>
    public DateTime? BeginTime { get; set; }
    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }
}