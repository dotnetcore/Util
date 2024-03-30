using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Routing;

namespace Util.Ui.Razor.Internal;

/// <summary>
/// 分部视图路径查找器
/// </summary>
public class PartViewPathFinder : IPartViewPathFinder {
    /// <summary>
    /// 视图引擎
    /// </summary>
    private readonly ICompositeViewEngine _viewEngine;
    /// <summary>
    /// Razor配置
    /// </summary>
    private readonly RazorOptions _options;

    /// <summary>
    /// 初始化分部视图路径查找器
    /// </summary>
    /// <param name="viewEngine">视图引擎</param>
    /// <param name="options">Razor配置</param>
    public PartViewPathFinder( ICompositeViewEngine viewEngine, IOptions<RazorOptions> options ) {
        _viewEngine = viewEngine ?? throw new ArgumentNullException( nameof( viewEngine ) );
        _options = options.Value;
    }

    /// <inheritdoc />
    public string Find( string viewPath, string partViewName ) {
        if ( viewPath.IsEmpty() )
            return null;
        if ( partViewName.IsEmpty() )
            return null;
        var result = _viewEngine.GetView( GetRouteValue( viewPath ), partViewName, false );
        if ( result.Success )
            return result.View.Path;
        var view = _viewEngine.FindView( CreateViewContext( viewPath ), GetPartViewName( partViewName ), isMainPage: false );
        return view.Success ? view.View.Path : null;
    }

    /// <summary>
    /// 获取路由值
    /// </summary>
    private string GetRouteValue( string viewPath ) {
        return viewPath.RemoveStart( _options.RazorRootDirectory ).RemoveEnd( ".cshtml" );
    }

    /// <summary>
    /// 创建视图上下文
    /// </summary>
    private ViewContext CreateViewContext( string viewPath ) {
        return new ViewContext {
            ExecutingFilePath = viewPath,
            RouteData = new RouteData {
                Values = { { "page", GetRouteValue( viewPath ) } }
            },
            ActionDescriptor = new PageActionDescriptor {
                RouteValues = { { "page", GetRouteValue( viewPath ) } }
            }
        };
    }

    /// <summary>
    /// 获取分部视图路径
    /// </summary>
    private string GetPartViewName( string partViewName ) {
        return partViewName.RemoveEnd( ".cshtml" );
    }
}