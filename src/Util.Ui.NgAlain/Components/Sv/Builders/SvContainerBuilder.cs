using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Enums;

namespace Util.Ui.NgAlain.Components.Sv.Builders;

/// <summary>
/// 查看容器标签生成器
/// </summary>
public class SvContainerBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 初始化查看容器标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SvContainerBuilder( Config config ) : base( config, "sv-container" ) {
        _config = config;
    }

    /// <summary>
    /// 配置列数
    /// </summary>
    public SvContainerBuilder Column() {
        AttributeIfNotEmpty( "[col]", _config.GetValue( UiConst.Column ) );
        return this;
    }

    /// <summary>
    /// 配置尺寸
    /// </summary>
    public SvContainerBuilder Size() {
        AttributeIfNotEmpty( "size", _config.GetValue<SvSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[size]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置布局
    /// </summary>
    public SvContainerBuilder Layout() {
        AttributeIfNotEmpty( "layout", _config.GetValue<SvLayout?>( UiConst.Layout )?.Description() );
        AttributeIfNotEmpty( "[layout]", _config.GetValue( AngularConst.BindLayout ) );
        return this;
    }

    /// <summary>
    /// 配置间距
    /// </summary>
    public SvContainerBuilder Gutter() {
        AttributeIfNotEmpty( "[gutter]", _config.GetValue( UiConst.Gutter ) );
        return this;
    }

    /// <summary>
    /// 配置标签文本宽度
    /// </summary>
    public SvContainerBuilder LabelWidth() {
        AttributeIfNotEmpty( "[labelWidth]", _config.GetValue( UiConst.LabelWidth ) );
        return this;
    }

    /// <summary>
    /// 配置显示默认文本
    /// </summary>
    public SvContainerBuilder Default() {
        AttributeIfNotEmpty( "[default]", _config.GetValue( UiConst.Default ) );
        return this;
    }

    /// <summary>
    /// 配置标题
    /// </summary>
    public SvContainerBuilder Title() {
        AttributeIfNotEmpty( "title", _config.GetValue( UiConst.Title ) );
        AttributeIfNotEmpty( "[title]", _config.GetValue( AngularConst.BindTitle ) );
        return this;
    }

    /// <summary>
    /// 配置冒号
    /// </summary>
    public SvContainerBuilder NoColon() {
        AttributeIfNotEmpty( "[noColon]", _config.GetValue( UiConst.NoColon ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示边框
    /// </summary>
    public SvContainerBuilder Bordered() {
        AttributeIfNotEmpty( "[bordered]", _config.GetValue( UiConst.Bordered ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Column().Size().Layout().Gutter().LabelWidth()
            .Default().Title().NoColon().Bordered();
    }
}