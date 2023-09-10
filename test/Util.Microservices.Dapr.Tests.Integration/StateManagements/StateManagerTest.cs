using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.StateManagements;

/// <summary>
/// 状态管理测试
/// </summary>
[Collection( "Global" )]
public partial class StateManagerTest {
    /// <summary>
    /// 状态管理操作
    /// </summary>
    private readonly IStateManager _stateManager;
    /// <summary>
    /// 日志
    /// </summary>
    private readonly ILogger<StateManagerTest> _logger;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public StateManagerTest( IStateManager stateManager, ILogger<StateManagerTest> logger ) {
        _stateManager = stateManager;
        _logger = logger;
    }

    /// <summary>
    /// 测试
    /// </summary>
    [Fact]
    public async Task Test_1() {
        //变量定义
        var key = $"key_{Id.Create()}";
        var dto = new CustomerDto { Code = "123" };

        //添加数据
        await _stateManager.AddAsync( key, dto );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto>( key );
        Assert.Equal( "123", result.Code );
    }

    /// <summary>
    /// 测试并发标记
    /// </summary>
    [Fact]
    public async Task Test_2() {
        //变量定义
        var key = $"key_{Id.Create()}";
        var dto = new CustomerDto { Code = "123" };

        //添加数据
        await _stateManager.AddAsync( key, dto );

        //获取数据
        var eTagData = await _stateManager.GetStateAndETagAsync<CustomerDto>( key );
        Assert.Equal( "123", eTagData.value.Code );

        //修改数据
        dto.Code = "456";
        var isUpdate = await _stateManager.UpdateAsync( key, dto, eTagData.etag );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto>( key );
        Assert.True( isUpdate );
        Assert.Equal( "456", result.Code );
    }

    /// <summary>
    /// 测试并发标记 - 无效标记
    /// </summary>
    [Fact]
    public async Task Test_3() {
        //变量定义
        var key = $"key_{Id.Create()}";
        var dto = new CustomerDto { Code = "123" };

        //添加数据
        await _stateManager.AddAsync( key, dto );

        //修改数据
        dto.Code = "456";
        var isUpdate = await _stateManager.UpdateAsync( key, dto, "" );
        Assert.False( isUpdate );
    }

