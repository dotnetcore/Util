using Util.FileStorage.Aliyun.Samples;
using Util.Helpers;
using Util.Http;
using File = Util.Helpers.File;

namespace Util.FileStorage.Aliyun.Tests;

/// <summary>
/// 阿里云对象存储服务测试
/// </summary>
public class AliyunFileStoreTest : IDisposable {

    #region 测试初始化

    /// <summary>
    /// 文件存储服务
    /// </summary>
    private readonly AliyunFileStore _fileStore;
    /// <summary>
    /// 输出操作
    /// </summary>
    private readonly ITestOutputHelper _testOutputHelper;
    /// <summary>
    /// Http客户端
    /// </summary>
    private IHttpClient _client;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public AliyunFileStoreTest( IFileStore fileStore, ITestOutputHelper testOutputHelper, IHttpClient client ) {
        _fileStore = fileStore as AliyunFileStore;
        _testOutputHelper = testOutputHelper;
        _client = client;
        Time.SetTime( new DateTime( 2012, 12, 12, 12, 12, 12, 123 ) );
    }

    #endregion

    #region 测试清理

    /// <summary>
    /// 测试清理
    /// </summary>
    public void Dispose() {
        Time.Reset();
    }

    #endregion

    #region CreateBucketAsync

    /// <summary>
    /// 测试创建存储桶 - 修正名称有大写字母和下划线及两侧横线
    /// </summary>
    [Fact]
    public async Task TestCreateBucketAsync_1() {
        var name = $"-Test{Id.Create()}_1_";

        //创建桶
        await _fileStore.CreateBucketAsync( name );

        //验证
        var result = await _fileStore.BucketExistsAsync( name );
        Assert.True( result );

        //删除桶
        await _fileStore.DeleteBucketAsync( name );

        //验证桶已不存在
        result = await _fileStore.BucketExistsAsync( name );
        Assert.False( result );
    }

    #endregion

    #region FileExistsAsync

    /// <summary>
    /// 测试文件是否存在 - 默认桶
    /// </summary>
    [Fact]
    public async Task TestFileExistsAsync_1() {
        //定义文件名
        var name = $"{Id.Create()}.png";

        //文件未创建不存在
        var result = await _fileStore.FileExistsAsync( name );
        Assert.False( result );

        //读取文件
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );

        //创建文件
        await _fileStore.SaveFileAsync( stream, name );

