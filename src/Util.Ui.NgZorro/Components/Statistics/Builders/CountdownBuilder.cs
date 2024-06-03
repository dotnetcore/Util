using Util.Ui.Angular.Configs;

namespace Util.Ui.NgZorro.Components.Statistics.Builders; 

/// <summary>
/// 倒计时标签生成器
/// </summary>
public class CountdownBuilder : StatisticBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化倒计时标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public CountdownBuilder( Config config ) : base( config,"nz-countdown" ) {
        _config = config;
    }

    /// <summary>
    /// 配置格式化
    /// </summary>
    public CountdownBuilder Format() {
        AttributeIfNotEmpty( "nzFormat", _config.GetValue( UiConst.Format ) );
        AttributeIfNotEmpty( "[nzFormat]", _config.GetValue( AngularConst.BindFormat ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public CountdownBuilder Events() {
        AttributeIfNotEmpty( "(nzCountdownFinish)", _config.GetValue( UiConst.OnCountdownFinish ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Format().Events();
    }
}