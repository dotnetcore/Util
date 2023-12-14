using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs.Builders;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Inputs.Renders; 

/// <summary>
/// 文本域渲染器
/// </summary>
public class TextareaRender : InputRenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化文本域渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public TextareaRender( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 获取输入框标签生成器
    /// </summary>
    protected override TagBuilder GetInputBuilder() {
        var builder = new TextareaBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <summary>
    /// 获取输入框组合的样式类
    /// </summary>
    protected override string GetInputGroupClass() {
        if( IsAllowClear() )
            return "ant-input-affix-wrapper-textarea-with-clear-btn";
        return null;
    }

    /// <summary>
    /// 是否允许清除
    /// </summary>
    private bool IsAllowClear() {
        var isAllowClear = _config.GetValue<bool?>( UiConst.AllowClear );
        if( isAllowClear == null ) {
            var options = NgZorroOptionsService.GetOptions();
            if( options.EnableAllowClear )
                return true;
        }
        return isAllowClear.SafeValue();
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new TextareaRender( _config.Copy() );
    }
}