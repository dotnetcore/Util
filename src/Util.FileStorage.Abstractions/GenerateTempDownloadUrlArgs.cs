namespace Util.FileStorage; 

/// <summary>
/// 生成临时下载Url方法参数
/// </summary>
public class GenerateTempDownloadUrlArgs : FileStorageArgs {
    /// <summary>
    /// 初始化生成临时下载Url方法参数
    /// </summary>
    /// <param name="fileName">文件名</param>
    public GenerateTempDownloadUrlArgs( string fileName ) : base( fileName ) {
    }

    /// <summary>
    /// 下载地址过期时间,单位:秒
    /// </summary>
    public int? Expiration { get; set; }

    /// <summary>
    /// 响应内容类型
    /// </summary>
    public string ResponseContentType { get; set; }
}