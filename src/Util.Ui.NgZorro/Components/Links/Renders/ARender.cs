using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Links.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Links.Renders;

/// <summary>
/// 链接渲染器
/// </summary>
public class ARender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化链接渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public ARender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        if ( IsHide() )
            return new EmptyTagBuilder();
        var builder = new ABuilder( _config );
        builder.Config();
        return builder;
    }

    /// <summary>
    /// 是否隐藏标签
    /// </summary>
    private bool IsHide() {
        var isSearch = _config.GetValue<bool?>( UiConst.IsSearch );
        if ( isSearch != true )
            return false;
        var formShareConfig = GetFormShareConfig();
        return formShareConfig.GetConditionCount() <= formShareConfig.SearchFormShowNumber;
    }

    /// <summary>
    /// 获取表单共享配置
    /// </summary>
    public FormShareConfig GetFormShareConfig() {
        return _config.GetValueFromItems<FormShareConfig>() ?? new FormShareConfig();
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ARender( _config.Copy() );
    }
}