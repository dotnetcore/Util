namespace Util.Ui.Razor.Internal;

/// <summary>
/// Razor视图容器
/// </summary>
public class RazorViewContainer {
    /// <summary>
    /// Razor视图集合
    /// </summary>
    private readonly Dictionary<string, RazorView> _views;
    /// <summary>
    /// 分部视图路径解析器
    /// </summary>
    private readonly IPartViewPathResolver _partViewPathResolver;
    /// <summary>
    /// 视图内容解析器
    /// </summary>
    private readonly IViewContentResolver _contentResolver;

    /// <summary>
    /// 初始化Razor视图容器
    /// </summary>
    /// <param name="partViewPathResolver">分部视图路径解析器</param>
    /// <param name="contentResolver">视图内容解析器</param>
    public RazorViewContainer( IPartViewPathResolver partViewPathResolver, IViewContentResolver contentResolver = null ) {
        _partViewPathResolver = partViewPathResolver ?? throw new ArgumentNullException( nameof( partViewPathResolver ) );
        _contentResolver = contentResolver ?? new ViewContentResolver();
        _views = [];
    }

    /// <summary>
    /// 获取全部视图
    /// </summary>
    public List<RazorView> GetAllViews() {
        return _views.Values.ToList();
    }

    /// <summary>
    /// 获取全部主视图
    /// </summary>
    public List<RazorView> GetMainViews() {
        return _views.Values.Where( view => view is MainView ).ToList();
    }

    /// <summary>
    /// 获取全部主视图路径
    /// </summary>
    public List<string> GetMainViewPaths() {
        return GetMainViews().Select( t => t.Path ).ToList();
    }

    /// <summary>
    /// 获取随机视图路径
    /// </summary>
    public List<string> GetRandomPaths() {
        return Util.Helpers.Random.GetValues( _views.Values.Where( view => view is MainView ).Select( t => t.Path ), 3 );
    }

    /// <summary>
    /// 查找视图
    /// </summary>
    /// <param name="path">视图路径</param>
    public RazorView FindView( string path ) {
        if ( path.IsEmpty() )
            return null;
        return _views.TryGetValue( path.SafeString().ToLower(), out var view ) ? view : null;
    }

    /// <summary>
    /// 添加视图到容器
    /// </summary>
    /// <param name="view">视图</param>
    public void AddView( RazorView view ) {
        if ( view == null )
            return;
        _views.TryAdd( view.Path.SafeString().ToLower(), view );
    }

    /// <summary>
    /// 初始化视图容器
    /// </summary>
    /// <param name="viewContents">视图内容集合</param>
    public void Init( IDictionary<string, string> viewContents ) {
        if ( viewContents == null )
            return;
        foreach ( var viewContent in viewContents )
            CreateView( viewContent.Key, viewContent.Value );
    }

    /// <summary>
    /// 创建视图
    /// </summary>
    /// <param name="path">视图路径</param>
    /// <param name="content">视图文件内容</param>
    public RazorView CreateView( string path, string content ) {
        if ( path.IsEmpty() )
            return null;
        if ( content.IsEmpty() )
            return null;
        RazorView result = FindOrCreateView( path, content );
        var partViewPaths = _partViewPathResolver.Resolve( path, content ) ?? [];
        foreach ( var partViewPath in partViewPaths ) {
            var partViewContent = GetContent( partViewPath );
            var partView = CreateView( partViewPath, partViewContent );
            if ( partView != null )
                result.AddPartView( (PartView)partView );
        }
        AddView( result );
        return result;
    }

    /// <summary>
    /// 查找或创建视图
    /// </summary>
    protected RazorView FindOrCreateView( string path, string content ) {
        var result = FindView( path );
        if ( result != null )
            return result;
        return IsPartView( content ) ? new PartView( path ) : new MainView( path );
    }

    /// <summary>
    /// 是否分部视图
    /// </summary>
    /// <param name="content">视图内容</param>
    protected bool IsPartView( string content ) {
        return content.SafeString().StartsWith( "@page" ) == false;
    }

    /// <summary>
    /// 获取Razor文件内容
    /// </summary>
    protected string GetContent( string relativePath ) {
        return _contentResolver.Resolve( relativePath );
    }

    /// <summary>
    /// 获取关联的视图路径列表,如果是主视图,获取它本身的路径,如果是分部视图,获取引用它的主视图路径集合
    /// </summary>
    /// <param name="path">视图路径</param>
    public List<string> GetViewPaths( string path ) {
        if ( path.IsEmpty() )
            return new List<string>();
        var view = FindView( path );
        if ( view == null )
            return new List<string>();
        return view.GetMainViewPaths();
    }
}