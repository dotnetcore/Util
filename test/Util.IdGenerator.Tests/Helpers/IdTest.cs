namespace Util.IdGenerator.Tests.Helpers;

/// <summary>
/// Id测试
/// </summary>
public class IdTest {
    /// <summary>
    /// 输出日志
    /// </summary>
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public IdTest( ITestOutputHelper output ) {
        _output = output;
    }

    /// <summary>
    /// 测试设置自定义标识
    /// </summary>
    [Fact]
    public void TestSetId_1() {
        var guid = Guid.NewGuid().ToString();
        Id.SetId( guid );
        Assert.Equal( guid, Id.Create() );
        Assert.Equal( new Guid( guid ), Id.CreateGuid() );
        Assert.Equal( guid, Id.CreateNanoid() );
        Id.Reset();
        Assert.NotEqual( guid, Id.Create() );
        Assert.NotEqual( new Guid( guid ), Id.CreateGuid() );
        Assert.NotEqual( guid, Id.CreateNanoid() );
    }

    /// <summary>
    /// 测试设置自定义标识 - Nanoid异步方法
    /// </summary>
    [Fact]
    public async Task TestSetId_2() {
        var guid = Guid.NewGuid().ToString();
        Id.SetId( guid );
        Assert.Equal( guid, await Id.CreateNanoidAsync() );
        Id.Reset();
        Assert.NotEqual( guid, await Id.CreateNanoidAsync() );
    }

    /// <summary>
    /// 测试设置自定义标识 - YitId
    /// </summary>
    [Fact]
    public void TestSetId_3() {
        var id = 1;
        Id.SetId( id.ToString() );
        Assert.Equal( id, Id.CreateYitId() );
        Id.Reset();
        Assert.NotEqual( id, Id.CreateYitId() );
    }

    /// <summary>
    /// 测试 Nanoid - 默认返回21个字符
    /// </summary>
    [Fact]
    public void TestCreateNanoid_1() {
        var id = Id.CreateNanoid();
        _output.WriteLine( id );
        Assert.Equal( 21, id.Length );
    }

    /// <summary>
    /// 测试 Nanoid - 设置字符数
    /// </summary>
    [Fact]
    public void TestCreateNanoid_2() {
        var id = Id.CreateNanoid( 10 );
        _output.WriteLine( id );
        Assert.Equal( 10, id.Length );
    }

    /// <summary>
    /// 测试 Nanoid - 设置可选字符
    /// </summary>
    [Fact]
    public void TestCreateNanoid_3() {
        var id = Id.CreateNanoid( "ab" );
        _output.WriteLine( id );
        Assert.Equal( 21, id.Count( t => t == 'a' ) + id.Count( t => t == 'b' ) );
    }

    /// <summary>
    /// 测试 Nanoid - 设置可选字符和字符数
    /// </summary>
    [Fact]
    public void TestCreateNanoid_4() {
        var id = Id.CreateNanoid( "ab", 10 );
        _output.WriteLine( id );
        Assert.Equal( 10, id.Count( t => t == 'a' ) + id.Count( t => t == 'b' ) );
    }

    /// <summary>
    /// 测试 Nanoid - 默认返回21个字符
    /// </summary>
    [Fact]
    public async Task TestCreateNanoidAsync_1() {
        var id = await Id.CreateNanoidAsync();
        _output.WriteLine( id );
        Assert.Equal( 21, id.Length );
    }

    /// <summary>
    /// 测试 Nanoid - 设置字符数
    /// </summary>
    [Fact]
    public async Task TestCreateNanoidAsync_2() {
        var id = await Id.CreateNanoidAsync( 10 );
        _output.WriteLine( id );
        Assert.Equal( 10, id.Length );
    }

    /// <summary>
    /// 测试 Nanoid - 设置可选字符
    /// </summary>
    [Fact]
    public async Task TestCreateNanoidAsync_3() {
        var id = await Id.CreateNanoidAsync( "ab" );
        _output.WriteLine( id );
        Assert.Equal( 21, id.Count( t => t == 'a' ) + id.Count( t => t == 'b' ) );
    }

    /// <summary>
    /// 测试 Nanoid - 设置可选字符和字符数
    /// </summary>
    [Fact]
    public async Task TestCreateNanoidAsync_4() {
        var id = await Id.CreateNanoidAsync( "ab", 10 );
        _output.WriteLine( id );
        Assert.Equal( 10, id.Count( t => t == 'a' ) + id.Count( t => t == 'b' ) );
    }

    /// <summary>
    /// 测试使用 YitIdHelper 雪花漂移算法创建标识
    /// </summary>
    [Fact]
    public void TestCreateYitId() {
        var id = Id.CreateYitId();
        _output.WriteLine( id.ToString() );
        Assert.NotEqual( 0, id );
    }
}