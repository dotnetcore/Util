namespace Util.FileStorage;

/// <summary>
/// 客户端直传参数
/// </summary>
public class DirectUploadParam {
    /// <summary>
    /// 初始化直传参数
    /// </summary>
    /// <param name="url">直传Url</param>
    /// <param name="data">直传数据</param>
    public DirectUploadParam( string url,object data = null ) {
        Url = url;
        Data = data;
    }

    /// <summary>
    /// 直传Url
    /// </summary>
    public string Url { get; }
    /// <summary>
    /// 直传数据
    /// </summary>
    public object Data { get; }
}