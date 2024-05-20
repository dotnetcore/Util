using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Dropdowns.Configs;

namespace Util.Ui.NgZorro.Components.Dropdowns.Builders; 

/// <summary>
/// 下拉菜单标签生成器
/// </summary>
public class DropdownMenuBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化下拉菜单标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public DropdownMenuBuilder( Config config ) : base( config,"nz-dropdown-menu" ) {
        _config = config;
    }

    /// <summary>
    /// 配置标识
    /// </summary>
    protected override void ConfigId( Config config ) {
        if ( config.Contains( UiConst.Id ) )
            Attribute( $"#{config.GetValue( UiConst.Id )}", "nzDropdownMenu" );
        AttributeIfNotEmpty( "id", config.GetValue( AngularConst.RawId ) );
    }

    /// <summary>
    /// 配置内容元素
    /// </summary>
    protected override void ConfigContent( Config config ) {
        var shareConfig = GetShareConfig();
        if ( shareConfig.AutoCreateUl == false ) {
            config.Content.AppendTo( this );
            return;
        }
        var ulBuilder = CreateUlBuilder();
        ConfigSelectable( ulBuilder );
        ConfigEvents( ulBuilder );
        SetContent( ulBuilder );
        _config.Content.AppendTo( ulBuilder );
    }

    /// <summary>
    /// 获取下拉菜单共享配置
    /// </summary>
    private DropdownMenuShareConfig GetShareConfig() {
        return _config.GetValueFromItems<DropdownMenuShareConfig>() ?? new DropdownMenuShareConfig();
    }

    /// <summary>
    /// 创建ul标签生成器
    /// </summary>
    private TagBuilder CreateUlBuilder() {
        var builder = new UlBuilder();
        builder.Attribute( "nz-menu" );
        return builder;
    }

    /// <summary>
    /// 配置允许选中
    /// </summary>
    private void ConfigSelectable( TagBuilder builder ) {
        builder.AttributeIfNotEmpty( "[nzSelectable]", _config.GetValue( UiConst.Selectable ) );
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    private void ConfigEvents( TagBuilder builder ) {
        builder.AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
    }
}