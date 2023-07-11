using System.Linq;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Util.Helpers;
using Xunit;
using Convert = Util.Helpers.Convert;

namespace Util.Data.Tests.Queries.Conditions; 

/// <summary>
/// 测试double范围过滤条件
/// </summary>
public class DecimalSegmentConditionTest {
    /// <summary>
    /// 测试获取查询条件
    /// </summary>
    [Fact]
    public void TestGetCondition_1() {
        var condition = new DecimalSegmentCondition<Sample, decimal>( t => t.DecimalValue, 1.1M, 10.1M );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Convert.ToDouble( Lambda.GetValue( leftExpression )) );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Convert.ToDouble( Lambda.GetValue( rightExpression ) ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 可空
    /// </summary>
    [Fact]
    public void TestGetCondition_2() {
        var condition = new DecimalSegmentCondition<Sample, decimal?>( t => t.NullableDecimalValue, 1.1M, 10.1M );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Convert.ToDouble( Lambda.GetValue( leftExpression ) ) );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Convert.ToDouble( Lambda.GetValue( rightExpression ) ) );
    }
}