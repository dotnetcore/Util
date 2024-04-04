using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.HashCodes.Builders;

/// <summary>
/// 哈希码标签生成器
/// </summary>
public class HashCodeBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化哈希码标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public HashCodeBuilder( Config config ) : base( config, "nz-hash-code" ) {
        _config = config;
    }

    /// <summary>
    /// 配置值
    /// </summary>
    public HashCodeBuilder Value() {
        AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
        AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
        return this;
    }

    /// <summary>
    /// 配置标题
    /// </summary>
    public HashCodeBuilder Title() {
        AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
        AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
        return this;
    }

    /// <summary>
    /// 配置标志
    /// </summary>
    public HashCodeBuilder Logo() {
        AttributeIfNotEmpty( "nzLogo", _config.GetValue( UiConst.Logo ) );
        AttributeIfNotEmpty( "[nzLogo]", _config.GetValue( AngularConst.BindLogo ) );
        return this;
    }

    /// <summary>
    /// 配置展示模式
    /// </summary>
    public HashCodeBuilder Mode() {
        AttributeIfNotEmpty( "nzMode", _config.GetValue<HashCodeMode?>( UiConst.Mode )?.Description() );
        AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
        return this;
    }

    /// <summary>
    /// 配置样式
    /// </summary>
    public HashCodeBuilder Type() {
        AttributeIfNotEmpty( "nzType", _config.GetValue<HashCodeType?>( UiConst.Type )?.Description() );
        AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public HashCodeBuilder Events() {
        AttributeIfNotEmpty( "(nzOnCopy)", _config.GetValue( UiConst.OnCopy ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Value().Title().Logo().Mode().Type().Events();
    }
}