namespace Util.Microservices.Dapr.Tests.StateManagements.Queries;

/// <summary>
/// 状态查询对象测试
/// </summary>
public class StateQueryTest {
    /// <summary>
    /// 状态查询对象
    /// </summary>
    private readonly StateQuery _query;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public StateQueryTest() {
        _query = new StateQuery();
    }

    /// <summary>
    /// 测试默认输出
    /// </summary>
    [Fact]
    public void TestDefault() {
        var json = Util.Helpers.Json.ToJson( _query );
        Assert.Equal( "{}", json );
    }

    /// <summary>
    /// 测试过滤条件
    /// </summary>
    [Fact]
    public void TestFilter() {
        var filter = new StateFilter();
        filter.Equal( "a","1" );
        _query.Filter = filter.GetCondition();
        var json = Json.ToJson( _query );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"filter\":{" );
        result.Append( "\"EQ\":{\"a\":\"1\"}" );
        result.Append( "}}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试排序条件
    /// </summary>
    [Fact]
    public void TestSort() {
        var sort = new StateSort { "a", "b desc" };
        _query.Sort = sort;
        var json = Json.ToJson( _query );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"sort\":" );
        result.Append( "[" );
        result.Append( "{\"key\":\"a\"}," );
        result.Append( "{\"key\":\"b\"," );
        result.Append( "\"order\":\"DESC\"}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试分页条件
    /// </summary>
    [Fact]
    public void TestPage() {
        var page = new StatePage { Limit = 1,Token = "2"};
        _query.Page = page;
        var json = Json.ToJson( _query );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"page\":{" );
        result.Append( "\"limit\":1," );
        result.Append( "\"token\":\"2\"" );
        result.Append( "}}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }
}