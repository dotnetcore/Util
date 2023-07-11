using Util.Data.EntityFrameworkCore.Migrations;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Data.EntityFrameworkCore.Tests; 

/// <summary>
/// 迁移文件服务测试
/// </summary>
public class MigrationFileServiceTest {
    /// <summary>
    /// 迁移文件服务
    /// </summary>
    private readonly IMigrationFileService _service;
    /// <summary>
    /// 测试消息输出
    /// </summary>
    private readonly ITestOutputHelper _testOutputHelper;
    /// <summary>
    /// 迁移目录路径
    /// </summary>
    private readonly string _migrationsPath;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public MigrationFileServiceTest( IMigrationFileService service, ITestOutputHelper testOutputHelper ) {
        _service = service;
        _testOutputHelper = testOutputHelper;
        _migrationsPath = Common.JoinPath( Common.GetCurrentDirectory(), "Samples/Migrations" );
    }

    /// <summary>
    /// 测试获取迁移文件路径
    /// </summary>
    [Fact]
    public void TestGetFilePath() {
        var path = _service.MigrationsPath( _migrationsPath ).MigrationName( "Init" ).GetFilePath();
        var result = Common.JoinPath( Common.GetCurrentDirectory(), "Samples/Migrations/20230302102051_Init.cs" );
        Assert.Equal( result, path.Replace( "\\","/" ) );
    }

    /// <summary>
    /// 测试获取迁移文件内容
    /// </summary>
    [Fact]
    public void TestGetContent() {
        var content = _service.MigrationsPath( _migrationsPath ).MigrationName( "Init" ).GetContent();
        Assert.Contains( "public partial class Init : Migration", content );
        Assert.Contains( "table.ForeignKey", content );
    }

    /// <summary>
    /// 测试移除所有外键
    /// </summary>
    [Fact]
    public void TestRemoveForeignKeys() {
        var filePath = Common.JoinPath( Common.GetCurrentDirectory(), "Samples/Migrations/Init_Copy.cs" );
        _service.MigrationsPath( _migrationsPath ).MigrationName( "Init" ).RemoveForeignKeys().Save( filePath );
        var result = Util.Helpers.File.ReadToString( filePath );
        _testOutputHelper.WriteLine(result);
        Assert.DoesNotContain( "table.ForeignKey", result );
        Util.Helpers.File.Delete( filePath );
    }
}