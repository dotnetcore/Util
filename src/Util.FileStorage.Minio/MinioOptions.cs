namespace Util.FileStorage.Minio {
    /// <summary>
    /// Minio配置
    /// </summary>
    public class MinioOptions {
        /// <summary>
        /// Minio配置
        /// </summary>
        private readonly MinioConfig _config;

        /// <summary>
        /// 初始化Minio配置
        /// </summary>
        public MinioOptions() {
            _config = new MinioConfig();
        }

        /// <summary>
        /// 设置Minio存储服务地址
        /// </summary>
        /// <param name="endpoint">Minio存储服务地址</param>
        public MinioOptions Endpoint( string endpoint ) {
            _config.Endpoint = endpoint;
            return this;
        }

        /// <summary>
        /// 设置访问密钥,用来标识帐户的Id
        /// </summary>
        /// <param name="accessKey">访问密钥</param>
        public MinioOptions AccessKey( string accessKey ) {
            _config.AccessKey = accessKey;
            return this;
        }

        /// <summary>
        /// 设置密钥,即帐户密码
        /// </summary>
        /// <param name="secretKey">密钥</param>
        public MinioOptions SecretKey( string secretKey ) {
            _config.SecretKey = secretKey;
            return this;
        }

        /// <summary>
        /// 设置是否使用Https
        /// </summary>
        /// <param name="useSSL">是否使用Https</param>
        public MinioOptions UseSSL( bool useSSL = true ) {
            _config.UseSSL = useSSL;
            return this;
        }

        /// <summary>
        /// 设置默认存储桶名称
        /// </summary>
        /// <param name="bucketName">存储桶名称</param>
        public MinioOptions DefaultBucketName( string bucketName ) {
            _config.DefaultBucketName = bucketName;
            return this;
        }

        /// <summary>
        /// 设置HttpClient名称
        /// </summary>
        /// <param name="httpClientName">HttpClient名称</param>
        public MinioOptions HttpClient( string httpClientName ) {
            _config.HttpClientName = httpClientName;
            return this;
        }

        /// <summary>
        /// 设置上传地址过期时间,单位:秒
        /// </summary>
        /// <param name="expiration">上传地址过期时间,单位:秒</param>
        public MinioOptions UploadUrlExpiration( int expiration ) {
            _config.UploadUrlExpiration = expiration;
            return this;
        }

        /// <summary>
        /// 设置下载地址过期时间,单位:秒
        /// </summary>
        /// <param name="expiration">下载地址过期时间,单位:秒</param>
        public MinioOptions DownloadUrlExpiration( int expiration ) {
            _config.DownloadUrlExpiration = expiration;
            return this;
        }

        /// <summary>
        /// 转换为Minio配置
        /// </summary>
        internal MinioConfig ToConfig() {
            return _config;
        }
    }
}
