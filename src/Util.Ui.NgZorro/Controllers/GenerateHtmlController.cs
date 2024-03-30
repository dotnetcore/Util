using Util.Ui.Razor;

namespace Util.Ui.NgZorro.Controllers;

/// <summary>
/// Razor生成Html控制器
/// </summary>
[ApiController]
[Route( "api/html" )]
public class GenerateHtmlController : ControllerBase {
    /// <summary>
    /// 生成所有Razor页面的Html
    /// </summary>
    [HttpGet]
    public async Task<string> GenerateAsync() {
        var message = new StringBuilder();
        var result = await HtmlGenerator.GenerateAsync();
        message.AppendLine( "======================= 欢迎使用 Util 应用框架 - 开始生成全部Razor页面html =======================" );
        message.AppendLine();
        message.AppendLine();
        foreach ( var path in result )
            message.AppendLine( path );
        message.AppendLine();
        message.AppendLine();
        message.Append( "======================================== html文件生成完成 ========================================" );
        return message.ToString();
    }
}