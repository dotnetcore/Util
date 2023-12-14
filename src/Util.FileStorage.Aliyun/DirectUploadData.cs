namespace Util.FileStorage.Aliyun;

/// <summary>
/// 客户端直传数据
/// </summary>
public class DirectUploadData {
    /// <summary>
    /// 初始化客户端直传数据
    /// </summary>
    /// <param name="key">文件标识</param>
    /// <param name="policy">上传策略</param>
    /// <param name="ossAccessKeyId">AccessKeyId</param>
    /// <param name="signature">签名</param>
    /// <param name="successActionStatus">成功操作状态码,默认值: 200</param>
    public DirectUploadData( string key, string policy, string ossAccessKeyId,string signature,string successActionStatus = "200" ) {
        Key = key;
        Policy = policy;
        OssAccessKeyId = ossAccessKeyId;
        Signature = signature;
        SuccessActionStatus = successActionStatus;
    }

    /// <summary>
    /// 文件标识,使用文件完整路径,范例: a/b/c.jpg
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; }
    /// <summary>
    /// 上传策略
    /// </summary>
    [JsonPropertyName( "policy" )]
    public string Policy { get; }
    /// <summary>
    /// AccessKeyId
    /// </summary>
    [JsonPropertyName( "OSSAccessKeyId" )]
    public string OssAccessKeyId { get; }
    /// <summary>
    /// 签名
    /// </summary>
    [JsonPropertyName( "Signature" )]
    public string Signature { get; }
    /// <summary>
    /// 成功操作状态码
    /// </summary>
    [JsonPropertyName( "success_action_status" )]
    public string SuccessActionStatus { get; }
}