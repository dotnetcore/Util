using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgAlain.Components.Ellipsis.Builders;

/// <summary>
/// 文本省略标签生成器
/// </summary>
public class EllipsisBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 初始化文本省略标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public EllipsisBuilder( Config config ) : base( config, "ellipsis" ) {
        _config = config;
    }

    /// <summary>
    /// 配置工具提示
    /// </summary>
    public EllipsisBuilder Tooltip() {
        AttributeIfNotEmpty( "[tooltip]", _config.GetBoolValue( UiConst.Tooltip ) );
        AttributeIfNotEmpty( "[tooltip]", _config.GetValue( AngularConst.BindTooltip ) );
        return this;
    }

    /// <summary>
    /// 配置文本最大长度
    /// </summary>
    public EllipsisBuilder Length() {
        AttributeIfNotEmpty( "length", _config.GetValue( UiConst.Length ) );
        AttributeIfNotEmpty( "[length]", _config.GetValue( AngularConst.BindLength ) );
        return this;
    }

    /// <summary>
    /// 配置文本最大行数
    /// </summary>
    public EllipsisBuilder Lines() {
        AttributeIfNotEmpty( "lines", _config.GetValue( UiConst.Lines ) );
        AttributeIfNotEmpty( "[lines]", _config.GetValue( AngularConst.BindLines ) );
        return this;
    }

    /// <summary>
    /// 配置是否将全角字符的长度视为2来计算字符串长度
    /// </summary>
    public EllipsisBuilder FullWidthRecognition() {
        AttributeIfNotEmpty( "[fullWidthRecognition]", _config.GetBoolValue( UiConst.FullWidthRecognition ) );
        AttributeIfNotEmpty( "[fullWidthRecognition]", _config.GetValue( AngularConst.BindFullWidthRecognition ) );
        return this;
    }

    /// <summary>
    /// 配置溢出尾巴
    /// </summary>
    public EllipsisBuilder Tail() {
        AttributeIfNotEmpty( "tail", _config.GetValue( UiConst.Tail ) );
        AttributeIfNotEmpty( "[tail]", _config.GetValue( AngularConst.BindTail ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Tooltip().Length().Lines().FullWidthRecognition().Tail();
        var value = _config.GetValue( UiConst.Value );
        if ( value.IsEmpty() )
            return;
        AppendContent( "{{" + value + "}}" );
    }
}