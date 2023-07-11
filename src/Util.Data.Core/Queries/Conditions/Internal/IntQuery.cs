namespace Util.Data.Queries.Conditions.Internal;

/// <summary>
/// int范围查询参数对象 - 使用该对象的目的是构建参数化条件
/// </summary>
internal class IntQuery {
    /// <summary>
    /// 最小值
    /// </summary>
    public int? MinValue { get; set; }
    /// <summary>
    /// 最大值
    /// </summary>
    public int? MaxValue { get; set; }
}