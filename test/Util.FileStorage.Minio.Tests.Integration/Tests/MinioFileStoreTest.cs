using System;
using System.IO;
using System.Threading.Tasks;
using Util.FileStorage.Minio.Samples;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;
using File = Util.Helpers.File;

namespace Util.FileStorage.Minio.Tests {
    /// <summary>
    /// Minio文件存储服务测试
    /// </summary>
    public class MinioFileStoreTest : IDisposable {

        #region 测试初始化

        /// <summary>
        /// 文件存储服务
        /// </summary>
        private readonly IFileStore _fileStore;
        /// <summary>
        /// 输出操作
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MinioFileStoreTest( IFileStore fileStore, ITestOutputHelper testOutputHelper ) {
            _fileStore = fileStore;
            _testOutputHelper = testOutputHelper;
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

        #region BucketExistsAsync

        /// <summary>
        /// 测试存储桶是否存在
        /// </summary>
        [Fact]
        public async Task TestBucketExistsAsync() {
            var name = Id.Create();

            //未创建的桶不存在
            var result = await _fileStore.BucketExistsAsync( name );
            Assert.False( result );

            //创建桶
            await _fileStore.CreateBucketAsync( name );

            //验证
            result = await _fileStore.BucketExistsAsync( name );
            Assert.True( result );
        }

        #endregion

        #region CreateBucketAsync

        /// <summary>
        /// 测试创建存储桶 - 修正名称有大写字母和下划线
        /// </summary>
        [Fact]
        public async Task TestCreateBucketAsync_1() {
            var name = "TestCreateBucketAsync_1";

            //创建桶
            await _fileStore.CreateBucketAsync( name );

            //验证
            var result = await _fileStore.BucketExistsAsync( "testcreatebucketasync-1" );
            Assert.True( result );
        }

        #endregion

        #region DeleteBucketAsync

        /// <summary>
        /// 测试删除存储桶
        /// </summary>
        [Fact]
        public async Task TestDeleteBucketAsync_1() {
            var name = "TestDeleteBucketAsync_1";

            //创建桶
            await _fileStore.CreateBucketAsync( name );

            //验证桶已存在
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
            var name = $"{Id.Create()}.jpg";

            //文件未创建不存在
            var result = await _fileStore.FileExistsAsync( name );
            Assert.False( result );

            //读取文件
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
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
            var name = $"{Id.Create()}.jpg";
            var bucketName = "TestFileExistsAsync_2";

            //文件未创建不存在
            var result = await _fileStore.FileExistsAsync( new FileExistsArgs( name ) { BucketName = bucketName } );
            Assert.False( result );

            //读取文件
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
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
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
            var fileInfo = new FileInfo( path );
            var result = await _fileStore.SaveFileAsync( fileInfo );

            //验证
            var exists = await _fileStore.FileExistsAsync( result.FileName );
            Assert.True( exists );

            //获取文件
            var stream = await _fileStore.GetFileStreamAsync( result.FileName );
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
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
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
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
            await using var stream = File.ReadToStream( path );
            var result = await _fileStore.SaveFileAsync( stream, "b.jpg" );
            Assert.Equal( "b.jpg", result.FilePath );
            Assert.Equal( "b.jpg", result.FileName );
            Assert.Equal( "jpg", result.Extension );
            Assert.Equal( "1.09 MB", result.Size.ToString() );
        }

        /// <summary>
        /// 测试保存文件 - 指定存储桶
        /// </summary>
        [Fact]
        public async Task TestSaveFileAsync_2() {
            var fileName = "b.jpg";
            var bucketName = "TestSaveFileAsync_2";
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
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
            var fileName = "b.jpg";
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
            await using var stream = File.ReadToStream( path );
            var result =  await _fileStore.SaveFileAsync( stream, fileName,UserTimeFileNameProcessor.Policy );
            Assert.Equal( $"{TestSession.TestUserId}/2012-12-12-12-12-12-123/b.jpg", result.FilePath );
            Assert.Equal( "b.jpg", result.FileName );
            Assert.Equal( "jpg", result.Extension );
        }

        /// <summary>
        /// 测试保存文件 - 使用FileInfo
        /// </summary>
        [Fact]
        public async Task TestSaveFileAsync_4() {
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
            var fileInfo = new FileInfo( path );
            var result = await _fileStore.SaveFileAsync( fileInfo );
            Assert.Equal( "b.jpg", result.FilePath );
            Assert.Equal( "b.jpg", result.FileName );
            Assert.Equal( "jpg", result.Extension );
            Assert.Equal( "1.09 MB", result.Size.ToString() );
        }

        /// <summary>
        /// 测试保存文件 - 使用字节流
        /// </summary>
        [Fact]
        public async Task TestSaveFileAsync_5() {
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
            var stream = Util.Helpers.File.ReadToBytes( path );
            var result = await _fileStore.SaveFileAsync( stream, "b.jpg" );
            Assert.Equal( "b.jpg", result.FileName );
            Assert.Equal( "jpg", result.Extension );
            Assert.Equal( "1.09 MB", result.Size.ToString() );
        }

        #endregion

        #region DeleteFileAsync

        /// <summary>
        /// 测试删除文件
        /// </summary>
        [Fact]
        public async Task TestDeleteFileAsync() {
            var name = "b.jpg";

            //保存文件
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
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
            //保存文件
            var path = Common.GetPhysicalPath( "~/Resources/b.jpg" );
            var fileInfo = new FileInfo( path );
            var result = await _fileStore.SaveFileAsync( fileInfo );

            //生成url
            var url = await _fileStore.GenerateDownloadUrlAsync( result.FileName );
            _testOutputHelper.WriteLine( url );
            Assert.StartsWith( "http", url );
        }

        #endregion

        #region GenerateUploadUrlAsync

        /// <summary>
        /// 测试生成上传Url
        /// </summary>
        [Fact]
        public async Task TestGenerateUploadUrlAsync() {
            var url = await _fileStore.GenerateUploadUrlAsync( "a.jpg" );
            _testOutputHelper.WriteLine( url );
            Assert.StartsWith( "http", url );
        }

        #endregion
    }
}
