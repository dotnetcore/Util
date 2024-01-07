namespace Util.FileStorage;

/// <summary>
/// 文件存储服务工厂
/// </summary>
public class FileStoreFactory : IFileStoreFactory {
    /// <summary>
    /// 文件名处理器工厂
    /// </summary>
    private readonly IFileNameProcessorFactory _fileNameProcessorFactory;
    /// <summary>
    /// 存储桶名称处理器工厂
    /// </summary>
    private readonly IBucketNameProcessorFactory _bucketNameProcessorFactory;
    /// <summary>
    /// Http操作
    /// </summary>
    private readonly IHttpClient _httpClient;
    /// <summary>
    /// Http客户端工厂
    /// </summary>
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// 初始化本地文件存储服务
    /// </summary>
    /// <param name="fileNameProcessorFactory">文件名处理器工厂</param>
    /// <param name="bucketNameProcessorFactory">存储桶名称处理器工厂</param>
    /// <param name="httpClientFactory">Http客户端工厂</param>
    /// <param name="httpClient">Http操作</param>
    public FileStoreFactory( IFileNameProcessorFactory fileNameProcessorFactory, IBucketNameProcessorFactory bucketNameProcessorFactory,
        IHttpClientFactory httpClientFactory, IHttpClient httpClient ) {
        _fileNameProcessorFactory = fileNameProcessorFactory ?? throw new ArgumentNullException( nameof( fileNameProcessorFactory ) );
        _bucketNameProcessorFactory = bucketNameProcessorFactory ?? throw new ArgumentNullException( nameof( bucketNameProcessorFactory ) );
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException( nameof( httpClientFactory ) );
        _httpClient = httpClient ?? throw new ArgumentNullException( nameof( httpClient ) );
    }

    /// <inheritdoc />
    public IFileStore Create( LocalStoreOptions options ) {
        return new LocalFileStore( new LocalStoreConfigProvider( options ), _fileNameProcessorFactory, _httpClient );
    }

    /// <inheritdoc />
    public IFileStore Create( MinioOptions options ) {
        return new MinioFileStore( new MinioConfigProvider( options ), _httpClientFactory, _bucketNameProcessorFactory, _fileNameProcessorFactory, _httpClient );
    }

    /// <inheritdoc />
    public IFileStore Create( AliyunOssOptions options ) {
        return new AliyunFileStore( new AliyunOssConfigProvider( options ), _bucketNameProcessorFactory, _fileNameProcessorFactory, _httpClient );
    }

    /// <inheritdoc />
    public IAliyunOssFileStore CreateAliyunOss( AliyunOssOptions options ) {
        return new AliyunFileStore( new AliyunOssConfigProvider( options ), _bucketNameProcessorFactory, _fileNameProcessorFactory, _httpClient );
    }
}