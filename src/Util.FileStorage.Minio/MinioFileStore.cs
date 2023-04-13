using System;
using System.Collections.Generic;
using Minio;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Minio.Exceptions;

namespace Util.FileStorage.Minio {
    /// <summary>
    /// Minio文件存储服务
    /// </summary>
    public class MinioFileStore : IFileStore {

        #region 字段

        /// <summary>
        /// 配置提供器
        /// </summary>
        private readonly IMinioConfigProvider _configProvider;
        /// <summary>
        /// Http客户端工厂
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;
        /// <summary>
        /// 存储桶名称处理器工厂
        /// </summary>
        private readonly IBucketNameProcessorFactory _bucketNameProcessorFactory;
        /// <summary>
        /// 文件名处理器工厂
        /// </summary>
        private readonly IFileNameProcessorFactory _fileNameProcessorFactory;
        /// <summary>
        /// Minio配置
        /// </summary>
        private MinioConfig _config;
        /// <summary>
        /// Minio客户端
        /// </summary>
        private MinioClient _client;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Minio文件存储服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        /// <param name="httpClientFactory">Http客户端工厂</param>
        /// <param name="bucketNameProcessorFactory">存储桶名称处理器工厂</param>
        /// <param name="fileNameProcessorFactory">文件名处理器工厂</param>
        public MinioFileStore( IMinioConfigProvider configProvider, IHttpClientFactory httpClientFactory,
            IBucketNameProcessorFactory bucketNameProcessorFactory,IFileNameProcessorFactory fileNameProcessorFactory ) {
            _configProvider = configProvider ?? throw new ArgumentNullException( nameof( configProvider ) );
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException( nameof( httpClientFactory ) );
            _bucketNameProcessorFactory = bucketNameProcessorFactory ?? throw new ArgumentNullException( nameof( bucketNameProcessorFactory ) );
            _fileNameProcessorFactory = fileNameProcessorFactory ?? throw new ArgumentNullException( nameof( fileNameProcessorFactory ) );
        }

        #endregion

        #region InitConfig

        /// <summary>
        /// 初始化Minio配置
        /// </summary>
        protected virtual async Task InitConfig() {
            if ( _config != null )
                return;
            _config = await _configProvider.GetConfigAsync();
        }

        #endregion

        #region GetClient

        /// <summary>
        /// 获取Minio客户端
        /// </summary>
        protected virtual async Task<MinioClient> GetClient() {
            await InitConfig();
            return _client ??= new MinioClient()
                .WithEndpoint( GetEndpoint() )
                .WithCredentials( _config.AccessKey, _config.SecretKey )
                .WithSSL( _config.UseSSL )
                .WithHttpClient( GetHttpClient() );
        }

        /// <summary>
        /// 获取服务端点
        /// </summary>
        protected virtual string GetEndpoint() {
            var endpoint = _config.Endpoint;
            if ( endpoint.StartsWith( "http" ) == false )
                return endpoint;
            return endpoint.RemoveStart( "https://" ).RemoveStart( "http://" );
        }

        /// <summary>
        /// 获取Http客户端
        /// </summary>
        protected virtual HttpClient GetHttpClient() {
            if ( _config.HttpClientName.IsEmpty() )
                return _httpClientFactory.CreateClient();
            return _httpClientFactory.CreateClient( _config.HttpClientName );
        }

        #endregion

        #region GetBucketNamesAsync

        /// <inheritdoc />
        public virtual async Task<List<string>> GetBucketNamesAsync( CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            var result = await client.ListBucketsAsync( cancellationToken );
            return result.Buckets.Select( t => t.Name ).ToList();
        }

        #endregion

        #region BucketExistsAsync

