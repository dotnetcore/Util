using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Util.Helpers;

namespace Util.Ui.Pages {
    /// <summary>
    /// Page静态Html生成器
    /// </summary>
    public class PageHtmlGenerator : IHtmlGenerator {
        /// <summary>
        /// 操作描述集合提供程序
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        /// <summary>
        /// 页面加载器
        /// </summary>
        private readonly IPageLoader _pageLoader;

        /// <summary>
        /// 初始化一个<see cref="PageHtmlGenerator"/>类型的实例
        /// </summary>
        /// <param name="actionDescriptorCollectionProvider">操作描述集合提供程序</param>
        /// <param name="pageLoader">页面加载器</param>
        public PageHtmlGenerator( IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
            IPageLoader pageLoader ) {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _pageLoader = pageLoader;
        }

        /// <summary>
        /// 构建并生成Html
        /// </summary>
        public async Task BuildAsync() {
            var pageActionDescriptors = GetPageActionDescriptors();
            var requestUrl = $"{Web.Request.Scheme}://{Web.Request.Host}";
            foreach( var actionDescriptor in pageActionDescriptors ) {
                if( actionDescriptor.RelativePath.ToLower() == "/Pages/Index.cshtml".ToLower() ) {
                    continue;
                }
                var compiledPage = _pageLoader.Load( actionDescriptor );
                var path = actionDescriptor.ViewEnginePath;// Url访问路径：/Components/DataDisplay/Table
                var htmlPath = GetHtmlPathAttribute( compiledPage );
                if( htmlPath != null ) {
                    if( htmlPath.Ignore ) {
                        continue;
                    }
                }
                await Web.Client<string>().Get( $"{requestUrl}/view{path}" ).ResultAsync();
            }
        }

        /// <summary>
        /// 获取页面操作描述
        /// </summary>
        private IEnumerable<PageActionDescriptor> GetPageActionDescriptors() {
            return this._actionDescriptorCollectionProvider.ActionDescriptors.Items.OfType<PageActionDescriptor>();
        }

        /// <summary>
        /// 获取Html生成路径特性
        /// </summary>
        /// <param name="compiledPage">编译后的页面</param>
        private HtmlPathAttribute GetHtmlPathAttribute( CompiledPageActionDescriptor compiledPage ) =>
            compiledPage.PageTypeInfo.GetCustomAttribute<HtmlPathAttribute>() ??
            compiledPage.DeclaredModelTypeInfo.GetCustomAttribute<HtmlPathAttribute>();

    }
}
