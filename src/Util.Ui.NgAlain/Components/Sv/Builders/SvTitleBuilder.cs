using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgAlain.Components.Sv.Builders;

/// <summary>
/// 查看标题标签生成器
/// </summary>
public class SvTitleBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化查看标题标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SvTitleBuilder( Config config ) : base( config, "sv-title" ) {
        _config = config;
    }

    /// <summary>
    /// 配置标签
    /// </summary>
    public SvTitleBuilder Title() {
        var options = NgZorroOptionsService.GetOptions();
        var title = _config.GetValue( UiConst.Title );
        if ( options.EnableI18n ) {
            this.AppendContentByI18n( title );
            return this;
        }
        AppendContent(title);
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Title();
    }
}