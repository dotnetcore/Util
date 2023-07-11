using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Util.Data.Queries;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Util.Helpers;
using Xunit;

namespace Util.Data.Tests.Queries.Conditions; 

/// <summary>
/// 测试日期范围过滤条件 - 包含时间
/// </summary>
public class DateTimeSegmentConditionTest {
    /// <summary>
    /// 测试初始化
    /// </summary>
    public DateTimeSegmentConditionTest() {
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo( "zh-CN" ) {
            DateTimeFormat = new DateTimeFormatInfo {
                ShortDatePattern = "yyyy/M/d"
            }
        };
        _min = DateTime.Parse( "2000-1-1 10:10:10" );
        _max = DateTime.Parse( "2000-1-2 10:10:10" );
    }

    /// <summary>
    /// 最小日期
    /// </summary>
    private readonly DateTime? _min;
    /// <summary>
    /// 最大日期
    /// </summary>
    private readonly DateTime? _max;

    /// <summary>
    /// 测试获取查询条件
    /// </summary>
    [Fact]
    public void TestGetCondition_DateTime() {
        var condition = new DateTimeSegmentCondition<Sample, DateTime>( t => t.DateValue, _min, _max );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 10:10:10".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-2 10:10:10".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 可空
    /// </summary>
    [Fact]
    public void TestGetCondition_NullableDateTime() {
        var condition = new DateTimeSegmentCondition<Sample, DateTime?>( t => t.NullableDateValue, _min, _max );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 10:10:10".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-2 10:10:10".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 不包含边界
    /// </summary>
    [Fact]
    public void TestGetCondition_Boundary_1() {
        var condition = new DateTimeSegmentCondition<Sample, DateTime>( t => t.DateValue, _min, _max, Boundary.Neither );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.Greater, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 10:10:10".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-2 10:10:10".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含左边界
    /// </summary>
    [Fact]
    public void TestGetCondition_Boundary_2() {
        var condition = new DateTimeSegmentCondition<Sample, DateTime>( t => t.DateValue, _min, _max, Boundary.Left );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 10:10:10".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-2 10:10:10".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含右边界
    /// </summary>
    [Fact]
    public void TestGetCondition_Boundary_3() {
        var condition = new DateTimeSegmentCondition<Sample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Right );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.Greater, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 10:10:10".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-2 10:10:10".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含两边
    /// </summary>
    [Fact]
    public void TestGetCondition_Boundary_4() {
        var condition = new DateTimeSegmentCondition<Sample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Both );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 10:10:10".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.LessEqual, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-2 10:10:10".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }
}