        /// <inheritdoc />
        public virtual async Task<bool> BucketExistsAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
            if ( bucketName.IsEmpty() )
                return false;
            var processedBucketName = ProcessBucketName( bucketName, policy );
            return await BucketExistsAsync( processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 处理存储桶名称
        /// </summary>
        protected ProcessedName ProcessBucketName( string bucketName, string policy ) {
            var processor = _bucketNameProcessorFactory.CreateProcessor( policy );
            return processor.Process( bucketName );
        }

        /// <summary>
        /// 存储桶是否存在
        /// </summary>
        protected virtual async Task<bool> BucketExistsAsync( ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            var args = new BucketExistsArgs().WithBucket( bucketName.Name );
            return await client.BucketExistsAsync( args, cancellationToken );
        }

        #endregion

        #region CreateBucketAsync

        /// <inheritdoc />
        public virtual async Task CreateBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
            if ( bucketName.IsEmpty() )
                return;
            var processedBucketName = ProcessBucketName( bucketName, policy );
            await CreateBucketAsync( processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 创建存储桶
        /// </summary>
        protected virtual async Task CreateBucketAsync( ProcessedName bucketName, CancellationToken cancellationToken ) {
            var client = await GetClient();
            var exists = await BucketExistsAsync( bucketName, cancellationToken );
            if ( exists )
                return;
            var args = new MakeBucketArgs().WithBucket( bucketName.Name );
            await client.MakeBucketAsync( args, cancellationToken );
        }

        #endregion

        #region DeleteBucketAsync

        /// <inheritdoc />
        public async Task DeleteBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
            if ( bucketName.IsEmpty() )
                return;
            var processedBucketName = ProcessBucketName( bucketName, policy );
            await DeleteBucketAsync( processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 删除存储桶
        /// </summary>
        protected virtual async Task DeleteBucketAsync( ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            var exists = await BucketExistsAsync( bucketName, cancellationToken );
            if ( exists == false )
                return;
            var args = new RemoveBucketArgs().WithBucket( bucketName.Name );
            await client.RemoveBucketAsync( args, cancellationToken );
        }

        /// <summary>
        /// 安全删除存储桶,不报异常
        /// </summary>
        protected virtual async Task SafeDeleteBucketAsync( ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            try {
                var client = await GetClient();
                var args = new RemoveBucketArgs().WithBucket( bucketName.Name );
                await client.RemoveBucketAsync( args, cancellationToken );
            }
            catch {
                //ignored
            }
        }

        #endregion

        #region FileExistsAsync

        /// <inheritdoc />
        public async Task<bool> FileExistsAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            var args = new FileExistsArgs( fileName ) { FileNamePolicy = policy };
            return await FileExistsAsync( args, cancellationToken );
        }

        /// <inheritdoc />
        public async Task<bool> FileExistsAsync( FileExistsArgs args, CancellationToken cancellationToken = default ) {
            args.CheckNull( nameof( args ) );
            var processedFileName = ProcessFileName( args );
            var processedBucketName = await ProcessBucketName( args );
            return await FileExistsAsync( processedFileName, processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 处理文件名
        /// </summary>
        protected ProcessedName ProcessFileName( FileStorageArgs args ) {
            if ( args.FileName.IsEmpty() )
                throw new ArgumentNullException( nameof( args.FileName ) );
            var processor = _fileNameProcessorFactory.CreateProcessor( args.FileNamePolicy );
            return processor.Process( args.FileName );
        }

        /// <summary>
        /// 处理存储桶名称
        /// </summary>
        protected async Task<ProcessedName> ProcessBucketName( FileStorageArgs args ) {
            await InitConfig();
            args.BucketName ??= _config.DefaultBucketName;
            if ( args.BucketName.IsEmpty() )
                throw new ArgumentNullException( nameof( args.BucketName ) );
            var processor = _bucketNameProcessorFactory.CreateProcessor( args.BucketNamePolicy );
            return processor.Process( args.BucketName );
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        protected async Task<bool> FileExistsAsync( ProcessedName fileName, ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            var args = new StatObjectArgs().WithBucket( bucketName.Name ).WithObject( fileName.Name );
            try {
                await client.StatObjectAsync( args, cancellationToken );
            }
            catch ( Exception ex ) {
                if ( ex is BucketNotFoundException )
                    return false;
                if ( ex is ObjectNotFoundException )
                    return false;
                throw;
            }
            return true;
        }

        #endregion

        #region GetFileStreamAsync

        /// <inheritdoc />
        public async Task<Stream> GetFileStreamAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            var args = new GetFileStreamArgs( fileName ) { FileNamePolicy = policy };
            return await GetFileStreamAsync( args, cancellationToken );
        }

        /// <inheritdoc />
        public async Task<Stream> GetFileStreamAsync( GetFileStreamArgs args, CancellationToken cancellationToken = default ) {
            args.CheckNull( nameof( args ) );
            var processedFileName = ProcessFileName( args );
            var processedBucketName = await ProcessBucketName( args );
            return await GetFileStreamAsync( processedFileName, processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 获取文件流
        /// </summary>
        protected async Task<Stream> GetFileStreamAsync( ProcessedName fileName, ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            var exists = await FileExistsAsync( fileName, bucketName, cancellationToken );
            if ( exists == false )
                return null;
            var memoryStream = new MemoryStream();
            var args = new GetObjectArgs().WithBucket( bucketName.Name ).WithObject( fileName.Name ).WithCallbackStream(
                async (stream,token) => {
                    if ( stream == null ) 
                        return;
                    await stream.CopyToAsync( memoryStream, token ).ConfigureAwait( false );
                    await stream.DisposeAsync();
                } );
            await client.GetObjectAsync( args, cancellationToken );
            return memoryStream;
        }

        #endregion

        #region SaveFileAsync

        /// <inheritdoc />
        public virtual async Task<FileResult> SaveFileAsync( Stream stream, string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            var args = new SaveFileArgs( fileName, stream ) { FileNamePolicy = policy };
            return await SaveFileAsync( args, cancellationToken );
        }

        /// <inheritdoc />
        public virtual async Task<FileResult> SaveFileAsync( SaveFileArgs args, CancellationToken cancellationToken = default ) {
            args.CheckNull( nameof( args ) );
            var processedFileName = ProcessFileName( args );
            var processedBucketName = await ProcessBucketName( args );
            return await SaveFileAsync( args.Stream, processedFileName, processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        public virtual async Task<FileResult> SaveFileAsync( Stream stream, ProcessedName fileName, ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            stream.CheckNull( nameof( stream ) );
            await CreateBucketAsync( bucketName, cancellationToken );
            var client = await GetClient();
            var args = new PutObjectArgs()
                .WithBucket( bucketName.Name )
                .WithObject( fileName.Name )
                .WithStreamData( stream )
                .WithObjectSize( stream.Length );
            await client.PutObjectAsync( args, cancellationToken );
            return new FileResult( fileName.Name, stream.Length, bucketName.Name );
        }

        #endregion

        #region DeleteFileAsync

        /// <inheritdoc />
        public async Task DeleteFileAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            var args = new DeleteFileArgs( fileName ) { FileNamePolicy = policy };
            await DeleteFileAsync( args, cancellationToken );
        }

        /// <inheritdoc />
        public async Task DeleteFileAsync( DeleteFileArgs args, CancellationToken cancellationToken = default ) {
            args.CheckNull( nameof( args ) );
            var processedFileName = ProcessFileName( args );
            var processedBucketName = await ProcessBucketName( args );
            await DeleteFileAsync( processedFileName, processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="bucketName">存储桶名称</param>
        /// <param name="cancellationToken">取消令牌</param>
        protected async Task DeleteFileAsync( ProcessedName fileName, ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            var exists = await FileExistsAsync( fileName,bucketName, cancellationToken );
            if ( exists == false )
                return;
            var args = new RemoveObjectArgs().WithBucket( bucketName.Name ).WithObject( fileName.Name );
            await client.RemoveObjectAsync( args, cancellationToken );
        }

        #endregion

        #region GenerateDownloadUrlAsync

        /// <inheritdoc />
        public async Task<string> GenerateDownloadUrlAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            var args = new GenerateDownloadUrlArgs( fileName ) { FileNamePolicy = policy };
            return await GenerateDownloadUrlAsync( args, cancellationToken );
        }

        /// <inheritdoc />
        public async Task<string> GenerateDownloadUrlAsync( GenerateDownloadUrlArgs args, CancellationToken cancellationToken = default ) {
            args.CheckNull( nameof( args ) );
            var processedFileName = ProcessFileName( args );
            var processedBucketName = await ProcessBucketName( args );
            return await GenerateDownloadUrlAsync( processedFileName, processedBucketName, args.ResponseContentType,cancellationToken );
        }

        /// <summary>
        /// 生成下载Url
        /// </summary>
        protected async Task<string> GenerateDownloadUrlAsync( ProcessedName fileName, ProcessedName bucketName, string responseContentType, CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            var exists = await FileExistsAsync( fileName, bucketName, cancellationToken );
            if ( exists == false )
                return null;
            responseContentType ??= "application/octet-stream";
            var headers = new Dictionary<string, string> { { "response-content-type", responseContentType } };
            var args = new PresignedGetObjectArgs()
                .WithBucket( bucketName.Name )
                .WithObject( fileName.Name )
                .WithExpiry( _config.DownloadUrlExpiration )
                .WithHeaders( headers );
            return await client.PresignedGetObjectAsync( args );
        }

        #endregion

        #region GenerateUploadUrlAsync

        /// <inheritdoc />
        public async Task<string> GenerateUploadUrlAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
            var args = new GenerateUploadUrlArgs( fileName ) { FileNamePolicy = policy };
            return await GenerateUploadUrlAsync( args, cancellationToken );
        }

        /// <inheritdoc />
        public async Task<string> GenerateUploadUrlAsync( GenerateUploadUrlArgs args, CancellationToken cancellationToken = default ) {
            args.CheckNull( nameof( args ) );
            var processedFileName = ProcessFileName( args );
            var processedBucketName = await ProcessBucketName( args );
            return await GenerateUploadUrlAsync( processedFileName, processedBucketName, cancellationToken );
        }

        /// <summary>
        /// 生成上传Url
        /// </summary>
        protected async Task<string> GenerateUploadUrlAsync( ProcessedName fileName, ProcessedName bucketName, CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            await CreateBucketAsync( bucketName, cancellationToken );
            var headers = new Dictionary<string, string> { };
            var args = new PresignedPutObjectArgs()
                .WithBucket( bucketName.Name )
                .WithObject( fileName.Name )
                .WithExpiry( _config.UploadUrlExpiration )
                .WithHeaders( headers );
            return await client.PresignedPutObjectAsync( args );
        }

        #endregion

        #region ClearAsync

        /// <inheritdoc />
        public async Task ClearAsync( CancellationToken cancellationToken = default ) {
            var client = await GetClient();
            while ( true ) {
                var buckets = await GetBucketNamesAsync( cancellationToken );
                if ( buckets.Count == 0 )
                    return;
                foreach ( var bucket in buckets ) {
                    await SafeDeleteBucketAsync( new ProcessedName( bucket ), cancellationToken );
                    var listObjectsArgs = new ListObjectsArgs().WithBucket( bucket ).WithRecursive( true );
                    client.ListObjectsAsync( listObjectsArgs, cancellationToken ).Subscribe( item => {
                        var removeObjectArgs = new RemoveObjectArgs().WithBucket( bucket ).WithObject( item.Key );
                        client.RemoveObjectAsync( removeObjectArgs, cancellationToken ).GetAwaiter();
                    }, () => {
                        SafeDeleteBucketAsync( new ProcessedName( bucket ), cancellationToken ).GetAwaiter();
                    } );
                }
            }
        }

        #endregion
    }
}
