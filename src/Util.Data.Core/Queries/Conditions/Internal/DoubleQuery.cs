namespace Util.Data.Queries.Conditions.Internal;

/// <summary>
/// double范围查询参数对象 - 使用该对象的目的是构建参数化条件
/// </summary>
internal class DoubleQuery {
    /// <summary>
    /// 最小值
    /// </summary>
    public double? MinValue { get; set; }
    /// <summary>
    /// 最大值
    /// </summary>
    public double? MaxValue { get; set; }
}