using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.StateManagements;

/// <summary>
/// 状态管理测试 - 泛型接口测试
/// </summary>
[Collection( "Global" )]
public class StateManagerOfTTest {
    /// <summary>
    /// 状态管理操作
    /// </summary>
    private readonly IStateManager<CustomerDto2> _stateManager;
    /// <summary>
    /// 日志
    /// </summary>
    private readonly ILogger<StateManagerOfTTest> _logger;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public StateManagerOfTTest( IStateManager<CustomerDto2> stateManager, ILogger<StateManagerOfTTest> logger ) {
        _stateManager = stateManager;
        _logger = logger;
    }

    /// <summary>
    /// 测试查询 - 1个相等条件 - 属性表达式
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_1() {
        //变量定义
        var code = $"TestQueryAsync_{Id.Create()}";
        var code2 = $"TestQueryAsync_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code2 };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.Equal( t => t.Code, code ).QueryAsync<CustomerDto2>();
        Assert.Single( result );
        Assert.Contains( result, t => t.Code == code );
    }

    /// <summary>
    /// 测试查询 - 1个In条件 - 属性表达式
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_2() {
        //变量定义
        var code = $"TestQueryAsync_{Id.Create()}";
        var code2 = $"TestQueryAsync_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code2 };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.In( t => t.Code, code, code2 ).QueryAsync<CustomerDto2>();
        Assert.Equal( 2, result.Count );
        Assert.Contains( result, t => t.Code == code );
        Assert.Contains( result, t => t.Code == code2 );
    }
}