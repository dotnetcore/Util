using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Buttons.Builders;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Buttons.Renders;

/// <summary>
/// 按钮渲染器
/// </summary>
public class ButtonRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化按钮渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public ButtonRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = CreateTagBuilder();
        builder.Attribute( "nz-button" );
        builder.Config();
        return builder;
    }

    /// <summary>
    /// 创建标签生成器
    /// </summary>
    private TagBuilder CreateTagBuilder() {
        if ( GetButtonType() != ButtonType.Link )
            return new ButtonBuilder( _config );
        if ( IsHide() )
            return new EmptyTagBuilder();
        return new ABuilder( _config );
    }

    /// <summary>
    /// 获取按钮类型
    /// </summary>
    private ButtonType? GetButtonType() {
        return _config.GetValue<ButtonType?>( UiConst.Type );
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
    private FormShareConfig GetFormShareConfig() {
        return _config.GetValueFromItems<FormShareConfig>() ?? new FormShareConfig();
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ButtonRender( _config.Copy() );
    }
}