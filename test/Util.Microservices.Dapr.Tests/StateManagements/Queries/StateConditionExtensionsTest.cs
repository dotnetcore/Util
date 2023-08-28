namespace Util.Microservices.Dapr.Tests.StateManagements.Queries;

/// <summary>
/// 状态对象查询条件扩展测试
/// </summary>
public class StateConditionExtensionsTest {

    #region And

    /// <summary>
    /// 测试And连接条件 - 两个条件都为空
    /// </summary>
    [Fact]
    public void TestAnd_1() {
        IStateCondition condition1 = null;
        IStateCondition condition2 = null;
        var result = condition1.And( condition2 );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试And连接条件 - 第1个条件为空
    /// </summary>
    [Fact]
    public void TestAnd_2() {
        IStateCondition condition1 = null;
        IStateCondition condition2 = new EqualCondition( "a", "1" );
        var result = condition1.And( condition2 );
        var json = Json.ToJson( result );
        Assert.Equal( "{\"EQ\":{\"a\":\"1\"}}", json );
    }

    /// <summary>
    /// 测试And连接条件 - 第2个条件为空
    /// </summary>
    [Fact]
    public void TestAnd_3() {
        IStateCondition condition1 = new EqualCondition( "a", "1" );
        IStateCondition condition2 = null;
        var result = condition1.And( condition2 );
        var json = Json.ToJson( result );
        Assert.Equal( "{\"EQ\":{\"a\":\"1\"}}", json );
    }

    /// <summary>
    /// 测试And连接条件 - 2个相等条件连接
    /// </summary>
    [Fact]
    public void TestAnd_4() {
        IStateCondition condition1 = new EqualCondition( "a", "1" );
        IStateCondition condition2 = new EqualCondition( "b", "2" );
        var and = condition1.And( condition2 );
        var json = Json.ToJson( and );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试And连接条件 - 第1个条件为And
    /// </summary>
    [Fact]
    public void TestAnd_5() {
        IStateCondition condition1 = new AndCondition( new EqualCondition( "a", "1" ) );
        IStateCondition condition2 = new EqualCondition( "b", "2" );
        var and = condition1.And( condition2 );
        var json = Json.ToJson( and );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试And连接条件 - 第2个条件为And
    /// </summary>
    [Fact]
    public void TestAnd_6() {
        IStateCondition condition1 = new EqualCondition( "a", "1" );
        IStateCondition condition2 = new AndCondition( new EqualCondition( "b", "2" ) );
        var and = condition1.And( condition2 );
        var json = Json.ToJson( and );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}," );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试And连接条件 - 2个条件都为And
    /// </summary>
    [Fact]
    public void TestAnd_7() {
        IStateCondition condition1 = new AndCondition( new EqualCondition( "a", "1" ) );
        IStateCondition condition2 = new AndCondition( new EqualCondition( "b", "2" ) );
        var and = condition1.And( condition2 );
        var json = Json.ToJson( and );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    #endregion

    #region Or

    /// <summary>
    /// 测试Or连接条件 - 两个条件都为空
    /// </summary>
    [Fact]
    public void TestOr_1() {
        IStateCondition condition1 = null;
        IStateCondition condition2 = null;
        var result = condition1.Or( condition2 );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试Or连接条件 - 第1个条件为空
    /// </summary>
    [Fact]
    public void TestOr_2() {
        IStateCondition condition1 = null;
        IStateCondition condition2 = new EqualCondition( "a", "1" );
        var result = condition1.Or( condition2 );
        var json = Json.ToJson( result );
        Assert.Equal( "{\"EQ\":{\"a\":\"1\"}}", json );
    }

    /// <summary>
    /// 测试Or连接条件 - 第2个条件为空
    /// </summary>
    [Fact]
    public void TestOr_3() {
        IStateCondition condition1 = new EqualCondition( "a", "1" );
        IStateCondition condition2 = null;
        var result = condition1.Or( condition2 );
        var json = Json.ToJson( result );
        Assert.Equal( "{\"EQ\":{\"a\":\"1\"}}", json );
    }

    /// <summary>
    /// 测试Or连接条件 - 2个相等条件连接
    /// </summary>
    [Fact]
    public void TestOr_4() {
        IStateCondition condition1 = new EqualCondition( "a", "1" );
        IStateCondition condition2 = new EqualCondition( "b", "2" );
        var or = condition1.Or( condition2 );
        var json = Json.ToJson( or );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"OR\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试Or连接条件 - 第1个条件为Or
    /// </summary>
    [Fact]
    public void TestOr_5() {
        IStateCondition condition1 = new OrCondition( new EqualCondition( "a", "1" ) );
        IStateCondition condition2 = new EqualCondition( "b", "2" );
        var or = condition1.Or( condition2 );
        var json = Json.ToJson( or );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"OR\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试Or连接条件 - 第2个条件为Or
    /// </summary>
    [Fact]
    public void TestOr_6() {
        IStateCondition condition1 = new EqualCondition( "a", "1" );
        IStateCondition condition2 = new OrCondition( new EqualCondition( "b", "2" ) );
        var or = condition1.Or( condition2 );
        var json = Json.ToJson( or );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"OR\":[" );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}," );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试Or连接条件 - 2个条件都为Or
    /// </summary>
    [Fact]
    public void TestOr_7() {
        IStateCondition condition1 = new OrCondition( new EqualCondition( "a", "1" ) );
        IStateCondition condition2 = new OrCondition( new EqualCondition( "b", "2" ) );
        var or = condition1.Or( condition2 );
        var json = Json.ToJson( or );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"OR\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    #endregion
}