namespace Util.FileStorage.Minio {
    /// <summary>
    /// Minio配置
    /// </summary>
    public class MinioConfig {
        /// <summary>
        /// Minio存储服务地址
        /// </summary>
        public string Endpoint { get; set; }
        /// <summary>
        /// 访问密钥,用来标识帐户的Id
        /// </summary>
        public string AccessKey { get; set; }
        /// <summary>
        /// 密钥,即帐户密码
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 是否使用Https,默认值: false
        /// </summary>
        public bool UseSSL { get; set; }
        /// <summary>
        /// 默认存储桶名称
        /// </summary>
        public string DefaultBucketName { get; set; }
        /// <summary>
        /// HttpClient名称
        /// </summary>
        public string HttpClientName { get; set; }
        /// <summary>
        /// 上传地址过期时间,单位:秒,默认值: 3600
        /// </summary>
        public int UploadUrlExpiration { get; set; } = 3600;
        /// <summary>
        /// 下载地址过期时间,单位:秒,默认值: 3600
        /// </summary>
        public int DownloadUrlExpiration { get; set; } = 3600;
    }
}
