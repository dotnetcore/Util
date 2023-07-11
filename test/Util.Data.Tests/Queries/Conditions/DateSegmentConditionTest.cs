using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Util.Data.Queries;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;
using Thread = System.Threading.Thread;

namespace Util.Data.Tests.Queries.Conditions; 

/// <summary>
/// 测试日期范围过滤条件 - 不包含时间
/// </summary>
public class DateSegmentConditionTest {
    /// <summary>
    /// 输出日志
    /// </summary>
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public DateSegmentConditionTest( ITestOutputHelper output) {
        Thread.CurrentThread.CurrentCulture = new CultureInfo( "zh-CN" ) {
            DateTimeFormat = new DateTimeFormatInfo {
                ShortDatePattern = "yyyy/M/d"
            }
        };
        _output = output;
        _min = "2000-1-1 10:10:10".ToDateTime();
        _max = "2000-1-3 10:10:10".ToDateTime();
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
    /// 测试获取查询条件 - 不包含边界
    /// </summary>
    [Fact]
    public void TestGetCondition_Neither() {
        var condition = new DateSegmentCondition<Sample, DateTime>( t => t.DateValue, _min, _max, Boundary.Neither );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        _output.WriteLine( condition.GetCondition().ToString() );
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-2 00:00:00".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-3 00:00:00".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含左边
    /// </summary>
    [Fact]
    public void TestGetCondition_Left() {
        var condition = new DateSegmentCondition<Sample, DateTime>( t => t.DateValue, _min, _max, Boundary.Left );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        _output.WriteLine( condition.GetCondition().ToString() );
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 00:00:00".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-3 00:00:00".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含右边
    /// </summary>
    [Fact]
    public void TestGetCondition_Right() {
        var condition = new DateSegmentCondition<Sample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Right );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        _output.WriteLine( condition.GetCondition().ToString() );
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-2 00:00:00".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-4 00:00:00".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }

    /// <summary>
    /// 测试获取查询条件 - 包含两边
    /// </summary>
    [Fact]
    public void TestGetCondition_Both() {
        var condition = new DateSegmentCondition<Sample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Both );
        var expression = Lambda.GetGroupPredicates( condition.GetCondition() ).First();
        var leftExpression = expression[0];
        var rightExpression = expression[1];
        _output.WriteLine( condition.GetCondition().ToString() );
        Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( leftExpression ) );
        Assert.Equal( "2000-1-1 00:00:00".ToDateTime(), Lambda.GetValue( leftExpression ).SafeString().ToDateTime() );
        Assert.Equal( Operator.Less, Lambda.GetOperator( rightExpression ) );
        Assert.Equal( "2000-1-4 00:00:00".ToDateTime(), Lambda.GetValue( rightExpression ).SafeString().ToDateTime() );
    }
}