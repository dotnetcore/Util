using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;

namespace Util.Ui.NgZorro.Components.Modals.Builders;

/// <summary>
/// 对话框内容容器标签生成器
/// </summary>
public class DialogContainerBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化对话框内容容器标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public DialogContainerBuilder( Config config ) : base( config, "x-dialog-container" ) {
        _config = config;
    }

    /// <summary>
    /// 配置最小宽度
    /// </summary>
    public DialogContainerBuilder MinWidth() {
        AttributeIfNotEmpty( "minWidth", _config.GetValue( UiConst.MinWidth ) );
        AttributeIfNotEmpty( "[minWidth]", _config.GetValue( AngularConst.BindMinWidth ) );
        return this;
    }

    /// <summary>
    /// 配置最大宽度
    /// </summary>
    public DialogContainerBuilder MaxWidth() {
        AttributeIfNotEmpty( "maxWidth", _config.GetValue( UiConst.MaxWidth ) );
        AttributeIfNotEmpty( "[maxWidth]", _config.GetValue( AngularConst.BindMaxWidth ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        MinWidth().MaxWidth();
    }
}