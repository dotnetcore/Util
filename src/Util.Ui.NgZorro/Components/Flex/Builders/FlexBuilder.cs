using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Flex.Builders;

/// <summary>
/// 弹性布局栅格标签生成器
/// </summary>
public class FlexBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化弹性布局栅格标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public FlexBuilder( Config config ) : base( config,"div" ) {
        _config = config;
        base.Attribute("nz-flex");
    }

    /// <summary>
    /// 配置是否垂直布局
    /// </summary>
    public FlexBuilder Vertical() {
        AttributeIfNotEmpty( "[nzVertical]", _config.GetValue( UiConst.Vertical ) );
        return this;
    }

    /// <summary>
    /// 配置对齐方式
    /// </summary>
    public FlexBuilder Justify() {
        AttributeIfNotEmpty( "nzJustify", _config.GetValue<FlexJustify?>( UiConst.Justify )?.Description() );
        AttributeIfNotEmpty( "[nzJustify]", _config.GetValue( AngularConst.BindJustify ) );
        return this;
    }

    /// <summary>
    /// 配置垂直对齐方式
    /// </summary>
    public FlexBuilder Align() {
        AttributeIfNotEmpty( "nzAlign", _config.GetValue<FlexAlign?>( UiConst.Align )?.Description() );
        AttributeIfNotEmpty( "[nzAlign]", _config.GetValue( AngularConst.BindAlign ) );
        return this;
    }

    /// <summary>
    /// 配置间距
    /// </summary>
    public FlexBuilder Gap() {
        AttributeIfNotEmpty( "nzGap", _config.GetValue<FlexGap?>( UiConst.Gap )?.Description() );
        AttributeIfNotEmpty( "[nzGap]", _config.GetValue( AngularConst.BindGap ) );
        return this;
    }

    /// <summary>
    /// 配置自动换行
    /// </summary>
    public FlexBuilder Wrap() {
        AttributeIfNotEmpty( "nzWrap", _config.GetValue<FlexWrap?>( UiConst.Wrap )?.Description() );
        AttributeIfNotEmpty( "[nzWrap]", _config.GetValue( AngularConst.BindWrap ) );
        return this;
    }

    /// <summary>
    /// 配置flex
    /// </summary>
    public FlexBuilder Flex() {
        AttributeIfNotEmpty( "nzFlex", _config.GetValue( UiConst.Flex ) );
        AttributeIfNotEmpty( "[nzFlex]", _config.GetValue( AngularConst.BindFlex ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Vertical().Justify().Align().Gap().Wrap().Flex();
    }
}