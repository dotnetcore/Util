using System.Linq;
using Util.Data.Queries;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Util.Helpers;
using Xunit;

namespace Util.Data.Tests.Queries.Conditions; 

/// <summary>
/// 测试double范围过滤条件
/// </summary>
public class DoubleSegmentConditionTest  {
    /// <summary>
    /// 测试获取查询条件
    /// </summary>
    [Fact]
    public void TestGetCondition_1() {
        var condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, 10.1 );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( rightExpression ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 可空
    /// </summary>
    [Fact]
    public void TestGetCondition_2() {
        var condition = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 1.1, 10.1 );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( rightExpression ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 不包含边界
    /// </summary>
    [Fact]
    public void TestGetCondition_3() {
        var condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, 10.1, Boundary.Neither );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.Greater, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( rightExpression ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含左边界
    /// </summary>
    [Fact]
    public void TestGetCondition_4() {
        var condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, 10.1, Boundary.Left );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( rightExpression ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含右边界
    /// </summary>
    [Fact]
    public void TestGetCondition_5() {
        var condition = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 1.1, 10.1, Boundary.Right );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.Greater, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( rightExpression ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含两边
    /// </summary>
    [Fact]
    public void TestGetCondition_6() {
        var condition = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 1.1, 10.1, Boundary.Both );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( rightExpression ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 最小值大于最大值，则交换大小值的位置
    /// </summary>
    [Fact]
    public void TestGetCondition_7() {
        var condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 10.1, 1.1 );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( rightExpression ) );
    }

    /// <summary>
    /// 测试获取查询条件 - 最小值为空，忽略最小值条件
    /// </summary>
    [Fact]
    public void TestGetCondition_8() {
        var condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, null, 10.1 );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 10.1, Lambda.GetValue( leftExpression ) );
        Assert.Single( expression);
    }

    /// <summary>
    /// 测试获取查询条件 - 最大值为空，忽略最大值条件
    /// </summary>
    [Fact]
    public void TestGetCondition_9() {
        var condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, null );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( 1.1, Lambda.GetValue( leftExpression ) );
        Assert.Single( expression );
    }

    /// <summary>
    /// 测试获取查询条件 - 最大值为空，忽略最大值条件
    /// </summary>
    [Fact]
    public void TestGetCondition_10() {
        var condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, null, null );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).FirstOrDefault();
        Assert.Null( expression );
    }
}