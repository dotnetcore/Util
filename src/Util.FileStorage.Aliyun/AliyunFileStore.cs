namespace Util.FileStorage.Aliyun;

/// <summary>
/// 阿里云对象存储服务
/// </summary>
public class AliyunFileStore : IAliyunOssFileStore {

    #region 字段

    /// <summary>
    /// 配置提供器
    /// </summary>
    private readonly IAliyunOssConfigProvider _configProvider;
    /// <summary>
    /// 存储桶名称处理器工厂
    /// </summary>
    private readonly IBucketNameProcessorFactory _bucketNameProcessorFactory;
    /// <summary>
    /// 文件名处理器工厂
    /// </summary>
    private readonly IFileNameProcessorFactory _fileNameProcessorFactory;
    /// <summary>
    /// 阿里云对象存储配置
    /// </summary>
    private AliyunOssOptions _config;
    /// <summary>
    /// 阿里云对象存储客户端
    /// </summary>
    private IOss _client;
    /// <summary>
    /// Http操作
    /// </summary>
    private readonly IHttpClient _httpClient;

    #endregion

    #region 构造方法

    /// <summary>
    /// 初始化阿里云对象存储服务
    /// </summary>
    /// <param name="configProvider">配置提供器</param>
    /// <param name="bucketNameProcessorFactory">存储桶名称处理器工厂</param>
    /// <param name="fileNameProcessorFactory">文件名处理器工厂</param>
    ///  <param name="httpClient">Http操作</param>
    public AliyunFileStore( IAliyunOssConfigProvider configProvider,
        IBucketNameProcessorFactory bucketNameProcessorFactory, IFileNameProcessorFactory fileNameProcessorFactory,
        IHttpClient httpClient ) {
        _configProvider = configProvider ?? throw new ArgumentNullException( nameof( configProvider ) );
        _bucketNameProcessorFactory = bucketNameProcessorFactory ?? throw new ArgumentNullException( nameof( bucketNameProcessorFactory ) );
        _fileNameProcessorFactory = fileNameProcessorFactory ?? throw new ArgumentNullException( nameof( fileNameProcessorFactory ) );
        _httpClient = httpClient ?? throw new ArgumentNullException( nameof( httpClient ) );
    }

    #endregion

    #region InitConfig

    /// <summary>
    /// 初始化配置
    /// </summary>
    protected virtual async Task InitConfig() {
        if( _config != null )
            return;
        _config = await _configProvider.GetConfigAsync();
    }

    #endregion

    #region GetClient

    /// <summary>
    /// 获取阿里云对象存储客户端
    /// </summary>
    public virtual async Task<IOss> GetClient() {
        if( _client != null )
            return _client;
        await InitConfig();
        _client = new OssClient( GetEndpoint(), _config.AccessKeyId, _config.AccessKeySecret );
        return _client;
    }

    /// <summary>
    /// 获取服务端点
    /// </summary>
    protected virtual string GetEndpoint() {
        var endpoint = _config.Endpoint;
        if( endpoint.StartsWith( "http" ) )
            return endpoint;
        return $"https://{endpoint}";
    }

    #endregion

    #region GetBucketNamesAsync

    /// <inheritdoc />
    public virtual async Task<List<string>> GetBucketNamesAsync( CancellationToken cancellationToken = default ) {
        var client = await GetClient();
        var result = client.ListBuckets();
        return result.Select( t => t.Name ).ToList();
    }

    #endregion

    #region BucketExistsAsync

