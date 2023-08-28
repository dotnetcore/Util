using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Util.Exceptions;
using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.Events;

/// <summary>
/// 集成事件管理器测试
/// </summary>
public class IntegrationEventManagerTest {

    #region 测试初始化

    /// <summary>
    /// 集成事件管理器
    /// </summary>
    private readonly IntegrationEventManager _manager;
    /// <summary>
    /// 模拟集成事件日志记录存储器
    /// </summary>
    private readonly Mock<IIntegrationEventLogStore> _mockStore;
    /// <summary>
    /// 模拟用户会话
    /// </summary>
    private readonly Mock<ISession> _mockSession;
    /// <summary>
    /// 模拟获取应用标识
    /// </summary>
    private readonly Mock<IGetAppId> _mockGetAppId;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public IntegrationEventManagerTest() {
        _mockStore = new Mock<IIntegrationEventLogStore>();
        _mockSession = new Mock<ISession>();
        _mockGetAppId = new Mock<IGetAppId>();
        var options = new Mock<IOptions<DaprOptions>>();
        options.Setup( t => t.Value ).Returns( new DaprOptions { Pubsub = { MaxRetry = 10 } } );
        var log = new Mock<ILogger<IntegrationEventManager>>();
        _manager = new IntegrationEventManager( _mockStore.Object, _mockSession.Object, _mockGetAppId.Object, options.Object, log.Object );
    }

    #endregion

    #region CanSubscriptionAsync

    /// <summary>
    /// 测试是否允许处理订阅 - 首次订阅
    /// </summary>
    [Fact]
    public async Task TestCanSubscriptionAsync_1() {
        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CanSubscriptionAsync( eventId );

        //验证
        Assert.True( result );
    }

    /// <summary>
    /// 测试是否允许处理订阅 - 多次调用同一个订阅端口 - 前一个调用正在执行,不允许处理
    /// </summary>
    [Fact]
    public async Task TestCanSubscriptionAsync_2() {
        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published,
            SubscriptionLogs = { new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing } }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CanSubscriptionAsync( eventId );

