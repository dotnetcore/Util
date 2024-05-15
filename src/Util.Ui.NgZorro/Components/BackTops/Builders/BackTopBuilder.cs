using Util.Applications;
using Util.Helpers;
using Util.Ui.Angular.Builders;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Config = Util.Ui.Configs.Config;

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
    /// 模板标识
    /// </summary>
    private string _templateId;

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
        Template( _config.GetValue( UiConst.Template ) );
        return this;
    }

    /// <summary>
    /// 配置模板标识
    /// </summary>
    /// <param name="templateId">模板标识</param>
    public BackTopBuilder Template( string templateId ) {
        AttributeIfNotEmpty( "[nzTemplate]", templateId );
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

    /// <summary>
    /// 配置内容
    /// </summary>
    protected override void ConfigContent( Config config ) {
        if ( config.Content.IsEmpty() )
            return;
        Template( GetTemplateId() );
        var templateBuilder = new TemplateBuilder( _config );
        templateBuilder.Attribute( $"#{GetTemplateId()}" );
        templateBuilder.AppendContent( config.Content );
        AppendContent( templateBuilder );
    }

    /// <summary>
    /// 获取模板标识
    /// </summary>
    private string GetTemplateId() {
        if ( _templateId.IsEmpty() == false )
            return _templateId;
        _templateId = _config.GetValue( UiConst.Template );
        if ( _templateId.IsEmpty() == false )
            return _templateId;
        var id = _config.GetValue( UiConst.Id );
        if ( id.IsEmpty() )
            id = Id.Create();
        _templateId = $"tpl_{id}";
        return _templateId;
    }
}