    /// <inheritdoc />
    public virtual async Task<bool> BucketExistsAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
        if( bucketName.IsEmpty() )
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
        return client.DoesBucketExist( bucketName.Name );
    }

    #endregion

    #region CreateBucketAsync

    /// <inheritdoc />
    public virtual async Task CreateBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
        if( bucketName.IsEmpty() )
            return;
        var args = new CreateBucketArgs( bucketName );
        await CreateBucketAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public async Task CreateBucketAsync( CreateBucketArgs args, CancellationToken cancellationToken = default ) {
        var bucketName = ProcessBucketName( args.BucketName, args.BucketNamePolicy );
        var client = await GetClient();
        var exists = await BucketExistsAsync( bucketName, cancellationToken );
        if( exists )
            return;
        var request = new CreateBucketRequest( bucketName.Name ) {
            ACL = args.Acl,
            StorageClass = args.StorageClass,
            DataRedundancyType = args.DataRedundancyType
        };
        client.CreateBucket( request );
    }

    /// <summary>
    /// 创建存储桶
    /// </summary>
    protected virtual async Task CreateBucketAsync( ProcessedName bucketName, CancellationToken cancellationToken = default ) {
        var client = await GetClient();
        var exists = await BucketExistsAsync( bucketName, cancellationToken );
        if( exists )
            return;
        var request = new CreateBucketRequest( bucketName.Name );
        client.CreateBucket( request );
    }

    #endregion

    #region DeleteBucketAsync

    /// <inheritdoc />
    public async Task DeleteBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
        if( bucketName.IsEmpty() )
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
        if( exists == false )
            return;
        client.DeleteBucket( bucketName.Name );
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
        if( args.FileName.IsEmpty() )
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
        if( args.BucketName.IsEmpty() )
            throw new ArgumentNullException( nameof( args.BucketName ) );
        var processor = _bucketNameProcessorFactory.CreateProcessor( args.BucketNamePolicy );
        return processor.Process( args.BucketName );
    }

    /// <summary>
    /// 文件是否存在
    /// </summary>
    protected async Task<bool> FileExistsAsync( ProcessedName fileName, ProcessedName bucketName, CancellationToken cancellationToken = default ) {
        var client = await GetClient();
        return client.DoesObjectExist( bucketName.Name, fileName.Name );
    }

    #endregion

    #region GetFileStreamAsync

    /// <inheritdoc />
    public async Task<Stream> GetFileStreamAsync( string fileName, CancellationToken cancellationToken = default ) {
        var args = new GetFileStreamArgs( fileName );
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
        if( exists == false )
            return null;
        var memoryStream = new MemoryStream();
        var result = client.GetObject( bucketName.Name, fileName.Name );
        await using var stream = result.Content;
        if( stream == null )
            return memoryStream;
        await stream.CopyToAsync( memoryStream, cancellationToken ).ConfigureAwait( false );
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
        var client = await GetClient();
        var result = client.PutObject( bucketName.Name, fileName.Name, stream );
        if( result.HttpStatusCode == HttpStatusCode.OK )
            return new FileResult( fileName.Name, stream.Length, fileName.OriginalName, bucketName.Name );
        throw new InvalidOperationException( Util.Helpers.File.ReadToString( result.ResponseStream ) );
    }

    #endregion

    #region SaveFileByUrlAsync

    /// <inheritdoc />
    public async Task<FileResult> SaveFileByUrlAsync( string url, string fileName, string policy = null, CancellationToken cancellationToken = default ) {
        var args = new SaveFileByUrlArgs( fileName, url ) { FileNamePolicy = policy };
        return await SaveFileByUrlAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public async Task<FileResult> SaveFileByUrlAsync( SaveFileByUrlArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        var processedBucketName = await ProcessBucketName( args );
        var bytes = await _httpClient.Get( args.Url ).GetStreamAsync( cancellationToken );
        await using var stream = new MemoryStream( bytes );
        return await SaveFileAsync( stream, processedFileName, processedBucketName, cancellationToken );
    }

    #endregion

    #region CopyFileAsync

    /// <inheritdoc />
    public async Task CopyFileAsync( string sourceFileName, string destinationFileName, CancellationToken cancellationToken = default ) {
        var sourceArgs = new FileStorageArgs( sourceFileName );
        var destinationArgs = new FileStorageArgs( destinationFileName );
        await CopyFileAsync( sourceArgs, destinationArgs, cancellationToken );
    }

    /// <inheritdoc />
    public async Task CopyFileAsync( FileStorageArgs sourceArgs, FileStorageArgs destinationArgs, CancellationToken cancellationToken = default ) {
        var processedSourceBucketName = await ProcessBucketName( sourceArgs );
        var processedSourceFileName = ProcessFileName( sourceArgs );
        var processedDestinationBucketName = await ProcessBucketName( destinationArgs );
        var processedDestinationFileName = ProcessFileName( destinationArgs );
        var request = new CopyObjectRequest( processedSourceBucketName.Name, processedSourceFileName.Name, processedDestinationBucketName.Name, processedDestinationFileName.Name );
        var client = await GetClient();
        client.CopyObject( request );
    }

    #endregion

    #region MoveFileAsync

    /// <inheritdoc />
    public async Task MoveFileAsync( string sourceFileName, string destinationFileName, CancellationToken cancellationToken = default ) {
        var sourceArgs = new FileStorageArgs( sourceFileName );
        var destinationArgs = new FileStorageArgs( destinationFileName );
        await MoveFileAsync( sourceArgs, destinationArgs, cancellationToken );
    }

    /// <inheritdoc />
    public async Task MoveFileAsync( FileStorageArgs sourceArgs, FileStorageArgs destinationArgs, CancellationToken cancellationToken = default ) {
        await CopyFileAsync( sourceArgs, destinationArgs, cancellationToken );
        var processedSourceFileName = ProcessFileName( sourceArgs );
        var processedSourceBucketName = await ProcessBucketName( sourceArgs );
        await DeleteFileAsync( processedSourceFileName, processedSourceBucketName, cancellationToken );
    }

    #endregion

    #region DeleteFileAsync

    /// <inheritdoc />
    public async Task DeleteFileAsync( string fileName,CancellationToken cancellationToken = default ) {
        var args = new DeleteFileArgs( fileName );
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
        var exists = await FileExistsAsync( fileName, bucketName, cancellationToken );
        if( exists == false )
            return;
        client.DeleteObject( bucketName.Name, fileName.Name );
    }

    #endregion

    #region GenerateDownloadUrlAsync

    /// <inheritdoc />
    public async Task<string> GenerateDownloadUrlAsync( string fileName, CancellationToken cancellationToken = default ) {
        var args = new GenerateDownloadUrlArgs( fileName );
        return await GenerateDownloadUrlAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task<string> GenerateDownloadUrlAsync( GenerateDownloadUrlArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        var processedBucketName = await ProcessBucketName( args );
        var endpoint = await GetEndPoint( processedBucketName.Name );
        return Util.Helpers.Common.JoinPath( endpoint, processedFileName.Name );
    }

    /// <summary>
    /// 获取端点
    /// </summary>
    protected virtual async Task<string> GetEndPoint(string bucketName ) {
        await InitConfig();
        var endpoint = _config.Endpoint.RemoveStart( "http://" ).RemoveStart( "https://" );
        return $"https://{bucketName}.{endpoint}";
    }

    #endregion

    #region GenerateTempDownloadUrlAsync

    /// <inheritdoc />
    public async Task<string> GenerateTempDownloadUrlAsync( string fileName, CancellationToken cancellationToken = default ) {
        var args = new GenerateTempDownloadUrlArgs( fileName );
        return await GenerateTempDownloadUrlAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task<string> GenerateTempDownloadUrlAsync( GenerateTempDownloadUrlArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        var processedBucketName = await ProcessBucketName( args );
        var expiration = args.Expiration ?? _config.DownloadUrlExpiration;
        return await GenerateTempDownloadUrlAsync( processedFileName, processedBucketName, expiration, cancellationToken );
    }

    /// <summary>
    /// 生成临时下载Url
    /// </summary>
    protected virtual async Task<string> GenerateTempDownloadUrlAsync( ProcessedName fileName, ProcessedName bucketName,int expiration, CancellationToken cancellationToken = default ) {
        var client = await GetClient();
        var request = new GeneratePresignedUriRequest( bucketName.Name, fileName.Name, SignHttpMethod.Get ) {
            Expiration = DateTime.Now.AddSeconds( expiration )
        };
        var result = client.GeneratePresignedUri( request );
        return result.AbsoluteUri;
    }

    #endregion

    #region GenerateUploadUrlAsync

    /// <inheritdoc />
    public async Task<DirectUploadParam> GenerateUploadUrlAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
        var args = new GenerateUploadUrlArgs( fileName ) { FileNamePolicy = policy };
        return await GenerateUploadUrlAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public async Task<DirectUploadParam> GenerateUploadUrlAsync( GenerateUploadUrlArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        var processedBucketName = await ProcessBucketName( args );
        return await GenerateUploadUrlAsync( processedFileName, processedBucketName, args.SizeLimit );
    }

    /// <summary>
    /// 生成直传Url
    /// </summary>
    protected async Task<DirectUploadParam> GenerateUploadUrlAsync( ProcessedName fileName, ProcessedName bucketName, long sizeLimit ) {
        await InitConfig();
        var url = CreateGenerateUploadHost( bucketName.Name );
        var data = await CreateGenerateUploadData( fileName, bucketName, sizeLimit );
        return new DirectUploadParam( fileName.Name, url, data, fileName.OriginalName, bucketName.Name );
    }

    /// <summary>
    /// 创建直传域名
    /// </summary>
    protected string CreateGenerateUploadHost( string bucketName ) {
        var result = new StringBuilder();
        var endpoint = _config.Endpoint.RemoveStart( "https://" );
        endpoint = endpoint.RemoveStart( "http://" );
        result.Append( "https://" );
        result.Append( bucketName );
        result.Append( '.' );
        result.Append( endpoint );
        return result.ToString();
    }

    /// <summary>
    /// 创建直传数据
    /// </summary>
    protected async Task<DirectUploadData> CreateGenerateUploadData( ProcessedName fileName, ProcessedName bucketName, long sizeLimit ) {
        var policy = await GetPostPolicy( bucketName, sizeLimit );
        var signature = ComputeSignature( _config.AccessKeySecret, policy );
        return new DirectUploadData( fileName.Name, policy, _config.AccessKeyId, signature );
    }

    /// <summary>
    /// 获取Post策略
    /// </summary>
    protected virtual async Task<string> GetPostPolicy( ProcessedName bucketName,long sizeLimit ) {
        var client = await GetClient();
        var expiration = DateTime.Now.AddSeconds( _config.UploadUrlExpiration );
        var policy = new PolicyConditions();
        policy.AddConditionItem( "bucket", bucketName.Name );
        if( sizeLimit > 0)
            policy.AddConditionItem( "content-length-range", 1,sizeLimit );
        var postPolicy = client.GeneratePostPolicy( expiration, policy );
        return Util.Helpers.Convert.ToBase64( postPolicy );
    }

    /// <summary>
    /// 计算签名
    /// </summary>
    protected virtual string ComputeSignature( string key, string data ) {
        using var algorithm = new HMACSHA1();
        algorithm.Key = Encoding.UTF8.GetBytes( key.ToCharArray() );
        return Convert.ToBase64String( algorithm.ComputeHash( Encoding.UTF8.GetBytes( data.ToCharArray() ) ) );
    }

    #endregion

    #region ClearAsync

    /// <inheritdoc />
    public async Task ClearAsync( CancellationToken cancellationToken = default ) {
        var buckets = await GetBucketNamesAsync( cancellationToken );
        if( buckets.Count == 0 )
            return;
        foreach( var bucket in buckets ) {
            await ClearBucket( bucket );
        }
    }

    /// <summary>
    /// 清空存储桶
    /// </summary>
    private async Task ClearBucket( string bucket ) {
        var client = await GetClient();
        var listObjectsRequest = new ListObjectsRequest( bucket ) {
            MaxKeys = 100,
        };
        var objects = client.ListObjects( listObjectsRequest );
        if( objects.ObjectSummaries.Any() ) {
            var deleteObjectsRequest = new DeleteObjectsRequest( bucket, objects.ObjectSummaries.Select( t => t.Key ).ToList(), true );
            client.DeleteObjects( deleteObjectsRequest );
            await ClearBucket( bucket );
            return;
        }
        client.DeleteBucket( bucket );
    }

    #endregion
}