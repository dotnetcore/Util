using Util.Data.Queries.Conditions.Internal;

namespace Util.Data.Queries.Conditions; 

/// <summary>
/// 整数范围过滤条件
/// </summary>
/// <typeparam name="TEntity">实体类型</typeparam>
/// <typeparam name="TProperty">属性类型</typeparam>
public class IntSegmentCondition<TEntity, TProperty> : SegmentConditionBase<TEntity, TProperty, int> where TEntity : class {
    /// <summary>
    /// 范围查询参数对象
    /// </summary>
    private readonly IntQuery _query;

    /// <summary>
    /// 初始化整数范围过滤条件
    /// </summary>
    /// <param name="propertyExpression">属性表达式</param>
    /// <param name="min">最小值</param>
    /// <param name="max">最大值</param>
    /// <param name="boundary">包含边界</param>
    public IntSegmentCondition( Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max, Boundary boundary = Boundary.Both )
        : base( propertyExpression,min,max, boundary ) {
        _query = new IntQuery();
    }

    /// <summary>
    /// 最小值是否大于最大值
    /// </summary>
    protected override bool IsMinGreaterMax( int? min, int? max ) {
        return min > max;
    }

    /// <summary>
    /// 获取最小值表达式
    /// </summary>
    protected override Expression GetMinValueExpression() {
        _query.MinValue = GetMinValue();
        return Expression.Property( Expression.Constant( _query ), "MinValue" );
    }

    /// <summary>
    /// 获取最大值表达式
    /// </summary>
    protected override Expression GetMaxValueExpression() {
        _query.MaxValue = GetMaxValue();
        return Expression.Property( Expression.Constant( _query ), "MaxValue" );
    }
}