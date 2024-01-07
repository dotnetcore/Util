namespace Util.FileStorage; 

/// <summary>
/// 下载远程文件并保存方法参数
/// </summary>
public class SaveFileByUrlArgs : FileStorageArgs {
    /// <summary>
    /// 初始化下载远程文件并保存方法参数
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="url">远程文件地址</param>
    public SaveFileByUrlArgs( string fileName, string url ) : base( fileName ) {
        Url = url;
    }

    /// <summary>
    /// 远程文件地址
    /// </summary>
    public string Url { get; }
}