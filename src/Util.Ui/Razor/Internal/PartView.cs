namespace Util.Ui.Razor.Internal;

/// <summary>
/// 分部视图
/// </summary>
public class PartView : RazorView {
    /// <summary>
    /// 初始化分部视图
    /// </summary>
    public PartView( string path ) : base( path ) {
        MainViews = [];
    }

    /// <summary>
    /// 引用了当前分部视图的视图集合
    /// </summary>
    public List<RazorView> MainViews { get; set; }

    /// <summary>
    /// 添加主视图
    /// </summary>
    /// <param name="mainView">主视图</param>
    public void AddMainView( RazorView mainView ) {
        if ( mainView == null )
            return;
        if ( MainViews.Any( t => t.Path == mainView.Path ) )
            return;
        MainViews.Add( mainView );
    }

    /// <inheritdoc />
    public override List<string> GetMainViewPaths() {
        var result = new List<string>();
        foreach (var view in MainViews )
            result.AddRange( view.GetMainViewPaths() );
        return result;
    }
}