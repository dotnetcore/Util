using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.BackTops.Builders;

/// <summary>
/// 回到顶部标签生成器
/// </summary>
public class BackTopBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化回到顶部标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public BackTopBuilder( Config config ) : base( config, "nz-back-top" ) {
        _config = config;
    }

    /// <summary>
    /// 配置自定义内容
    /// </summary>
    public BackTopBuilder Template() {
        AttributeIfNotEmpty( "[nzTemplate]", _config.GetValue( UiConst.Template ) );
        return this;
    }

    /// <summary>
    /// 配置可见高度
    /// </summary>
    public BackTopBuilder VisibilityHeight() {
        AttributeIfNotEmpty( "[nzVisibilityHeight]", _config.GetValue( UiConst.VisibilityHeight ) );
        return this;
    }

    /// <summary>
    /// 配置监听目标
    /// </summary>
    public BackTopBuilder Target() {
        AttributeIfNotEmpty( "[nzTarget]", _config.GetValue( UiConst.Target ) );
        return this;
    }

    /// <summary>
    /// 配置持续时间
    /// </summary>
    public BackTopBuilder Duration() {
        AttributeIfNotEmpty( "[nzDuration]", _config.GetValue( UiConst.Duration ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public BackTopBuilder Events() {
        AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Template().VisibilityHeight().Target().Duration().Events();
    }
}