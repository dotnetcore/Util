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
    /// <param name="paths">视图路径列表</param>
    public void Init( List<string> paths ) {
        if ( paths == null )
            return;
        foreach ( var path in paths )
            AddView( path );
    }

    /// <summary>
    /// 添加视图
    /// </summary>
    /// <param name="path">视图路径</param>
    public RazorView AddView( string path ) {
        if ( path.IsEmpty() )
            return null;
        var content = GetContent( path );
        if ( content.IsEmpty() )
            return null;
        RazorView view = FindOrCreateView( path, content );
        var partViewPaths = _partViewPathResolver.Resolve( path, content ) ?? [];
        foreach ( var partViewPath in partViewPaths ) {
            var partView = AddView( partViewPath );
            if ( partView != null )
                view.AddPartView( (PartView)partView );
        }
        AddView( view );
        return view;
    }

    /// <summary>
    /// 获取Razor文件内容
    /// </summary>
    protected string GetContent( string relativePath ) {
        return _contentResolver.Resolve( relativePath );
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