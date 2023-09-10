using Util.Data.Queries;
using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.StateManagements;

/// <summary>
/// 状态管理测试 - 查询测试
/// </summary>
public partial class StateManagerTest {

    #region GetAsync

    /// <summary>
    /// 测试根据键批量获取
    /// </summary>
    [Fact]
    public async Task TestGetAsync_1() {
        //添加数据1
        var dto_1 = new CustomerDto2 { Code = "1" };
        var key_1 = await _stateManager.SaveAsync( dto_1 );

        //添加数据2
        var dto_2 = new CustomerDto2 { Code = "2" };
        var key_2 = await _stateManager.SaveAsync( dto_2 );

        //获取数据并验证
        var result = await _stateManager.GetAsync<CustomerDto2>( new[] { key_1, key_2 } );
        Assert.Contains( result, t => t.Code == "1" );
        Assert.Contains( result, t => t.Code == "2" );
    }

    #endregion

    #region GetByIdAsync

    /// <summary>
    /// 测试通过标识获取数据
    /// </summary>
    [Fact]
    public async Task TestGetByIdAsync() {
        //变量定义
        var dto = new CustomerDto2 { Code = "123" };

        //添加数据
        await _stateManager.SaveAsync( dto );

        //获取数据并验证
        var result = await _stateManager.GetByIdAsync<CustomerDto2>( dto.Id );
        Assert.Equal( "123", result.Code );
    }

    #endregion

    #region GetAllAsync

    /// <summary>
    /// 测试获取指定类型的全部数据
    /// </summary>
    [Fact]
    public async Task TestGetAllAsync() {
        //变量定义
        var code = $"TestGetAllAsync_{Id.Create()}";
        var code2 = $"TestGetAllAsync_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code2 };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.GetAllAsync<CustomerDto2>();
        Assert.Contains( result, t => t.Code == code );
        Assert.Contains( result, t => t.Code == code2 );
    }

    #endregion

    #region SingleAsync

    /// <summary>
    /// 测试获取指定类型的单条数据
    /// </summary>
    [Fact]
    public async Task TestSingleAsync() {
        //变量定义
        var code = $"TestSingleAsync_{Id.Create()}";

        //添加数据
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //获取数据并验证
        var result = await _stateManager.Equal<CustomerDto2>( t => t.Code, code ).SingleAsync<CustomerDto2>();
        Assert.Equal( code, result.Code );
    }

    #endregion

    #region QueryAsync

    /// <summary>
    /// 测试查询 - 1个相等条件
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_1() {
        //变量定义
        var code = $"TestQueryAsync_1_{Id.Create()}";
        var code2 = $"TestQueryAsync_1_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code2 };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.Equal( "code", code ).QueryAsync<CustomerDto2>();
        Assert.Single( result );
        Assert.Contains( result, t => t.Code == code );
    }

    /// <summary>
    /// 测试查询 - 1个相等条件 - 属性表达式
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_2() {
        //变量定义
        var code = $"TestQueryAsync_2_{Id.Create()}";
        var code2 = $"TestQueryAsync_2_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code2 };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.Equal<CustomerDto2>( t => t.Code, code ).QueryAsync<CustomerDto2>();
        Assert.Single( result );
        Assert.Contains( result, t => t.Code == code );
    }

    /// <summary>
    /// 测试查询 - 1个In条件
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_3() {
        //变量定义
        var code = $"TestQueryAsync_3_{Id.Create()}";
        var code2 = $"TestQueryAsync_3_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code2 };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.In( "code", code, code2 ).QueryAsync<CustomerDto2>();
        Assert.Equal( 2, result.Count );
        Assert.Contains( result, t => t.Code == code );
        Assert.Contains( result, t => t.Code == code2 );
    }

    /// <summary>
    /// 测试查询 - 1个In条件 - 属性表达式
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_4() {
        //变量定义
        var code = $"TestQueryAsync_4_{Id.Create()}";
        var code2 = $"TestQueryAsync_4_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code2 };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.In<CustomerDto2>( t => t.Code, code, code2 ).QueryAsync<CustomerDto2>();
        Assert.Equal( 2, result.Count );
        Assert.Contains( result, t => t.Code == code );
        Assert.Contains( result, t => t.Code == code2 );
    }

    /// <summary>
    /// 测试查询 - 升序排序
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_OrderBy() {
        //变量定义
        var code = $"TestQueryAsync_OrderBy_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code, Name = "b" };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code, Name = "a" };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.OrderBy<CustomerDto2>( t => t.Name ).Equal( "code", code ).QueryAsync<CustomerDto2>();
        Assert.Equal( "a", result[0].Name );
        Assert.Equal( "b", result[1].Name );
    }

    /// <summary>
    /// 测试查询 - 降序排序
    /// </summary>
    [Fact]
    public async Task TestQueryAsync_OrderByDescending() {
        //变量定义
        var code = $"TestQueryAsync_OrderBy_{Id.Create()}";

        //添加数据1
        var dto = new CustomerDto2 { Code = code, Name = "a" };
        await _stateManager.SaveAsync( dto );

        //添加数据2
        var dto2 = new CustomerDto2 { Code = code, Name = "b" };
        await _stateManager.SaveAsync( dto2 );

        //获取数据并验证
        var result = await _stateManager.OrderByDescending<CustomerDto2>( t => t.Name ).Equal( "code", code ).QueryAsync<CustomerDto2>();
        Assert.Equal( "b", result[0].Name );
        Assert.Equal( "a", result[1].Name );
    }

    #endregion

    #region PageQueryAsync

    /// <summary>
    /// 测试分页查询
    /// </summary>
    [Fact]
    public async Task TestPageQueryAsync() {
        //变量定义
        var code = $"TestPageQueryAsync_{Id.Create()}";

        //添加数据
        await _stateManager.SaveAsync( new[] {
            new CustomerDto2 { Code = code, Name = "a" },
            new CustomerDto2 { Code = code, Name = "b" },
            new CustomerDto2 { Code = code, Name = "c" },
            new CustomerDto2 { Code = code, Name = "d" },
            new CustomerDto2 { Code = code, Name = "e" }
        } );

        //分页查询第1页
        var query = new Pager( 1, 2, "name desc" );
        var result = await _stateManager.Equal( "code", code ).PageQueryAsync<CustomerDto2>( query );
        Assert.Equal( 2, result.Data.Count );
        Assert.Equal( "e", result.Data[0].Name );
        Assert.Equal( "d", result.Data[1].Name );

        //分页查询第2页
        query = new Pager( 2, 2, "name desc" );
        result = await _stateManager.Equal( "code", code ).PageQueryAsync<CustomerDto2>( query );
        Assert.Equal( 2, result.Data.Count );
        Assert.Equal( "c", result.Data[0].Name );
        Assert.Equal( "b", result.Data[1].Name );

        //分页查询第3页
        query = new Pager( 3, 2, "name desc" );
        result = await _stateManager.Equal( "code", code ).PageQueryAsync<CustomerDto2>( query );
        Assert.Single( result.Data );
        Assert.Equal( "a", result.Data[0].Name );

        //分页查询第4页
        query = new Pager( 4, 2, "name desc" );
        result = await _stateManager.Equal( "code", code ).PageQueryAsync<CustomerDto2>( query );
        Assert.Empty( result.Data );
    }

    #endregion
}