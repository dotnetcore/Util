using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Files;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Tools {
    /// <summary>
    /// 上传控制器
    /// </summary>
    public class UploadController : WebApiControllerBase {
        /// <summary>
        /// 初始化上传控制器
        /// </summary>
        /// <param name="fileStore">文件存储器</param>
        public UploadController( IFileStore fileStore ) {
            FileStore = fileStore;
        }

        /// <summary>
        /// 文件存储器
        /// </summary>
        public IFileStore FileStore { get; set; }

        /// <summary>
        /// 上传到本地目录
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Upload() {
            var path = await FileStore.SaveAsync();
            return Success( path );
        }
    }
}