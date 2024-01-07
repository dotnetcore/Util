namespace Util.FileStorage; 

/// <summary>
/// 生成上传Url方法参数
/// </summary>
public class GenerateUploadUrlArgs : FileStorageArgs {
    /// <summary>
    /// 请求头
    /// </summary>
    private readonly Dictionary<string, string> _headers;

    /// <summary>
    /// 初始化生成上传Url方法参数
    /// </summary>
    /// <param name="fileName">文件名</param>
    public GenerateUploadUrlArgs( string fileName ) : base( fileName ) {
        _headers = new Dictionary<string, string>();
    }

    /// <summary>
    /// 设置内容类型 application/octet-stream
    /// </summary>
    public void SetOctetStream() {
        SetContentType( "application/octet-stream" );
    }

    /// <summary>
    /// 设置内容类型
    /// </summary>
    public void SetContentType( string contentType ) {
        AddHeader( "content-type", contentType );
    }

    /// <summary>
    /// 添加请求头
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    public void AddHeader( string key,string value ) {
        if ( _headers.ContainsKey( key ) )
            _headers.Remove( key );
        _headers.Add( key, value );
    }

    /// <summary>
    /// 获取请求头
    /// </summary>
    public IDictionary<string, string> GetHeaders() {
        return _headers;
    }

    /// <summary>
    /// 文件大小限制,单位:字节
    /// </summary>
    public long SizeLimit { get; set; }
}