    /// <summary>
    /// 测试删除数据
    /// </summary>
    [Fact]
    public async Task Test_4() {
        //变量定义
        var key = $"key_{Id.Create()}";
        var dto = new CustomerDto { Code = "123" };

        //添加数据
        await _stateManager.AddAsync( key, dto );

        //删除
        await _stateManager.RemoveAsync( key );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto>( key );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试保存实体
    /// </summary>
    [Fact]
    public async Task Test_5() {
        //变量定义
        var dto = new CustomerDto2 { Code = "123" };

        //添加数据
        var key = await _stateManager.SaveAsync( dto );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto2>( key );
        Assert.Equal( "123", result.Code );
        Assert.False( result.ETag.IsEmpty() );
        _logger.LogInformation( $"Test_5.1.ETag:{result.ETag}" );

        //修改数据
        result.Code = "456";
        await _stateManager.SaveAsync( result );

        //获取数据并验证
        result = await _stateManager.GetAsync<CustomerDto2>( key );
        Assert.Equal( "456", result.Code );
        _logger.LogInformation( $"Test_5.2.ETag:{result.ETag}" );
    }

    /// <summary>
    /// 测试保存实体 - 传入key
    /// </summary>
    [Fact]
    public async Task Test_6() {
        //变量定义
        var key = $"key_{Id.Create()}";
        var dto = new CustomerDto2 { Code = "123" };

        //添加数据
        await _stateManager.SaveAsync( dto, key: key );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto2>( key );
        Assert.Equal( "123", result.Code );
        Assert.False( result.ETag.IsEmpty() );

        //修改数据
        result.Code = "456";
        await _stateManager.SaveAsync( result, key: key );

        //获取数据并验证
        result = await _stateManager.GetAsync<CustomerDto2>( key );
        Assert.Equal( "456", result.Code );
    }

    /// <summary>
    /// 测试事务操作
    /// </summary>
    [Fact]
    public async Task Test_7() {
        //添加数据1
        var key_1 = $"key_{Id.Create()}";
        var dto_1 = new CustomerDto { Code = "1" };
        await _stateManager.AddAsync( key_1, dto_1 );

        //添加数据2
        var dto_2 = new CustomerDto2 { Code = "2" };
        var key_2 = await _stateManager.SaveAsync( dto_2 );

        //开始事务
        _stateManager.BeginTransaction();

        //添加数据3
        var key_3 = $"key_{Id.Create()}";
        var dto_3 = new CustomerDto { Code = "3" };
        await _stateManager.AddAsync( key_3, dto_3 );

        //修改数据1
        var result1 = await _stateManager.GetStateAndETagAsync<CustomerDto>( key_1 );
        result1.value.Code = "4";
        await _stateManager.UpdateAsync( key_1, result1.value, result1.etag );

        //删除数据2
        await _stateManager.RemoveAsync( key_2 );

        //提交事务
        await _stateManager.CommitAsync();

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto>( key_1 );
        Assert.Equal( "4", result.Code );
        result = await _stateManager.GetAsync<CustomerDto>( key_2 );
        Assert.Null( result );
        result = await _stateManager.GetAsync<CustomerDto>( key_3 );
        Assert.Equal( "3", result.Code );
    }

    /// <summary>
    /// 测试事务操作 - 未提交 - 添加
    /// </summary>
    [Fact]
    public async Task Test_8() {
        //开始事务
        _stateManager.BeginTransaction();

        //添加数据1
        var key_1 = $"key_{Id.Create()}";
        var dto_1 = new CustomerDto { Code = "1" };
        await _stateManager.AddAsync( key_1, dto_1 );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto>( key_1 );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试事务操作 - 未提交 - 修改
    /// </summary>
    [Fact]
    public async Task Test_9() {
        //添加数据
        var key_1 = $"key_{Id.Create()}";
        var dto_1 = new CustomerDto { Code = "1" };
        await _stateManager.AddAsync( key_1, dto_1 );

        //开始事务
        _stateManager.BeginTransaction();

        //修改数据
        var result = await _stateManager.GetStateAndETagAsync<CustomerDto>( key_1 );
        result.value.Code = "2";
        await _stateManager.UpdateAsync( key_1, result.value, result.etag );

        //获取数据并验证
        dto_1 = await _stateManager.GetAsync<CustomerDto>( key_1 );
        Assert.Equal( "1", dto_1.Code );
    }

    /// <summary>
    /// 测试事务操作 - 未提交 - 删除
    /// </summary>
    [Fact]
    public async Task Test_10() {
        //添加数据
        var key_1 = $"key_{Id.Create()}";
        var dto_1 = new CustomerDto { Code = "1" };
        await _stateManager.AddAsync( key_1, dto_1 );

        //开始事务
        _stateManager.BeginTransaction();

        //修改数据
        await _stateManager.RemoveAsync( key_1 );

        //获取数据并验证
        dto_1 = await _stateManager.GetAsync<CustomerDto>( key_1 );
        Assert.Equal( "1", dto_1.Code );
    }

    /// <summary>
    /// 测试事务操作 - 未提交 - 保存 - 添加
    /// </summary>
    [Fact]
    public async Task Test_11() {
        //开始事务
        _stateManager.BeginTransaction();

        //添加数据
        var dto = new CustomerDto2 { Code = "1" };
        var key = await _stateManager.SaveAsync( dto );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto2>( key );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试通过标识删除数据
    /// </summary>
    [Fact]
    public async Task Test_12() {
        //变量定义
        var key = $"key_{Id.Create()}";
        var dto = new CustomerDto2 { Code = "123" };

        //添加数据
        await _stateManager.AddAsync( key, dto );

        //删除
        await _stateManager.RemoveByIdAsync<CustomerDto2>( dto.Id );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto2>( key );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试添加int类型数据
    /// </summary>
    [Fact]
    public async Task Test_13() {
        //变量定义
        var key = $"key_{Id.Create()}";

        //添加数据
        await _stateManager.AddAsync( key, 1 );

        //获取数据并验证
        var result = await _stateManager.GetAsync<int>( key );
        Assert.Equal( 1, result );
    }

    /// <summary>
    /// 测试添加string类型数据
    /// </summary>
    [Fact]
    public async Task Test_14() {
        //变量定义
        var key = $"key_{Id.Create()}";

        //添加数据
        await _stateManager.AddAsync( key, "a" );

        //获取数据并验证
        var result = await _stateManager.GetAsync<string>( key );
        Assert.Equal( "a", result );
    }
}