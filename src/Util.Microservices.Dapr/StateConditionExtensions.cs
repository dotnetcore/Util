using Util.Microservices.Dapr.StateManagements.Queries.Conditions;

namespace Util.Microservices.Dapr;

/// <summary>
/// 状态对象查询条件扩展
/// </summary>
public static class StateConditionExtensions {
    /// <summary>
    /// 使用And条件连接
    /// </summary>
    /// <param name="source">源查询条件</param>
    /// <param name="condition">目标查询条件</param>
    public static IStateCondition And( this IStateCondition source, IStateCondition condition ) {
        if ( condition == null )
            return source;
        if ( source == null )
            return condition;
        if ( source is AndCondition andCondition ) {
            andCondition.AddCondition( condition );
            return andCondition;
        }
        if ( condition is AndCondition andCondition2 ) {
            andCondition2.AddCondition( source );
            return andCondition2;
        }
        return new AndCondition( source, condition );
    }

    /// <summary>
    /// 使用Or条件连接
    /// </summary>
    /// <param name="source">源查询条件</param>
    /// <param name="condition">目标查询条件</param>
    public static IStateCondition Or( this IStateCondition source, IStateCondition condition ) {
        if ( condition == null )
            return source;
        if ( source == null )
            return condition;
        if ( source is OrCondition orCondition ) {
            orCondition.AddCondition( condition );
            return orCondition;
        }
        if ( condition is OrCondition orCondition2 ) {
            orCondition2.AddCondition( source );
            return orCondition2;
        }
        return new OrCondition( source, condition );
    }
}