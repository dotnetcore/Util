namespace Util.Helpers;

/// <summary>
/// 文件流操作
/// </summary>
public static class File {

    #region ToBytes

    /// <summary>
    /// 流转换为字节数组
    /// </summary>
    /// <param name="stream">流</param>
    public static byte[] ToBytes( Stream stream ) {
        stream.Seek( 0, SeekOrigin.Begin );
        var buffer = new byte[stream.Length];
        stream.Read( buffer, 0, buffer.Length );
        return buffer;
    }

    /// <summary>
    /// 字符串转换成字节数组
    /// </summary>
    /// <param name="data">数据,默认字符编码utf-8</param>        
    public static byte[] ToBytes( string data ) {
        return ToBytes( data, Encoding.UTF8 );
    }

    /// <summary>
    /// 字符串转换成字节数组
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="encoding">字符编码</param>
    public static byte[] ToBytes( string data, Encoding encoding ) {
        if ( string.IsNullOrWhiteSpace( data ) )
            return Array.Empty<byte>();
        return encoding.GetBytes( data );
    }

    #endregion

    #region ToBytesAsync

    /// <summary>
    /// 流转换为字节数组
    /// </summary>
    /// <param name="stream">流</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<byte[]> ToBytesAsync( Stream stream, CancellationToken cancellationToken = default ) {
        stream.Seek( 0, SeekOrigin.Begin );
        var buffer = new byte[stream.Length];
        await stream.ReadAsync( buffer, 0, buffer.Length, cancellationToken );
        return buffer;
    }

    #endregion

    #region ToStream

    /// <summary>
    /// 字符串转换成流
    /// </summary>
    /// <param name="data">数据</param>
    public static Stream ToStream( string data ) {
        return ToStream( data, Encoding.UTF8 );
    }

    /// <summary>
    /// 字符串转换成流
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="encoding">字符编码</param>
    public static Stream ToStream( string data, Encoding encoding ) {
        if ( data.IsEmpty() )
            return Stream.Null;
        return new MemoryStream( ToBytes( data, encoding ) );
    }

    #endregion

    #region FileExists

    /// <summary>
    /// 判断文件是否存在
    /// </summary>
    /// <param name="path">文件绝对路径</param>
    public static bool FileExists( string path ) {
        return System.IO.File.Exists( path );
    }

    #endregion

    #region DirectoryExists

    /// <summary>
    /// 判断目录是否存在
    /// </summary>
    /// <param name="path">目录绝对路径</param>
    public static bool DirectoryExists( string path ) {
        return Directory.Exists( path );
    }

    #endregion

    #region CreateDirectory

    /// <summary>
    /// 创建目录
    /// </summary>
    /// <param name="path">文件或目录绝对路径</param>
    public static void CreateDirectory( string path ) {
        if ( path.IsEmpty() )
            return;
        var file = new FileInfo( path );
        var directoryPath = file.Directory?.FullName;
        if ( Directory.Exists( directoryPath ) )
            return;
        Directory.CreateDirectory( directoryPath );
    }

    #endregion

    #region ReadToString

    /// <summary>
    /// 读取文件到字符串
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    public static string ReadToString( string filePath ) {
        return ReadToString( filePath, Encoding.UTF8 );
    }

    /// <summary>
    /// 读取文件到字符串
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="encoding">字符编码</param>
    public static string ReadToString( string filePath, Encoding encoding ) {
        if ( System.IO.File.Exists( filePath ) == false )
            return string.Empty;
        using var reader = new StreamReader( filePath, encoding );
        return reader.ReadToEnd();
    }

    /// <summary>
    /// 读取流转换成字符串
    /// </summary>
    /// <param name="stream">流</param>
    /// <param name="encoding">字符编码</param>
    /// <param name="bufferSize">缓冲区大小</param>
    /// <param name="isCloseStream">读取完成是否释放流，默认为true</param>
    public static string ReadToString( Stream stream, Encoding encoding = null, int bufferSize = 1024 * 2, bool isCloseStream = true ) {
        if ( stream == null )
            return string.Empty;
        encoding ??= Encoding.UTF8;
        if ( stream.CanRead == false )
            return string.Empty;
        using var reader = new StreamReader( stream, encoding, true, bufferSize, !isCloseStream );
        if ( stream.CanSeek )
            stream.Seek( 0, SeekOrigin.Begin );
        var result = reader.ReadToEnd();
        if ( stream.CanSeek )
            stream.Seek( 0, SeekOrigin.Begin );
        return result;
    }

    #endregion

    #region ReadToStringAsync

    /// <summary>
    /// 读取文件到字符串
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    public static async Task<string> ReadToStringAsync( string filePath ) {
        return await ReadToStringAsync( filePath, Encoding.UTF8 );
    }

    /// <summary>
    /// 读取文件到字符串
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="encoding">字符编码</param>
    public static async Task<string> ReadToStringAsync( string filePath, Encoding encoding ) {
        if ( System.IO.File.Exists( filePath ) == false )
            return string.Empty;
        using var reader = new StreamReader( filePath, encoding );
        return await reader.ReadToEndAsync();
    }

    #endregion

    #region ReadToStream

    /// <summary>
    /// 读取文件流
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    public static Stream ReadToStream( string filePath ) {
        try {
            return new FileStream( filePath, FileMode.Open );
        }
        catch {
            return null;
        }
    }

    #endregion

    #region ReadToBytes

    /// <summary>
    /// 将文件读取到字节流中
    /// </summary>
    /// <param name="filePath">文件的绝对路径</param>
    public static byte[] ReadToBytes( string filePath ) {
        if ( !System.IO.File.Exists( filePath ) )
            return null;
        var fileInfo = new FileInfo( filePath );
        using var reader = new BinaryReader( fileInfo.Open( FileMode.Open ) );
        return reader.ReadBytes( (int)fileInfo.Length );
    }

    /// <summary>
    /// 读取流转换成字节数组
    /// </summary>
    /// <param name="stream">流</param>
    public static byte[] ReadToBytes( Stream stream ) {
        if ( stream == null )
            return null;
        if ( stream.CanRead == false )
            return null;
        if ( stream.CanSeek )
            stream.Seek( 0, SeekOrigin.Begin );
        var buffer = new byte[stream.Length];
        stream.Read( buffer, 0, buffer.Length );
        if ( stream.CanSeek )
            stream.Seek( 0, SeekOrigin.Begin );
        return buffer;
    }

    #endregion

    #region ReadToBytesAsync

    /// <summary>
    /// 读取流转换成字节数组
    /// </summary>
    /// <param name="stream">流</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<byte[]> ReadToBytesAsync( Stream stream, CancellationToken cancellationToken = default ) {
        if ( stream == null )
            return null;
        if ( stream.CanRead == false )
            return null;
        if ( stream.CanSeek )
            stream.Seek( 0, SeekOrigin.Begin );
        var buffer = new byte[stream.Length];
        await stream.ReadAsync( buffer, 0, buffer.Length, cancellationToken );
        if ( stream.CanSeek )
            stream.Seek( 0, SeekOrigin.Begin );
        return buffer;
    }

    #endregion

    #region ReadToMemoryStreamAsync

    /// <summary>
    /// 读取文件到内存流
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<MemoryStream> ReadToMemoryStreamAsync( string filePath, CancellationToken cancellationToken = default ) {
        try {
            if ( FileExists( filePath ) == false )
                return null;
            var memoryStream = new MemoryStream();
            await using var stream = new FileStream( filePath, FileMode.Open );
            await stream.CopyToAsync( memoryStream, cancellationToken ).ConfigureAwait( false );
            return memoryStream;
        }
        catch {
            return null;
        }
    }

    #endregion

    #region Write

    /// <summary>
    /// 将字符串写入文件
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="content">内容</param>
    public static void Write( string filePath, string content ) {
        if ( content.IsEmpty() )
            return;
        Write( filePath, Convert.ToBytes( content ) );
    }

    /// <summary>
    /// 将流写入文件
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="content">内容</param>
    public static void Write( string filePath, Stream content ) {
        if ( content == null )
            return;
        using ( content ) {
            var bytes = ToBytes( content );
            Write( filePath, bytes );
        }
    }

    /// <summary>
    /// 将字节流写入文件
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="content">内容</param>
    public static void Write( string filePath, byte[] content ) {
        if ( string.IsNullOrWhiteSpace( filePath ) )
            return;
        if ( content == null )
            return;
        CreateDirectory( filePath );
        System.IO.File.WriteAllBytes( filePath, content );
    }

    #endregion

    #region WriteAsync

    /// <summary>
    /// 将字符串写入文件
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="content">内容</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task WriteAsync( string filePath, string content, CancellationToken cancellationToken = default ) {
        if ( content.IsEmpty() )
            return;
        await WriteAsync( filePath, Convert.ToBytes( content ), cancellationToken );
    }

    /// <summary>
    /// 将流写入文件
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="content">内容</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task WriteAsync( string filePath, Stream content, CancellationToken cancellationToken = default ) {
        if ( content == null )
            return;
        await using ( content ) {
            var bytes = await ToBytesAsync( content, cancellationToken );
            await WriteAsync( filePath, bytes, cancellationToken );
        }
    }

    /// <summary>
    /// 将字节流写入文件
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    /// <param name="content">内容</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task WriteAsync( string filePath, byte[] content, CancellationToken cancellationToken = default ) {
        if ( string.IsNullOrWhiteSpace( filePath ) )
            return;
        if ( content == null )
            return;
        CreateDirectory( filePath );
        await System.IO.File.WriteAllBytesAsync( filePath, content, cancellationToken );
    }

    #endregion

    #region Delete

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="filePaths">文件绝对路径集合</param>
    public static void Delete( IEnumerable<string> filePaths ) {
        foreach ( var filePath in filePaths )
            Delete( filePath );
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="filePath">文件绝对路径</param>
    public static void Delete( string filePath ) {
        if ( string.IsNullOrWhiteSpace( filePath ) )
            return;
        if ( System.IO.File.Exists( filePath ) )
            System.IO.File.Delete( filePath );
    }

    #endregion

    #region GetAllFiles

    /// <summary>
    /// 获取全部文件,包括所有子目录
    /// </summary>
    /// <param name="path">目录路径</param>
    /// <param name="searchPattern">搜索模式</param>
    public static List<FileInfo> GetAllFiles( string path, string searchPattern ) {
        return Directory.GetFiles( path, searchPattern, SearchOption.AllDirectories )
            .Select( filePath => new FileInfo( filePath ) ).ToList();
    }

    #endregion

    #region Copy

    /// <summary>
    /// 复制文件
    /// </summary>
    /// <param name="sourceFilePath">源文件绝对路径</param>
    /// <param name="destinationFilePath">目标文件绝对路径</param>
    /// <param name="overwrite">目标文件存在时是否覆盖,默认值: false</param>
    public static void Copy( string sourceFilePath, string destinationFilePath, bool overwrite = false ) {
        if ( sourceFilePath.IsEmpty() || destinationFilePath.IsEmpty() )
            return;
        if ( FileExists( sourceFilePath ) == false )
            return;
        CreateDirectory( destinationFilePath );
        System.IO.File.Copy( sourceFilePath, destinationFilePath, overwrite );
    }

    #endregion

    #region Move

    /// <summary>
    /// 移动文件
    /// </summary>
    /// <param name="sourceFilePath">源文件绝对路径</param>
    /// <param name="destinationFilePath">目标文件绝对路径</param>
    /// <param name="overwrite">目标文件存在时是否覆盖,默认值: false</param>
    public static void Move( string sourceFilePath, string destinationFilePath, bool overwrite = false ) {
        if ( sourceFilePath.IsEmpty() || destinationFilePath.IsEmpty() )
            return;
        if ( FileExists( sourceFilePath ) == false )
            return;
        CreateDirectory( destinationFilePath );
        System.IO.File.Move( sourceFilePath, destinationFilePath, overwrite );
    }

    #endregion
}