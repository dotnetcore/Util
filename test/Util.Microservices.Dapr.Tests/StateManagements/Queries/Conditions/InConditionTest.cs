namespace Util.Microservices.Dapr.Tests.StateManagements.Queries.Conditions;

/// <summary>
/// In查询条件测试
/// </summary>
public class InConditionTest {
    /// <summary>
    /// 测试In条件
    /// </summary>
    [Fact]
    public void Test() {
        var condition = new InCondition( "state", new[] { "a", "b" } );
        var json = Util.Helpers.Json.ToJson( condition );
        Assert.Equal( "{\"IN\":{\"state\":[\"a\",\"b\"]}}", json );
    }
}