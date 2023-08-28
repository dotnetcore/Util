namespace Util.Microservices.Dapr.Tests.StateManagements.Queries.Conditions; 

/// <summary>
/// 相等查询条件测试
/// </summary>
public class EqualConditionTest {
    /// <summary>
    /// 测试相等条件
    /// </summary>
    [Fact]
    public void Test() {
        var condition = new EqualCondition( "a","1" );
        var json = Util.Helpers.Json.ToJson( condition );
        Assert.Equal( "{\"EQ\":{\"a\":\"1\"}}", json );
    }
}