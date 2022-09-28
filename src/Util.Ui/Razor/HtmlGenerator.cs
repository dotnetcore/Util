using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Util.Helpers;

namespace Util.Ui.Razor {
    /// <summary>
    /// Html生成器
    /// </summary>
    public static class HtmlGenerator {
        /// <summary>
        /// 生成Html
        /// </summary>
        public static async Task<List<string>> GenerateAsync() {
            var result = new List<string>();
            EnableGenerateHtml();
            var descriptors = GetPageActionDescriptors();
            var requestUrl = $"{Web.Request.Scheme}://{Web.Request.Host}";
            foreach( var descriptor in descriptors ) {
                var path = $"{requestUrl}/view{descriptor.ViewEnginePath}";
                result.Add( path );
                await Web.Client.Get( path ).GetResultAsync();
            }
            return result.Distinct().ToList();
        }

        /// <summary>
        /// 启用Html自动生成
        /// </summary>
        private static void EnableGenerateHtml() {
            var options = Ioc.Create<IOptions<RazorOptions>>();
            options.Value.IsGenerateHtml = true;
        }

        /// <summary>
        /// 获取页面操作描述符列表
        /// </summary>
        private static List<PageActionDescriptor> GetPageActionDescriptors() {
            var provider = Ioc.Create<IActionDescriptorCollectionProvider>();
            return provider.ActionDescriptors.Items.OfType<PageActionDescriptor>().ToList();
        }
    }
}
