using Util.Microservices.Polly.Tests.Samples;

namespace Util.Microservices.Polly.Tests;

/// <summary>
/// 弹性处理策略测试 - 重试策略 - 异步
/// </summary>
public partial class PolicyTest {

    #region HandleException

    /// <summary>
    /// 测试重试 - 异常触发重试 - 重试1次
    /// </summary>
    [Fact]
    public async Task TestRetry_1_Async() {
        var i = 0;
        await Assert.ThrowsAsync<Exception>( async () => {
            await _policy.Retry().HandleException<Exception>().ExecuteAsync( async () => {
                i++;
                await Task.CompletedTask;
                throw new Exception();
            } );
        } );
        Assert.Equal( 2, i );
    }

    /// <summary>
    /// 测试重试 - 异常触发重试 - 重试3次
    /// </summary>
    [Fact]
    public async Task TestRetry_2_Async() {
        var i = 0;
        await Assert.ThrowsAsync<Exception>( async () => {
            await _policy.Retry( 3 ).HandleException<Exception>().ExecuteAsync( async () => {
                i++;
                await Task.CompletedTask;
                throw new Exception();
            } );
        } );
        Assert.Equal( 4, i );
    }

    /// <summary>
    /// 测试重试 - 异常触发重试 - 持续重试
    /// </summary>
    [Fact]
    public async Task TestRetry_3_Async() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await _policy.Retry().HandleException<Exception>().Forever().ExecuteAsync( async () => {
            i++;
            await Task.CompletedTask;
            if ( i < 100 )
                throw new Exception();
        } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( 100, i );
        Assert.True( stopwatch.Elapsed.Milliseconds < 50 );
    }

    /// <summary>
    /// 测试重试 - 异常触发重试 - 重试3次 - 等待
    /// </summary>
    [Fact]
    public async Task TestRetry_4_Async() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await Assert.ThrowsAsync<Exception>( async () => {
            await _policy.Retry( 3 ).HandleException<Exception>()
                .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
                .ExecuteAsync( async () => {
                    i++;
                    await Task.CompletedTask;
                    throw new Exception();
                } );
        } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( 4, i );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    /// <summary>
    /// 测试重试 - 异常触发重试 - 回调函数处理
    /// </summary>
    [Fact]
    public async Task TestRetry_5_Async() {
        var i = 0;
        await Assert.ThrowsAsync<Exception>( async () => {
            await _policy.Retry( 3 ).HandleException<Exception>()
                .OnRetry( ( e, n ) => { i = n; } )
                .ExecuteAsync( async () => {
                    await Task.CompletedTask;
                    throw new Exception();
                } );
        } );
        Assert.Equal( 3, i );
    }

    /// <summary>
    /// 测试重试 - 异常触发重试 - 回调函数处理 - 持续重试
    /// </summary>
    [Fact]
    public async Task TestRetry_6_Async() {
        var i = 0;
        await _policy.Retry().HandleException<Exception>().Forever()
            .OnRetry( ( e, n ) => { i = n; } )
            .ExecuteAsync( async () => {
                await Task.CompletedTask;
                if ( i < 3 )
                    throw new Exception();
            } );
        Assert.Equal( 3, i );
    }

    /// <summary>
    /// 测试重试 - 异常触发重试 - 回调函数处理 - 等待
    /// </summary>
    [Fact]
    public async Task TestRetry_7_Async() {
        var i = 0;
        await Assert.ThrowsAsync<Exception>( async () => {
            await _policy.Retry( 3 ).HandleException<Exception>()
                .Wait( retry => TimeSpan.FromMilliseconds( 1 ) )
                .OnRetry( ( e, n ) => { i = n; } )
                .ExecuteAsync( async () => {
                    await Task.CompletedTask;
                    throw new Exception();
                } );
        } );
        Assert.Equal( 3, i );
    }

    /// <summary>
    /// 测试重试 - 异常触发重试 - 回调函数处理 - 等待 - 持续重试
    /// </summary>
    [Fact]
    public async Task TestRetry_8_Async() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await _policy.Retry().HandleException<Exception>().Forever()
            .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
            .OnRetry( ( e, n ) => { i = n; } )
            .ExecuteAsync( async () => {
                await Task.CompletedTask;
                if ( i < 3 )
                    throw new Exception();
            } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( 3, i );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    #endregion

    #region HandleResult

    /// <summary>
    /// 测试重试 - 结果触发重试 - 重试1次
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_1_Async() {
        var i = 0;
        var result = await _policy.Retry().HandleResult<SampleResult>( t => t.Result != "ok" )
            .ExecuteAsync( async () => {
                i++;
                await Task.CompletedTask;
                return new SampleResult { Result = i.ToString() };
            } );
        Assert.Equal( "2", result.Result );
    }

    /// <summary>
    /// 测试重试 - 结果触发重试 - 重试3次
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_2_Async() {
        var i = 0;
        var result = await _policy.Retry( 3 ).HandleResult<SampleResult>( t => t.Result != "ok" )
            .ExecuteAsync( async () => {
                i++;
                await Task.CompletedTask;
                return new SampleResult { Result = i.ToString() };
            } );
        Assert.Equal( "4", result.Result );
    }

    /// <summary>
    /// 测试重试 - 结果触发重试 - 持续重试
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_3_Async() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = await _policy.Retry()
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .Forever()
            .ExecuteAsync( async () => {
                i++;
                await Task.CompletedTask;
                if ( i < 100 )
                    return new SampleResult { Result = i.ToString() };
                return new SampleResult { Result = "ok" };
            } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( "ok", result.Result );
        Assert.True( stopwatch.Elapsed.Milliseconds < 50 );
    }

    /// <summary>
    /// 测试重试 - 结果触发重试 - 重试3次 - 等待
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_4_Async() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = await _policy.Retry( 3 )
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
            .ExecuteAsync( async () => {
                i++;
                await Task.CompletedTask;
                return new SampleResult { Result = i.ToString() };
            } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( "4", result.Result );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    /// <summary>
    /// 测试重试 - 结果触发重试 - 回调函数处理
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_5_Async() {
        var sample = new SampleResult();
        var result = await _policy.Retry( 3 )
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .ExecuteAsync( async () => await Task.FromResult(sample) );
        Assert.Equal( "3", result.Result );
    }

    /// <summary>
    /// 测试重试 - 结果触发重试 - 回调函数处理 - 持续重试
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_6_Async() {
        var sample = new SampleResult();
        var result = await _policy.Retry()
            .HandleResult<SampleResult>( t => t.Result != "10" )
            .Forever()
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .ExecuteAsync( async () => await Task.FromResult( sample ) );
        Assert.Equal( "10", result.Result );
    }

    /// <summary>
    /// 测试重试 - 结果触发重试 - 回调函数处理 - 等待
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_7_Async() {
        var sample = new SampleResult();
        var result = await _policy.Retry( 3 )
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .Wait( retry => TimeSpan.FromMilliseconds( 1 ) )
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .ExecuteAsync( async () => await Task.FromResult( sample ) );
        Assert.Equal( "3", result.Result );
    }

    /// <summary>
    /// 测试重试 - 结果触发重试 - 回调函数处理 - 等待 - 持续重试
    /// </summary>
    [Fact]
    public async Task TestRetry_HandleResult_8_Async() {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var sample = new SampleResult();
        var result = await _policy.Retry()
            .HandleResult<SampleResult>( t => t.Result != "3" )
            .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
            .Forever()
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .ExecuteAsync( async () => await Task.FromResult( sample ) );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( "3", result.Result );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    #endregion
}