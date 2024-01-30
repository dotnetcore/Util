using Util.Helpers;

namespace Util.FileStorage.Tests;

/// <summary>
/// 本地文件存储服务测试
/// </summary>
public class LocalFileStoreTest {
    /// <summary>
    /// 本地文件存储服务
    /// </summary>
    private readonly ILocalFileStore _fileStore;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public LocalFileStoreTest( ILocalFileStore fileStore ) {
        _fileStore = fileStore;
    }

    /// <summary>
    /// 测试保存文件
    /// </summary>
    [Fact]
    public async Task TestSaveFileAsync_1() {
        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/1.jpg" );
        await using var stream = File.ReadToStream( path );
        var result = await _fileStore.SaveFileAsync( stream, "1.jpg" );
        Assert.Equal( "upload\\1.jpg", result.FilePath );
        Assert.Equal( "1.jpg", result.FileName );
        Assert.Equal( "jpg", result.Extension );

        //验证上传文件是否存在
        var exists = await _fileStore.FileExistsAsync( "1.jpg" );
        Assert.True( exists );
    }

    /// <summary>
    /// 测试保存文件 - 自定义文件名策略
    /// </summary>
    [Fact]
    public async Task TestSaveFileAsync_2() {
        var path = Common.GetPhysicalPath( "~/Resources/2.png" );
        await using var stream = File.ReadToStream( path );
        var result = await _fileStore.SaveFileAsync( stream, "2.png","test" );
        Assert.Equal( "upload\\a.png", result.FilePath );
        Assert.Equal( "a.png", result.FileName );
        Assert.Equal( "2.png", result.OriginalFileName );
        Assert.Equal( "png", result.Extension );
    }

    /// <summary>
    /// 测试获取文件流
    /// </summary>
    [Fact]
    public async Task TestGetFileStreamAsync() {
        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/1.jpg" );
        var fileInfo = new System.IO.FileInfo( path );
        var result = await _fileStore.SaveFileAsync( fileInfo );

        //验证
        var exists = await _fileStore.FileExistsAsync( result.FileName );
        Assert.True( exists );

        //获取文件
        await using var stream = await _fileStore.GetFileStreamAsync( result.FileName );
        var bytes = await File.ToBytesAsync( stream );
        Assert.Equal( result.Size.Size, bytes.Length );
    }

    /// <summary>
    /// 测试下载远程文件并保存到文件存储
    /// </summary>
    [Fact]
    public async Task TestSaveFileByUrlAsync_1() {
        var result = await _fileStore.SaveFileByUrlAsync( "https://www.baidu.com/img/PCtm_d9c8750bed0b3c7d089fa7d55720d6cf.png", "baidu.png" );
        var exists = await _fileStore.FileExistsAsync( result.FileName );
        Assert.True( exists );
    }

    /// <summary>
    /// 测试复制文件
    /// </summary>
    [Fact]
    public async Task TestCopyFileAsync() {
        var sourceName = "e.jpg";
        var destinationName = "a/b/c/f.jpg";

        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/1.jpg" );
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

    /// <summary>
    /// 测试移动文件
    /// </summary>
    [Fact]
    public async Task TestMoveFileAsync() {
        var sourceName = "e.jpg";
        var destinationName = "a/b/c/g.jpg";

        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/1.jpg" );
        await using var stream = File.ReadToStream( path );
        await _fileStore.SaveFileAsync( stream, sourceName );

        //复制文件
        await _fileStore.MoveFileAsync( sourceName, destinationName );

        //验证
        var result = await _fileStore.FileExistsAsync( sourceName );
        Assert.False( result );
        result = await _fileStore.FileExistsAsync( destinationName );
        Assert.True( result );
    }

    /// <summary>
    /// 测试删除文件
    /// </summary>
    [Fact]
    public async Task TestDeleteFileAsync() {
        var name = "b.jpg";

        //保存文件
        var path = Common.GetPhysicalPath( "~/Resources/1.jpg" );
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
}