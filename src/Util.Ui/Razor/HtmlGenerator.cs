using Util.Helpers;

namespace Util.Ui.Razor;

/// <summary>
/// Html生成器
/// </summary>
public static class HtmlGenerator {
    /// <summary>
    /// 生成Html
    /// </summary>
    public static async Task<List<string>> GenerateAsync( CancellationToken cancellationToken = default ) {
        EnableGenerateHtml();
        var result = new List<string>();
        var descriptors = GetPageActionDescriptors();
        foreach ( var descriptor in descriptors ) {
            var path = $"{GetHost()}/view{descriptor.ViewEnginePath}";
            result.Add( path );
            await Web.Client.Get( path ).GetResultAsync( cancellationToken );
        }
        return result.Distinct().ToList();
    }

    /// <summary>
    /// 启用Html自动生成
    /// </summary>
    private static void EnableGenerateHtml( bool isGenerateHtml = true ) {
        var options = Ioc.Create<IOptions<RazorOptions>>();
        options.Value.IsGenerateHtml = isGenerateHtml;
    }

    /// <summary>
    /// 获取页面操作描述符列表
    /// </summary>
    private static List<PageActionDescriptor> GetPageActionDescriptors() {
        var provider = Ioc.Create<IActionDescriptorCollectionProvider>();
        return provider.ActionDescriptors.Items.OfType<PageActionDescriptor>().ToList();
    }

    /// <summary>
    /// 获取请求主机
    /// </summary>
    private static string GetHost() {
        return $"{Web.Request.Scheme}://{Web.Request.Host}";
    }
}