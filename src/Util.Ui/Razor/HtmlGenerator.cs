using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Util.Helpers;

namespace Util.Ui.Razor {
    /// <summary>
    /// Html生成器
    /// </summary>
    public static class HtmlGenerator {
        /// <summary>
        /// 生成Html
        /// </summary>
        public static async Task GenerateAsync() {
            var descriptors = GetPageActionDescriptors();
            var requestUrl = $"{Web.Request.Scheme}://{Web.Request.Host}";
            foreach( var descriptor in descriptors ) {
                var path = descriptor.ViewEnginePath;
                await Web.Client.Get( $"{requestUrl}/view{path}" ).GetResultAsync();
            }
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
