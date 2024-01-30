namespace Util.FileStorage.Local;

/// <summary>
/// 本地文件存储服务
/// </summary>
public class LocalFileStore : IFileStore {

    #region 字段

    /// <summary>
    /// 配置提供器
    /// </summary>
    private readonly ILocalStoreConfigProvider _configProvider;
    /// <summary>
    /// 文件名处理器工厂
    /// </summary>
    private readonly IFileNameProcessorFactory _fileNameProcessorFactory;
    /// <summary>
    /// 本地文件存储配置
    /// </summary>
    private LocalStoreOptions _config;
    /// <summary>
    /// Http操作
    /// </summary>
    private readonly IHttpClient _httpClient;

    #endregion

    #region 构造方法

    /// <summary>
    /// 初始化本地文件存储服务
    /// </summary>
    /// <param name="configProvider">配置提供器</param>
    /// <param name="fileNameProcessorFactory">文件名处理器工厂</param>
    /// <param name="httpClient">Http操作</param>
    public LocalFileStore( ILocalStoreConfigProvider configProvider, IFileNameProcessorFactory fileNameProcessorFactory, IHttpClient httpClient ) {
        _configProvider = configProvider ?? throw new ArgumentNullException( nameof( configProvider ) );
        _fileNameProcessorFactory = fileNameProcessorFactory ?? throw new ArgumentNullException( nameof( fileNameProcessorFactory ) );
        _httpClient = httpClient ?? throw new ArgumentNullException( nameof( httpClient ) );
    }

    #endregion

    #region GetConfig

    /// <summary>
    /// 获取配置
    /// </summary>
    protected virtual async Task<LocalStoreOptions> GetConfig() {
        return _config ??= await _configProvider.GetConfigAsync();
    }

    #endregion

    #region GetBucketNamesAsync

    /// <inheritdoc />
    public virtual Task<List<string>> GetBucketNamesAsync( CancellationToken cancellationToken = default ) {
        throw new NotImplementedException();
    }

    #endregion

    #region BucketExistsAsync

