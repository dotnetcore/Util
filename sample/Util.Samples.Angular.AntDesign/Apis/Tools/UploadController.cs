using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Files;
using Util.Helpers;
using Util.Samples.Models.Tools;
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
            await Task.Delay( 3000 );
            var code = Web.GetParam( "code" );
            var name = Web.GetParam( "name" );
            var file = Web.GetFile();
            var path = await FileStore.SaveAsync();
            var result = new UploadFileInfo {
                Id = Id.Guid(),
                Name = file.FileName,
                Size = file.Length,
                Type = file.ContentType,
                Url = path
            };
            return Success( result );
        }
    }
}