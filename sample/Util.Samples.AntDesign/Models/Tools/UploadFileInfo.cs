namespace Util.Samples.Models.Tools {
    /// <summary>
    /// 上传文件信息
    /// </summary>
    public class UploadFileInfo {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Url { get; set; }
    }
}
