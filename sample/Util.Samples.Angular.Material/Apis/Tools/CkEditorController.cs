using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Files;
using Util.Ui.CkEditor;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Tools {
    /// <summary>
    /// CKEditor控制器
    /// </summary>
    public class CkEditorController : WebApiControllerBase {
        /// <summary>
        /// 初始化CKEditor控制器
        /// </summary>
        /// <param name="fileStore">文件存储服务</param>
        public CkEditorController( IFileStore fileStore ) {
            FileStore = fileStore;
        }

        /// <summary>
        /// 文件存储服务
        /// </summary>
        public IFileStore FileStore { get; set; }

        /// <summary>
        /// 上传
        /// </summary>
        [Route("/api/upload")]
        [HttpPost]
        public async Task<IActionResult> Upload() {
            var path = await FileStore.SaveAsync();
            return new UploadResult( path, "上传成功" );
        }
    }
}
