using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Util.Ui.Razor {
    /// <summary>
    /// 页面默认路由添加view前缀
    /// </summary>
    public class PageRouteConvention : IPageRouteModelConvention {
        /// <summary>
        /// 修改默认路由
        /// </summary>
        public void Apply( PageRouteModel model ) {
            foreach( var selector in model.Selectors.ToList() ) {
                var template = selector.AttributeRouteModel?.Template;
                if( string.IsNullOrWhiteSpace( template ) )
                    continue;
                if( template == "Error" )
                    continue;
                selector.AttributeRouteModel.Template = $"view/{template}";
            }
        }
    }
}
