using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Util.Ui.Pages {
    /// <summary>
    /// 视图页面路由约定，将页面路由添加view前缀
    /// </summary>
    public class ViewPageRouteConvention : IPageRouteModelConvention {
        /// <summary>
        /// 修改路由
        /// </summary>
        public void Apply( PageRouteModel model ) {
            foreach( var selector in model.Selectors.ToList() ) {
                var template = selector.AttributeRouteModel.Template;
                if( string.IsNullOrWhiteSpace( template ) )
                    continue;
                if( template.ToLower() == "index" )
                    continue;
                selector.AttributeRouteModel.Template = $"view/{selector.AttributeRouteModel.Template}";
            }
        }
    }
}