        //验证
        result = await _fileStore.FileExistsAsync( name );
        Assert.True( result );
    }

    /// <summary>
    /// 测试文件是否存在 - 指定存储桶
    /// </summary>
    [Fact]
    public async Task TestFileExistsAsync_2() {
        //定义变量
        var name = $"{Id.Create()}.png";
        var bucketName = "TestFileExistsAsync_2";

        //文件未创建不存在
        var result = await _fileStore.FileExistsAsync( new FileExistsArgs( name ) { BucketName = bucketName } );
        Assert.False( result );

        //读取文件
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );

        //创建文件
        await _fileStore.SaveFileAsync( new SaveFileArgs( name, stream ) { BucketName = bucketName } );

        //验证
        result = await _fileStore.FileExistsAsync( new FileExistsArgs( name ) { BucketName = bucketName } );
        Assert.True( result );
    }

    #endregion

    #region GetFileStreamAsync

    /// <summary>
    /// 测试获取文件流
    /// </summary>
    [Fact]
    public async Task TestGetFileStreamAsync() {
        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        var fileInfo = new FileInfo( path );
        var result = await _fileStore.SaveFileAsync( fileInfo );

        //验证
        var exists = await _fileStore.FileExistsAsync( result.FileName );
        Assert.True( exists );

        //获取文件
        await using var stream = await _fileStore.GetFileStreamAsync( result.FileName );
        var bytes = await File.ToBytesAsync( stream );
        Assert.Equal( result.Size.Size, bytes.Length );
    }

    #endregion

    #region GetFileBytesAsync

    /// <summary>
    /// 测试获取文件字节流
    /// </summary>
    [Fact]
    public async Task TestGetFileBytesAsync() {
        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        var fileInfo = new FileInfo( path );
        var result = await _fileStore.SaveFileAsync( fileInfo );

        //获取文件
        var bytes = await _fileStore.GetFileBytesAsync( result.FileName );
        Assert.Equal( result.Size.Size, bytes.Length );
    }

    #endregion

    #region SaveFileAsync

    /// <summary>
    /// 测试保存文件 - 使用默认桶
    /// </summary>
    [Fact]
    public async Task TestSaveFileAsync_1() {
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );
        var result = await _fileStore.SaveFileAsync( stream, "b.png" );
        Assert.Equal( "b.png", result.FilePath );
        Assert.Equal( "b.png", result.FileName );
        Assert.Equal( "png", result.Extension );
        Assert.Equal( "5.23 KB", result.Size.ToString() );
    }

    /// <summary>
    /// 测试保存文件 - 指定存储桶
    /// </summary>
    [Fact]
    public async Task TestSaveFileAsync_2() {
        var fileName = "a.png";
        var bucketName = "TestSaveFileAsync_2";
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );
        await _fileStore.SaveFileAsync( new SaveFileArgs( fileName, stream ) { BucketName = bucketName } );
        var result = await _fileStore.FileExistsAsync( new FileExistsArgs( fileName ) { BucketName = bucketName } );
        Assert.True( result );
    }

    /// <summary>
    /// 测试保存文件 - 指定文件名处理策略
    /// </summary>
    [Fact]
    public async Task TestSaveFileAsync_3() {
        var fileName = "b.png";
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );
        var result = await _fileStore.SaveFileAsync( stream, fileName, UserTimeFileNameProcessor.Policy );
        Assert.Equal( $"{TestSession.TestUserId}/2012-12-12-12-12-12-123/b.png", result.FilePath );
        Assert.Equal( "b.png", result.FileName );
        Assert.Equal( "png", result.Extension );
    }

    /// <summary>
    /// 测试保存文件 - 使用FileInfo
    /// </summary>
    [Fact]
    public async Task TestSaveFileAsync_4() {
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        var fileInfo = new FileInfo( path );
        var result = await _fileStore.SaveFileAsync( fileInfo );
        Assert.Equal( "a.png", result.FilePath );
        Assert.Equal( "a.png", result.FileName );
        Assert.Equal( "png", result.Extension );
    }

    /// <summary>
    /// 测试保存文件 - 使用字节流
    /// </summary>
    [Fact]
    public async Task TestSaveFileAsync_5() {
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        var stream = Util.Helpers.File.ReadToBytes( path );
        var result = await _fileStore.SaveFileAsync( stream, "b.png" );
        Assert.Equal( "b.png", result.FileName );
        Assert.Equal( "png", result.Extension );
    }

    #endregion

    #region SaveFileByUrlAsync

    /// <summary>
    /// 测试下载远程文件并保存到文件存储
    /// </summary>
    [Fact]
    public async Task TestSaveFileByUrlAsync_1() {
        var result = await _fileStore.SaveFileByUrlAsync( "https://www.baidu.com/img/PCtm_d9c8750bed0b3c7d089fa7d55720d6cf.png", "baidu.png" );
        var exists = await _fileStore.FileExistsAsync( result.FilePath );
        Assert.True( exists );
    }

    #endregion

    #region CopyFileAsync

    /// <summary>
    /// 测试复制文件
    /// </summary>
    [Fact]
    public async Task TestCopyFileAsync() {
        var sourceName = "e.png";
        var destinationName = "a/b/c/f.png";

        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );
        await _fileStore.SaveFileAsync( stream, sourceName );

        //复制文件
        await _fileStore.CopyFileAsync( sourceName, destinationName );

        //验证
        var result = await _fileStore.FileExistsAsync( sourceName );
        Assert.True( result );
        result = await _fileStore.FileExistsAsync( destinationName );
        Assert.True( result );
    }

    #endregion

    #region MoveFileAsync

    /// <summary>
    /// 测试移动文件
    /// </summary>
    [Fact]
    public async Task TestMoveFileAsync() {
        var sourceName = "r.png";
        var destinationName = "t/y/z/g.png";

        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );
        await _fileStore.SaveFileAsync( stream, sourceName );

        //移动文件
        await _fileStore.MoveFileAsync( sourceName, destinationName );

        //验证
        var result = await _fileStore.FileExistsAsync( sourceName );
        Assert.False( result );
        result = await _fileStore.FileExistsAsync( destinationName );
        Assert.True( result );
    }

    #endregion

    #region DeleteFileAsync

    /// <summary>
    /// 测试删除文件
    /// </summary>
    [Fact]
    public async Task TestDeleteFileAsync() {
        var name = "b.png";

        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        await using var stream = File.ReadToStream( path );
        await _fileStore.SaveFileAsync( stream, name );

        //验证已存在
        var result = await _fileStore.FileExistsAsync( name );
        Assert.True( result );

        //删除文件
        await _fileStore.DeleteFileAsync( name );

        //验证已不存在
        result = await _fileStore.FileExistsAsync( name );
        Assert.False( result );
    }

    #endregion

    #region GenerateDownloadUrlAsync

    /// <summary>
    /// 测试生成下载Url
    /// </summary>
    [Fact]
    public async Task TestGenerateDownloadUrlAsync() {
        var args = new GenerateDownloadUrlArgs("a.jpg") {
            BucketName = "test"
        };
        var url = await _fileStore.GenerateDownloadUrlAsync( args );
        _testOutputHelper.WriteLine( url );
        Assert.StartsWith( "https://test.oss-cn-beijing.aliyuncs.com/a.jpg", url );
    }

    #endregion

    #region GenerateUploadUrlAsync

    /// <summary>
    /// 测试生成上传Url
    /// </summary>
    [Fact]
    public async Task TestGenerateUploadUrlAsync() {
        //生成上传Url
        var fileName = Id.Create();
        var path = Common.GetPhysicalPath( "~/Resources/a.png" );
        var upload = await _fileStore.GenerateUploadUrlAsync( new GenerateUploadUrlArgs( fileName ) { BucketName = "util-test" } );
        _testOutputHelper.WriteLine( Util.Helpers.Json.ToJson( upload ) );

        //发送请求
        await _client.Post( upload.Url ).FileContent( path ).Content( upload.Data )
            .OnFail( ( m, o ) => { _testOutputHelper.WriteLine( Util.Helpers.Json.ToJson( o ) ); } )
            .GetResultAsync();

        //验证
        var exists = await _fileStore.FileExistsAsync( new FileExistsArgs( fileName ) {BucketName = "util-test" } );
        Assert.True( exists );
    }

    #endregion
}