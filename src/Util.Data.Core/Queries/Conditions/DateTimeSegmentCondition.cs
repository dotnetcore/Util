using Util.Data.Queries.Conditions.Internal;

namespace Util.Data.Queries.Conditions; 

/// <summary>
/// 日期范围过滤条件 - 包含时间
/// </summary>
/// <typeparam name="TEntity">实体类型</typeparam>
/// <typeparam name="TProperty">属性类型</typeparam>
public class DateTimeSegmentCondition<TEntity, TProperty> : SegmentConditionBase<TEntity, TProperty, DateTime> where TEntity : class {
    /// <summary>
    /// 日期范围查询参数对象
    /// </summary>
    private readonly DateTimeQuery _query;

    /// <summary>
    /// 初始化日期范围过滤条件 - 包含时间
    /// </summary>
    /// <param name="propertyExpression">属性表达式</param>
    /// <param name="min">最小值</param>
    /// <param name="max">最大值</param>
    /// <param name="boundary">包含边界</param>
    public DateTimeSegmentCondition( Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, Boundary boundary = Boundary.Both )
        : base( propertyExpression, min, max, boundary ) {
        _query = new DateTimeQuery();
    }

    /// <summary>
    /// 最小值是否大于最大值
    /// </summary>
    protected override bool IsMinGreaterMax( DateTime? min, DateTime? max ) {
        return min > max;
    }

    /// <summary>
    /// 获取最小值表达式
    /// </summary>
    protected override Expression GetMinValueExpression() {
        return GetMinValueExpression( GetMinValue() );
    }

    /// <summary>
    /// 获取最小值表达式
    /// </summary>
    protected Expression GetMinValueExpression( DateTime? value ) {
        _query.BeginTime = value;
        return Expression.Property( Expression.Constant( _query ), "BeginTime" );
    }

    /// <summary>
    /// 获取最大值表达式
    /// </summary>
    protected override Expression GetMaxValueExpression() {
        return GetMaxValueExpression( GetMaxValue() );
    }

    /// <summary>
    /// 获取最大值表达式
    /// </summary>
    protected Expression GetMaxValueExpression( DateTime? value ) {
        _query.EndTime = value;
        return Expression.Property( Expression.Constant( _query ), "EndTime" );
    }
}