        //验证
        Assert.False( result );
    }

    /// <summary>
    /// 测试是否允许处理订阅 - 多次调用同一个订阅端口 - 前一个调用已成功完成,不允许处理
    /// </summary>
    [Fact]
    public async Task TestCanSubscriptionAsync_3() {
        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published,
            SubscriptionLogs = { new SubscriptionLog { AppId = appId, State = SubscriptionState.Success } }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CanSubscriptionAsync( eventId );

        //验证
        Assert.False( result );
    }

    /// <summary>
    /// 测试是否允许处理订阅 - 多次调用同一个订阅端口 - 前一个调用已失败,但重试次数还没有达到最大值,允许处理
    /// </summary>
    [Fact]
    public async Task TestCanSubscriptionAsync_4() {
        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published,
            SubscriptionLogs = { new SubscriptionLog { AppId = appId, State = SubscriptionState.Fail, RetryCount = 9 } }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CanSubscriptionAsync( eventId );

        //验证
        Assert.True( result );
    }

    /// <summary>
    /// 测试是否允许处理订阅 - 多次调用同一个订阅端口 - 前一个调用已失败,重试次数达到最大值,不允许处理
    /// </summary>
    [Fact]
    public async Task TestCanSubscriptionAsync_5() {
        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published,
            SubscriptionLogs = { new SubscriptionLog { AppId = appId, State = SubscriptionState.Fail, RetryCount = 10 } }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CanSubscriptionAsync( eventId );

        //验证
        Assert.False( result );
    }

    #endregion

    #region CreatePublishLogAsync

    /// <summary>
    /// 测试创建集成事件发布日志记录
    /// </summary>
    [Fact]
    public async Task TestCreatePublishLogAsync() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var testEvent = new TestEvent( "code", "name" );
        var cloudEvent = new CloudEvent<object>( testEvent.EventId, testEvent );
        cloudEvent.Headers.Add( "c", "2" );
        var metadata = new Dictionary<string, string> { { "a", "1" } };
        var argument = new PubsubArgument( "pubsub2", "topic", cloudEvent, metadata );

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( "appid" );
        _mockSession.Setup( t => t.UserId ).Returns( "userid" );

        //创建发布日志
        var result = await _manager.CreatePublishLogAsync( argument );

        //验证
        _mockStore.Verify( store => store.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ) );
        Assert.Equal( testEvent.EventId, result.Id );
        Assert.Equal( "appid", result.AppId );
        Assert.Equal( "userid", result.UserId );
        Assert.Equal( "pubsub2", result.PubsubName );
        Assert.Equal( "topic", result.Topic );
        Assert.Equal( EventState.Published, result.State );
        Assert.Equal( time, result.PublishTime );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Empty( result.SubscriptionLogs );
        Assert.Equal( "a", result.GetValue<PubsubArgument>().Metadata.First().Key );
        Assert.Equal( "1", result.GetValue<PubsubArgument>().Metadata.First().Value );
        Assert.Equal( "c", result.GetValue<PubsubArgument>().GetEventData<CloudEvent<object>>().Headers.First().Key );
        Assert.Equal( "2", result.GetValue<PubsubArgument>().GetEventData<CloudEvent<object>>().Headers.First().Value );
        Assert.Equal( "code", result.GetValue<PubsubArgument>().GetEventData<CloudEvent<object>>().GetData<TestEvent>().Code );
        Assert.Equal( "name", result.GetValue<PubsubArgument>().GetEventData<CloudEvent<object>>().GetData<TestEvent>().Name );
    }

    #endregion

    #region CreateSubscriptionLogAsync

    /// <summary>
    /// 测试创建集成事件订阅日志记录 - 首次触发订阅
    /// </summary>
    [Fact]
    public async Task TestCreateSubscriptionLogAsync_1() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CreateSubscriptionLogAsync( eventId, "routeUrl" );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Processing, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Equal( appId, subLog.AppId );
        Assert.Equal( "routeUrl", subLog.RouteUrl );
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Processing, subLog.State );
        Assert.Equal( time, subLog.SubscriptionTime );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    /// <summary>
    /// 测试创建集成事件订阅日志记录 - 多次触发订阅 - 之前已成功完成
    /// </summary>
    [Fact]
    public async Task TestCreateSubscriptionLogAsync_2() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        var time2 = new DateTime( 2111, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog{ AppId = appId,State = SubscriptionState.Success,RouteUrl = "routeUrl",SubscriptionTime = time2,LastModificationTime = time2}
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CreateSubscriptionLogAsync( eventId, "routeUrl" );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Never );
        Assert.Equal( EventState.Processing, result.State );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Success, subLog.State );
        Assert.Equal( time2, subLog.SubscriptionTime );
        Assert.Equal( time2, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    /// <summary>
    /// 测试创建集成事件订阅日志记录 - 多次触发同一个订阅 - 之前的订阅正在处理
    /// </summary>
    [Fact]
    public async Task TestCreateSubscriptionLogAsync_3() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        var time2 = new DateTime( 2111, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog{ AppId = appId,State = SubscriptionState.Processing,SubscriptionTime = time2,LastModificationTime = time2 }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CreateSubscriptionLogAsync( eventId, "routeUrl" );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Never );
        Assert.Equal( EventState.Processing, result.State );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Equal( appId, subLog.AppId );
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Processing, subLog.State );
        Assert.Equal( time2, subLog.SubscriptionTime );
        Assert.Equal( time2, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    /// <summary>
    /// 测试创建集成事件订阅日志记录 - 多次触发同一个订阅 - 之前的订阅已失败,第一次重试
    /// </summary>
    [Fact]
    public async Task TestCreateSubscriptionLogAsync_4() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        var time2 = new DateTime( 2111, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Fail,
            SubscriptionLogs = {
                new SubscriptionLog{
                    AppId = appId,
                    State = SubscriptionState.Fail,
                    SubscriptionTime = time2,
                    LastModificationTime = time2,
                    RetryCount = 0,
                    RetryLogs = { new SubscriptionRetryLog{Number = 1,Message = "a" }}
                }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CreateSubscriptionLogAsync( eventId, "routeUrl" );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Processing, result.State );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Equal( 1, subLog.RetryCount );
        Assert.Equal( SubscriptionState.Processing, subLog.State );
        Assert.Equal( time2, subLog.SubscriptionTime );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Single( subLog.RetryLogs );
        Assert.Equal( 1, subLog.RetryLogs.First().Number );
        Assert.Equal( "a", subLog.RetryLogs.First().Message );
        Assert.Equal( time, subLog.RetryLogs.First().RetryTime );
    }

    /// <summary>
    /// 测试创建集成事件订阅日志记录 - 多次触发同一个订阅 - 之前的订阅已失败,重试已达到最大值
    /// </summary>
    [Fact]
    public async Task TestCreateSubscriptionLogAsync_5() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        var time2 = new DateTime( 2111, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Fail,
            SubscriptionLogs = {
                new SubscriptionLog{
                    AppId = appId,
                    State = SubscriptionState.Fail,
                    SubscriptionTime = time2,
                    LastModificationTime = time2,
                    RetryCount = 10
                }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //创建订阅日志
        var result = await _manager.CreateSubscriptionLogAsync( eventId, "routeUrl" );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Never );
        Assert.Equal( EventState.Fail, result.State );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Equal( 10, subLog.RetryCount );
        Assert.Equal( SubscriptionState.Fail, subLog.State );
        Assert.Equal( time2, subLog.SubscriptionTime );
        Assert.Equal( time2, subLog.LastModificationTime );
    }

    /// <summary>
    /// 测试创建集成事件订阅日志记录 - 并发处理
    /// </summary>
    [Fact]
    public async Task TestCreateSubscriptionLogAsync_6() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_1";
        var appId2 = "appid_2";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published,
            ETag = "1"
        };
        var eventLog2 = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Published,
            ETag = "2",
            SubscriptionLogs = { new SubscriptionLog { AppId = appId2 } }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog2 );
        _mockStore.Setup( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log.ETag == "1" ), It.IsAny<CancellationToken>() ) ).Throws<ConcurrencyException>();

        //创建订阅日志
        var result = await _manager.CreateSubscriptionLogAsync( eventLog, "routeUrl" );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Processing, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        Assert.Equal( appId2, result.SubscriptionLogs[0].AppId );
        var subLog = result.SubscriptionLogs[1];
        Assert.Equal( appId, subLog.AppId );
        Assert.Equal( "routeUrl", subLog.RouteUrl );
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Processing, subLog.State );
        Assert.Equal( time, subLog.SubscriptionTime );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    #endregion

    #region SubscriptionSuccessAsync

    /// <summary>
    /// 测试集成事件订阅成功 - 一个订阅 - 成功
    /// </summary>
    [Fact]
    public async Task TestSubscriptionSuccessAsync_1() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = { new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing } }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅成功
        var result = await _manager.SubscriptionSuccessAsync( eventId );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Success, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Success, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    /// <summary>
    /// 测试集成事件订阅成功 - 2个订阅 - 都成功
    /// </summary>
    [Fact]
    public async Task TestSubscriptionSuccessAsync_2() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = "a", State = SubscriptionState.Success }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅成功
        var result = await _manager.SubscriptionSuccessAsync( eventId );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Success, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Success, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    /// <summary>
    /// 测试集成事件订阅成功 - 2个订阅 - 前一个处理中
    /// </summary>
    [Fact]
    public async Task TestSubscriptionSuccessAsync_3() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = "a", State = SubscriptionState.Processing }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅成功
        var result = await _manager.SubscriptionSuccessAsync( eventId );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Processing, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Success, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    /// <summary>
    /// 测试集成事件订阅成功 - 2个订阅 - 前一个失败
    /// </summary>
    [Fact]
    public async Task TestSubscriptionSuccessAsync_4() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = "a", State = SubscriptionState.Fail }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅成功
        var result = await _manager.SubscriptionSuccessAsync( eventId );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Fail, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Success, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Empty( subLog.RetryLogs );
    }

    /// <summary>
    /// 测试集成事件订阅成功 - 并发处理
    /// </summary>
    [Fact]
    public async Task TestSubscriptionSuccessAsync_5() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_1";
        var appId2 = "appid_2";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            ETag = "1",
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = appId2, State = SubscriptionState.Processing }
            }
        };
        var eventLog2 = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            ETag = "2",
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = appId2, State = SubscriptionState.Success }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog2 );
        _mockStore.Setup( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log.ETag == "1" ), It.IsAny<CancellationToken>() ) ).Throws<ConcurrencyException>();

        //订阅成功
        var result = await _manager.SubscriptionSuccessAsync( eventLog );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Success, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Success, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
    }

    #endregion

    #region SubscriptionFailAsync

    /// <summary>
    /// 测试集成事件订阅失败 - 一个订阅 - 失败
    /// </summary>
    [Fact]
    public async Task TestSubscriptionFailAsync_1() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var message = "a";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = { new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing } }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅失败
        var result = await _manager.SubscriptionFailAsync( eventId, message );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Fail, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Fail, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Single( subLog.RetryLogs );
        var retryLog = subLog.RetryLogs[0];
        Assert.Equal( 1, retryLog.Number );
        Assert.Equal( message, retryLog.Message );
        Assert.Null( retryLog.RetryTime );
    }

    /// <summary>
    /// 测试集成事件订阅失败 - 2个订阅 - 一个处理中,一个失败
    /// </summary>
    [Fact]
    public async Task TestSubscriptionFailAsync_2() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var message = "a";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = "app", State = SubscriptionState.Processing }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅失败
        var result = await _manager.SubscriptionFailAsync( eventId, message );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Processing, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Fail, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Single( subLog.RetryLogs );
        var retryLog = subLog.RetryLogs[0];
        Assert.Equal( 1, retryLog.Number );
        Assert.Equal( message, retryLog.Message );
        Assert.Null( retryLog.RetryTime );
    }

    /// <summary>
    /// 测试集成事件订阅失败 - 2个订阅 - 一个成功,一个失败
    /// </summary>
    [Fact]
    public async Task TestSubscriptionFailAsync_3() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var message = "a";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = "app", State = SubscriptionState.Success }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅失败
        var result = await _manager.SubscriptionFailAsync( eventId, message );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Fail, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Fail, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Single( subLog.RetryLogs );
        var retryLog = subLog.RetryLogs[0];
        Assert.Equal( 1, retryLog.Number );
        Assert.Equal( message, retryLog.Message );
        Assert.Null( retryLog.RetryTime );
    }

    /// <summary>
    /// 测试集成事件订阅失败 - 1个订阅 - 2个重试记录
    /// </summary>
    [Fact]
    public async Task TestSubscriptionFailAsync_4() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_sub";
        var message = "a";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing,RetryLogs = { new SubscriptionRetryLog{ Number = 1,Message = "m" } } }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog );

        //订阅失败
        var result = await _manager.SubscriptionFailAsync( eventId, message );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Fail, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Single( result.SubscriptionLogs );
        var subLog = result.SubscriptionLogs[0];
        Assert.Null( subLog.RetryCount );
        Assert.Equal( SubscriptionState.Fail, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Equal( 2, subLog.RetryLogs.Count );
        var retryLog = subLog.RetryLogs[1];
        Assert.Equal( 2, retryLog.Number );
        Assert.Equal( message, retryLog.Message );
        Assert.Null( retryLog.RetryTime );
    }

    /// <summary>
    /// 测试集成事件订阅失败 - 并发处理
    /// </summary>
    [Fact]
    public async Task TestSubscriptionFailAsync_5() {
        //设置模拟时间
        var time = new DateTime( 2000, 1, 1, 1, 1, 1 );
        Time.SetTime( time );

        //参数定义
        var eventId = "123";
        var appId = "appid_1";
        var appId2 = "appid_2";
        var message = "a";
        var eventLog = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            ETag = "1",
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = appId2, State = SubscriptionState.Processing }
            }
        };
        var eventLog2 = new IntegrationEventLog {
            Id = eventId,
            State = EventState.Processing,
            ETag = "2",
            SubscriptionLogs = {
                new SubscriptionLog { AppId = appId, State = SubscriptionState.Processing },
                new SubscriptionLog { AppId = appId2, State = SubscriptionState.Success }
            }
        };

        //设置模拟操作
        _mockGetAppId.Setup( t => t.GetAppId() ).Returns( appId );
        _mockStore.Setup( t => t.GetAsync( eventId, It.IsAny<CancellationToken>() ) ).ReturnsAsync( eventLog2 );
        _mockStore.Setup( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log.ETag == "1" ), It.IsAny<CancellationToken>() ) ).Throws<ConcurrencyException>();

        //订阅处理
        var result = await _manager.SubscriptionFailAsync( eventLog, message );

        //验证
        _mockStore.Verify( t => t.SaveAsync( It.Is<IntegrationEventLog>( log => log == result ), It.IsAny<CancellationToken>() ), Times.Once );
        Assert.Equal( EventState.Fail, result.State );
        Assert.Equal( time, result.LastModificationTime );
        Assert.Equal( 2, result.SubscriptionLogs.Count );
        var subLog = result.SubscriptionLogs[0];
        Assert.Equal( SubscriptionState.Fail, subLog.State );
        Assert.Equal( time, subLog.LastModificationTime );
        Assert.Single( subLog.RetryLogs );
        var retryLog = subLog.RetryLogs[0];
        Assert.Equal( 1, retryLog.Number );
        Assert.Equal( message, retryLog.Message );
    }

    #endregion
}