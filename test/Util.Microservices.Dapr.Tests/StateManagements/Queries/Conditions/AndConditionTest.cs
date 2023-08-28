namespace Util.Microservices.Dapr.Tests.StateManagements.Queries.Conditions;

/// <summary>
/// And查询条件测试
/// </summary>
public class AndConditionTest {
    /// <summary>
    /// 测试And条件 - 1个条件
    /// </summary>
    [Fact]
    public void Test_1() {
        var equalCondition = new EqualCondition( "a", "1" );
        var andCondition = new AndCondition( equalCondition );
        var json = Util.Helpers.Json.ToJson( andCondition );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}" );
        result.Append( "]" );
        result.Append( "}" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试And条件 - 2个条件
    /// </summary>
    [Fact]
    public void Test_2() {
        var equalCondition1 = new EqualCondition( "a", "1" );
        var equalCondition2 = new EqualCondition( "b", "2" );
        var andCondition = new AndCondition( equalCondition1, equalCondition2 );
        var json = Util.Helpers.Json.ToJson( andCondition );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试And条件 - 3个条件
    /// </summary>
    [Fact]
    public void Test_3() {
        //创建and条件
        var equalCondition1 = new EqualCondition( "a", "1" );
        var equalCondition2 = new EqualCondition( "b", "2" );
        var andCondition = new AndCondition( equalCondition1, equalCondition2 );

        //添加第3个条件
        var equalCondition3 = new EqualCondition( "c", "3" );
        andCondition.AddCondition( equalCondition3 );

        //获取json
        var json = Util.Helpers.Json.ToJson( andCondition );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}," );
        result.Append( "{\"EQ\":{\"c\":\"3\"}}" );
        result.Append( "]" );
        result.Append( "}" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试And条件 - and条件合并
    /// </summary>
    [Fact]
    public void Test_4() {
        //创建and条件
        var equalCondition1 = new EqualCondition( "a", "1" );
        var equalCondition2 = new EqualCondition( "b", "2" );
        var andCondition = new AndCondition( equalCondition1, equalCondition2 );

        //添加第3个条件
        var equalCondition3 = new EqualCondition( "c", "3" );
        var andCondition2 = new AndCondition( andCondition, equalCondition3 );

        //获取json
        var json = Util.Helpers.Json.ToJson( andCondition2 );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}," );
        result.Append( "{\"EQ\":{\"c\":\"3\"}}" );
        result.Append( "]" );
        result.Append( "}" );
        Assert.Equal( result.ToString(), json );
    }
}