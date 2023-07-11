using System;
using System.Threading.Tasks;
using Util.Events;
using Util.Tests.Events;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;
using Xunit;
using Xunit.Abstractions;

namespace Util.Data.EntityFrameworkCore.Tests;

/// <summary>
/// 工作单元操作管理器测试
/// </summary>
public class UnitOfWorkActionManagerTest : TestBase {
    /// <summary>
    /// 测试输出
    /// </summary>
    private readonly ITestOutputHelper _testOutputHelper;
    /// <summary>
    /// 产品仓储
    /// </summary>
    private readonly IProductRepository _productRepository;
    /// <summary>
    /// 测试事件总线
    /// </summary>
    private readonly ITestEventBus _eventBus;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public UnitOfWorkActionManagerTest( ITestOutputHelper testOutputHelper, IProductRepository productRepository, 
        ITestUnitOfWork unitOfWork, ITestEventBus eventBus ) :base(unitOfWork){
        _testOutputHelper = testOutputHelper;
        _productRepository = productRepository;
        _eventBus = eventBus;
    }

    /// <summary>
    /// 测试执行操作 - 提交成功,执行操作
    /// </summary>
    [Fact]
    public async Task TestExecuteAsync_1() {
        //添加实体
        var entity = ProductFakeService.GetProduct();
        entity.Init();
        entity.Name = "TestExecuteAsync_1";

        //在提交前发送事件
        var @event = new TestEvent { Name = "1" };
        await _eventBus.PublishAsync( @event );

        await _productRepository.AddAsync( entity );
        await UnitOfWork.CommitAsync();

        //提交成功后执行事件处理器
        Assert.Equal( "12", @event.Name );
    }

    /// <summary>
    /// 测试执行操作 - 提交失败,不执行操作
    /// </summary>
    [Fact]
    public async Task TestExecuteAsync_2() {
        //添加实体
        var entity = ProductFakeService.GetProduct();
        entity.Init();
        entity.Name = "TestExecuteAsync_2";

        //在提交前发送事件
        var @event = new TestEvent { Name = "1" };
        await _eventBus.PublishAsync( @event );

        try {
            await _productRepository.AddAsync( entity );
            throw new Exception();
            await UnitOfWork.CommitAsync();
        }
        catch ( Exception e ) {
            //提交失败不执行事件处理器
            Assert.Equal( "1", @event.Name );
        }
    }

    /// <summary>
    /// 测试执行操作 - 多次提交成功,应只执行一次操作
    /// </summary>
    [Fact]
    public async Task TestExecuteAsync_3() {
        //添加实体
        var entity = ProductFakeService.GetProduct();
        entity.Init();
        entity.Name = "TestExecuteAsync_3_1";

        //在提交前发送事件
        var @event = new TestEvent { Name = "1" };
        await _eventBus.PublishAsync( @event );

        await _productRepository.AddAsync( entity );
        await UnitOfWork.CommitAsync();

        //修改后提交
        entity = await _productRepository.FindByIdAsync( entity.Id );
        entity.Name = "TestExecuteAsync_3_2";
        await UnitOfWork.CommitAsync();

        //提交成功后执行事件处理器
        Assert.Equal( "12", @event.Name );
    }
}

/// <summary>
/// 测试事件处理器
/// </summary>
public class TestEventHandler : EventHandlerBase<TestEvent> {
    public override Task HandleAsync( TestEvent @event ) {
        @event.Name += "2";
        return Task.CompletedTask;
    }
}