namespace Util.FileStorage.Aliyun;

/// <summary>
/// 创建存储桶参数
/// </summary>
public class CreateBucketArgs : FileStorageArgs {
    /// <summary>
    /// 初始化创建存储桶参数
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    public CreateBucketArgs( string bucketName ) : base( null ) {
        BucketName = bucketName;
    }

    /// <summary>
    /// 访问权限
    /// </summary>
    public CannedAccessControlList Acl { get; set; } = CannedAccessControlList.Private;

    /// <summary>
    /// 存储类型
    /// </summary>
    public StorageClass StorageClass { get; set; } = StorageClass.Standard;

    /// <summary>
    /// 数据冗余类型
    /// </summary>
    public DataRedundancyType DataRedundancyType { get; set; } = DataRedundancyType.LRS;
}