using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Typographies.Builders;

/// <summary>
/// article标签生成器
/// </summary>
public class ArticleBuilder : AngularTagBuilder {
    /// <summary>
    /// 初始化article标签生成器
    /// <param name="config">配置</param>
    /// </summary>
    public ArticleBuilder( Config config ) : base( config, "article" ) {
    }
}