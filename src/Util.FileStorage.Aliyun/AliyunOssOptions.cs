namespace Util.FileStorage.Aliyun; 

/// <summary>
/// 阿里云对象存储配置
/// </summary>
public class AliyunOssOptions {
    /// <summary>
    /// 存储服务地址
    /// </summary>
    public string Endpoint { get; set; }
    /// <summary>
    /// 访问密钥的Id
    /// </summary>
    public string AccessKeyId { get; set; }
    /// <summary>
    /// 访问密钥的密码
    /// </summary>
    public string AccessKeySecret { get; set; }
    /// <summary>
    /// 默认存储桶名称
    /// </summary>
    public string DefaultBucketName { get; set; }
    /// <summary>
    /// 上传地址过期时间,单位:秒,默认值: 3600
    /// </summary>
    public int UploadUrlExpiration { get; set; } = 3600;
    /// <summary>
    /// 下载地址过期时间,单位:秒,默认值: 3600
    /// </summary>
    public int DownloadUrlExpiration { get; set; } = 3600;
}