    /// <inheritdoc />
    public virtual Task<bool> BucketExistsAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
        throw new NotImplementedException();
    }

    #endregion

    #region CreateBucketAsync

    /// <inheritdoc />
    public virtual Task CreateBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
        throw new NotImplementedException();
    }

    #endregion

    #region DeleteBucketAsync

    /// <inheritdoc />
    public virtual Task DeleteBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default ) {
        throw new NotImplementedException();
    }

    #endregion

    #region FileExistsAsync

    /// <inheritdoc />
    public virtual async Task<bool> FileExistsAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
        var args = new FileExistsArgs( fileName ) { FileNamePolicy = policy };
        return await FileExistsAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task<bool> FileExistsAsync( FileExistsArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        return await FileExistsAsync( processedFileName, cancellationToken );
    }

    /// <summary>
    /// 处理文件名
    /// </summary>
    protected virtual ProcessedName ProcessFileName( FileStorageArgs args ) {
        if ( args.FileName.IsEmpty() )
            throw new ArgumentNullException( nameof( args.FileName ) );
        var processor = _fileNameProcessorFactory.CreateProcessor( args.FileNamePolicy );
        return processor.Process( args.FileName );
    }

    /// <summary>
    /// 文件是否存在
    /// </summary>
    protected virtual async Task<bool> FileExistsAsync( ProcessedName fileName, CancellationToken cancellationToken = default ) {
        var filePath = await GetPhysicalPath( fileName );
        return Util.Helpers.File.FileExists( filePath );
    }

    /// <summary>
    /// 获取文件绝对路径
    /// </summary>
    protected virtual async Task<string> GetPhysicalPath( ProcessedName fileName ) {
        var config = await GetConfig();
        return Path.Combine( GetRootPath(), config.RootPath, fileName.Name );
    }

    /// <summary>
    /// 获取根路径
    /// </summary>
    protected virtual string GetRootPath() {
        return Util.Helpers.Web.Environment == null ? string.Empty : Util.Helpers.Web.Environment.WebRootPath;
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
        var filePath = await GetPhysicalPath( processedFileName );
        return await Util.Helpers.File.ReadToMemoryStreamAsync( filePath, cancellationToken );
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
        return await SaveFileAsync( args.Stream, processedFileName, cancellationToken );
    }

    /// <summary>
    /// 保存文件
    /// </summary>
    public virtual async Task<FileResult> SaveFileAsync( Stream stream, ProcessedName fileName, CancellationToken cancellationToken = default ) {
        stream.CheckNull( nameof( stream ) );
        var config = await GetConfig();
        var filePath = Path.Combine( config.RootPath, fileName.Name );
        var physicalPath = Path.Combine( GetRootPath(), filePath );
        await Util.Helpers.File.WriteAsync( physicalPath, stream, cancellationToken );
        return new FileResult( filePath, stream.Length, fileName.OriginalName );
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
        var bytes = await _httpClient.Get( args.Url ).GetStreamAsync( cancellationToken );
        await using var stream = new MemoryStream( bytes );
        return await SaveFileAsync( stream, processedFileName, cancellationToken );
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
        var processedSourceFileName = ProcessFileName( sourceArgs );
        var processedDestinationFileName = ProcessFileName( destinationArgs );
        var sourceFilePath = await GetPhysicalPath( processedSourceFileName );
        var destinationFilePath = await GetPhysicalPath( processedDestinationFileName );
        Util.Helpers.File.Copy( sourceFilePath, destinationFilePath, true );
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
    public virtual async Task MoveFileAsync( FileStorageArgs sourceArgs, FileStorageArgs destinationArgs, CancellationToken cancellationToken = default ) {
        var processedSourceFileName = ProcessFileName( sourceArgs );
        var processedDestinationFileName = ProcessFileName( destinationArgs );
        var sourceFilePath = await GetPhysicalPath( processedSourceFileName );
        var destinationFilePath = await GetPhysicalPath( processedDestinationFileName );
        Util.Helpers.File.Move( sourceFilePath, destinationFilePath, true );
    }

    #endregion

    #region DeleteFileAsync

    /// <inheritdoc />
    public async Task DeleteFileAsync( string fileName, CancellationToken cancellationToken = default ) {
        var args = new DeleteFileArgs( fileName );
        await DeleteFileAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task DeleteFileAsync( DeleteFileArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        var filePath = await GetPhysicalPath( processedFileName );
        Util.Helpers.File.Delete( filePath );
    }

    #endregion

    #region GenerateDownloadUrlAsync

    /// <inheritdoc />
    public async Task<string> GenerateDownloadUrlAsync( string fileName, CancellationToken cancellationToken = default ) {
        var args = new GenerateDownloadUrlArgs( fileName );
        return await GenerateDownloadUrlAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public virtual Task<string> GenerateDownloadUrlAsync( GenerateDownloadUrlArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        var url = Util.Helpers.Common.JoinPath( Util.Helpers.Web.Host, processedFileName.Name );
        return Task.FromResult( url );
    }

    #endregion

    #region GenerateTempDownloadUrlAsync

    /// <inheritdoc />
    public async Task<string> GenerateTempDownloadUrlAsync( string fileName, CancellationToken cancellationToken = default ) {
        var args = new GenerateTempDownloadUrlArgs( fileName );
        return await GenerateTempDownloadUrlAsync( args, cancellationToken );
    }

    /// <inheritdoc />
    public virtual Task<string> GenerateTempDownloadUrlAsync( GenerateTempDownloadUrlArgs args, CancellationToken cancellationToken = default ) {
        args.CheckNull( nameof( args ) );
        var processedFileName = ProcessFileName( args );
        var url = Util.Helpers.Common.JoinPath( Util.Helpers.Web.Host, processedFileName.Name );
        return Task.FromResult( url );
    }

    #endregion

    #region GenerateUploadUrlAsync

    /// <inheritdoc />
    public virtual Task<DirectUploadParam> GenerateUploadUrlAsync( string fileName, string policy = null, CancellationToken cancellationToken = default ) {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public virtual Task<DirectUploadParam> GenerateUploadUrlAsync( GenerateUploadUrlArgs args, CancellationToken cancellationToken = default ) {
        throw new NotImplementedException();
    }

    #endregion

    #region ClearAsync

    /// <inheritdoc />
    public virtual async Task ClearAsync( CancellationToken cancellationToken = default ) {
        var config = await GetConfig();
        var filePath = Util.Helpers.Common.GetPhysicalPath( config.RootPath );
        Util.Helpers.File.Delete( filePath );
    }

    #endregion
}