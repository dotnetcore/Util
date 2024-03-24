namespace Util.Ui.Razor.Internal;

/// <summary>
/// Razor视图
/// </summary>
public class RazorView {
    /// <summary>
    /// 初始化主视图
    /// </summary>
    /// <param name="path">视图路径</param>
    protected RazorView( string path ) {
        if ( path.IsEmpty() )
            throw new ArgumentNullException( nameof( path ) );
        Path = path;
        PartViews = [];
    }

    /// <summary>
    /// 视图路径
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// 包含的分部视图集合
    /// </summary>
    public List<PartView> PartViews { get; set; }

    /// <summary>
    /// 添加分部视图
    /// </summary>
    /// <param name="partView">分部视图</param>
    public virtual void AddPartView( PartView partView ) {
        if ( partView == null )
            return;
        if ( PartViews.Any( t => t.Path == partView.Path ) )
            return;
        partView.AddMainView( this );
        PartViews.Add( partView );
    }

    /// <summary>
    /// 获取主视图路径集合
    /// </summary>
    public virtual List<string> GetMainViewPaths() {
        return [Path];
    }
}