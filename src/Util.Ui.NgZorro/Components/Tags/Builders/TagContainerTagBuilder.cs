using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tags.Builders;

/// <summary>
/// 标签容器标签生成器
/// </summary>
public class TagContainerTagBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 标识
    /// </summary>
    private string _id;

    /// <summary>
    /// 初始化标签标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public TagContainerTagBuilder( Config config ) : base( config, "ng-container" ) {
        _config = config;
    }

    /// <summary>
    /// 扩展标识
    /// </summary>
    public string ExtendId => $"x_{GetId()}";

    /// <summary>
    /// 获取标识
    /// </summary>
    private string GetId() {
        if( _id.IsEmpty() == false )
            return _id;
        _id = _config.GetValue( UiConst.Id );
        if( _id.IsEmpty() )
            _id = Util.Helpers.Id.Create();
        return _id;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public TagContainerTagBuilder Events() {
        AttributeIfNotEmpty( "(onLoad)", _config.GetValue( UiConst.OnLoad ) );
        AttributeIfNotEmpty( "(selectedTextChange)", _config.GetValue( UiConst.OnSelectedTextChange ) );
        AttributeIfNotEmpty( "(selectedValueChange)", _config.GetValue( UiConst.OnSelectedValueChange ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Events();
        EnableExtend();
        AutoLoad().QueryParam().Url().Data()
            .AllSelected().SelectedText().SelectedValue();
    }

    /// <summary>
    /// 启用扩展
    /// </summary>
    public TagContainerTagBuilder EnableExtend() {
        Attribute( $"#{ExtendId}", "xTagExtend" );
        Attribute( "x-tag-extend" );
        return this;
    }

    /// <summary>
    /// 配置自动加载
    /// </summary>
    private TagContainerTagBuilder AutoLoad() {
        AttributeIfNotEmpty( "[autoLoad]", _config.GetBoolValue( UiConst.AutoLoad ) );
        return this;
    }

    /// <summary>
    /// 配置查询参数
    /// </summary>
    private TagContainerTagBuilder QueryParam() {
        AttributeIfNotEmpty( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
        return this;
    }

    /// <summary>
    /// 配置Api地址
    /// </summary>
    private TagContainerTagBuilder Url() {
        AttributeIfNotEmpty( "url", _config.GetValue( UiConst.Url ) );
        AttributeIfNotEmpty( "[url]", _config.GetValue( AngularConst.BindUrl ) );
        return this;
    }

    /// <summary>
    /// 配置数据源
    /// </summary>
    private TagContainerTagBuilder Data() {
        AttributeIfNotEmpty( "[data]", _config.GetValue( UiConst.Data ) );
        return this;
    }

    /// <summary>
    /// 配置全部选中
    /// </summary>
    private TagContainerTagBuilder AllSelected() {
        AttributeIfNotEmpty( "[(allSelected)]", _config.GetValue( UiConst.AllSelected ) );
        return this;
    }

    /// <summary>
    /// 配置选中文本
    /// </summary>
    private TagContainerTagBuilder SelectedText() {
        AttributeIfNotEmpty( "[(selectedText)]", _config.GetValue( UiConst.SelectedText ) );
        return this;
    }

    /// <summary>
    /// 配置选中值
    /// </summary>
    private TagContainerTagBuilder SelectedValue() {
        AttributeIfNotEmpty( "[(selectedValue)]", _config.GetValue( UiConst.SelectedValue ) );
        return this;
    }

    /// <summary>
    /// 配置内容
    /// </summary>
    /// <param name="config">配置</param>
    protected override void ConfigContent( Config config ) {
    }
}