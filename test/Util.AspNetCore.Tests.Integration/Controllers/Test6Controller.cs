using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Util.AspNetCore.Tests.Controllers;

/// <summary>
/// 测试Api控制器6 - 用于测试上传
/// </summary>
[ApiController]
[Route( "api/[controller]" )]
public class Test6Controller : ControllerBase {
    /// <summary>
    /// 上传
    /// </summary>
    [HttpPost]
    public async Task<string> Upload() {
        var file = Util.Helpers.Web.GetFile();
        await using var stream = file.OpenReadStream();
        await Util.Helpers.File.WriteAsync( file.FileName, stream );
        var param = Util.Helpers.Web.GetParam( "util" );
        if( param.IsEmpty() )
            return $"ok:{file.Name}:{file.FileName}";
        return $"ok:{file.Name}:{file.FileName}:{param}";
    }

    /// <summary>
    /// 多上传
    /// </summary>
    [HttpPost("multi")]
    public async Task<string> MultiUpload() {
        var files = Util.Helpers.Web.GetFiles();
        var result = new StringBuilder();
        result.Append( "ok" );
        foreach ( var file in files ) {
            await using var stream = file.OpenReadStream();
            await Util.Helpers.File.WriteAsync( file.FileName, stream );
            result.Append( $":{file.Name}:{file.FileName}" );
        }
        return result.ToString();
    }
}