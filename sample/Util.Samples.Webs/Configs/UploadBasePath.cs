using Util.Files.Paths;

namespace Util.Samples.Webs.Configs {
    /// <summary>
    /// 上传基路径
    /// </summary>
    public class UploadBasePath : IBasePath {
        /// <summary>
        /// 获取基路径
        /// </summary>
        public string GetPath() {
            return "upload";
        }
    }
}